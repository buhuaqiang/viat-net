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

namespace VIAT.Price.Services
{
    public partial class Viat_app_cust_price_groupService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_app_cust_price_groupRepository _repository;//访问数据库
        private readonly IView_cust_custgroup_pricegroupService _view_Cust_Custgroup_PricegroupService;

        [ActivatorUtilitiesConstructor]
        public Viat_app_cust_price_groupService(
            IViat_app_cust_price_groupRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IView_cust_custgroup_pricegroupService view_Cust_Custgroup_PricegroupService
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
            _view_Cust_Custgroup_PricegroupService = view_Cust_Custgroup_PricegroupService;
        }

        /// <summary>
        /// 根据GROUPID获取单实体
        /// </summary>
        /// <param name="group_id"></param>
        /// <returns></returns>
        public Viat_app_cust_price_group getPriceGroupByGroupID(string group_id)
        {

            return repository.FindAsIQueryable(x => x.group_id == group_id).FirstOrDefault();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public override PageGridData<Viat_app_cust_price_group> GetPageData(PageDataOptions options)
        {
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
    }
}
