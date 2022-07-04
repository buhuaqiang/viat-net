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
            QuerySql = "select * from view_app_hp_contract ";
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
      
            /*
             * 如果表头是Isgroup,则把组内的用户，同时增加到viat_app_hp_contract_cust表中
             *思路：根据pricegroup_dbid关联出用户，根据信息生成cust类，用框架表头表体事务插入
             */
            AddOnExecute = (saveModel) => {

                //指定操作类型为新增
                saveModel.mainOptionType = SaveModel.MainOptionType.add;
                //如果是视图，则要替换maindata
                saveModel.MainFacType = typeof(Viat_app_hp_contract);

                //新增保存时，给合约号赋值
                string code = getContractNo();
                saveModel.MainData["contract_no"] = code;

                   

                if (saveModel.MainData.GetValue("costomer_type")?.ToString() == "0")
                {
                    //isgroup为1时，则pricegroup
                    string sPriceGroupDBID = saveModel.MainData.GetValue("pricegroup_dbid")?.ToString();
                   /* string sSql = @"select distinct b.* from viat_app_cust_group  a left join viat_com_cust b on a.cust_dbid=b.cust_dbid 
                            where a.pricegroup_dbid=@pricegroup_dbid";*/
                    //根据pricegroupid获取用户信息列表
                  //  List<Viat_com_cust> lstCust = repository.DapperContext.QueryList<Viat_com_cust>(sSql, new { pricegroup_dbid = sPriceGroupDBID });
                    List<Viat_com_cust> lstCust = Viat_com_custService.Instance.GetCustListByPriceGroupDBID(sPriceGroupDBID);
                    List<Dictionary<string, object>> dicLst = new List<Dictionary<string, object>>();
                    SaveModel.DetailListDataResult detailDataResult = new SaveModel.DetailListDataResult();

                    detailDataResult.detailType = typeof(Viat_app_hp_contract_cust);
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

                return webResponse.OK();

            };

            //多表体处理
            dataProcess(saveModel);

            return base.Add(saveModel);
 
        }
        //更新
        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecute = (saveModel) =>
            {
                //指定表头真实有类型
                saveModel.MainFacType = typeof(Viat_app_hp_contract);
                saveModel.mainOptionType = SaveModel.MainOptionType.update;
                return webResponse.OK();
            };

            //多表体处理
            dataProcess(saveModel);

            return base.Update(saveModel);
        }

        private WebResponseContent dataProcess(SaveModel saveModel)
        {

            /*多表处理时，自定义处理表体的addlist,editlidt,delKeys*/
            UpdateMoreDetails = (saveModel) =>
            {
                //isgroup与iscust二选择一
                if (saveModel.MainData.GetValue("costomer_type")?.ToString() == "0")
                {
                    saveModel.MainData["cust_dbid"] = "";
                }
                else if (saveModel.MainData.GetValue("costomer_type")?.ToString() == "1")
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
                                detailDataResult.detailType = typeof(Viat_app_hp_contract_cust);


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
                                    detailDataResult.detailType = typeof(Viat_app_hp_contract_free_prod);


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
                                detailDataResult.detailType = typeof(Viat_app_hp_contract_cust);

                                //计算表体和实体的值
                                List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, cusDic);
                                foreach (Dictionary<string, object> entiry in entityDic)
                                {
                                    detailDataResult.detailDelKeys.Add(entiry.GetValue("hpcontcust_dbid"));
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
                                    detailDataResult.detailType = typeof(Viat_app_hp_contract_free_prod);

                                    //计算表体和实体的值
                                    List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(detailDataResult.detailType, cusDic);
                                    foreach (Dictionary<string, object> entiry in entityDic)
                                    {
                                        detailDataResult.detailDelKeys.Add(entiry.GetValue("hpcontfreeprod_dbid"));
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
          
    }
}
