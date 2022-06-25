/*
 *所有关于View_app_power_contract_main类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_app_power_contract_mainService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;
using System.Linq;
using VOL.Core.Utilities;
using System.Linq.Expressions;
using VOL.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Contract.IRepositories;
using System.Collections.Generic;
using System;
using VIAT.Contract.Repositories;
using Newtonsoft.Json;

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

            AddOnExecuting = (View_app_power_contract_main view_App_Power, object list) =>
            {
                //如果设置code=-1会强制返回，不再继续后面的操作,2021.07.04更新LambdaExtensions文件后才可以使用此属性
                //webResponse.Code = "-1";
                // webResponse.Message = "测试强制返回";
                //return webResponse.OK();

                Viat_app_power_contract app_Power_Contract = new Viat_app_power_contract()
                {
                    powercont_dbid = Guid.NewGuid(),
                    accrue_amt = view_App_Power.allw_type,
                    close_date2 = view_App_Power.close_date2

                };

                _viat_App_Power_ContractRepository.Add(app_Power_Contract);

                List<Viat_app_power_contract_cust> orderLists = list as List<Viat_app_power_contract_cust>;
                //  orderLists
                foreach (var item in orderLists)
                {
                    item.powercont_dbid = app_Power_Contract.powercont_dbid;
                }
                if (orderLists.Count > 0)
                {
                    _viat_App_Power_ContractRepository.AddRange(orderLists);
                }

                _viat_App_Power_ContractRepository.SaveChanges();
                webResponse.Code = "-1";

                return webResponse.OK();
            };
            saveModel.DetailData = null;

            string code = getContractNo();
            saveModel.MainData["contract_no"] = code;

            //可以直接修改视图提交saveModel里面的字段信息
            return Viat_app_power_contractService.Instance.Add(saveModel);
            //return base.Update(saveModel);
        }


        public string getContractNo()
        {
            string rule = "C" + $"D{DateTime.Now.GetHashCode()}";
            return rule.Substring(0, 10);
        }


        WebResponseContent webResponse = new WebResponseContent();
        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecute = (saveModel) =>
             {
                 //指定表头真实有类型
                 saveModel.MainFacType = typeof(Viat_app_power_contract);
                 return webResponse.OK();
             };

            /*多表处理时，自定义处理表体的addlist,editlidt,delKeys*/
            UpdateMoreDetails = (saveModel) =>
            {
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

                                #region
                                //定义合约客户表体实体                            
                                // Newtonsoft.Json.Linq.JArray jarray = JsonConvert.DeserializeObject(cusDic) as Newtonsoft.Json.Linq.JArray;
                                //  List<Viat_app_power_contract_cust> bodyList = new List<Viat_app_power_contract_cust>();



                                /* for (int i = 0; i < jarray.Count; i++)
                                 {
                                     Dictionary<string, object> dcResult = new Dictionary<string, object>();

                                     string listdata = jarray[i].ToString();
                                     Object obj1 = JsonConvert.DeserializeObject(listdata);
                                     Newtonsoft.Json.Linq.JObject js1 = obj1 as Newtonsoft.Json.Linq.JObject;//把上面的obj转换为 Jobject对象

                                     foreach(var item in js1)
                                     {
                                         string s = item.Key;
                                         object d =item.Value;
                                     }

                                     dcResult.Add("powercont_dbid", new Guid(js1["powercont_dbid"].ToString()));
                                     dcResult.Add("cust_dbid", js1["cust_dbid"].ToString());
                                     dcResult.Add("cust_id", js1["cust_id"].ToString());
                                    // dcResult.Add("territory_id", js1["territory_id"].ToString());

                                     lst.Add(dcResult);
                                 }*/
                                #endregion
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

                      
                    };

                }
                return base.UpdateToEntityForDetails(saveModel);

            };

            return base.Update(saveModel);
        }

        #region
        /*UpdateOnExecuting = (View_app_power_contract_main view_App_Power, object addList, object updateList, List<object> delKeys) =>
        {

            Viat_app_power_contract app_Power_Contract = new Viat_app_power_contract()
            {
                powercont_dbid = view_App_Power.powercont_dbid,
                contract_no = view_App_Power.contract_no,
                contract_type = view_App_Power.contract_type,
                start_date = view_App_Power.start_date,
                end_date = view_App_Power.end_date,
                cust_dbid = view_App_Power.cust_dbid,
                pricegroup_dbid = view_App_Power.pricegroup_dbid,
                territory_id = view_App_Power.territory_id,
                allw_type = view_App_Power.allw_type,
                accrue_amt = view_App_Power.accrue_amt,
                contract_term = view_App_Power.contract_term,
                state = view_App_Power.state,
                close_date = view_App_Power.close_date,
                rate = view_App_Power.rate,
                total_fg_amount = view_App_Power.total_fg_amount

            };
            _viat_App_Power_ContractRepository.Update(app_Power_Contract, x => new
            { x.contract_no, x.contract_type, x.start_date, x.end_date, x.cust_dbid, x.pricegroup_dbid, x.territory_id, x.allw_type, x.accrue_amt, x.contract_term, x.state, x.close_date, x.rate, x.total_fg_amount });

             //  _viat_App_Power_ContractRepository.Update(app_Power_Contract);

             ////如果要手动设置某些字段的值,值不是前端提交的（代码生成器里面编辑行必须设置为0并生成model）,如Remark字段:
             ////注意必须设置上面saveModel.MainData.TryAdd("Remark", "1231")
             //order.Remark = "888";

             //新增的明细表
             List<Viat_app_power_contract_cust> add = addList as List<Viat_app_power_contract_cust>;
            _viat_App_Power_ContractRepository.AddRange(add);
             //修改的明细表
             List<Viat_app_power_contract_cust> update = updateList as List<Viat_app_power_contract_cust>;

            _viat_App_Power_ContractRepository.UpdateRange(update);

             //删除明细表Id
             //  var guids = delKeys?.Select(x => (Guid)x);
             if (delKeys.Count > 0)
            {
                Viat_app_power_contract_custRepository.Instance.DeleteWithKeys(delKeys.ToArray());
            }

            _viat_App_Power_ContractRepository.SaveChanges();
            webResponse.Code = "-1";
            return webResponse.OK("OK");
        }
*/
        //return base.Update(saveModel);
        #endregion

        public override PageGridData<View_app_power_contract_main> GetPageData(PageDataOptions options)
        {
            /*解析查询条件*/

            options.TableName = "Viat_app_power_contract_cust";
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
             Viat_app_power_contractService.Instance.Del(keys, delList);
            return webResponse.OK("OK");
        }
    }
}
