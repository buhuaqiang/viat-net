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
            QuerySql = @"
               select distinct 	
                    cust.cust_dbid,
	                cust.cust_id, 
	                cust.cust_name,
	                cust.status as custStatus,
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
                where cust.cust_id is not null and prc.group_id is not null
               ";
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
               x.status,
               x.custStatus
            };

            return base.Export(pageData);
        }
    }
}
