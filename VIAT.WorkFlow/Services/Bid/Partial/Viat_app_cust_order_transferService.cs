/*
 *所有关于Viat_app_cust_order_transfer类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_app_cust_order_transferService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.WorkFlow.IRepositories;

namespace VIAT.WorkFlow.Services
{
    public partial class Viat_app_cust_order_transferService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_app_cust_order_transferRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_app_cust_order_transferService(
            IViat_app_cust_order_transferRepository dbRepository,
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
        /// 取得数据
        /// </summary>
        /// <param name="price_transfer_dbid"></param>
        /// <returns></returns>
        public Viat_app_cust_order_transfer getPriceTransferByDBID(string order_transfer_dbid)
        {
            string sSql = "select * from viat_app_cust_order_transfer where order_transfer_dbid='" + order_transfer_dbid + "'";

            return _repository.DapperContext.QueryFirst<Viat_app_cust_order_transfer>(sSql, null);
        }
    }
}
