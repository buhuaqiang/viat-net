/*
 *所有关于View_cust_price_transfer类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_cust_price_transferService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VIAT.Price.Services;
using System.Text.RegularExpressions;

namespace VIAT.WorkFlow.Services
{
    public partial class View_cust_price_transferService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_cust_price_transferRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_cust_price_transferService(
            IView_cust_price_transferRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override PageGridData<View_cust_price_transfer> GetPageData(PageDataOptions options)
        {
            QuerySql = @"SELECT trs.*,
            CONCAT(trs.territory_id,' ',trs.requestor_name) as requestorName,
            cust.cust_id,
            cust.cust_name,
            prod.prod_id,
            prod.prod_ename,
            prod.localmpg_dbid,
            prod.state as prodStatus,
            mpg.mpg_name,
            grp.group_id,
            grp.group_name,
            '' as 'pendingReason'
             from viat_app_cust_price_transfer trs
            left JOIN viat_com_cust cust on cust.cust_dbid=trs.cust_dbid
            left OUTER join viat_com_prod prod on prod.prod_dbid=trs.prod_dbid
            left join viat_app_cust_price_group grp on trs.pricegroup_dbid=grp.pricegroup_dbid
            LEFT JOIN viat_com_local_mpg mpg on prod.localmpg_dbid=mpg.localmpg_dbid";
            PageGridData<View_cust_price_transfer> pageGridData = base.GetPageData(options);
            foreach(View_cust_price_transfer trans in pageGridData.rows)
            {
                string result = "";
                if (trans.start_date!=null && trans.transfer_date!=null && getFormatYYYYMMDD(trans.start_date) != getFormatYYYYMMDD(trans.transfer_date))
                    result += " Start Date ≠ Approved Date; ";
                if (trans.end_date != null && trans.end_date.Value.Year != 2099)
                    result += " End Date ≠ 2099; ";
                if (trans.end_date != null && trans.end_date.Value.Date < DateTime.Now.Date)
                    result += " End Date < Today; ";
                if (trans.net_price == trans.invoice_price && trans.net_price != trans.nhi_price)
                    result += " Net Price=Invoce Price But ≠ NHI Price; ";
                if (trans.net_price > trans.invoice_price)
                    result += " Net Price > Invoice Price; ";
                trans.pendingReason = result;
            }
            return pageGridData;
        }
        public override WebResponseContent Export(PageDataOptions pageData)
        {
            ExportColumns = x => new {
                x.bid_no,
                x.state,
                x.modified_date,
                x.created_date,
                x.requestorName,
                x.group_id,
                x.group_name,
                x.cust_id,
                x.cust_name,
                x.prod_id,
                x.prod_ename,
                x.note
            };
            return base.Export(pageData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            //1：个人：1：（个人）cust_dbid不为空，add_group不为空并（客户组）in_pricegroup_dbid不为空 需要添加：Viat_app_cust_price，Viat_app_cust_group
            //1：个人：1：（个人）cust_dbid不为空，add_group为空 需要添加：Viat_app_cust_price_detail
            //1：个人：2：（个人）cust_dbid不为空，add_group不为空（客户组）in_pricegroup_dbid为空 需要添加：Viat_app_cust_price_detail

            //2：组：1：（组）（pricegroup_dbid）不为空，需要添加：Viat_app_cust_price

            string cust_dbid = saveModel.MainData["cust_dbid"]?.ToString();
            string add_group = saveModel.MainData["add_group"]?.ToString();
            string in_pricegroup_dbid = saveModel.MainData["in_pricegroup_dbid"]?.ToString();
            string pricegroup_dbid = saveModel.MainData["pricegroup_dbid"]?.ToString();
            string cust = "";
            if (!string.IsNullOrEmpty(cust_dbid))
            {
                if (!string.IsNullOrEmpty(add_group) && !string.IsNullOrEmpty(in_pricegroup_dbid))
                {
                    cust = "CustPriceGroup";
                }
                else if (!string.IsNullOrEmpty(add_group) && string.IsNullOrEmpty(in_pricegroup_dbid))
                {
                    cust = "CustDetail";
                }
                else if (string.IsNullOrEmpty(add_group))
                {
                    cust = "CustDetail";
                }
            }
            else if (!string.IsNullOrEmpty(pricegroup_dbid))
            {
                cust = "CustPrice";
            }

            //根據主鍵取得master數據,只更新狀態
            processBidAndOrder(saveModel, cust);
            return base.CustomBatchProcessEntity(saveModel);
        }

        public List<View_cust_price_detail> CustPriceDetailData(string pricegroup_dbid, string[] prod_dbid, string cust_dbid)
        {

            string str = string.Format("'{0}'", string.Join(",", prod_dbid.ToArray()).Replace(",", "','"));
            string sql = @$"SELECT
	                    detail.pricedetail_dbid,
	                    detail.cust_dbid,
	                    detail.prod_dbid,
	                    cust.cust_id,
	                    cust.cust_name,
	                    prod.prod_id,
	                    prod.prod_ename,
	                    detail.invoice_price,
	                    detail.net_price,
	                    detail.min_qty,
	                    detail.start_date,
	                    detail.end_date,
	                    detail.status 
                    FROM
	                    viat_app_cust_price_detail detail
	                    LEFT JOIN viat_com_cust cust ON detail.cust_dbid = cust.cust_dbid
	                    LEFT JOIN viat_com_prod prod ON prod.prod_dbid = detail.prod_dbid 
                    WHERE
	                    1 = 1 
	                    AND detail.cust_dbid IN ( SELECT DISTINCT cust_dbid FROM viat_app_cust_group WHERE pricegroup_dbid = '{pricegroup_dbid}') 
	                    AND detail.prod_dbid IN ({str}) and detail.status = 'Y' and detail.cust_dbid <> '{cust_dbid}'";
            //List<View_cust_price_detail> lstProceDetail = (List<View_cust_price_detail>)repository.DapperContext.ExecuteScalar(sql,null);
            return repository.DapperContext.QueryList<View_cust_price_detail>(sql, new { });
        }


        #region         


        /// <summary>
        /// 处理bid order 
        /// </summary>
        /// <param name="saveDataModel"></param>
        public void processBidAndOrder(SaveModel saveDataModel, string Cust)
        {
            if (saveDataModel.DetailData != null && saveDataModel.DetailData.Count > 0)
            {
                string inpricegrouddbid = saveDataModel.MainData["in_pricegroup_dbid"] == null ? "" : saveDataModel.MainData["in_pricegroup_dbid"].ToString();
                string pricegrouddbid = saveDataModel.MainData["pricegroup_dbid"] == null ? "" : saveDataModel.MainData["pricegroup_dbid"].ToString();
                Guid? pricegroupdbid = null;
                if (!string.IsNullOrEmpty(inpricegrouddbid))
                {
                    pricegroupdbid = new Guid(inpricegrouddbid);
                }
                else if (!string.IsNullOrEmpty(pricegrouddbid))
                {
                    pricegroupdbid = new Guid(pricegrouddbid);
                }
                //取得两个remark;
                string sBidPriceReamrk = "";
                string sBidOrderRemark ="";
                foreach (Dictionary<string, object> dic in saveDataModel.DetailData)
                {
                    Dictionary<string, object> dicTmp = dic;
                    if (dicTmp["key"]?.ToString() == "orderNote")
                    {
                        sBidOrderRemark = dicTmp["value"]?.ToString();
                    }
                    else if (dicTmp["key"]?.ToString() == "priceNote")
                    {
                        sBidPriceReamrk = dicTmp["value"]?.ToString();
                    }
                }
                 foreach (Dictionary<string, object> dic in saveDataModel.DetailData)
                {

                   
                    Dictionary<string, object> dicTmp = dic;
                    if (dicTmp["key"]?.ToString() == "priceTableRowData")
                    {
                        string sBidData = dicTmp["value"]?.ToString();
                        processGroupAndCust(saveDataModel, sBidData, Cust, sBidPriceReamrk, pricegroupdbid);
                    }
                    else if (dicTmp["key"]?.ToString() == "orderTableRowData")
                    {
                        string sOrderData = dicTmp["value"]?.ToString();
                        processOrder(saveDataModel, sOrderData, sBidOrderRemark);
                    }
                    else if (dicTmp["key"]?.ToString() == "joinGroupList")
                    {
                        string sJoinData = dicTmp["value"]?.ToString();
                        processCustGroup(saveDataModel, sJoinData, Cust, pricegroupdbid);
                    }

                }
            }
        }



        #region 除以上規則外，全部直接寫入cust_price_detail表和 viat_app_cust_order表

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="masterEntry"></param>
        /// <param name="sData"></param>
        public void processGroupAndCust(SaveModel saveModel, string sData, string Cust, string sRemak,Guid? pricegroupdbid)
        {
            if (string.IsNullOrEmpty(sData) == false)
            {
                List<Viat_app_cust_price_transfer> bidList = JsonConvert.DeserializeObject<List<Viat_app_cust_price_transfer>>(sData);
                string cust_dbid = saveModel.MainData["cust_dbid"]?.ToString();
                Guid? custdbid = null;
                if (!string.IsNullOrEmpty(cust_dbid))
                {
                    custdbid = new Guid(cust_dbid);
                }
                //处理本身
                SaveModel.DetailListDataResult priceTransferResult = new SaveModel.DetailListDataResult();
                saveModel.DetailListData.Add(priceTransferResult);
                foreach (Viat_app_cust_price_transfer bid in bidList)
                {
                    bid.cust_dbid = custdbid;
                    bid.start_date = Convert.ToDateTime(saveModel.MainData["start_date"]);
                    bid.end_date = Convert.ToDateTime(saveModel.MainData["end_date"]);
                    if (bid.state == "2")
                    {
                        //不导入  //更新自己
                        bid.state = "2";                         
                    }
                    else
                    {
                        //已导入
                        bid.state = "1";
                       
                    }
                    bid.pricegroup_dbid = pricegroupdbid;
                    bid.add_group = saveModel.MainData["add_group"].ToString();
                    //更新本身数据
                    priceTransferResult.optionType = SaveModel.MainOptionType.update;
                    priceTransferResult.detailType = typeof(Viat_app_cust_price_transfer);
                    priceTransferResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(bid)));
                }
                //处理关联
                //processCustPrice(saveModel, bidList, bImport, sRemak);
                //processPriceDetail(saveModel, bidList, bImport, sRemak);
                processCust(saveModel, bidList, Cust, sRemak, pricegroupdbid);
            }

        }

        public void processCust(SaveModel saveModel, List<Viat_app_cust_price_transfer> bidLst, string Cust, string sRemark,Guid? pricegroupdbid)
        {
            if (bidLst != null && bidLst.Count > 0)
            {
                List<Dictionary<string, object>> pricesLst = new List<Dictionary<string, object>>();
                List<Dictionary<string, object>> groupList = new List<Dictionary<string, object>>();
                //SaveModel.DetailListDataResult ImportResult = new SaveModel.DetailListDataResult();
                //saveModel.DetailListData.Add(ImportResult);
                
                switch (Cust)
                {
                    case "CustPriceGroup":
                        foreach (var bid in bidLst)
                        {
                            if (bid.state == "2") continue;
                            //处理组
                            //把cust記錄寫入transfer, delivery transfer
                            Viat_app_cust_price custPrice = new Viat_app_cust_price(); //JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(bid));
                            bid.MapValueToEntity(custPrice);
                            custPrice.custprice_dbid = System.Guid.NewGuid();
                            custPrice.remarks = sRemark;
                            if (bid.start_date != null)
                            {
                                custPrice.start_date = getFormatYYYYMMDD(bid.start_date);
                            }

                            if (bid.end_date != null)
                            {
                                custPrice.end_date = getFormatYYYYMMDD(bid.end_date);
                            }
                            custPrice.status = "Y";
                            custPrice.pricegroup_dbid = pricegroupdbid;
                            Dictionary<string, object> priceDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custPrice));
                            /*  custPriceResult.DetailData.Add(priceDic);
                              custPriceResult.optionType = SaveModel.MainOptionType.add;
                              custPriceResult.detailType = typeof(Viat_app_cust_price);
                              saveModel.DetailListData.Add(custPriceResult);*/

                            //记录旧数据
                            pricesLst.Add(priceDic);

                            Viat_app_cust_group custGroup = new Viat_app_cust_group();
                            bid.MapValueToEntity(custGroup);
                            //custGroup.pricegroup_dbid = new Guid(saveModel.MainData["pricegroup_dbid"].ToString());
                            custGroup.custgroup_dbid = System.Guid.NewGuid();
                            custGroup.start_date = getFormatYYYYMMDD(bid.start_date);
                            custGroup.end_date = getFormatYYYYMMDD(bid.end_date);
                            custGroup.status = "Y";
                            custGroup.pricegroup_dbid = pricegroupdbid;
                            custGroup.prod_dbid = bid.prod_dbid;
                            custGroup.cust_dbid = bid.cust_dbid;
                            Dictionary<string, object> groupDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custGroup));
                            groupList.Add(groupDic);
                            //ImportResult.optionType = SaveModel.MainOptionType.add;
                            //ImportResult.detailType = typeof(Viat_app_cust_group);
                            //ImportResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custGroup)));
                        }

                        //处理旧数据
                        saveModel.MainDatas = pricesLst;
                        View_cust_priceService.Instance.processData(saveModel);

                        saveModel.DetailsData = groupList;
                        Viat_app_cust_groupService.Instance.processData(saveModel);
                        break;
                    case "CustPrice":
                        foreach (var bid in bidLst)
                        {
                            if (bid.state == "2") continue;
                            //处理组
                            //把cust記錄寫入transfer, delivery transfer
                            Viat_app_cust_price custPrice = new Viat_app_cust_price(); //JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(bid));
                            bid.MapValueToEntity(custPrice);
                            custPrice.custprice_dbid = System.Guid.NewGuid();
                            custPrice.remarks = sRemark;
                            if (bid.start_date != null)
                            {
                                custPrice.start_date = getFormatYYYYMMDD(bid.start_date);
                            }

                            if (bid.end_date != null)
                            {
                                custPrice.end_date = getFormatYYYYMMDD(bid.end_date);
                            }
                            custPrice.status = "Y";
                            custPrice.pricegroup_dbid = pricegroupdbid;
                            Dictionary<string, object> priceDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custPrice));
                            /*  custPriceResult.DetailData.Add(priceDic);
                              custPriceResult.optionType = SaveModel.MainOptionType.add;
                              custPriceResult.detailType = typeof(Viat_app_cust_price);
                              saveModel.DetailListData.Add(custPriceResult);*/

                            //记录旧数据
                            pricesLst.Add(priceDic);
                        }
                        //处理旧数据
                        saveModel.MainDatas = pricesLst;
                        View_cust_priceService.Instance.processData(saveModel);
                        break;
                    case "CustDetail":
                        string cust_dbid = saveModel.MainData["cust_dbid"]?.ToString();
                        Guid? custdbid = null;
                        if (!string.IsNullOrEmpty(cust_dbid))
                        {
                            custdbid = new Guid(cust_dbid);
                        }
                        foreach (var bid in bidLst)
                        {
                            if (bid.state == "2") continue;
                            //把cust記錄寫入transfer, delivery transfer
                            Viat_app_cust_price_detail custPrice = new Viat_app_cust_price_detail(); //JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(bid));
                            bid.MapValueToEntity(custPrice);
                            custPrice.pricedetail_dbid = System.Guid.NewGuid();
                            custPrice.remarks = sRemark;
                            custPrice.cust_dbid = custdbid;
                            if (bid.start_date != null)
                            {
                                custPrice.start_date = getFormatYYYYMMDD(bid.start_date);
                            }

                            if (bid.end_date != null)
                            {
                                custPrice.end_date = getFormatYYYYMMDD(bid.end_date);
                            }

                            /* priceDetail.bid_no = bid.bid_no;
                             priceDetail.prod_dbid = bid.prod_dbid;*/
                            custPrice.status = "Y";

                            Dictionary<string, object> priceDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custPrice));
                            /* custPriceResult.DetailData.Add(priceDic);
                             custPriceResult.optionType = SaveModel.MainOptionType.add;
                             custPriceResult.detailType = typeof(Viat_app_cust_price_detail);
                             saveModel.DetailListData.Add(custPriceResult);*/

                            //记录旧数据
                            pricesLst.Add(priceDic);
                        }
                        //处理旧数据
                        saveModel.MainDatas = pricesLst;
                        View_cust_price_detailService.Instance.processData(saveModel);
                        break;
                }
            }
        }

        /// <summary>
        /// Viat_app_cust_price_detail
        /// </summary>
        /// <param name="saveModel"></param>
        //public void processCustPrice(SaveModel saveModel, List<Viat_app_cust_price_transfer> bidLst, string Cust, string sRemark)
        //{
        //    if (bidLst != null && bidLst.Count > 0)
        //    {
        //        //关联处理记录.
        //        List<Dictionary<string, object>> pricesLst = new List<Dictionary<string, object>>();

        //        SaveModel.DetailListDataResult ImportResult = new SaveModel.DetailListDataResult();
        //        saveModel.DetailListData.Add(ImportResult);
        //        string pricegroud = saveModel.MainData["in_pricegroup_dbid"] == null ? "" : saveModel.MainData["in_pricegroup_dbid"].ToString();
        //        Guid? pricegroupdbid = null;
        //        if (!string.IsNullOrEmpty(pricegroud))
        //        {
        //            pricegroupdbid = new Guid(pricegroud);
        //        }
        //        switch (Cust)
        //        {
        //            case "CustPriceGroup":

        //                break;
        //            default:
        //                break;
        //        }
        //        foreach (Viat_app_cust_price_transfer bid in bidLst)
        //        {
        //            if (bid.state == "2") continue;
        //            //导入,根据cust_id,group_id进行区分
        //            if (string.IsNullOrEmpty(pricegroupdbid.ToString()) == false || 
        //                bImport == true)
        //            {
                        
        //                //处理组
        //                //把cust記錄寫入transfer, delivery transfer
        //                Viat_app_cust_price custPrice = new Viat_app_cust_price(); //JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(bid));
        //                bid.MapValueToEntity(custPrice);
        //                custPrice.custprice_dbid = System.Guid.NewGuid();                         
        //                custPrice.remarks = sRemark;
        //                if (bid.start_date != null)
        //                {
        //                    custPrice.start_date = getFormatYYYYMMDD(bid.start_date);
        //                }

        //                if (bid.end_date != null)
        //                {
        //                    custPrice.end_date = getFormatYYYYMMDD(bid.end_date);
        //                }
        //                custPrice.status = "Y";
        //                custPrice.pricegroup_dbid = pricegroupdbid;
        //                Dictionary<string, object> priceDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custPrice));
        //                /*  custPriceResult.DetailData.Add(priceDic);
        //                  custPriceResult.optionType = SaveModel.MainOptionType.add;
        //                  custPriceResult.detailType = typeof(Viat_app_cust_price);
        //                  saveModel.DetailListData.Add(custPriceResult);*/

        //                //记录旧数据
        //                pricesLst.Add(priceDic);

        //                //如果是groupimport,需要插cust_group
        //                if(bImport == true)
        //                {
        //                    Viat_app_cust_group custGroup = new Viat_app_cust_group();
        //                    bid.MapValueToEntity(custGroup);
        //                    //custGroup.pricegroup_dbid = new Guid(saveModel.MainData["pricegroup_dbid"].ToString());
        //                    custGroup.custgroup_dbid = System.Guid.NewGuid();
        //                    custGroup.start_date = getFormatYYYYMMDD(bid.start_date);
        //                    custGroup.end_date = getFormatYYYYMMDD(bid.end_date);
        //                    custGroup.status = "Y";
        //                    custGroup.pricegroup_dbid = pricegroupdbid;
        //                    custGroup.prod_dbid = bid.prod_dbid;
        //                    custGroup.cust_dbid = bid.cust_dbid;
        //                    ImportResult.optionType = SaveModel.MainOptionType.add;
        //                    ImportResult.detailType = typeof(Viat_app_cust_group);
        //                    ImportResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string,object>>(JsonConvert.SerializeObject(custGroup)));
        //                }
        //            }
        //            else if (string.IsNullOrEmpty(bid.cust_dbid?.ToString()) == false)
        //            {
        //                //处理pricedetail
        //                return;
        //            }

        //        }

        //        //处理旧数据
        //        saveModel.MainDatas = pricesLst;
        //        View_cust_priceService.Instance.processData(saveModel);

        //    }

        //}


        /// <summary>
        /// Viat_app_cust_price_detail
        /// </summary>
        /// <param name="saveModel"></param>
        //public void processPriceDetail(SaveModel saveModel, List<Viat_app_cust_price_transfer> bidLst,bool bImport, string sRemark)
        //{
        //    if (bidLst != null && bidLst.Count > 0)
        //    {
                
        //        //关联处理记录.
        //        List<Dictionary<string, object>> pricesLst = new List<Dictionary<string, object>>();

        //        // SaveModel.DetailListDataResult custPriceResult = new SaveModel.DetailListDataResult();
        //        string pricegroud = saveModel.MainData["in_pricegroup_dbid"] == null ? "" : saveModel.MainData["in_pricegroup_dbid"].ToString();
        //        Guid? pricegroupdbid = null;
        //        if (!string.IsNullOrEmpty(pricegroud))
        //        {
        //            pricegroupdbid = new Guid(pricegroud);
        //        }
        //        foreach (Viat_app_cust_price_transfer bid in bidLst)
        //        {
        //            if (bid.state == "2") continue;

        //            //导入,根据cust_id,group_id进行区分
        //            if (string.IsNullOrEmpty(pricegroupdbid.ToString()) == false || bImport == true)
        //            {
        //                //处理组
        //                return;
        //            }
        //            else if (string.IsNullOrEmpty(bid.cust_dbid?.ToString()) == false)
        //            {
        //                //处理pricedetail
                       
        //            }

        //            //把cust記錄寫入transfer, delivery transfer
        //            Viat_app_cust_price_detail custPrice = new Viat_app_cust_price_detail(); //JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(bid));
        //            bid.MapValueToEntity(custPrice);
        //            custPrice.pricedetail_dbid = System.Guid.NewGuid();
        //            custPrice.remarks = sRemark;
        //            if(bid.start_date != null)
        //            {
        //                custPrice.start_date = getFormatYYYYMMDD(bid.start_date);
        //            }
                   
        //            if(bid.end_date != null)
        //            {
        //                custPrice.end_date = getFormatYYYYMMDD(bid.end_date);
        //            }
                  
        //            /* priceDetail.bid_no = bid.bid_no;
        //             priceDetail.prod_dbid = bid.prod_dbid;*/
        //            custPrice.status = "Y";

        //            Dictionary<string, object> priceDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custPrice));
        //           /* custPriceResult.DetailData.Add(priceDic);
        //            custPriceResult.optionType = SaveModel.MainOptionType.add;
        //            custPriceResult.detailType = typeof(Viat_app_cust_price_detail);
        //            saveModel.DetailListData.Add(custPriceResult);*/

        //            //记录旧数据
        //            pricesLst.Add(priceDic);
        //        }

        //        //处理旧数据
        //        saveModel.MainDatas = pricesLst;
        //        View_cust_price_detailService.Instance.processData(saveModel);

        //    }


        //}



        /// <summary>
        /// 处理order
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="sOrdData"></param>
        /// <param name="sRemark"></param>
        public void processOrder(SaveModel saveModel, string sOrdData, string sRemark)
        {
            if (string.IsNullOrEmpty(sOrdData) == false)
            {
                List<Viat_app_cust_order_transfer> bidList = JsonConvert.DeserializeObject<List<Viat_app_cust_order_transfer>>(sOrdData);

                processCustOrder(saveModel, bidList, sRemark);
            }
        }

        /// <summary>
        /// Viat_app_cust_order
        /// </summary>
        /// <param name="saveModel"></param>
        public void processCustOrder(SaveModel saveModel, List<Viat_app_cust_order_transfer> orderLst, string sRemark)
        {

            if (orderLst != null && orderLst.Count > 0)
            {
                SaveModel.DetailListDataResult transferResult = new SaveModel.DetailListDataResult();
                saveModel.DetailListData.Add(transferResult);
                SaveModel.DetailListDataResult orderResult = new SaveModel.DetailListDataResult();
                saveModel.DetailListData.Add(orderResult);
                string orderDate = "ORDER" + DateTime.Now.ToString("yyyyMMdd"), orderNo = "";
                foreach (Viat_app_cust_order_transfer order in orderLst)
                {

                    if (order.state == "2")
                    {
                        //不导入  //更新自己
                        order.state = "2";

                    }
                    else
                    {
                        //已导入
                        order.state = "1";

                    }
                    //更新本身数据
                    orderResult.optionType = SaveModel.MainOptionType.update;
                    orderResult.detailType = typeof(Viat_app_cust_order_transfer);
                    orderResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(order)));

                    if (order.state == "2")
                    {
                        continue;
                    }
                    //#region 增加order_no规则
                    //List<Viat_app_cust_order> lstCustOrder = repository.DbContext.Set<Viat_app_cust_order>()
                    //    .Where(a => a.order_no.Contains(orderDate)).OrderByDescending(a => a.order_no).ToList();
                    //if (string.IsNullOrEmpty(orderNo))
                    //{
                    //    if (lstCustOrder.Count() > 0)
                    //    {
                    //        orderNo = lstCustOrder[0].order_no;
                    //    }
                    //}
                    ////int str = string.IsNullOrEmpty(orderNo) ? 0 : (Convert.ToInt32(orderNo.Substring(orderNo.Length - 5)));
                    //orderNo = orderDate + "-" + OrderNo(string.IsNullOrEmpty(orderNo) ? 0 : (Convert.ToInt32(orderNo.Substring(orderNo.Length - 5))));
                    //#endregion
                    //把cust記錄寫入transfer, delivery transfer
                    Viat_app_cust_order custOrder = JsonConvert.DeserializeObject<Viat_app_cust_order>(JsonConvert.SerializeObject(order));
                    custOrder.order_dbid = System.Guid.NewGuid();
                    //处理bidno 
                    custOrder.cust_dbid = order.cust_dbid;
                    custOrder.state = "0";
                    //custOrder.order_no = orderNo;
                    custOrder.prod_dbid = order.prod_dbid;
                    custOrder.qty = order.qty;
                    custOrder.remarks = sRemark;

                    //
                    transferResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custOrder)));
                    transferResult.optionType = SaveModel.MainOptionType.add;
                    transferResult.detailType = typeof(Viat_app_cust_order);
                    
                }

            }
        }
        /// <summary>
        /// 处理price_detail, 处理cust_group
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="sData"></param>
        public void processCustGroup(SaveModel saveModel,string sData, string Cust,Guid? pricegroupdbid)
        {
            if (string.IsNullOrEmpty(sData) == false && Cust.Equals("CustPriceGroup"))
            {
                List<Dictionary<string, object>> groupList = new List<Dictionary<string, object>>();
                string bid_no = saveModel.MainData["bid_no"] == null ? "" : saveModel.MainData["bid_no"].ToString();

                List<Viat_app_cust_price_detail> detailList = JsonConvert.DeserializeObject<List<Viat_app_cust_price_detail>>(sData);
                //detail
                SaveModel.DetailListDataResult detailResult = new SaveModel.DetailListDataResult();
                detailResult.optionType = SaveModel.MainOptionType.update;
                detailResult.detailType = typeof(Viat_app_cust_price_detail);
                saveModel.DetailListData.Add(detailResult);
                //custgroup
                //SaveModel.DetailListDataResult custGroupResult = new SaveModel.DetailListDataResult();
                //custGroupResult.optionType = SaveModel.MainOptionType.add;
                //custGroupResult.detailType = typeof(Viat_app_cust_group);
                //saveModel.DetailListData.Add(custGroupResult);

                foreach(Viat_app_cust_price_detail detail in detailList)
                {
                    //detail
                    detail.status = "N";
                    detailResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string,object>>(JsonConvert.SerializeObject(detail)));

                    //custgroup
                    Viat_app_cust_group custGroup = new Viat_app_cust_group();
                    custGroup.custgroup_dbid = System.Guid.NewGuid();
                    custGroup.pricegroup_dbid = pricegroupdbid;
                    custGroup.cust_dbid = detail.cust_dbid;
                    custGroup.prod_dbid = detail.prod_dbid;
                    custGroup.bid_no = bid_no;
                    custGroup.status = "Y";
                    custGroup.start_date = getFormatYYYYMMDD(saveModel.MainData["start_date"].ToString());
                    custGroup.end_date = getFormatYYYYMMDD(saveModel.MainData["end_date"].ToString());
                    Dictionary<string, object> groupDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custGroup));
                    groupList.Add(groupDic);
                    //custGroupResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custGroup)));
                }
                saveModel.DetailsData = groupList;
                Viat_app_cust_groupService.Instance.processData(saveModel);
            }
        }
        #endregion

        #endregion
    }
}
