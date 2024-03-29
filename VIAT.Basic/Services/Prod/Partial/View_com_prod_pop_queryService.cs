/*
 *所有关于View_com_prod_pop_query类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_com_prod_pop_queryService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Basic.IRepositories;
using System.Collections.Generic;
using VIAT.Core.Enums;

namespace VIAT.Basic.Services
{
    public partial class View_com_prod_pop_queryService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_com_prod_pop_queryRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_com_prod_pop_queryService(
            IView_com_prod_pop_queryRepository dbRepository,
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
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public override PageGridData<View_com_prod_pop_query> GetPageData(PageDataOptions options)
        {
            base.OrderByExpression = x => new Dictionary<object, QueryOrderBy>() {
                {
                    x.prod_ename,QueryOrderBy.Asc
                } 
            };
            return base.GetPageData(options);
        }
    }
}
