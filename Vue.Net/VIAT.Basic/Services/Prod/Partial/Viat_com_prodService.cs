/*
 *所有关于Viat_com_prod类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_com_prodService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Basic.IRepositories;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_prodService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_com_prodRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_com_prodService(
            IViat_com_prodRepository dbRepository,
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
        /// 根据prodID获取单一实体
        /// </summary>
        /// <param name="sCustID"></param>
        /// <returns></returns>
        public Viat_com_prod getProdByProdID(string prod_id)
        {
            return repository.FindAsIQueryable(x => x.prod_id == prod_id).FirstOrDefault();
        }
    }
}