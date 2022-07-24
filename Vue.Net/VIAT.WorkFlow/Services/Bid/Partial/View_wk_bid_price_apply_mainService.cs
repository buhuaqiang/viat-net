/*
 *所有关于View_wk_bid_price_apply_main类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_wk_bid_price_apply_mainService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;
using System.Linq;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using VIAT.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.WorkFlow.IRepositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using VIAT.Price.Services;
using VIAT.Basic.Services;
using VIAT.Core.DBManager;
using VIAT.Core.Dapper;
namespace VIAT.WorkFlow.Services
{
    public partial class View_wk_bid_price_apply_mainService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_wk_bid_price_apply_mainRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_wk_bid_price_apply_mainService(
            IView_wk_bid_price_apply_mainRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webRespose = new WebResponseContent();

        /// <summary>
        /// add
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
           addWKMaster(saveDataModel,"00",false);

            return base.CustomBatchProcessEntity(saveDataModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>

        public override WebResponseContent Update(SaveModel saveModel)
        {
            //根據主鍵取得master數據,只更新狀態
            string sbidmast_dbid = saveModel.MainData["bidmast_dbid"].ToString();
            updateWKMaster(saveModel,"00",false);

            Viat_wk_master masterEntry = JsonConvert.DeserializeObject<Viat_wk_master>(JsonConvert.SerializeObject(saveModel.MainData));
            processBidAndOrder(saveModel, masterEntry, false);
            return base.CustomBatchProcessEntity(saveModel);
        }
        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            List<string> delLst = new List<string>();
            foreach (string bidmast_dbid in keys)
            {
                string delViatOrd = $"delete from viat_wk_ord_detail where bidmast_dbid = '{bidmast_dbid}'";
                string delViatBid = $"delete from viat_wk_bid_detail where bidmast_dbid = '{bidmast_dbid}'";
                string delViatMaster = $"delete from viat_wk_master where bidmast_dbid = '{bidmast_dbid}'";

                //string sDelWKMaster = "delete from viat_wk_master where bidmast_dbid='" + bidmast_dbid + "'";
                //string sDelWKCust = "delete from viat_wk_cust where bidmast_dbid='" + bidmast_dbid + "'";
                delLst.Add(delViatOrd);
                delLst.Add(delViatBid);
                delLst.Add(delViatMaster);
            }

            return base.CustomExcuteBySql(delLst, "");
        }

        /// <summary>
        /// 提交邏輯
        /// </summary>
        /// <returns></returns>
        public WebResponseContent Submit([FromBody] object saveModelData)
        {

            List<Dictionary<string, object>> lst = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(saveModelData.ToString());
            if (lst == null || lst.Count == 0)
            {
                return webRespose.Error("no data");
            }
            SaveModel saveModel = new SaveModel();
            saveModel.MainData = lst[0];

            processSubmit(saveModel,false);
            return base.CustomBatchProcessEntity(saveModel);
        }

        /// <summary>
        /// addsubmit
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public WebResponseContent addSubmit([FromBody] SaveModel saveModel)
        { 

            //判断是否为新增还是编辑
            string sbidmast_dbid = saveModel.MainData["bidmast_dbid"].ToString();
           
            processSubmit(saveModel,true);
            return base.CustomBatchProcessEntity(saveModel);
        }

        /// <summary>
        /// 处理提交
        /// </summary>
        /// <param name="saveModel"></param>
        private void processSubmit(SaveModel saveModel,bool bAddEditSubmit)
        {
            string sBidMasterBDID = saveModel.MainData["bidmast_dbid"]?.ToString();     
            if(string.IsNullOrEmpty(sBidMasterBDID)==true)            
            {
                sBidMasterBDID = System.Guid.NewGuid().ToString();
            }
            processWKMaster(saveModel, sBidMasterBDID, "03");
            string sJson = JsonConvert.SerializeObject(saveModel.MainData);
            if(saveModel.MainData.ContainsKey("upload")==true)
            {
                saveModel.MainData.Remove("upload");
            }
            Viat_wk_master masterEntry = JsonConvert.DeserializeObject<Viat_wk_master>(JsonConvert.SerializeObject(saveModel.MainData));
            if (bAddEditSubmit == true)
            {
                processBidAndOrder(saveModel, masterEntry, bAddEditSubmit);
            }
            else
            {
                processBidRelation(saveModel, bAddEditSubmit,masterEntry, new List<Viat_wk_bid_detail> { });
                processOrdRelation(saveModel, bAddEditSubmit, masterEntry, new List<Viat_wk_ord_detail> { });
            }
          

        }

        /// <summary>
        /// 
        /// </summary>
        public void processBidRelation(SaveModel saveModel, bool bAddEditSubmit, Viat_wk_master masterEntry, List<Viat_wk_bid_detail> bidLst)
        {
            string sBidMasterBDID = saveModel.MainData["bidmast_dbid"]?.ToString();
            string sPriceGroupDBID = "";
            if (saveModel.MainData.ContainsKey("pricegroup_dbid") == true)
            {
                sPriceGroupDBID = saveModel.MainData["pricegroup_dbid"]?.ToString();
            }
            string sCustDBID = "";
            if (saveModel.MainData.ContainsKey("cust_dbid") == true)
            {
                sCustDBID = saveModel.MainData["cust_dbid"]?.ToString();
            }

            //04为仅order
            string sApplyType = saveModel.MainData["apply_type"]?.ToString();
            //开始时间 
            string sStartDate = saveModel.MainData["start_date"]?.ToString();
            if (string.IsNullOrEmpty(sStartDate) == false)
            {
                sStartDate = getFormatYYYYMMDD(sStartDate).ToString("yyyy-MM-dd");
            }
            //结束时间 
            string sEndDate = saveModel.MainData["end_date"]?.ToString();
            if (string.IsNullOrEmpty(sEndDate) == false)
            {
                sEndDate = getFormatYYYYMMDD(sEndDate).ToString("yyyy-MM-dd");
            }
            //提取值
            string scontstret_dbid = saveModel.MainData["contstret_dbid"]?.ToString();
            Viat_com_cust cust = null;
            Viat_app_cust_group custGroup = null;
            if (string.IsNullOrEmpty(sCustDBID) == false)
            {
                cust = Viat_com_custService.Instance.getCustByCustDBID(sCustDBID);
                custGroup = Viat_app_cust_groupService.Instance.getCustGroupByCustDBID(sCustDBID);
            }

            if (string.IsNullOrEmpty(sBidMasterBDID) == true)
            {
                sBidMasterBDID = System.Guid.NewGuid().ToString();
            }
            string sBidNo = saveModel.MainData["bid_no"]?.ToString();

            //进行判断处理
            /*
             如果是group 申請，或是（cust_dbid !=null&& viat_com_cust.status= invalid）或是客戶已存在cust_group表的有效記錄，審批后進入 price_transfer/order_transfer
             其他情況：如果申請主體是客戶ID，沒有選擇合約範本（contstret_dbid ==null）&& End_data!='2099-12-31',卡控到price_transfer/order_transer
             */
            if (string.IsNullOrEmpty(sPriceGroupDBID) == false ||
                (string.IsNullOrEmpty(sCustDBID) == false && (cust != null && cust.status == "N")) ||
                (string.IsNullOrEmpty(sCustDBID) == false && custGroup != null && custGroup.status == "Y") ||
                (string.IsNullOrEmpty(sCustDBID) == false && string.IsNullOrEmpty(scontstret_dbid) == true && sEndDate != "2099-12-31")

                )
            {
                //卡控到price_transfer/order_transer
                if (sApplyType != "04")
                {
                    if (bAddEditSubmit == false)
                    {
                        processPriceTransferByBidMasterDBID(saveModel, masterEntry);
                    }
                    else
                    {
                        processPriceTransfer(saveModel, bidLst,masterEntry);
                    }

                }                
            }
            /*
             如果是客戶主體申請，選擇了合約範本， && Start_date< Approved Data ，則卡控到priceTransfer/order 表
             */
            else if (string.IsNullOrEmpty(sCustDBID) == false
                && string.IsNullOrEmpty(scontstret_dbid) == false
                && getFormatYYYYMMDD(sStartDate) < getFormatYYYYMMDD(DateTime.Now))
            {
                //卡控到priceTransfer/order 表
                if (sApplyType != "04")
                {
                    if (bAddEditSubmit == false)
                    {
                        processPriceTransferByBidMasterDBID(saveModel, masterEntry);
                    }
                    else
                    {
                        processPriceTransfer(saveModel, bidLst, masterEntry);
                    }

                }
               
            }
            /*
             除以上規則外，全部直接寫入cust_price_detail表和 viat_app_cust_order表
             */
            else
            {
                //全部直接寫入cust_price_detail表和 viat_app_cust_order表
                if (sApplyType != "04")
                {
                    if (bAddEditSubmit == false)
                    {
                        processPriceDetailerByBidMasterDBID(saveModel,masterEntry);
                    }
                    else
                    {
                        processPriceDetail(saveModel, masterEntry, bidLst);
                    }
                }
               
            }
        }

        public void processOrdRelation(SaveModel saveModel, bool bAddEditSubmit, Viat_wk_master masterEntry, List<Viat_wk_ord_detail> ordLst)
        {
            string sBidMasterBDID = saveModel.MainData["bidmast_dbid"]?.ToString();
            string sPriceGroupDBID = "";
            if (saveModel.MainData.ContainsKey("pricegroup_dbid") == true)
            {
                sPriceGroupDBID = saveModel.MainData["pricegroup_dbid"]?.ToString();
            }
            string sCustDBID = "";
            if (saveModel.MainData.ContainsKey("cust_dbid") == true)
            {
                sCustDBID = saveModel.MainData["cust_dbid"]?.ToString();
            }

            //04为仅order
            string sApplyType = saveModel.MainData["apply_type"]?.ToString();
            //开始时间 
            string sStartDate = saveModel.MainData["start_date"]?.ToString();
            if (string.IsNullOrEmpty(sStartDate) == false)
            {
                sStartDate = getFormatYYYYMMDD(sStartDate).ToString("yyyy-MM-dd");
            }
            //结束时间 
            string sEndDate = saveModel.MainData["end_date"]?.ToString();
            if (string.IsNullOrEmpty(sEndDate) == false)
            {
                sEndDate = getFormatYYYYMMDD(sEndDate).ToString("yyyy-MM-dd");
            }
            //提取值
            string scontstret_dbid = saveModel.MainData["contstret_dbid"]?.ToString();
            Viat_com_cust cust = null;
            Viat_app_cust_group custGroup = null;
            if (string.IsNullOrEmpty(sCustDBID) == false)
            {
                cust = Viat_com_custService.Instance.getCustByCustDBID(sCustDBID);
                custGroup = Viat_app_cust_groupService.Instance.getCustGroupByCustDBID(sCustDBID);
            }

            if (string.IsNullOrEmpty(sBidMasterBDID) == true)
            {
                sBidMasterBDID = System.Guid.NewGuid().ToString();
            }

            if(sApplyType == "04")
            {
                //全部直接寫入cust_price_detail表和 viat_app_cust_order表               
                if (bAddEditSubmit == false)
                {
                    processCustOrderByBidMasterDBID(saveModel, masterEntry);
                }
                else
                {
                    processCustOrder(saveModel, masterEntry, ordLst);
                }
            }
            //进行判断处理
            /*
             如果是group 申請，或是（cust_dbid !=null&& viat_com_cust.status= invalid）或是客戶已存在cust_group表的有效記錄，審批后進入 price_transfer/order_transfer
             其他情況：如果申請主體是客戶ID，沒有選擇合約範本（contstret_dbid ==null）&& End_data!='2099-12-31',卡控到price_transfer/order_transer
             */
           else if (string.IsNullOrEmpty(sPriceGroupDBID) == false ||
                (string.IsNullOrEmpty(sCustDBID) == false && (cust != null && cust.status == "N")) ||
                (string.IsNullOrEmpty(sCustDBID) == false && custGroup != null && custGroup.status == "Y") ||
                (string.IsNullOrEmpty(sCustDBID) == false && string.IsNullOrEmpty(scontstret_dbid) == true && sEndDate != "2099-12-31")

                )
            {
                //卡控到price_transfer/order_transer
               
                if (bAddEditSubmit == false)
                {
                    processOrderTransferByBidMasterDBID(saveModel, masterEntry);
                }
                else
                {
                    processOrderTransfer(saveModel, ordLst,masterEntry);
                }
            }
            /*
             如果是客戶主體申請，選擇了合約範本， && Start_date< Approved Data ，則卡控到priceTransfer/order 表
             */
            else if (string.IsNullOrEmpty(sCustDBID) == false
                && string.IsNullOrEmpty(scontstret_dbid) == false
                && getFormatYYYYMMDD(sStartDate) < getFormatYYYYMMDD(DateTime.Now))
            {
                //卡控到priceTransfer/order 表
               
                if (bAddEditSubmit == false)
                {
                    processOrderTransferByBidMasterDBID(saveModel, masterEntry);
                }
                else
                {
                    processOrderTransfer(saveModel, ordLst,masterEntry);
                }
            }
            /*
             除以上規則外，全部直接寫入cust_price_detail表和 viat_app_cust_order表
             */
            else
            {
               
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public WebResponseContent processBack(string[] bidmast_dbidLst)
        {

            SaveModel saveModel = new SaveModel();
            SaveModel.DetailListDataResult backResult = new SaveModel.DetailListDataResult();
            saveModel.DetailListData.Add(backResult);
            foreach (string bidmast_dbid in bidmast_dbidLst)
            {
                Viat_wk_master master = Viat_wk_masterService.Instance.getMasterByDBID(bidmast_dbid);
                master.status = "02";

                backResult.optionType = SaveModel.MainOptionType.update;
                backResult.detailType = typeof(Viat_wk_master);
                backResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(master)));
            }

            return base.CustomBatchProcessEntity(saveModel);
        }

        #region 

        /// <summary>
        /// add master
        /// </summary>
        /// <param name="saveModel"></param>
        private void addWKMaster(SaveModel saveDataModel,string sStatus, bool bSubmit)
        {

            string sbidMastDBID = Guid.NewGuid().ToString();
            processWKMaster(saveDataModel, sbidMastDBID, sStatus);

            Viat_wk_master masterEntry = JsonConvert.DeserializeObject<Viat_wk_master>(JsonConvert.SerializeObject(saveDataModel.MainData));
            //处理bid和order 
            processBidAndOrder(saveDataModel, masterEntry,bSubmit);
        }


        /// <summary>
        /// 处理master
        /// </summary>
        private void processWKMaster(SaveModel saveDataModel,string bidMastDBID,string sStatus)
        {

            //增加master数据
            SaveModel.DetailListDataResult masterResult = new SaveModel.DetailListDataResult();
            saveDataModel.MainData["status"] = sStatus;
            if (saveDataModel.MainData["bidmast_dbid"]!= null && string.IsNullOrEmpty(saveDataModel.MainData["bidmast_dbid"].ToString())==true)
            {
                //新增
                string sBinNo = Viat_wk_masterService.Instance.getBidNO();

                saveDataModel.MainData["bidmast_dbid"] = bidMastDBID;
                saveDataModel.MainData["bid_no"] = sBinNo;                
                saveDataModel.MainData["start_date"] = getFormatYYYYMMDD(DateTime.Now.ToString("yyyy-MM-dd"));

                masterResult.optionType = SaveModel.MainOptionType.add;
            }
            else
            {
                //修改
                masterResult.optionType = SaveModel.MainOptionType.update;
            } 
            masterResult.DetailData.Add(saveDataModel.MainData);        
            masterResult.detailType = typeof(Viat_wk_master);
            saveDataModel.DetailListData.Add(masterResult);
        }

        /// <summary>
        /// 处理bid order 
        /// </summary>
        /// <param name="saveDataModel"></param>
        private void processBidAndOrder(SaveModel saveDataModel,  Viat_wk_master masterEntry, bool bAddEditSubmit)
        {
            if (saveDataModel.DetailData != null && saveDataModel.DetailData.Count > 0)
            {
                foreach (Dictionary<string, object> dic in saveDataModel.DetailData)
                {
                    Dictionary<string, object> dicTmp = dic;
                    if (dicTmp["key"]?.ToString() == "priceTableRowData")
                    {
                        string sBidData = dicTmp["value"]?.ToString();
                        processBidDetail(saveDataModel, sBidData,  masterEntry, bAddEditSubmit);
                    }
                    else if (dicTmp["key"]?.ToString() == "orderTableRowData")
                    {
                        string sOrderData = dicTmp["value"]?.ToString();
                        processOrderDetail(saveDataModel, sOrderData,  masterEntry, bAddEditSubmit);
                    }
                    else if (dicTmp["key"]?.ToString() == "delPriceTableRowData")
                    {
                        string sBidData = dicTmp["value"]?.ToString();
                        processDelBidDetail(saveDataModel, sBidData);
                    }
                    else if (dicTmp["key"]?.ToString() == "delOrderTableRowData")
                    {
                        string sOrderData = dicTmp["value"]?.ToString();
                        processDelOrderDetail(saveDataModel, sOrderData);
                    }
                }
            }
        }

        /// <summary>
        /// 处理bid逻辑
        /// </summary>
        /// <param name="saveDataModel"></param>
        private void processBidDetail(SaveModel saveDataModel, string sBidData, Viat_wk_master masterEntry, bool bAddEditSubmit)
        {
            if (string.IsNullOrEmpty(sBidData) == false)
            {
                List<Viat_wk_bid_detail> bidList = JsonConvert.DeserializeObject<List<Viat_wk_bid_detail>>(sBidData);
               
                foreach (Viat_wk_bid_detail bid in bidList)
                {
                    SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
                    if (bid.bidetail_dbid == null || bid.bidetail_dbid.ToString() == getDefaultGuid(typeof(Viat_wk_bid_detail)))
                    {
                        //新增
                        custResult.optionType = SaveModel.MainOptionType.add;
                        bid.bidetail_dbid = System.Guid.NewGuid();
                        bid.bidmast_dbid = masterEntry.bidmast_dbid;
                    }
                    else
                    {
                        custResult.optionType = SaveModel.MainOptionType.update;
                    }           
                    custResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(bid)));                   
                    custResult.detailType = typeof(Viat_wk_bid_detail);
                    saveDataModel.DetailListData.Add(custResult);                    
                }

                processBidRelation(saveDataModel,bAddEditSubmit, masterEntry, bidList);
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <param name="sBidData"></param>
        /// <param name="bidMastDBID"></param>
        /// <param name="bSubmit"></param>
        private void processDelBidDetail(SaveModel saveDataModel, string sBidData)
        {
            if (string.IsNullOrEmpty(sBidData) == false)
            {
                List<Viat_wk_bid_detail> bidList = JsonConvert.DeserializeObject<List<Viat_wk_bid_detail>>(sBidData);
                foreach (Viat_wk_bid_detail bid in bidList)
                {
                    SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();

                    custResult.detailDelKeys.Add(bid.bidetail_dbid);                    
                    custResult.detailType = typeof(Viat_wk_bid_detail);
                    custResult.optionType = SaveModel.MainOptionType.delete;
                    saveDataModel.DetailListData.Add(custResult);
                } 
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <param name="sBidData"></param>
        /// <param name="bidMastDBID"></param>
        /// <param name="bSubmit"></param>
        private void processDelOrderDetail(SaveModel saveDataModel, string sOrderData)
        {
            if (string.IsNullOrEmpty(sOrderData) == false)
            {
                List<Viat_wk_ord_detail> orderList = JsonConvert.DeserializeObject<List<Viat_wk_ord_detail>>(sOrderData);
                foreach (Viat_wk_ord_detail order in orderList)
                {
                    SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
                    custResult.detailDelKeys.Add(order.ordetail_dbid);
                    custResult.detailType = typeof(Viat_wk_ord_detail);
                    custResult.optionType = SaveModel.MainOptionType.delete;
                    saveDataModel.DetailListData.Add(custResult);
                } 
            }
        }

        /// <summary>
        /// 处理order逻辑
        /// </summary>
        /// <param name="saveDataModel"></param>

        private void processOrderDetail(SaveModel saveDataModel,string sOrderData, Viat_wk_master masterEntry, bool bAddEditSubmit)
        {
            if (string.IsNullOrEmpty(sOrderData) == false)
            {
                List<Viat_wk_ord_detail> orderList = JsonConvert.DeserializeObject<List<Viat_wk_ord_detail>>(sOrderData);
                if (orderList != null && orderList.Count > 0)
                {
                    
         
                    foreach (Viat_wk_ord_detail order in orderList)
                    {
                        SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
                        saveDataModel.DetailListData.Add(custResult);
                        if (order.ordetail_dbid == null || order.ordetail_dbid.ToString() == getDefaultGuid(typeof(Viat_wk_ord_detail)))
                        {
                            //新增
                            order.ordetail_dbid = System.Guid.NewGuid();
                            order.bidmast_dbid = masterEntry.bidmast_dbid;
                            custResult.optionType = SaveModel.MainOptionType.add; 
                        }
                        else
                        {
                            //更新
                            custResult.optionType = SaveModel.MainOptionType.update;
                        }
                        custResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(order)));
                        custResult.detailType = typeof(Viat_wk_ord_detail);                       
                    }

                    processOrdRelation(saveDataModel, bAddEditSubmit, masterEntry, orderList);
                }
            }
        }

        /// <summary>
        /// add master
        /// </summary>
        /// <param name="saveModel"></param>
        private void updateWKMaster(SaveModel saveModel,string sStatus, bool bSubmit)
        {

            //根據主鍵取得master數據,只更新狀態
            string sbidmast_dbid = saveModel.MainData["bidmast_dbid"].ToString();
            processWKMaster(saveModel, sbidmast_dbid, sStatus);
           
        }


        /// <summary>
        /// 根据bidmast_dbid处理processPriceTransfer
        /// </summary>
        /// <param name="bidmast_dbid"></param>
        private void processPriceTransferByBidMasterDBID(SaveModel saveModel, Viat_wk_master masterEntity)
        {
            List<Viat_wk_bid_detail> bidLst = Viat_wk_bid_detailService.Instance.getDataByBidMasterDBID(masterEntity.bidmast_dbid.ToString());
            processPriceTransfer(saveModel,bidLst, masterEntity);
        }

        /// <summary>
        /// 根据bidmast_dbid处理processOrderyTransfer
        /// </summary>
        /// <param name="bidmast_dbid"></param>
        private void processOrderTransferByBidMasterDBID(SaveModel saveModel, Viat_wk_master masterEntry)
        {
            List<Viat_wk_ord_detail> ordLst = Viat_wk_ord_detailService.Instance.getDataByBidMasterDBID(masterEntry.bidmast_dbid.ToString());
            processOrderTransfer(saveModel, ordLst, masterEntry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        private void processPriceTransfer(SaveModel saveModel, List<Viat_wk_bid_detail> bidLst, Viat_wk_master masterEntity)
        {

            if (bidLst != null && bidLst.Count > 0)
            {
                SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();               
                foreach (Viat_wk_bid_detail bid in bidLst)
                {
                    //把cust記錄寫入transfer, delivery transfer
                    Viat_app_cust_price_transfer transfer = JsonConvert.DeserializeObject<Viat_app_cust_price_transfer>(JsonConvert.SerializeObject(bid));
                    transfer.price_transfer_dbid = System.Guid.NewGuid();
                    //处理bidno
                   /* string sBidNo = "";*/
                   /* Viat_wk_master master = Viat_wk_masterService.Instance.getMasterByDBID(bid.bidmast_dbid?.ToString());
                    if(master != null)
                    {
                        sBidNo = master.bid_no;
                    }*/

                    if(string.IsNullOrEmpty(masterEntity.pricegroup_dbid?.ToString()) ==false)
                    {
                        transfer.pricegroup_dbid = masterEntity.pricegroup_dbid;
                    }
                    else if(string.IsNullOrEmpty(masterEntity.cust_dbid?.ToString()) ==false)
                    {
                        transfer.cust_dbid = masterEntity.cust_dbid;
                    }

                    SaveModel.DetailListDataResult transferResult = new SaveModel.DetailListDataResult();
                    transfer.bid_no = masterEntity.bid_no;
                    transfer.state = "0";
                    UserInfo userInfo = VIAT.Core.ManageUser.UserContext.Current.UserInfo;
                    if (userInfo != null)
                    {
                        transfer.requestor = userInfo.User_Id;
                        transfer.requestor_name = userInfo.UserName;
                        transfer.territory_id = "";

                    }
                    transferResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(transfer)));
                    transferResult.optionType = SaveModel.MainOptionType.add;
                    transferResult.detailType = typeof(Viat_app_cust_price_transfer);
                    saveModel.DetailListData.Add(transferResult);

                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        private void processOrderTransfer(SaveModel saveModel, List<Viat_wk_ord_detail> orderLst, Viat_wk_master masterEntry)
        {

            if (orderLst != null && orderLst.Count > 0)
            {
                SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
               
                foreach(Viat_wk_ord_detail order in orderLst)
                {
                    //把cust記錄寫入transfer, delivery transfer
                    Viat_app_cust_order_transfer transfer = JsonConvert.DeserializeObject<Viat_app_cust_order_transfer>(JsonConvert.SerializeObject(order));
                    transfer.order_transfer_dbid = System.Guid.NewGuid();
                   
                    //处理bidno                   
                   /* Viat_wk_master master = Viat_wk_masterService.Instance.getMasterByDBID(order.bidmast_dbid?.ToString());
                    if (master != null)
                    {
                        transfer.requestor = master.created_user;
                        transfer.requestor_name = master.created_username;
                        transfer.territory_id = master.territory_id;
                    }*/
                    UserInfo userInfo = VIAT.Core.ManageUser.UserContext.Current.UserInfo;
                    if(userInfo != null)
                    {
                        transfer.requestor = userInfo.User_Id;
                        transfer.requestor_name = userInfo.UserName;
                        transfer.territory_id = "";

                    }
                    transfer.cust_dbid = masterEntry.cust_dbid;
                    transfer.bid_no = masterEntry.bid_no;
                    transfer.state = "0";
                    transfer.transfer_date = getFormatYYYYMMDD(System.DateTime.Now);
                    SaveModel.DetailListDataResult transferResult = new SaveModel.DetailListDataResult();
                    transferResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(transfer)));
                    transferResult.optionType = SaveModel.MainOptionType.add;
                    transferResult.detailType = typeof(Viat_app_cust_order_transfer);
                    saveModel.DetailListData.Add(transferResult);
                }
                
            }
        }


        #region 除以上規則外，全部直接寫入cust_price_detail表和 viat_app_cust_order表

        /// <summary>
        /// 根据bidmast_dbid处理processPriceTransfer
        /// </summary>
        /// <param name="bidmast_dbid"></param>
        private void processPriceDetailerByBidMasterDBID(SaveModel saveModel, Viat_wk_master masterEntry)
        {
            List<Viat_wk_bid_detail> bidLst = Viat_wk_bid_detailService.Instance.getDataByBidMasterDBID(masterEntry.bidmast_dbid.ToString());
            processPriceDetail(saveModel, masterEntry, bidLst);
        }

        /// <summary>
        /// 根据bidmast_dbid处理processOrderyTransfer
        /// </summary>
        /// <param name="bidmast_dbid"></param>
        private void processCustOrderByBidMasterDBID(SaveModel saveModel, Viat_wk_master masterEntry)
        {
            List<Viat_wk_ord_detail> ordLst = Viat_wk_ord_detailService.Instance.getDataByBidMasterDBID(masterEntry.bidmast_dbid.ToString());
            processCustOrder(saveModel, masterEntry,ordLst);
        }

        /// <summary>
        /// Viat_app_cust_price_detail
        /// </summary>
        /// <param name="saveModel"></param>
        private void processPriceDetail(SaveModel saveModel, Viat_wk_master masterEntry, List<Viat_wk_bid_detail> bidLst)
        {
            if (bidLst != null && bidLst.Count > 0)
            {
                //关联处理记录.
                List<Dictionary<string, object>> pricesLst = new List<Dictionary<string, object>>();

                SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
                foreach (Viat_wk_bid_detail bid in bidLst)
                {
                    //把cust記錄寫入transfer, delivery transfer
                    Viat_app_cust_price_detail priceDetail = JsonConvert.DeserializeObject<Viat_app_cust_price_detail>(JsonConvert.SerializeObject(bid));

                    //处理bidno
                    /*
                               Viat_wk_master master = Viat_wk_masterService.Instance.getMasterByDBID(bid.bidmast_dbid?.ToString());
                               if (master != null)
                               {

                                   priceDetail.start_date = getFormatYYYYMMDD(master.start_date);
                                   priceDetail.end_date = getFormatYYYYMMDD(master.end_date);
                               }*/
                    if(masterEntry.pricegroup_dbid != null)
                    {
                        priceDetail.pricedetail_dbid = masterEntry.pricegroup_dbid;
                    }
                    else if(masterEntry.cust_dbid != null)
                    {
                        priceDetail.cust_dbid = masterEntry.cust_dbid;
                    }
                   
                    priceDetail.start_date = getFormatYYYYMMDD(masterEntry.start_date);
                    priceDetail.end_date = getFormatYYYYMMDD(masterEntry.end_date);
                    priceDetail.bid_no = masterEntry.bid_no;
                    priceDetail.prod_dbid = bid.prod_dbid;
                    priceDetail.status = "Y";
                    
                    priceDetail.gross_price = View_cust_priceService.Instance.getNetPriceByProdDBID(bid.prod_dbid?.ToString());
                    SaveModel.DetailListDataResult transferResult = new SaveModel.DetailListDataResult();

                    Dictionary<string, object> priceDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(priceDetail));
                    transferResult.DetailData.Add(priceDic);
                    transferResult.optionType = SaveModel.MainOptionType.add;
                    transferResult.detailType = typeof(Viat_app_cust_price_detail);
                    saveModel.DetailListData.Add(transferResult);

                    //记录旧数据
                    pricesLst.Add(priceDic);
                }

                //处理旧数据
                saveModel.MainDatas = pricesLst;
                View_cust_priceService.Instance.processData(saveModel);
                
            }
           
        }


        /// <summary>
        /// Viat_app_cust_order
        /// </summary>
        /// <param name="saveModel"></param>
        private void processCustOrder(SaveModel saveModel, Viat_wk_master masterEntry, List<Viat_wk_ord_detail> orderLst)
        {

            if (orderLst != null && orderLst.Count > 0)
            {
                SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();

                foreach (Viat_wk_ord_detail order in orderLst)
                {
                    //把cust記錄寫入transfer, delivery transfer
                    Viat_app_cust_order custOrder = JsonConvert.DeserializeObject<Viat_app_cust_order>(JsonConvert.SerializeObject(order));
                    custOrder.order_dbid = System.Guid.NewGuid();
                    //处理bidno

                    /*Viat_wk_master master = Viat_wk_masterService.Instance.getMasterByDBID(order.bidmast_dbid?.ToString());
                    if (master != null)
                    {                      
                        custOrder.cust_dbid = master.cust_dbid;
                    }*/
                    custOrder.cust_dbid = masterEntry.cust_dbid;
                    custOrder.state = "0";
                    custOrder.order_no = "123";
                    custOrder.prod_dbid = order.prod_dbid;
                    custOrder.qty = order.qty;
                    SaveModel.DetailListDataResult transferResult = new SaveModel.DetailListDataResult();
                    transferResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custOrder)));
                    transferResult.optionType = SaveModel.MainOptionType.add;
                    transferResult.detailType = typeof(Viat_app_cust_order);
                    saveModel.DetailListData.Add(transferResult);
                }

            }
        }


        #endregion

        #endregion
    }
}
