/*
 *所有关于Viat_app_cust_price_group类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_app_cust_price_groupService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Price.IRepositories;
using System.Collections.Generic;
using VIAT.Core.Enums;
using VIAT.Price.IServices;
using Newtonsoft.Json;
using System;

namespace VIAT.Price.Services
{
    public partial class Viat_app_cust_price_groupService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_app_cust_price_groupRepository _repository;//访问数据库
        private readonly IView_cust_custgroup_pricegroupService _view_Cust_Custgroup_PricegroupService;
        WebResponseContent webResponse = new WebResponseContent();
        private readonly IView_cust_priceService _view_cust_priceService;


        [ActivatorUtilitiesConstructor]
        public Viat_app_cust_price_groupService(
            IViat_app_cust_price_groupRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IView_cust_custgroup_pricegroupService view_Cust_Custgroup_PricegroupService,
            IView_cust_priceService view_cust_priceService
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
            _view_Cust_Custgroup_PricegroupService = view_Cust_Custgroup_PricegroupService;
            _view_cust_priceService = view_cust_priceService;
        }

        /// <summary>
        /// 根据GROUPID获取单实体
        /// </summary>
        /// <param name="group_id"></param>
        /// <returns></returns>
        public Viat_app_cust_price_group getPriceGroupByGroupID(string group_id)
        {
            string sql = "select * from Viat_app_cust_price_group where group_id='"+group_id+"'";
            return _repository.DapperContext.QueryFirst<Viat_app_cust_price_group>(sql, null);
           // return repository.FindAsIQueryable(x => x.group_id == group_id).FirstOrDefault();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public override PageGridData<Viat_app_cust_price_group_select> GetPageData(PageDataOptions options)
        {
            QuerySql = @"SELECT grp.*,
	            emp.emp_ename as pricing_manager_name
             from viat_app_cust_price_group grp 
            left join viat_com_employee emp on grp.pricing_field=emp.emp_dbid";
            base.OrderByExpression = x => new Dictionary<object, QueryOrderBy>() {
                {
                    x.group_id,QueryOrderBy.Asc
                } 
            };
            return base.GetPageData(options);
        }

        /// <summary>
        /// 暫時不用了(和其他接口重複)
        /// </summary>
        /// <param name="prod_dbid"></param>
        /// <param name="cust_dbid"></param>
        /// <returns></returns>
        public Viat_app_cust_price_group getPriceGroupByCustAndProd(string prod_dbid, string cust_dbid)
        {
            if(prod_dbid!=null && cust_dbid != null)
            {

            }
            else
            {
                return null;
            }
            string sql = @"SELECT
	                *
                FROM
	                viat_app_cust_price_group
                WHERE
	                pricegroup_dbid IN (
		                SELECT
			                top 1 pricegroup_dbid
		                FROM
			                viat_app_cust_group
		                WHERE
			                prod_dbid = '"+prod_dbid+@"'
		                AND cust_dbid = '"+ cust_dbid + @"'
		                AND status = 'Y'
		                AND SysDateTime() >= start_date
		                ORDER BY
			                created_date DESC,
			                modified_date DESC
	                )";

            return _repository.DapperContext.QueryFirst<Viat_app_cust_price_group>(sql,null);
        }


        public override WebResponseContent Export(PageDataOptions pageData)
        {
            return _view_Cust_Custgroup_PricegroupService.Export(pageData);
        }

        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            bool hasPrice = false;
            foreach(string k in keys)
            {
                string sSql = "select count(*) from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid";
                object obj = _repository.DapperContext.ExecuteScalar(sSql, new { pricegroup_dbid =k });
                hasPrice= (((int)obj) == 0) ? false : true;
                break;
            }
            if (hasPrice)
            {
                webResponse.Code = "-1";
                return webResponse.Error("This group has price,can not delete.");
            }

            return base.Del(keys, delList);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //AddOnExecute = (SaveModel saveModel) =>
            //{
            //    Viat_app_cust_price_group group1=JsonConvert.DeserializeObject<Viat_app_cust_price_group>(JsonConvert.SerializeObject(saveModel.MainData));
            //    //如果返回false,后面代码不会再执行
            //    Viat_app_cust_price_group group = getPriceGroupByGroupID(group1.group_id);
            //    if (group != null)
            //    {
            //        return webResponse.Error("Group ID duplicate or have exist.");
            //    }
            //    return webResponse.OK();
            //};
            //
            Viat_app_cust_price_group group1 = JsonConvert.DeserializeObject<Viat_app_cust_price_group>(JsonConvert.SerializeObject(saveDataModel.MainData));
            //    //如果返回false,后面代码不会再执行
            Viat_app_cust_price_group group = getPriceGroupByGroupID(group1.group_id);
            if (group != null)
            {
                return webResponse.Error("Group ID duplicate or have exist.");
            }
            SaveModel.DetailListDataResult countResult = new SaveModel.DetailListDataResult();
            countResult.optionType = SaveModel.MainOptionType.add;
            if (!saveDataModel.MainData.ContainsKey("pricegroup_dbid"))
            {
                saveDataModel.MainData.Add("pricegroup_dbid", "");
            }
            saveDataModel.MainData["pricegroup_dbid"] = Guid.NewGuid().ToString();
            countResult.detailType = typeof(Viat_app_cust_price_group);
            //增加表头处理
            countResult.DetailData.Add(saveDataModel.MainData);
            saveDataModel.DetailListData.Add(countResult);
            Viat_app_cust_price_group groupEntry = JsonConvert.DeserializeObject<Viat_app_cust_price_group>(JsonConvert.SerializeObject(saveDataModel.MainData));
            return base.CustomBatchProcessEntity(saveDataModel);
        }

        public override WebResponseContent Update(SaveModel saveModel)
        {
            //UpdateOnExecute = (saveModel) =>
            //{
            //    Viat_app_cust_price_group group1 = JsonConvert.DeserializeObject<Viat_app_cust_price_group>(JsonConvert.SerializeObject(saveModel.MainData));
            //    //如果返回false,后面代码不会再执行
            //    Viat_app_cust_price_group group = repository.FindAsIQueryable(x => x.group_id == group1.group_id).FirstOrDefault();
            //    if (group != null)
            //    {
            //        return webResponse.Error("Group ID duplicate or have exist.");
            //    }
            //    //如果修改后的状态为N,需要修改group name+(x)

            //    return webResponse.OK();
            //};
            //UpdateOnExecuted = (Viat_app_cust_price_group order, object addList, object updateList, List<object> delKeys) =>
            //{
            //    //如果修改后的状态为N ,处理 cust_price和cust_group的数据
            //    return webResponse.OK();
            //};
            //return base.Update(saveModel);           
            ProcessPriceGroup(saveModel);

            return base.CustomBatchProcessEntity(saveModel);
        }

        public void ProcessPriceGroup(SaveModel saveModel)
        {
            Viat_app_cust_price_group groupEntry = JsonConvert.DeserializeObject<Viat_app_cust_price_group>(JsonConvert.SerializeObject(saveModel.MainData));
            if (groupEntry.status.Equals("N"))
            {
                ProcessCustPrice(saveModel, groupEntry);
                ProcessCustGroup(saveModel, groupEntry);
                saveModel.MainData["group_name"] = "(X)" + saveModel.MainData["group_name"];
            }
            SaveModel.DetailListDataResult countResult = new SaveModel.DetailListDataResult();
            countResult.optionType = SaveModel.MainOptionType.update;
            countResult.detailType = typeof(Viat_app_cust_price_group);
            
            //增加表头处理
            countResult.DetailData.Add(saveModel.MainData);
            saveModel.DetailListData.Add(countResult);
            
        }

        public void ProcessCustPrice(SaveModel saveModel, Viat_app_cust_price_group groupEntry)
        {
            List<Viat_app_cust_price> lstCustPrice = repository.DbContext.Set<Viat_app_cust_price>().Where(x => x.pricegroup_dbid == groupEntry.pricegroup_dbid && x.status == "Y").ToList();
            if (lstCustPrice.Count()>0)
            {
                foreach (var item in lstCustPrice)
                {
                    SaveModel.DetailListDataResult priceResult = new SaveModel.DetailListDataResult();
                    priceResult.optionType = SaveModel.MainOptionType.update;
                    item.end_date = getFormatYYYYMMDD(DateTime.Now);
                    item.status = "N";
                    priceResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    priceResult.detailType = typeof(Viat_app_cust_price);
                    saveModel.DetailListData.Add(priceResult);
                }
            }
        }
        public void ProcessCustGroup(SaveModel saveModel, Viat_app_cust_price_group groupEntry)
        {
            List<Viat_app_cust_group> lstCustGroup = repository.DbContext.Set<Viat_app_cust_group>().Where(x => x.pricegroup_dbid == groupEntry.pricegroup_dbid && x.status == "Y").ToList();
            if (lstCustGroup.Count()>0)
            {
                foreach (var item in lstCustGroup)
                {
                    DetachDetail(saveModel, item);
                    item.end_date = getFormatYYYYMMDD(DateTime.Now).AddDays(-1);
                    if (getFormatYYYYMMDD(item.end_date) < getFormatYYYYMMDD(item.start_date))
                    {
                        item.start_date = item.end_date;
                    }
                    item.status = "N";
                    item.remarks += " " + groupEntry.remarks;
                    SaveModel.DetailListDataResult custGroupResult = new SaveModel.DetailListDataResult();
                    custGroupResult.optionType = SaveModel.MainOptionType.update;
                    custGroupResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    custGroupResult.detailType = typeof(Viat_app_cust_group);
                    saveModel.DetailListData.Add(custGroupResult);
                }
            }
        }

        public void DetachDetail(SaveModel saveModel, Viat_app_cust_group entiy)
        {
            List<Viat_app_cust_price_detail> lstPriceDetail = View_cust_priceService.Instance.getAllPriceDetailByGroupAndProd("", entiy.prod_dbid.ToString(), entiy.cust_dbid.ToString(), entiy.pricegroup_dbid.ToString());
            if (lstPriceDetail.Count() > 0)
            {
                foreach (var item in lstPriceDetail)
                {
                    SaveModel.DetailListDataResult custPiceDetailResult = new SaveModel.DetailListDataResult();
                    custPiceDetailResult.optionType = SaveModel.MainOptionType.update;
                    item.status = "N";
                    custPiceDetailResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    custPiceDetailResult.detailType = typeof(Viat_app_cust_price_detail);
                    saveModel.DetailListData.Add(custPiceDetailResult);
                }
            }
        }
    }
}
