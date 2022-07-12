/*
 *所有关于View_full_allowance_main类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_full_allowance_mainService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.DataEntry.IRepositories;

namespace VIAT.DataEntry.Services
{
    public partial class View_full_allowance_mainService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_full_allowance_mainRepository _repository;//访问数据库
       

        [ActivatorUtilitiesConstructor]
        public View_full_allowance_mainService(
            IView_full_allowance_mainRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
           
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        
  }
}