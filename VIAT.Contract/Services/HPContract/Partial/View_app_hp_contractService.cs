/*
 *所有关于View_app_hp_contract类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_app_hp_contractService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using System;
using VIAT.Contract.Repositories;
using VIAT.Basic.Services;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VIAT.Contract.Services
{
    public partial class View_app_hp_contractService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_app_hp_contractRepository _repository;//访问数据库
        private readonly IViat_app_hp_contractService _viat_app_hp_contractService;
        private readonly IViat_app_hp_contractRepository _viat_app_hp_contractRepository;
        private WebResponseContent webResponse = new WebResponseContent();
        [ActivatorUtilitiesConstructor]
        public View_app_hp_contractService(
            IView_app_hp_contractRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_hp_contractService viat_app_hp_contractService,
            IViat_app_hp_contractRepository viat_app_hp_contractRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_app_hp_contractService = viat_app_hp_contractService;
            _viat_app_hp_contractRepository = viat_app_hp_contractRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }





       

        public override PageGridData<View_app_hp_contract> GetPageData(PageDataOptions options)
        {
           
            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            string contractNo = "";
            string startDate = "";
            string endDate = "";
            string groupDbid = "";
            string custDbid = "";
            string cpProdDbid = "";
            string cfProdDbid = "";
            string status = "";
            string innerCust = "";
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "contract_no".ToLower())
                        {
                            contractNo = " AND(hp_contract.contract_no like '%"+sp.Value+ "%') ";
                            continue;
                        }
                        if (sp.Name.ToLower() == "start_date".ToLower())
                        {
                            startDate = " and hp_contract.start_date>=" + sp.Value ;
                            continue;
                        }
                        if (sp.Name.ToLower() == "end_date".ToLower())
                        {
                            endDate = " and hp_contract.end_date<=" + sp.Value;
                            continue;
                        }
                        if (sp.Name.ToLower() == "pricegroup_dbid".ToLower())
                        {
                            groupDbid = " and ( hp_contract.pricegroup_dbid=" + sp.Value+")";
                            continue;
                        }
                        if (sp.Name.ToLower() == "cust_dbid".ToLower())
                        {
                            custDbid = " and ( c_cust.cust_dbid=" + sp.Value + ")";
                            innerCust = " INNER JOIN viat_app_hp_contract_cust  c_cust ON c_cust.hpcont_dbid = hp_contract.hpcont_dbid ";
                            continue;
                        }
                        if (sp.Name.ToLower() == "pu_prod_dbid".ToLower())
                        {
                            cpProdDbid = " and ( EXISTS (SELECT 1 AS C1 FROM viat_app_hp_contract_purchase_prod  p_prod WHERE p_prod.prod_dbid =" + sp.Value + " AND hp_contract.hpcont_dbid = p_prod.hpcont_dbid ))";
                            continue;
                        }
                        if (sp.Name.ToLower() == "cf_prod_dbid".ToLower())
                        {
                            cfProdDbid = " and ( EXISTS (SELECT 1 AS C1 FROM viat_app_hp_contract_free_prod f_prod WHERE f_prod.prod_dbid  =" + sp.Value + " AND hp_contract.hpcont_dbid =  f_prod.hpcont_dbid ))";
                            continue;
                        }
                        if (sp.Name.ToLower() == "state".ToLower())
                        {
                            status = " and hp_contract.state=" + sp.Value ;
                            continue;
                        }
                    }
                }
            }


            QuerySql = "select tab3.* , null as cf_prod_dbid ,null as pu_prod_dbid, " +
        "(select top 1 cust_id from viat_app_hp_contract_cust c where c.hpcont_dbid= tab3.hpcont_dbid order by created_date desc ) as cust_id," +
        "(select top 1 cust_name from viat_app_hp_contract_cust c where c.hpcont_dbid= tab3.hpcont_dbid order by created_date desc ) as cust_name," +
        "(select substring(prod_id,0,len(prod_id)) prod_id from (select (select CONVERT(NVARCHAR, prod_id)+' , ' from (" +
        "select  prod.prod_id from  viat_app_hp_contract_free_prod f_prod left join viat_com_prod prod on f_prod.prod_dbid=prod.prod_dbid and  f_prod.hpcont_dbid =  tab3.hpcont_dbid " +
        ") a FOR XML PATH ('') ) prod_id) c) as prod_id," +
        "(select substring(prod_ename,0,len(prod_ename)) prod_name from (select (select CONVERT(NVARCHAR, prod_ename)+' , ' from ( " +
        "select  prod.prod_ename from  viat_app_hp_contract_free_prod f_prod left join viat_com_prod prod on f_prod.prod_dbid=prod.prod_dbid  and  f_prod.hpcont_dbid =  tab3.hpcont_dbid " +
        ") a FOR XML PATH ('') ) prod_ename) c) as prod_ename " +
        "from ( " +
        "SELECT tab.*,tab1.cust_dbid,tab2.prod_dbid from ( " +
        "select  hp_contract.* ,c_a_sum1.A1 as C1,c_a_sum2.A1 AS C2,c_a_sum3.A1 AS C3,c_p_group.group_id ,c_p_group.group_name as group_name,case when c_p_group.group_id is null then '1' else '0' end costomer_type " +
        "from  viat_app_hp_contract hp_contract " +
        "LEFT OUTER JOIN( select hpcont_dbid as K1, sum(amount) as A1  from viat_app_hp_contract_allw_sum as allw_sum " +
        "where hpcont_dbid is not null  and action_type='1' and trans_date<=SysDateTime ( ) group  by hpcont_dbid) as  c_a_sum1 on c_a_sum1.K1 = hp_contract.hpcont_dbid " +
        "left outer join (select  hpcont_dbid as K1, sum(amount) as A1 	from  viat_app_hp_contract_allw_sum c_a_sum  " +
        "where hpcont_dbid is not null  and action_type='2' group  by hpcont_dbid ) as c_a_sum2 on c_a_sum2.K1 = hp_contract.hpcont_dbid " +
        "left outer join (select  hpcont_dbid as K1, sum(amount) as A1 from  viat_app_hp_contract_allw_sum c_a_sum  " +
        "where hpcont_dbid is not null  and action_type='3' group  by hpcont_dbid ) as c_a_sum3 on c_a_sum3.K1 = hp_contract.hpcont_dbid " +
        "left outer join viat_app_cust_price_group c_p_group on c_p_group.pricegroup_dbid = hp_contract.pricegroup_dbid " +
        innerCust +
        " where 1=1  " +
        contractNo +
        startDate +
        endDate +
        groupDbid +
        custDbid +
        cpProdDbid +
        cfProdDbid +
        status +
        " ) tab outer apply ( " +
        "select top 1 h_c_cust.cust_dbid as cust_dbid  " +
        "from  viat_app_hp_contract_cust h_c_cust " +
        "inner join viat_com_cust cust on cust.cust_dbid = h_c_cust.cust_dbid " +
        "where   h_c_cust.status = 'Y'  and cust.status='Y' and h_c_cust.hpcont_dbid=tab.hpcont_dbid " +
        ")tab1 outer apply( " +
        "select  top 1 c_f_prod.prod_dbid as prod_dbid from viat_app_hp_contract_free_prod  c_f_prod where c_f_prod.hpcont_dbid = tab.hpcont_dbid )tab2 " +
        ") tab3 " +
        "left outer join viat_com_cust c_cust on c_cust.cust_dbid=tab3.cust_dbid " +
        "left outer join viat_com_prod c_prod on c_prod.prod_dbid = tab3.prod_dbid ";
       

            return base.GetPageData(options);
        }

        public string getContractNo()
        {
            string rule = "A" + $"{DateTime.Now.GetHashCode()}";
            return rule.Substring(0, 10);
        }
        //新增
        public override WebResponseContent Add(SaveModel saveModel)
        {
            #region 看不懂逻辑，废弃

            /*
             * 如果表头是Isgroup,则把组内的用户，同时增加到viat_app_hp_contract_cust表中
             *思路：根据pricegroup_dbid关联出用户，根据信息生成cust类，用框架表头表体事务插入
             */
            //AddOnExecute = (saveModel) => {

            //    //指定操作类型为新增
            //    //saveModel.mainOptionType = SaveModel.MainOptionType.add;
            //    //如果是视图，则要替换maindata
            //    //saveModel.MainFacType = typeof(Viat_app_hp_contract);

            //    //新增保存时，给合约号赋值
            //    //string code = getContractNo();
            //    //saveModel.MainData["contract_no"] = code;
            //    //Guid hpcont_dbid = Guid.NewGuid();
            //    //saveModel.MainData.Add("hpcont_dbid", hpcont_dbid);

            //    if (saveModel.MainData.GetValue("costomer_type")?.ToString() == "0")
            //    {
            //        //isgroup为1时，则pricegroup
            //        //string sPriceGroupDBID = saveModel.MainData.GetValue("pricegroup_dbid")?.ToString();
            //       /* string sSql = @"select distinct b.* from viat_app_cust_group  a left join viat_com_cust b on a.cust_dbid=b.cust_dbid 
            //                where a.pricegroup_dbid=@pricegroup_dbid";*/
            //        //根据pricegroupid获取用户信息列表
            //      //  List<Viat_com_cust> lstCust = repository.DapperContext.QueryList<Viat_com_cust>(sSql, new { pricegroup_dbid = sPriceGroupDBID });
            //        //List<Viat_com_cust> lstCust = Viat_com_custService.Instance.GetCustListByPriceGroupDBID(sPriceGroupDBID);
            //        //List<Dictionary<string, object>> dicLst = new List<Dictionary<string, object>>();
            //        //SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();

            //        //detailDataResult.detailType = typeof(Viat_app_hp_contract_cust);
            //        //foreach (Viat_com_cust cust in lstCust)
            //        //{
            //        //    //把用户信息转化实体
            //        //    Dictionary<string, object> dic = new Dictionary<string, object>();
            //        //    dic.Add("cust_dbid", cust.cust_dbid);
            //        //    //dic.Add("hpcont_dbid", hpcont_dbid);
            //        //    //dic.Add("hpcontcust_dbid", Guid.NewGuid());
            //        //    dicLst.Add(dic);
            //        //}          
            //        //detailDataResult.DetailData = dicLst;

            //        //saveModel.DetailListData.Add(detailDataResult);

            //    }

            //    return webResponse.OK();

            //};

            ////多表体处理
            //dataProcess(saveModel);

            //return base.Add(saveModel);
            #endregion

            processHpContract(saveModel);

            return base.CustomBatchProcessEntity(saveModel);
        }
        //更新
        public override WebResponseContent Update(SaveModel saveModel)
        {
            //UpdateOnExecute = (saveModel) =>
            //{
            //    //指定表头真实有类型
            //    saveModel.MainFacType = typeof(Viat_app_hp_contract);
            //    saveModel.mainOptionType = SaveModel.MainOptionType.update;
            //    return webResponse.OK();
            //};

            //多表体处理
            //dataProcess(saveModel);
            processHpContract(saveModel);
            return base.CustomBatchProcessEntity(saveModel);
        }

        /// <summary>
        /// save -> Viat_app_hp_contract
        /// </summary>
        /// <param name="saveModel"></param>
        public void processHpContract(SaveModel saveModel)
        {
            SaveModel.DetailListDataResult countResult = new SaveModel.DetailListDataResult();
            string hpcount_dbid = "";
            if (!saveModel.MainData.ContainsKey("hpcont_dbid"))
            {
                saveModel.MainData.Add("hpcont_dbid", "");
            }
            hpcount_dbid = saveModel.MainData["hpcont_dbid"]?.ToString();
            if (string.IsNullOrEmpty(hpcount_dbid))
            {
                countResult.optionType = SaveModel.MainOptionType.add;
                saveModel.MainData["hpcont_dbid"] = Guid.NewGuid().ToString();
            }
            else
            {
                countResult.optionType = SaveModel.MainOptionType.update;
            }
            countResult.detailType = typeof(Viat_app_hp_contract);
            //增加表头处理
            countResult.DetailData.Add(saveModel.MainData);
            saveModel.DetailListData.Add(countResult);
            Viat_app_hp_contract contractEntry = JsonConvert.DeserializeObject<Viat_app_hp_contract>(JsonConvert.SerializeObject(saveModel.MainData));
            //处理子表
            ProcessCustOrProd(saveModel, contractEntry);
        }

        /// <summary>
        /// conduct -> Viat_app_hp_contract -> Viat_app_hp_contract
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="HpContrant"></param>
        public void ProcessCustOrProd(SaveModel saveModel, Viat_app_hp_contract HpContrant)
        {
            if (saveModel.DetailData != null && saveModel.DetailData.Count > 0)
            {
                foreach (Dictionary<string, object> dic in saveModel.DetailData)
                {
                    Dictionary<string, object> dicTmp = dic;
                    switch (dicTmp["key"]?.ToString())
                    {
                        case "table1RowData":
                        case "delTable1RowData":
                            ProcessCust(saveModel, HpContrant, dicTmp["value"]?.ToString());
                            break;
                        case "table2RowData":
                        case "delTable2RowData":
                            ProcessProd(saveModel, HpContrant, dicTmp["value"]?.ToString());
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// option -> Viat_app_hp_contract_cust
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="HpContrant"></param>
        /// <param name="s_cust"></param>
        public void ProcessCust(SaveModel saveModel, Viat_app_hp_contract HpContrant,string s_cust)
        {
            if (!string.IsNullOrEmpty(s_cust))
            {
                List<Viat_app_hp_contract_cust> lstCust = JsonConvert.DeserializeObject<List<Viat_app_hp_contract_cust>>(s_cust);
                foreach (var item in lstCust)
                {
                    SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
                    if (item.hpcontcust_dbid == null || item.hpcontcust_dbid.ToString() == getDefaultGuid(typeof(Viat_app_hp_contract_cust)))
                    {
                        custResult.optionType = SaveModel.MainOptionType.add;
                        item.hpcontcust_dbid = Guid.NewGuid();
                        item.hpcont_dbid = HpContrant.hpcont_dbid;
                        item.status = "Y";
                    }
                    else
                    {
                        custResult.optionType = SaveModel.MainOptionType.delete;
                    }
                    custResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    custResult.detailType = typeof(Viat_app_hp_contract_cust);
                    saveModel.DetailListData.Add(custResult);
                }
            }
        }

        /// <summary>
        /// option -> Viat_app_hp_contract_free_prod
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="HpContrant"></param>
        /// <param name="s_prod"></param>
        public void ProcessProd(SaveModel saveModel, Viat_app_hp_contract HpContrant, string s_prod)
        {
            if (!string.IsNullOrEmpty(s_prod))
            {
                List<Viat_app_hp_contract_free_prod> lstCust = JsonConvert.DeserializeObject<List<Viat_app_hp_contract_free_prod>>(s_prod);
                foreach (var item in lstCust)
                {
                    SaveModel.DetailListDataResult prodResult = new SaveModel.DetailListDataResult();
                    if (item.hpcontfreeprod_dbid == null || item.hpcontfreeprod_dbid.ToString() == getDefaultGuid(typeof(Viat_app_hp_contract_free_prod)))
                    {
                        prodResult.optionType = SaveModel.MainOptionType.add;
                        item.hpcontfreeprod_dbid = Guid.NewGuid();
                        item.hpcont_dbid = HpContrant.hpcont_dbid;
                    }
                    else
                    {
                        prodResult.optionType = SaveModel.MainOptionType.delete;
                    }
                    prodResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    prodResult.detailType = typeof(Viat_app_hp_contract_free_prod);
                    saveModel.DetailListData.Add(prodResult);
                }
            }
        }
        #region 废弃
        //private WebResponseContent dataProcess(SaveModel saveModel)
        //{

        //    /*多表处理时，自定义处理表体的addlist,editlidt,delKeys*/
        //    UpdateMoreDetails = (saveModel) =>
        //    {
        //        //isgroup与iscust二选择一
        //        if (saveModel.MainData.GetValue("costomer_type")?.ToString() == "0")
        //        {
        //            saveModel.MainData["cust_dbid"] = "";
        //        }
        //        else if (saveModel.MainData.GetValue("costomer_type")?.ToString() == "1")
        //        {
        //            saveModel.MainData["pricegroup_dbid"] = "";
        //        }

        //        if (saveModel.DetailData != null && saveModel.DetailData.Count > 0)
        //        {
        //            saveModel.DetailListData = new List<SaveModel.DetailListDataResult>();
        //            foreach (Dictionary<string, object> dic in saveModel.DetailData)
        //            {

        //                Dictionary<string, object> dicTmp = dic;
        //                if (dicTmp["key"]?.ToString() == "table1RowData")
        //                {
        //                    //合約客戶List
        //                    string cusDic = dicTmp["value"]?.ToString();
        //                    //取得所有
        //                    if (string.IsNullOrEmpty(cusDic) == false)
        //                    {

        //                        SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
        //                        detailDataResult.detailType = typeof(Viat_app_hp_contract_cust);


        //                        //计算表体和实体的值
        //                        List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, cusDic);

        //                        detailDataResult.DetailData = entityDic;
        //                        saveModel.DetailListData.Add(detailDataResult);
        //                    }

        //                }
        //                else if (dicTmp["key"]?.ToString() == "table2RowData")
        //                // 合約產品List   
        //                {
        //                    //合約客戶List
        //                    Dictionary<string, object> dicTmpPro = dic;
        //                    if (dicTmp["key"]?.ToString() == "table2RowData")
        //                    {
        //                        //合約客戶List
        //                        string proDic = dicTmp["value"]?.ToString();
        //                        //取得所有
        //                        if (string.IsNullOrEmpty(proDic) == false)
        //                        {

        //                            SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
        //                            detailDataResult.detailType = typeof(Viat_app_hp_contract_free_prod);


        //                            //计算表体和实体的值
        //                            List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, proDic);

        //                            detailDataResult.DetailData = entityDic;
        //                            saveModel.DetailListData.Add(detailDataResult);
        //                        }

        //                    }
        //                }
        //                //删除操作
        //                else if (dicTmp["key"]?.ToString() == "delTable1RowData")
        //                {
        //                    //合約贈送產品List      

        //                    //合約客戶List
        //                    string cusDic = dicTmp["value"]?.ToString();
        //                    //取得所有
        //                    if (string.IsNullOrEmpty(cusDic) == false)
        //                    {

        //                        SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
        //                        detailDataResult.detailType = typeof(Viat_app_hp_contract_cust);

        //                        //计算表体和实体的值
        //                        List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, cusDic);
        //                        foreach (Dictionary<string, object> entiry in entityDic)
        //                        {
        //                            detailDataResult.detailDelKeys.Add(entiry.GetValue("hpcontcust_dbid"));
        //                        }

        //                        saveModel.DetailListData.Add(detailDataResult);
        //                    }

        //                }
        //                else if (dicTmp["key"]?.ToString() == "delTable2RowData")
        //                {
        //                    //合約贈送產品List      
        //                    if (dicTmp["key"]?.ToString() == "delTable2RowData")
        //                    {
        //                        //合約客戶List
        //                        string cusDic = dicTmp["value"]?.ToString();
        //                        //取得所有
        //                        if (string.IsNullOrEmpty(cusDic) == false)
        //                        {
        //                            SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
        //                            detailDataResult.detailType = typeof(Viat_app_hp_contract_free_prod);

        //                            //计算表体和实体的值
        //                            List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, cusDic);
        //                            foreach (Dictionary<string, object> entiry in entityDic)
        //                            {
        //                                detailDataResult.detailDelKeys.Add(entiry.GetValue("hpcontfreeprod_dbid"));
        //                            }
        //                            saveModel.DetailListData.Add(detailDataResult);
        //                        }

        //                    }
        //                }

        //            };

        //        }
        //        return base.CustomUpdateToEntityForDetails(saveModel);

        //    };

        //    return webResponse.OK();
        //}
        #endregion

    }
}
