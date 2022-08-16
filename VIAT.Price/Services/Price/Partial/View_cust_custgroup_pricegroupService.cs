/*
 *所有关于View_cust_custgroup_pricegroup类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_cust_custgroup_pricegroupService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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

namespace VIAT.Price.Services
{
    public partial class View_cust_custgroup_pricegroupService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_cust_custgroup_pricegroupRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_cust_custgroup_pricegroupService(
            IView_cust_custgroup_pricegroupRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override PageGridData<View_cust_custgroup_pricegroup> GetPageData(PageDataOptions pageData)
        {
            string group_id = "";
            string group_name = "";
            string status = "";
            string pricing_field = "";
            string cust_type = "";
            string group_type = "";
            string where = "";
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(pageData.Wheres))
            {
                searchParametersList = pageData.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "group_id".ToLower())
                        {
                            
                            group_id = sp.Value;
                            if (!string.IsNullOrEmpty(group_id))
                            {
                                where += " and prc.group_id like '"+group_id+"'";
                            }
                            continue;
                        }
                        if (sp.Name.ToLower() == "group_name".ToLower())
                        {
                            group_name = sp.Value;
                            if (!string.IsNullOrEmpty(group_name))
                            {
                                where += " and prc.group_name like '" + group_name + "'";
                            }
                            continue;
                        }
                        if (sp.Name.ToLower() == "status".ToLower())
                        {
                            status = sp.Value;
                            if (!string.IsNullOrEmpty(status))
                            {
                                where += " and grp.status = '" + status + "'";
                            }
                            continue;
                        }
                        if (sp.Name.ToLower() == "pricing_field".ToLower())
                        {
                            pricing_field = sp.Value;
                            if (!string.IsNullOrEmpty(pricing_field))
                            {
                                where += " and prc.pricing_field = '" + pricing_field + "'";
                            }
                            continue;
                        }
                        if (sp.Name.ToLower() == "cust_type".ToLower())
                        {
                            cust_type = sp.Value;
                            if (!string.IsNullOrEmpty(cust_type))
                            {
                                where += " and prc.cust_type = '" + cust_type + "'";
                            }
                            continue;
                        }
                        if (sp.Name.ToLower() == "group_type".ToLower())
                        {
                            group_type = sp.Value;
                            if (!string.IsNullOrEmpty(group_type))
                            {
                                where += " and prc.group_type = '" + group_type + "'";
                            }
                            continue;
                        }

                    }
                }
            }
                    QuerySql = @"
               select distinct 	
                    cust.cust_dbid,
	                cust.cust_id, 
	                cust.cust_name,
                    cust.doh_type,
	                cust.status as custStatus,
                    cust.is_private,
					dic2.DicName as custType,
	                grp.status ,
	                prc.group_id as group_id,
	                prc.group_name as group_name,
					prc.group_type,
					dic1.DicName as groupTypeName,
					prc.cust_type,
					dic.DicName as custTypeName,
					prc.pricing_field,
					emp.emp_ename as pricing_manager_name,
                    prc.remarks
                from viat_app_cust_group grp
                left JOIN viat_com_cust cust ON cust.cust_dbid = grp.cust_dbid
                left JOIN viat_app_cust_price_group prc ON grp.pricegroup_dbid = prc.pricegroup_dbid
				left join viat_com_employee emp on prc.pricing_field=emp.emp_dbid
				left join Sys_DictionaryList dic on (prc.cust_type=dic.DicValue AND dic.Dic_ID=(SELECT top 1 Dic_ID FROM Sys_Dictionary WHERE DicNo='price_group_cust_type'))								
				left join Sys_DictionaryList dic1 on (prc.group_type=dic1.DicValue AND dic1.Dic_ID=(SELECT top 1 Dic_ID FROM Sys_Dictionary WHERE DicNo='group_price_channel'))
			left join Sys_DictionaryList dic2 on (cust.is_private=dic2.DicValue AND dic2.Dic_ID=(SELECT top 1 Dic_ID FROM Sys_Dictionary WHERE DicNo='PublicPrivate'))
                where cust.cust_id is not null and prc.group_id is not null
               ";
            QuerySql += where;
            return base.GetPageData(pageData);
        }
        public override WebResponseContent Export(PageDataOptions pageData)
        {
            ExportColumns = x =>new
            {
               x.group_id,
               x.group_name,
               x.pricing_manager_name,
               x.groupTypeName,
               x.custTypeName,
               x.remarks,
               x.cust_id,
               x.cust_name,
               x.custType,
               x.status,
               x.custStatus
            };

            return base.Export(pageData);
        }
    }
}
