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
using System.Text.RegularExpressions;
using System.IO;
using VIAT.WorkFlow.IServices;
using OfficeOpenXml;
using System.Data;
using VIAT.Price.IServices;

namespace VIAT.WorkFlow.Services
{
    public partial class View_wk_bid_price_apply_mainService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_wk_bid_price_apply_mainRepository _repository;//访问数据库
        private readonly IView_cust_price_detailService _Price_DetailService;

        [ActivatorUtilitiesConstructor]
        public View_wk_bid_price_apply_mainService(
            IView_wk_bid_price_apply_mainRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IView_cust_price_detailService Price_DetailService
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _Price_DetailService = Price_DetailService;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public enum enumOption
        {
            None,
            add,
            update,
            addsubmit,
            submit
        }

        private enumOption option = enumOption.None;

        WebResponseContent webRespose = new WebResponseContent();

        /// <summary>
        /// add
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            try
            {
                option = enumOption.add;
                addWKMaster(saveDataModel, "00", false);

                return base.CustomBatchProcessEntity(saveDataModel);
            }
            catch (Exception ex)
            {
                return webRespose.Error(ex.Message);
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>

        public override WebResponseContent Update(SaveModel saveModel)
        {
            try
            {
                option = enumOption.update;
                //根據主鍵取得master數據,只更新狀態
                string sbidmast_dbid = saveModel.MainData["bidmast_dbid"].ToString();
                updateWKMaster(saveModel, "00", false);

                Viat_wk_master masterEntry = JsonConvert.DeserializeObject<Viat_wk_master>(JsonConvert.SerializeObject(saveModel.MainData));
                processBidAndOrder(saveModel, masterEntry, false);
                return base.CustomBatchProcessEntity(saveModel);
            }
            catch (Exception ex)
            {
                return webRespose.Error(ex.Message);
            }
            
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
        /// [FromBody] 
        /// <returns></returns>
        public WebResponseContent Submit(object saveModelData)
        {
            try
            {
                option = enumOption.submit;
                List<Dictionary<string, object>> lst = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(saveModelData.ToString());
                if (lst == null || lst.Count == 0)
                {
                    return webRespose.Error("no data");
                }   
                SaveModel saveModel = new SaveModel();
                saveModel.MainData = lst[0];

                processSubmit(saveModel, false);
                return base.CustomBatchProcessEntity(saveModel);
            }
            catch (Exception ex)
            {
                return webRespose.Error(ex.Message);
            }
            
        }

        /// <summary>
        /// addsubmit
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public WebResponseContent addSubmit([FromBody] SaveModel saveModel)
        {
            try
            {
                option = enumOption.addsubmit;
                //判断是否为新增还是编辑
                string sbidmast_dbid = saveModel.MainData["bidmast_dbid"].ToString();

                processSubmit(saveModel, true);
                return base.CustomBatchProcessEntity(saveModel);
            }
            catch (Exception ex)
            {
                return webRespose.Error(ex.Message);
            }
            
        }

        /// <summary>
        /// 处理提交
        /// </summary>
        /// <param name="saveModel"></param>
        private void processSubmit(SaveModel saveModel,bool bAddEditSubmit)
        {
            try
            {
                string sBidMasterBDID = saveModel.MainData["bidmast_dbid"]?.ToString();
                if (string.IsNullOrEmpty(sBidMasterBDID) == true)
                {
                    sBidMasterBDID = System.Guid.NewGuid().ToString();
                }
                processWKMaster(saveModel, sBidMasterBDID, "03");
                string sJson = JsonConvert.SerializeObject(saveModel.MainData);
                if (saveModel.MainData.ContainsKey("upload") == true)
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
                    processBidRelation(saveModel, bAddEditSubmit, masterEntry, new List<Viat_wk_bid_detail> { });
                    processOrdRelation(saveModel, bAddEditSubmit, masterEntry, new List<Viat_wk_ord_detail> { });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override WebResponseContent DownLoadTemplate()
        {
            return Viat_wk_bid_detailService.Instance.DownLoadTemplate();
        }

        public WebResponseContent CustPriceTransferImport(List<IFormFile> files, string cust_id, string group_dbid)
        {
            WebResponseContent content = BidDetailData(files);
            if (!content.Status)
            {
                return content;
            }
            DataTable dt = content.Data as DataTable;
            List<Viat_wk_bid_detail_select> lstDetail = new List<Viat_wk_bid_detail_select>();
            PageGridData<View_cust_price_detail> GetPriceDetail = new PageGridData<View_cust_price_detail>();
            foreach (DataRow item in dt.Rows)
            {
                string prod_id = item["prod_id"].ToString();
                string prod_ename = item["prod_ename"].ToString();
                decimal? net_price = 0 ;
                decimal invice_price = item["invoice_price"] == null ? 0 : Convert.ToDecimal(item["invoice_price"]);
                decimal bid_price = item["bid_price"] == null ? 0 : Convert.ToDecimal(item["bid_price"]);
                int min_qty = item["min_qty"] == null ? 0 : Convert.ToInt32(item["min_qty"]);
               // string isbelong = item["isbelong"].ToString();
                Guid? prod_dbid = null;
                Viat_com_prod ComProd = repository.DbContext.Set<Viat_com_prod>().Where(x => x.prod_id == prod_id).First();
                if (ComProd.prod_dbid == null)
                {
                    return new WebResponseContent { Code = "-2", Message = $"{prod_ename} Product is empty" };
                }
                prod_dbid = ComProd.prod_dbid;
                if (!string.IsNullOrEmpty(cust_id))
                {
                    PageDataOptions pageData = new PageDataOptions();
                    string where = "[{\"Name\":\"cust_id\"},{\"Name\":\"prod_id\"}]";
                    pageData.Wheres = where;
                    GetPriceDetail = _Price_DetailService.GetPriceDataForTransfer(pageData);
                    net_price = GetPriceDetail.rows.Count() == 0 ? 0 : GetPriceDetail.rows[0].net_price;
                }
                else if (!string.IsNullOrEmpty(group_dbid))
                {
                    Viat_app_cust_price _Cust_Price = ProductPrice(prod_dbid.ToString(), group_dbid);
                    net_price = _Cust_Price.net_price == null?0: _Cust_Price.net_price;
                }
                Viat_wk_bid_detail_select bidDetail = new Viat_wk_bid_detail_select();
                bidDetail.prod_id = prod_id;
                bidDetail.prod_ename = prod_ename;
                bidDetail.invoice_price = invice_price;
                bidDetail.bid_price = bid_price;
                bidDetail.min_qty = min_qty;
              //  bidDetail.isbelong = isbelong;
                bidDetail.prod_dbid = prod_dbid;
                bidDetail.nhi_price = Convert.ToDecimal(ComProd.nhi_price);
                bidDetail.net_price = (decimal)net_price;
                lstDetail.Add(bidDetail);
            }
            webRespose.Data = lstDetail;
            webRespose.Code = "-1";
            return webRespose;
        }

        public static WebResponseContent BidDetailData(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return new WebResponseContent { Code = "-2", Status = false, Message = "please select file" };
            IFormFile formFile = files[0];
            string dicPath = $"Upload/{DateTime.Now.ToString("yyyMMdd")}/{typeof(Viat_wk_bid_detail_select).Name}/".MapPath();
            if (!Directory.Exists(dicPath)) Directory.CreateDirectory(dicPath);
            dicPath = $"{dicPath}{Guid.NewGuid().ToString()}_{formFile.FileName}";
            FileInfo file = new FileInfo(dicPath);
            using (var stream = new FileStream(dicPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            DataTable dt = new DataTable();
            using (ExcelPackage package = new ExcelPackage(file))
            {
                #region 获取列头
                ExcelWorksheet sheetFirst = package.Workbook.Worksheets.FirstOrDefault();

                for (int j = sheetFirst.Dimension.Start.Column, k = sheetFirst.Dimension.End.Column; j <= k; j++)
                {
                    string columnCNName = sheetFirst.Cells[1, j].Value?.ToString()?.Trim();
                    dt.Columns.Add(columnCNName);
                }
                #endregion

                if (package.Workbook.Worksheets.Count == 0 ||
                package.Workbook.Worksheets.FirstOrDefault().Dimension.End.Row <= 1)
                    return new WebResponseContent { Code = "-2",Status = false, Message = "no import data" };
                ExcelWorksheet sheet = package.Workbook.Worksheets.FirstOrDefault();
                for (int m = sheet.Dimension.Start.Row + 1, n = sheet.Dimension.End.Row; m <= n; m++)
                {
                    var dr = dt.NewRow();
                    for (int j = sheet.Dimension.Start.Column, k = sheet.Dimension.End.Column; j <= k; j++)
                    {
                        string value = sheet.Cells[m, j].Value?.ToString();
                        dr[j - 1] = value;
                    }
                    dt.Rows.Add(dr);
                }
            }
            File.Delete(dicPath);
            return new WebResponseContent { Data = dt,Status = true};
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
                    //增加数量判断
                    //List<Viat_wk_ord_detail> orderList;
                    //if (bAddEditSubmit == false)
                    //{
                    //    orderList = Viat_wk_ord_detailService.Instance.getDataByBidMasterDBID(masterEntry.bidmast_dbid.ToString());
                    //}
                    //else
                    //{
                    //    string orderDetail = "";
                    //    foreach (var item in saveModel.DetailData)
                    //    {
                    //        Dictionary<string, object> dicTmp = item;
                    //        if (dicTmp["key"]?.ToString() == "orderTableRowData")
                    //        {
                    //            orderDetail = dicTmp["value"]?.ToString();
                    //            break;
                    //        }
                    //    }
                    //    orderList = JsonConvert.DeserializeObject<List<Viat_wk_ord_detail>>(orderDetail.ToString());
                    //}
                    //if (OrderQty(saveModel, orderList))
                    //{
                    //    if (bAddEditSubmit == false)
                    //    {
                    //        processPriceDetailerByBidMasterDBID(saveModel, masterEntry);
                    //    }
                    //    else
                    //    {
                    //        processPriceDetail(saveModel, masterEntry, bidLst);
                    //    }
                    //}
                    //else
                    //{
                    //    if (bAddEditSubmit == false)
                    //    {
                    //        processPriceTransferByBidMasterDBID(saveModel, masterEntry);
                    //    }
                    //    else
                    //    {
                    //        processPriceTransfer(saveModel, bidLst, masterEntry);
                    //    }
                    //}
                    if (bAddEditSubmit == false)
                    {
                        processPriceDetailerByBidMasterDBID(saveModel, masterEntry);
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
            List<Viat_wk_ord_detail> orderList;
            if (bAddEditSubmit == false)
            {
                orderList = Viat_wk_ord_detailService.Instance.getDataByBidMasterDBID(masterEntry.bidmast_dbid.ToString());
            }
            else
            {
                orderList = ordLst;
            }
            if (sApplyType == "04")
            {

                //if (OrderQty(saveModel, orderList))
                //{
                //    //全部直接寫入cust_price_detail表和 viat_app_cust_order表               
                //    if (bAddEditSubmit == false)
                //    {
                //        processCustOrderByBidMasterDBID(saveModel, masterEntry);
                //    }
                //    else
                //    {
                //        processCustOrder(saveModel, masterEntry, ordLst);
                //    }
                //}
                //else
                //{
                //    if (bAddEditSubmit == false)
                //    {
                //        processOrderTransferByBidMasterDBID(saveModel, masterEntry);
                //    }
                //    else
                //    {
                //        processOrderTransfer(saveModel, ordLst, masterEntry);
                //    }
                //}
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
                //if (OrderQty(saveModel, orderList))
                //{
                //    //全部直接寫入cust_price_detail表和 viat_app_cust_order表               
                //    if (bAddEditSubmit == false)
                //    {
                //        processCustOrderByBidMasterDBID(saveModel, masterEntry);
                //    }
                //    else
                //    {
                //        processCustOrder(saveModel, masterEntry, ordLst);
                //    }
                //}
                //else
                //{
                //    if (bAddEditSubmit == false)
                //    {
                //        processOrderTransferByBidMasterDBID(saveModel, masterEntry);
                //    }
                //    else
                //    {
                //        processOrderTransfer(saveModel, ordLst, masterEntry);
                //    }
                //}
                if (bAddEditSubmit == false)
                {
                    processOrderTransferByBidMasterDBID(saveModel, masterEntry);
                }
                else
                {
                    processOrderTransfer(saveModel, ordLst, masterEntry);
                }
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
        /// <summary>
        /// 获取最近一年订单数据
        /// </summary>
        /// <param name="ProdctId"></param>
        /// <param name="CustomerId"></param>
        /// <param name="PricegroupiId"></param>
        /// <returns></returns>
       /* public List<Viat_app_cust_order> RecentOrder(string prod_dbid, string cust_dbid, string pricegroup_dbid)
        {
            string sSql = $"select  c_order.*,prod.prod_id,prod.prod_ename,cust.cust_id,cust.cust_name from  viat_app_cust_order c_order" +
                           $" left join viat_com_prod prod on c_order.prod_dbid = prod.prod_dbid" +
                           $" left join viat_com_cust cust on c_order.cust_dbid=cust.cust_dbid" +
                           $" where c_order.prod_dbid= '{prod_dbid}' and c_order.created_date > DATEADD(year,-1,GETDATE())";
            if (!string.IsNullOrEmpty(pricegroup_dbid) && pricegroup_dbid.ToLower() != "null")
            {
                sSql += $" and cust.cust_dbid in (SELECT distinct cust_dbid from viat_app_cust_group where pricegroup_dbid='{pricegroup_dbid}')";
            }
            if (!string.IsNullOrEmpty(cust_dbid) && cust_dbid.ToLower() != "null")
            {
                sSql += $"and cust.cust_dbid='{cust_dbid}'";
            }
            return repository.DapperContext.QueryList<Viat_app_cust_order>(sSql, new { });
        }*/

        public PageGridData<Viat_app_cust_order> RecentOrder(PageDataOptions pageData)
        {
            PageGridData<Viat_app_cust_order> pageGridData = new PageGridData<Viat_app_cust_order>();
            string prod_dbid = "";
            string cust_dbid = "";
            string pricegroup_dbid = "";
            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(pageData.Wheres))
            {
                searchParametersList = pageData.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "prod_dbid".ToLower())
                        {
                            prod_dbid = sp.Value;
                            continue;
                        }
                        if (sp.Name.ToLower() == "cust_dbid".ToLower())
                        {
                            cust_dbid = sp.Value;
                            continue;
                        }
                        if (sp.Name.ToLower() == "pricegroup_dbid".ToLower())
                        {
                            pricegroup_dbid = sp.Value;
                            continue;
                        }

                    }
                }
            }

            string where = "";
            if (string.IsNullOrEmpty(prod_dbid) == false)
            {
                where += " and c_order.created_date > DATEADD(year,-1,GETDATE()) and c_order.prod_dbid='" + prod_dbid + "'";
            }
            if (string.IsNullOrEmpty(cust_dbid) == false)
            {
                where += " and cust.cust_dbid='" + cust_dbid + "'";
            }
            if (string.IsNullOrEmpty(pricegroup_dbid) == false)
            {
                where += "and cust.cust_dbid in (SELECT distinct cust_dbid from viat_app_cust_group where pricegroup_dbid='" + pricegroup_dbid + "')";
            }

            QuerySql = @" select  ROW_NUMBER()over(order by c_order.order_no desc) as rowId , c_order.*,prod.prod_id,prod.prod_ename,cust.cust_id,cust.cust_name from  viat_app_cust_order c_order 
                        left join viat_com_prod prod on c_order.prod_dbid = prod.prod_dbid
                        left join viat_com_cust cust on c_order.cust_dbid=cust.cust_dbid  where 1=1 " + where;

            string sql = "select count(1) from (" + QuerySql + ") a";
            pageGridData.total = repository.DapperContext.ExecuteScalar(sql, null).GetInt();

            // QuerySql += "  ORDER BY prod_id, modified_date"; 
            sql = @$"select * from (" +
                QuerySql + $" ) as s where s.rowId between {((pageData.Page - 1) * pageData.Rows + 1)} and {pageData.Page * pageData.Rows} ";
            pageGridData.rows = repository.DapperContext.QueryList<Viat_app_cust_order>(sql, null);
            return pageGridData;

        }
        public View_wk_bid_price_apply_main getWkApplyMainByBidNO(string bid_no)
        {
            return repository.FindAsIQueryable(x => x.bid_no == bid_no).FirstOrDefault();
        }

        public Viat_app_cust_price ProductPrice(string prod_dbid, string pricegroup_dbid)
        {
            PageGridData<Viat_app_cust_price> detailGrid = new PageGridData<Viat_app_cust_price>();
            var sql = @$"select * from viat_app_cust_price where status = 'Y' AND ( SysDateTime ( ) ) >= start_date AND ( SysDateTime ( ) ) <= end_date 
                            AND prod_dbid = '{prod_dbid}' and pricegroup_dbid = '{pricegroup_dbid}'";
            detailGrid.rows = repository.DapperContext.QueryList<Viat_app_cust_price>(sql, new {});
            return detailGrid.rows.Count > 0 ? detailGrid.rows[0]:new Viat_app_cust_price();
        }

        #region 

        /// <summary>
        /// add master
        /// </summary>
        /// <param name="saveModel"></param>
        private void addWKMaster(SaveModel saveDataModel,string sStatus, bool bSubmit)
        {
            try
            {
                string sbidMastDBID = Guid.NewGuid().ToString();
                processWKMaster(saveDataModel, sbidMastDBID, sStatus);

                Viat_wk_master masterEntry = JsonConvert.DeserializeObject<Viat_wk_master>(JsonConvert.SerializeObject(saveDataModel.MainData));
                //处理bid和order 
                processBidAndOrder(saveDataModel, masterEntry, bSubmit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        /// <summary>
        /// 处理master
        /// </summary>
        private void processWKMaster(SaveModel saveDataModel,string bidMastDBID,string sStatus)
        {

            //增加master数据
            SaveModel.DetailListDataResult masterResult = new SaveModel.DetailListDataResult();
            saveDataModel.MainData["status"] = sStatus;
            saveDataModel.MainData["approved_date"] = DateTime.Now;
            if (saveDataModel.MainData["bidmast_dbid"]!= null && string.IsNullOrEmpty(saveDataModel.MainData["bidmast_dbid"].ToString())==true)
            {
                //新增
                string sBinNo = Viat_wk_masterService.Instance.getBidNO();

                saveDataModel.MainData["bidmast_dbid"] = bidMastDBID;
                saveDataModel.MainData["bid_no"] = sBinNo;                
                //saveDataModel.MainData["start_date"] = getFormatYYYYMMDD(DateTime.Now.ToString("yyyy-MM-dd"));

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
            try
            {
                if (saveDataModel.DetailData != null && saveDataModel.DetailData.Count > 0)
                {
                    foreach (Dictionary<string, object> dic in saveDataModel.DetailData)
                    {
                        Dictionary<string, object> dicTmp = dic;
                        if (dicTmp["key"]?.ToString() == "priceTableRowData")
                        {
                            string sBidData = dicTmp["value"]?.ToString();
                            processBidDetail(saveDataModel, sBidData, masterEntry, bAddEditSubmit);
                        }
                        else if (dicTmp["key"]?.ToString() == "orderTableRowData")
                        {
                            string sOrderData = dicTmp["value"]?.ToString();
                            processOrderDetail(saveDataModel, sOrderData, masterEntry, bAddEditSubmit);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    bid.price_close = bid.bid_price;
                    bid.final_allowance = bid.allowance;
                    bid.final_discount = bid.discount;
                    custResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(bid)));                   
                    custResult.detailType = typeof(Viat_wk_bid_detail);
                    saveDataModel.DetailListData.Add(custResult);                    
                }

                if (option == enumOption.addsubmit)
                {
                    processBidRelation(saveDataModel, bAddEditSubmit, masterEntry, bidList);
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
            try
            {
                if (!string.IsNullOrEmpty(sOrderData))
                {
                    List<Viat_wk_ord_detail> orderList = JsonConvert.DeserializeObject<List<Viat_wk_ord_detail>>(sOrderData);
                    if (orderList != null && orderList.Count > 0)
                    {
                        string bidPrice = "";

                        foreach (var item in saveDataModel.DetailData)
                        {
                            Dictionary<string, object> dicTmp = item;
                            if (dicTmp["key"]?.ToString() == "priceTableRowData")
                            {
                                bidPrice = dicTmp["value"]?.ToString();
                                break;
                            }
                        }
                        List<Viat_wk_bid_detail> bidList = new List<Viat_wk_bid_detail>();
                        if (string.IsNullOrEmpty(bidPrice))
                        {
                            bidList = Viat_wk_bid_detailService.Instance.getDataByBidMasterDBID(masterEntry.bidmast_dbid.ToString());
                        }
                        else
                        {
                            bidList = JsonConvert.DeserializeObject<List<Viat_wk_bid_detail>>(bidPrice.ToString());
                        }
                        foreach (Viat_wk_ord_detail order in orderList)
                        {
                            List<Viat_com_prod> prodModel = repository.DbContext.Set<Viat_com_prod>().Where(x => x.prod_dbid == order.prod_dbid).ToList();
                            #region 增加判断在bid和order的product_id不相等的情况下没有价格则不能保存
                            List<View_cust_price_detail> lstPriceDetail = CustPriceDetailData(order.prod_dbid.ToString(), saveDataModel.MainData["cust_dbid"].ToString());
                            if (lstPriceDetail.Count() == 0)
                            {
                                if (bidList != null && bidList.Count()>0)
                                {
                                    if (bidList.Where(x => x.prod_dbid.Equal(order.prod_dbid)).Count() == 0) throw new Exception("Order "+prodModel[0].prod_ename + " No effective price!");
                                }
                                else
                                {
                                    throw new Exception("Order "+prodModel[0].prod_ename + " No effective price!");
                                }
                            }
                            #endregion
                            #region 增加数量小于最小数量不能提交
                            if (!OrderQty(saveDataModel, orderList, bidPrice))
                            {
                                throw new Exception(prodModel[0].prod_ename + " The number of applications cannot be less than the minimum number!");
                            }
                            #endregion
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
                        if (option == enumOption.addsubmit)
                        {
                            processOrdRelation(saveDataModel, bAddEditSubmit, masterEntry, orderList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        #region 查询是否有有效价格
        private List<View_cust_price_detail> CustPriceDetailData(string prod_dbid,string cust_dbid)
        {
            string where = "";
            where += string.IsNullOrEmpty(prod_dbid) ? "" : "and  prod.prod_dbid ='" + prod_dbid + "'";
            where += string.IsNullOrEmpty(cust_dbid) ? "" : "and  cust.cust_dbid ='" + cust_dbid + "'";
            string sql = @"SELECT top 1 price.* 
                    FROM
	                    (
		                    (
		                    SELECT
			                    * 
		                    FROM
			                    (
			                    SELECT
				                    '1' AS source_type,
				                    MAX ( custPrice_d.dbid ) AS dbid,
				                    MAX ( custPrice_d.created_user ) AS created_user,
				                    MAX ( custPrice_d.created_client ) AS created_client,
				                    MAX ( custPrice_d.created_date ) AS created_date,
				                    MAX ( custPrice_d.modified_user ) AS modified_user,
				                    MAX ( custPrice_d.modified_client ) AS modified_client,
				                    MAX ( custPrice_d.modified_date ) AS modified_date,
				                    MAX ( custPrice_d.division ) AS division,
				                    '' AS group_id,
				                    '' AS group_name,
				                    custPrice_d.prod_dbid,
				                    MAX ( prod.prod_id ) AS prod_id,
				                    MAX ( prod.prod_ename ) AS prod_ename,
				                    MAX ( custPrice_d.nhi_price ) AS nhi_price,
				                    MAX ( custPrice_d.invoice_price ) AS invoice_price,
				                    MAX ( custPrice_d.net_price ) AS net_price,
				                    MAX ( custPrice_d.min_qty ) AS min_qty,
				                    MAX ( custPrice_d.start_date ) AS start_date,
				                    MAX ( custPrice_d.end_date ) AS end_date,
				                    custPrice_d.status,
				                    MAX ( custPrice_d.source ) AS source,
				                    MAX ( custPrice_d.remarks ) AS remarks,
				                    MAX ( cust.cust_id ) AS cust_id,
				                    MAX ( cust.cust_name ) AS cust_name,
				                    MAX ( prod.state ) AS prod_status,
				                    custPrice_d.cust_dbid 
			                    FROM
				                    viat_app_cust_price_detail AS custPrice_d
				                    LEFT JOIN viat_com_prod AS prod ON custPrice_d.prod_dbid = prod.prod_dbid
				                    LEFT JOIN viat_com_cust AS cust ON custPrice_d.cust_dbid = cust.cust_dbid 
			                    WHERE
				                    custPrice_d.status = 'Y' " + where + @"
			                    GROUP BY
				                    custPrice_d.prod_dbid,
				                    custPrice_d.cust_dbid,
				                    custPrice_d.status 
			                    ) AS cp_d 
		                    ) UNION
		                    (
		                    SELECT
			                    * 
		                    FROM
			                    (
			                    SELECT
				                    '0' AS source_type,
				                    MAX ( custPrice.dbid ) AS dbid,
				                    MAX ( custPrice.created_user ) AS created_user,
				                    MAX ( custPrice.created_client ) AS created_client,
				                    MAX ( custPrice.created_date ) AS created_date,
				                    MAX ( custPrice.modified_user ) AS modified_user,
				                    MAX ( custPrice.modified_client ) AS modified_client,
				                    MAX ( custPrice.modified_date ) AS modified_date,
				                    MAX ( custPrice.division ) AS division,
				                    priceGroup.group_id,
				                    priceGroup.group_name,
				                    custPrice.prod_dbid,
				                    MAX ( prod.prod_id ) AS prod_id,
				                    MAX ( prod.prod_ename ) AS prod_ename,
				                    MAX ( custPrice.nhi_price ) AS nhi_price,
				                    MAX ( custPrice.invoice_price ) AS invoice_price,
				                    MAX ( custPrice.net_price ) AS net_price,
				                    MAX ( custPrice.min_qty ) AS min_qty,
				                    MAX ( custPrice.start_date ) AS start_date,
				                    MAX ( custPrice.end_date ) AS end_date,
				                    custPrice.status,
				                    MAX ( custPrice.source ) AS source,
				                    MAX ( custPrice.remarks ) AS remarks,
				                    MAX ( cust.cust_id ) AS cust_id,
				                    MAX ( cust.cust_name ) AS cust_name,
				                    MAX ( prod.state ) AS prod_status,
				                    custGroup.cust_dbid 
			                    FROM
				                    viat_app_cust_price AS custPrice
				                    JOIN viat_app_cust_group AS custGroup ON custPrice.pricegroup_dbid = custGroup.pricegroup_dbid 
				                    AND custPrice.prod_dbid = custGroup.prod_dbid
				                    LEFT JOIN viat_app_cust_price_group AS priceGroup ON custPrice.pricegroup_dbid = priceGroup.pricegroup_dbid
				                    LEFT JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid
				                    LEFT JOIN viat_com_cust AS cust ON custGroup.cust_dbid = cust.cust_dbid
				                    LEFT JOIN viat_com_dist AS dist ON cust.cust_dbid = dist.cust_dbid 
			                    WHERE
				                    custGroup.status = 'Y' 
				                    AND prod.prod_dbid NOT IN ( SELECT priceDetail.prod_dbid FROM viat_app_cust_price_detail AS priceDetail WHERE priceDetail.cust_dbid = custGroup.cust_dbid AND priceDetail.status = 'Y' ) 
				                    AND custPrice.status = 'Y' " + where + @"
			                    GROUP BY
				                    custPrice.pricegroup_dbid,
				                    group_id,
				                    group_name,
				                    custPrice.prod_dbid,
				                    custGroup.cust_dbid,
				                    custPrice.status
			                    ) AS cp 
		                    ) 
	                    ) AS price";
            return repository.DapperContext.QueryList<View_cust_price_detail>(sql, new { });
        }
        #endregion

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

                    if (string.IsNullOrEmpty(masterEntity.pricegroup_dbid?.ToString()) == false)
                    {
                        transfer.pricegroup_dbid = masterEntity.pricegroup_dbid;
                    }
                    else if (string.IsNullOrEmpty(masterEntity.cust_dbid?.ToString()) == false)
                    {
                        transfer.cust_dbid = masterEntity.cust_dbid;
                    }

                    SaveModel.DetailListDataResult transferResult = new SaveModel.DetailListDataResult();
                    transfer.bid_no = masterEntity.bid_no;
                    transfer.start_date = masterEntity.start_date;
                    transfer.end_date = masterEntity.end_date;
                    transfer.state = "0";
                    transfer.price_close = bid.price_close;
                    transfer.final_discount = bid.final_discount;
                    transfer.final_fg = bid.final_allowance;
                    transfer.price_bid = bid.bid_price;
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
                string orderDate = "ORDER" + DateTime.Now.ToString("yyyyMMdd"),orderNo = "";
                foreach (Viat_wk_ord_detail order in orderLst)
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
                    if (userInfo != null)
                    {
                        transfer.requestor = userInfo.User_Id;
                        transfer.requestor_name = userInfo.UserName;
                        transfer.territory_id = "";

                    }
                    transfer.cust_dbid = masterEntry.cust_dbid;
                    transfer.bid_no = masterEntry.bid_no;

                    transfer.state = "0";
                    #region 增加order_no规则
                    List<Viat_app_cust_order_transfer> lstCustOrder = repository.DbContext.Set<Viat_app_cust_order_transfer>()
                        .Where(a => a.order_no.Contains(orderDate)).OrderByDescending(a => a.order_no).ToList();

                    if (string.IsNullOrEmpty(orderNo))
                    {
                        if (lstCustOrder.Count() > 0)
                        {
                            orderNo = lstCustOrder[0].order_no;
                        }
                    }
                    //int str = string.IsNullOrEmpty(orderNo) ? 0 : (Convert.ToInt32(orderNo.Substring(orderNo.Length - 5)));
                    orderNo = orderDate + "-" + OrderNo(string.IsNullOrEmpty(orderNo) ? 0 : (Convert.ToInt32(orderNo.Substring(orderNo.Length - 5))));
                    #endregion
                    transfer.order_no = orderNo;
                    //取viat_wk_master里面的remarks
                    transfer.note = masterEntry.remarks;
                    transfer.transfer_date = getFormatYYYYMMDD(System.DateTime.Now);
                    SaveModel.DetailListDataResult transferResult = new SaveModel.DetailListDataResult();
                    transferResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(transfer)));
                    transferResult.optionType = SaveModel.MainOptionType.add;
                    transferResult.detailType = typeof(Viat_app_cust_order_transfer);
                    saveModel.DetailListData.Add(transferResult);
                }


            }
        }
        private bool OrderQty(SaveModel saveModel, List<Viat_wk_ord_detail> orderLst,string bidPrice)
        {
            bool result = true;
            if (orderLst != null && orderLst.Count > 0)
            {
                string cust_dbid = saveModel.MainData["cust_dbid"] == null ? "" : saveModel.MainData["cust_dbid"].ToString();
                List<Viat_wk_bid_detail> bidList = JsonConvert.DeserializeObject<List<Viat_wk_bid_detail>>(bidPrice.ToString());
                foreach (var order in orderLst)
                {
                    if (!string.IsNullOrEmpty(bidPrice))
                    {
                        int orderCount = bidList.Where(a=>a.prod_dbid == order.prod_dbid && a.min_qty > order.qty).Count();
                        if (orderCount >0)
                        {
                            result = false;
                            break;
                        }
                    }
                    else
                    {
                        List<View_cust_price_detail> lstPriceDetail = CustPriceDetailData(order.prod_dbid.ToString(), cust_dbid);
                        if (lstPriceDetail != null && lstPriceDetail.Count() > 0)
                        {
                            int? minQty = lstPriceDetail[0].min_qty;
                            if (order.qty < minQty)
                            {
                                result = false;
                                break;
                            }
                        }
                    }

                   
                }
            }
            return result;
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
                    if (masterEntry.pricegroup_dbid != null)
                    {
                        priceDetail.pricedetail_dbid = masterEntry.pricegroup_dbid;
                    }
                    else if (masterEntry.cust_dbid != null)
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

                string orderDate = "ORDER" + DateTime.Now.ToString("yyyyMMdd"),orderNo = "";
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
                    #region 增加order_no规则
                    List<Viat_app_cust_order> lstCustOrder = repository.DbContext.Set<Viat_app_cust_order>()
                        .Where(a => a.order_no.Contains(orderDate)).OrderByDescending(a => a.order_no).ToList();

                    if (string.IsNullOrEmpty(orderNo))
                    {
                        if (lstCustOrder.Count() > 0)
                        {
                            orderNo = lstCustOrder[0].order_no;
                        }
                    }
                    //int str = string.IsNullOrEmpty(orderNo) ? 0 : (Convert.ToInt32(orderNo.Substring(orderNo.Length - 5)));
                    orderNo = orderDate + "-" + OrderNo(string.IsNullOrEmpty(orderNo) ? 0 : (Convert.ToInt32(orderNo.Substring(orderNo.Length - 5))));
                    #endregion
                    custOrder.cust_dbid = masterEntry.cust_dbid;
                    custOrder.state = "0";
                    custOrder.order_no = orderNo;
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

        private string OrderNo(int OrderNo)
        { 
            return OrderNo == 0 ? "1".PadLeft(5, '0'): (OrderNo+1).ToString().PadLeft(5, '0');
        }

        public Sys_User SysUserData()
        {
            UserInfo userInfo = VIAT.Core.ManageUser.UserContext.Current.UserInfo;
            List<Sys_User> userList = repository.DbContext.Set<Sys_User>().Where(x => x.User_Id.Equals(userInfo.User_Id)).ToList();
            return userList[0];
        }
        #endregion

        #endregion
    }
}
