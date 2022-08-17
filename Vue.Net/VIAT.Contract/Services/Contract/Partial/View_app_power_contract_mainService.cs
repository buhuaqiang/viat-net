/*
 *所有关于View_app_power_contract_main类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_app_power_contract_mainService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System.Collections.Generic;
using System;
using VIAT.Contract.Repositories;
using Newtonsoft.Json;
using System.Threading.Tasks;
using VIAT.Basic.Services;
using System.Reflection;

namespace VIAT.Contract.Services
{
    public partial class View_app_power_contract_mainService
    { 
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_app_power_contract_mainRepository _repository;//访问数据库
        private readonly IViat_app_power_contractRepository _viat_App_Power_ContractRepository;
        [ActivatorUtilitiesConstructor]
        public View_app_power_contract_mainService(
            IView_app_power_contract_mainRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_power_contractRepository viat_App_Power_ContractRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_App_Power_ContractRepository = viat_App_Power_ContractRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        public override WebResponseContent Add(SaveModel saveModel)
        {
            /*
             * 如果表头是Isgroup,则把组内的用户，同时增加到viat_app_power_contract_cust表中
             *思路：根据pricegroup_dbid关联出用户，根据信息生成cust类，用框架表头表体事务插入
             */
//            AddOnExecute = (saveModel) =>
//            {
//                //指定操作类型为新增
//                saveModel.mainOptionType = SaveModel.MainOptionType.add;
//                //如果是视图，则要替换maindata
//                saveModel.MainFacType = typeof(Viat_app_power_contract);

//                //新增保存时，给合约号赋值
//                //string code = ;
//                saveModel.MainData["contract_no"] = getContractNo();

//                //isgroup与iscust二选择一
//                /*if (saveModel.MainData.GetValue("isgroup")?.ToString() == "1")
//                {
//                    saveModel.MainData["cust_dbid"] = "";
//                }
//                else if (saveModel.MainData.GetValue("isgroup")?.ToString() == "0")
//                {
//                    saveModel.MainData["pricegroup_dbid"] = "";
//                }
//*/
//                if (saveModel.MainData.GetValue("isgroup")?.ToString() == "1")
//                {
//                    //isgroup为1时，则pricegroup
//                    string sPriceGroupDBID = saveModel.MainData.GetValue("pricegroup_dbid")?.ToString();
//                    /*
//                                        string sSql = @"select distinct b.* from viat_app_cust_group  a left join viat_com_cust b on a.cust_dbid=b.cust_dbid 
//                                                where a.pricegroup_dbid=@pricegroup_dbid";*/
//                    // repository.DapperContext.QueryList<Viat_com_cust>(sSql, new { pricegroup_dbid = sPriceGroupDBID });
//                    //根据pricegroupid获取用户信息列表
//                    List<Viat_com_cust> lstCust = Viat_com_custService.Instance.GetCustListByPriceGroupDBID(sPriceGroupDBID);
//                    List<Dictionary<string, object>> dicLst = new List<Dictionary<string, object>>();
//                    SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();

//                    detailDataResult.detailType = typeof(Viat_app_power_contract_cust);
//                    foreach (Viat_com_cust cust in lstCust)
//                    {
//                        //把用户信息转化实体
//                        Dictionary<string, object> dic = new Dictionary<string, object>();
//                        dic.Add("cust_dbid", cust.cust_dbid);
//                        dicLst.Add(dic);
//                    }
//                    detailDataResult.DetailData = dicLst;

//                    saveModel.DetailListData.Add(detailDataResult);

//                }

//                return webResponse.OK();

//            };

//            //处理表体
//            dataProcess(saveModel);


//            return base.Add(saveModel);

            processHpContract(saveModel);
            return base.CustomBatchProcessEntity(saveModel);
        }


        public string getContractNo()
        {
            string rule = "C" + $"D{DateTime.Now.GetHashCode()}";
            return rule.Substring(0, 10);
        }


        WebResponseContent webResponse = new WebResponseContent();
        public override WebResponseContent Update(SaveModel saveModel)
        {
            //UpdateOnExecute = (saveModel) =>
            // {
            //     //指定表头真实有类型
            //     saveModel.MainFacType = typeof(Viat_app_power_contract);
            //     saveModel.mainOptionType = SaveModel.MainOptionType.update;
            //     return webResponse.OK();
            // };

            //dataProcess(saveModel);


            //return base.Update(saveModel);
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
            if (!saveModel.MainData.ContainsKey("powercont_dbid"))
            {
                saveModel.MainData.Add("powercont_dbid", "");
            }
            if (!saveModel.MainData.ContainsKey("contract_no"))
            {
                saveModel.MainData.Add("contract_no", "");
            }
            hpcount_dbid = saveModel.MainData["powercont_dbid"]?.ToString();
            if (string.IsNullOrEmpty(hpcount_dbid))
            {
                countResult.optionType = SaveModel.MainOptionType.add;
                saveModel.MainData["powercont_dbid"] = Guid.NewGuid().ToString();
                saveModel.MainData["contract_no"] = getContractNo();
            }
            else
            {
                countResult.optionType = SaveModel.MainOptionType.update;
            }
            countResult.detailType = typeof(Viat_app_power_contract);
            if (saveModel.MainData.GetValue("isgroup")?.ToString() == "1")
            {
                saveModel.MainData["cust_dbid"] = "";
                //isgroup为1时，则pricegroup
                string sPriceGroupDBID = saveModel.MainData.GetValue("pricegroup_dbid")?.ToString();
                //根据pricegroupid获取用户信息列表
                List<Viat_com_cust> lstCust = Viat_com_custService.Instance.GetCustListByPriceGroupDBID(sPriceGroupDBID);
                List<Dictionary<string, object>> dicLst = new List<Dictionary<string, object>>();
                SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();

                detailDataResult.detailType = typeof(Viat_app_power_contract_cust);
                foreach (Viat_com_cust cust in lstCust)
                {
                    //把用户信息转化实体
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("cust_dbid", cust.cust_dbid);
                    dicLst.Add(dic);
                }
                detailDataResult.DetailData = dicLst;

                saveModel.DetailListData.Add(detailDataResult);
            }
            else if (saveModel.MainData.GetValue("isgroup")?.ToString() == "0")
            {
                saveModel.MainData["pricegroup_dbid"] = "";
            }
            //增加表头处理
            countResult.DetailData.Add(saveModel.MainData);
            saveModel.DetailListData.Add(countResult);

            Viat_app_power_contract contractEntry = JsonConvert.DeserializeObject<Viat_app_power_contract>(JsonConvert.SerializeObject(saveModel.MainData));
            //处理子表
            ProcessCustOrProd(saveModel, contractEntry);
        }

        /// <summary>
        /// conduct -> Viat_app_hp_contract -> Viat_app_hp_contract
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="HpContrant"></param>
        public void ProcessCustOrProd(SaveModel saveModel, Viat_app_power_contract PowerContrant)
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
                            //List<Viat_app_power_contract> c = new List<Viat_app_power_contract>();
                            //Cwsdh(saveModel, c, dicTmp["value"]?.ToString());
                            ProcessCust(saveModel, PowerContrant, dicTmp["value"]?.ToString(), dicTmp["key"]?.ToString());
                            break;
                        case "table2RowData":
                        case "delTable2RowData":
                            ProcessProd(saveModel, PowerContrant, dicTmp["value"]?.ToString(), dicTmp["key"]?.ToString());
                            break;
                        case "table3RowData":
                        case "delTable3RowData":
                            ProcessFreeProd(saveModel, PowerContrant, dicTmp["value"]?.ToString(), dicTmp["key"]?.ToString());
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void Cwsdh<T>(SaveModel saveModel, List<T> PowerContrant, string s_cust) where T : new()
        {
            PowerContrant = JsonConvert.DeserializeObject<List<T>>(s_cust);
            string tempName = "";
            foreach (var item in PowerContrant)
            {
                T t = new T();
                // 获得此模型的公共属性      
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;  // 检查DataTable是否包含此列    
                }    
                //if (item. == null || item.powercontcust_dbid.ToString() == getDefaultGuid(typeof(Viat_app_power_contract_cust)))
            }
        }

        /// <summary>
        /// option -> Viat_app_power_contract_cust
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="HpContrant"></param>
        /// <param name="s_cust"></param>
        public void ProcessCust(SaveModel saveModel, Viat_app_power_contract PowerContrant, string s_cust,string key)
        {
            if (!string.IsNullOrEmpty(s_cust))
            {
                List<Viat_app_power_contract_cust> lstCust = JsonConvert.DeserializeObject<List<Viat_app_power_contract_cust>>(s_cust);
                foreach (var item in lstCust)
                {
                    SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
                    if (key.Equal("table1RowData"))
                    {
                        if (item.powercontcust_dbid != new Guid())
                        {
                            continue;
                        }
                        custResult.optionType = SaveModel.MainOptionType.add;
                        item.powercontcust_dbid = Guid.NewGuid();
                        item.powercont_dbid = PowerContrant.powercont_dbid;
                    }
                    else
                    {
                        custResult.optionType = SaveModel.MainOptionType.delete;
                    }
                    custResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    custResult.detailType = typeof(Viat_app_power_contract_cust);
                    saveModel.DetailListData.Add(custResult);
                }
            }
        }

        /// <summary>
        /// option -> Viat_app_power_contract_purchase_prod
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="HpContrant"></param>
        /// <param name="s_prod"></param>
        public void ProcessProd(SaveModel saveModel, Viat_app_power_contract HpContrant, string s_prod,string key)
        {
            if (!string.IsNullOrEmpty(s_prod))
            {
                List<Viat_app_power_contract_purchase_prod> lstCust = JsonConvert.DeserializeObject<List<Viat_app_power_contract_purchase_prod>>(s_prod);
                foreach (var item in lstCust)
                {
                    SaveModel.DetailListDataResult prodResult = new SaveModel.DetailListDataResult();
                    if (key.Equal("table2RowData"))
                    {
                        if (item.powercontpurprod_dbid != new Guid())
                        {
                            continue;
                        }
                        prodResult.optionType = SaveModel.MainOptionType.add;
                        item.powercontpurprod_dbid = Guid.NewGuid();
                        item.powercont_dbid = HpContrant.powercont_dbid;
                    }
                    else
                    {
                        prodResult.optionType = SaveModel.MainOptionType.delete;
                    }
                    prodResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    prodResult.detailType = typeof(Viat_app_power_contract_purchase_prod);
                    saveModel.DetailListData.Add(prodResult);
                }
            }
        }
        public void ProcessFreeProd(SaveModel saveModel, Viat_app_power_contract HpContrant, string s_freeprod, string key)
        {
            if (!string.IsNullOrEmpty(s_freeprod))
            {
                List<Viat_app_power_contract_free_prod> lstCust = JsonConvert.DeserializeObject<List<Viat_app_power_contract_free_prod>>(s_freeprod);
                foreach (var item in lstCust)
                {
                    SaveModel.DetailListDataResult prodResult = new SaveModel.DetailListDataResult();
                    if (key.Equal("table3RowData"))
                    {
                        if (item.powercontfreeprod_dbid != new Guid())
                        {
                            continue;
                        }
                        prodResult.optionType = SaveModel.MainOptionType.add;
                        item.powercontfreeprod_dbid = Guid.NewGuid();
                        item.powercont_dbid = HpContrant.powercont_dbid;
                    }
                    else
                    {
                        prodResult.optionType = SaveModel.MainOptionType.delete;
                    }
                    prodResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    prodResult.detailType = typeof(Viat_app_power_contract_free_prod);
                    saveModel.DetailListData.Add(prodResult);
                }
            }
        }


        /// <summary>
        /// 新增，修改，同一方法操作保存
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        private WebResponseContent dataProcess(SaveModel saveModel)
        {
            /*多表处理时，自定义处理表体的addlist,editlidt,delKeys*/
            UpdateMoreDetails = (saveModel) =>
            {
               

                //isgroup与iscust二选择一
                if (saveModel.MainData.GetValue("isgroup")?.ToString() == "1")
                {
                    saveModel.MainData["cust_dbid"] = "";
                }
                else if (saveModel.MainData.GetValue("isgroup")?.ToString() == "0")
                {
                    saveModel.MainData["pricegroup_dbid"] = "";
                }


                if (saveModel.DetailData != null && saveModel.DetailData.Count > 0)
                {
                    saveModel.DetailListData = new List<SaveModel.DetailListDataResult>();
                    foreach (Dictionary<string, object> dic in saveModel.DetailData)
                    {

                        Dictionary<string, object> dicTmp = dic;
                        if (dicTmp["key"]?.ToString() == "table1RowData")
                        {
                            //合約客戶List
                            string cusDic = dicTmp["value"]?.ToString();
                            //取得所有
                            if (string.IsNullOrEmpty(cusDic) == false)
                            {

                                SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
                                detailDataResult.detailType = typeof(Viat_app_power_contract_cust);


                                //计算表体和实体的值
                                List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, cusDic);
                                
                                detailDataResult.DetailData = entityDic;
                                saveModel.DetailListData.Add(detailDataResult);
                            }

                        }
                        else if (dicTmp["key"]?.ToString() == "table2RowData")
                        // 合約產品List   
                        {
                            //合約客戶List
                            Dictionary<string, object> dicTmpPro = dic;
                            if (dicTmp["key"]?.ToString() == "table2RowData")
                            {
                                //合約客戶List
                                string proDic = dicTmp["value"]?.ToString();
                                //取得所有
                                if (string.IsNullOrEmpty(proDic) == false)
                                {

                                    SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
                                    detailDataResult.detailType = typeof(Viat_app_power_contract_purchase_prod);
                                    //计算表体和实体的值
                                    List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, proDic);
                                    detailDataResult.DetailData = entityDic;
                                    saveModel.DetailListData.Add(detailDataResult);
                                }

                            }
                        }

                        else if (dicTmp["key"]?.ToString() == "table3RowData")
                        {
                            //合約贈送產品List
                            Dictionary<string, object> dicTmpPro = dic;
                            if (dicTmp["key"]?.ToString() == "table3RowData")
                            {
                                //合約客戶List
                                string proDic = dicTmp["value"]?.ToString();
                                //取得所有
                                if (string.IsNullOrEmpty(proDic) == false)
                                {

                                    SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
                                    detailDataResult.detailType = typeof(Viat_app_power_contract_free_prod);
                                    //计算表体和实体的值
                                    List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, proDic);
                                    detailDataResult.DetailData = entityDic;
                                    saveModel.DetailListData.Add(detailDataResult);
                                }

                            }
                        }
                        //删除操作
                        else if (dicTmp["key"]?.ToString() == "delTable1RowData")
                        {
                            //合約贈送產品List      

                            //合約客戶List
                            string cusDic = dicTmp["value"]?.ToString();
                            //取得所有
                            if (string.IsNullOrEmpty(cusDic) == false)
                            {

                                SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
                                detailDataResult.detailType = typeof(Viat_app_power_contract_cust);
                                //计算表体和实体的值
                                List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, cusDic);
                                foreach (Dictionary<string, object> entiry in entityDic)
                                {
                                    detailDataResult.detailDelKeys.Add(entiry.GetValue("powercontcust_dbid"));
                                }

                                saveModel.DetailListData.Add(detailDataResult);
                            }

                        }
                        else if (dicTmp["key"]?.ToString() == "delTable2RowData")
                        {
                            //合約贈送產品List      
                            if (dicTmp["key"]?.ToString() == "delTable2RowData")
                            {
                                //合約客戶List
                                string cusDic = dicTmp["value"]?.ToString();
                                //取得所有
                                if (string.IsNullOrEmpty(cusDic) == false)
                                {
                                    SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
                                    detailDataResult.detailType = typeof(Viat_app_power_contract_purchase_prod);

                                    //计算表体和实体的值
                                    List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, cusDic);
                                    foreach (Dictionary<string, object> entiry in entityDic)
                                    {
                                        detailDataResult.detailDelKeys.Add(entiry.GetValue("powercontpurprod_dbid"));
                                    }
                                    saveModel.DetailListData.Add(detailDataResult);
                                }

                            }
                        }
                        else if (dicTmp["key"]?.ToString() == "delTable3RowData")
                        {
                            //合約贈送產品List      
                            if (dicTmp["key"]?.ToString() == "delTable3RowData")
                            {
                                //合約客戶List
                                string cusDic = dicTmp["value"]?.ToString();
                                //取得所有
                                if (string.IsNullOrEmpty(cusDic) == false)
                                {
                                    SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();
                                    detailDataResult.detailType = typeof(Viat_app_power_contract_free_prod);

                                    //计算表体和实体的值
                                    List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, cusDic);
                                    foreach (Dictionary<string, object> entiry in entityDic)
                                    {
                                        detailDataResult.detailDelKeys.Add(entiry.GetValue("powercontfreeprod_dbid"));
                                    }
                                    saveModel.DetailListData.Add(detailDataResult);
                                }

                            }
                        }

                    };

                }
                return base.CustomUpdateToEntityForDetails(saveModel);

            };

            return webResponse.OK();
        }
        public override PageGridData<View_app_power_contract_main> GetPageData(PageDataOptions options)
        {
            /*解析查询条件*/
            QuerySql = "select * from view_app_power_contract_main ";
            return base.GetPageData(options);
        }

        /// <summary>
        /// 查询业务代码编写(从表(明细表查询))
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        public override object GetDetailPage(PageDataOptions pageData)
        {
            //自定义查询胆细表

            ////明细表自定义查询方式一：EF
            //var query = SellOrderListRepository.Instance.IQueryablePage<SellOrderList>(
            //     pageData.Page,
            //     pageData.Rows,
            //     out int count,
            //     x => x.Order_Id == pageData.Value.GetGuid(),
            //      orderBy: x => new Dictionary<object, QueryOrderBy>() { { x.CreateDate, QueryOrderBy.Desc } }
            //    );
            PageGridData<Viat_app_power_contract_cust> detailGrid = new PageGridData<Viat_app_power_contract_cust>();


            ////明细表自定义查询方式二：dapper
            string sql = "select count(1) from Viat_app_power_contract_cust where powercont_dbid=@powercont_dbid";
            detailGrid.total = repository.DapperContext.ExecuteScalar(sql, new { powercont_dbid = pageData.Value }).GetInt();

            sql = @$"select * from (
 
                select  a.*,b.cust_id,b.cust_name,b.territory_id ,ROW_NUMBER()over(order by a.created_date desc) as rowId 
                from Viat_app_power_contract_cust a, viat_com_cust b where a.cust_dbid=b.cust_dbid  and a.powercont_dbid=@powercont_dbid
                    ) as s where s.rowId between {((pageData.Page - 1) * pageData.Rows + 1)} and {pageData.Page * pageData.Rows} ";
            detailGrid.rows = repository.DapperContext.QueryList<Viat_app_power_contract_cust>(sql, new { powercont_dbid = pageData.Value });

            return detailGrid;

            //return base.GetDetailPage(pageData);
        }

        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            DelOnExecuting = (keys) =>
             {
                 List<string> sSqlLst = new List<string>();

                 for (int i = 0; i < keys.Length; i++)
                 {
                     string sContractDeleteSql = "delete from  viat_app_power_contract  where powercont_dbid='" + keys[i].ToString() + "'";
                     string sCustDeleteSql = "delete from  viat_app_power_contract_cust  where powercont_dbid='" + keys[i].ToString() + "'";
                     string sPurchaseDeleteSql = "delete from  viat_app_power_contract_purchase_prod   where powercont_dbid='" + keys[i].ToString() + "'";
                     string sFreeDeleteSql = "delete from  viat_app_power_contract_free_prod where powercont_dbid='" + keys[i].ToString() + "'";

                     sSqlLst.Add(sContractDeleteSql);
                     sSqlLst.Add(sCustDeleteSql);
                     sSqlLst.Add(sPurchaseDeleteSql);
                     sSqlLst.Add(sFreeDeleteSql);
                 }

                 //直接自定义sql语句删除
                 return base.CustomExcuteBySql(sSqlLst,"delete success");
             };
            return base.Del(keys, delList);             
        }


        /// <summary>
        /// 批量更机新Contract_State，把状态为not close(Y)更新成Achieve(A)
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>

        public  WebResponseContent close(string[] ids)
        {
          
            List<string> sSqlLst = new List<string>();
            
            for(int i=0; i<ids.Length; i++)
            {
                string sSql = "update viat_app_power_contract set state='A',close_date=GETDATE() where powercont_dbid='" + ids[i].ToString() + "' and state='Y'";
                sSqlLst.Add(sSql);
            }         
           
            return base.CustomExcuteBySql(sSqlLst,"Close Success。");
        }

    }
}
