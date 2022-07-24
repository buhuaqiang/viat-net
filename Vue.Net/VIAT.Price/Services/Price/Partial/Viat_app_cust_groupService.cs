/*
 *所有关于Viat_app_cust_group类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_app_cust_groupService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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

namespace VIAT.Price.Services
{
    public partial class Viat_app_cust_groupService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_app_cust_groupRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_app_cust_groupService(
            IViat_app_cust_groupRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        /// <summary>
        /// 取得group信息
        /// </summary>
        /// <param name="sCustDBID"></param>
        /// <returns></returns>
        public Viat_app_cust_group getCustGroupByCustDBID(string sCustDBID)
        {
            string sSql = " select top(1) * from viat_app_cust_group where cust_dbid = '"+ sCustDBID+"' order by created_date desc";
            return _repository.DapperContext.QueryFirst<Viat_app_cust_group>(sSql, null);
        }

        /// <summary>
        /// 取得group信息
        /// </summary>
        /// <param name="sCustDBID"></param>
        /// <returns></returns>
        public Viat_app_cust_price_group getCustGroupIDAndANmeByCustDBID(string sCustDBID)
        {
            string sSql = @" select top(1) pg.* from viat_app_cust_price_group pg
                            inner join viat_app_cust_group cg on pg.pricegroup_dbid = cg.pricegroup_dbid
                            where pg.status = 'Y' and cg.status = 'Y' and  cg.cust_dbid='" + sCustDBID + @"' 
                            order by created_date desc ";
            return _repository.DapperContext.QueryFirst<Viat_app_cust_price_group>(sSql, null);
        }
    }
}
