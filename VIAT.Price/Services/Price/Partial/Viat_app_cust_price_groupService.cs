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

namespace VIAT.Price.Services
{
    public partial class Viat_app_cust_price_groupService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_app_cust_price_groupRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_app_cust_price_groupService(
            IViat_app_cust_price_groupRepository dbRepository,
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
        /// 根据GROUPID获取单实体
        /// </summary>
        /// <param name="group_id"></param>
        /// <returns></returns>
        public Viat_app_cust_price_group getPriceGroupByGroupID(string group_id)
        {

            return repository.FindAsIQueryable(x => x.group_id == group_id).FirstOrDefault();
        }
    }
}
