/*
 *所有关于View_com_prod类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_com_prodService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
    public partial class View_com_prodService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_com_prodRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_com_prodService(
            IView_com_prodRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        //重写更新方法，更新Viat_com_prod表
        public override WebResponseContent Update(SaveModel saveModel)
        {
            return Viat_com_prodService.Instance.Update(saveModel);
        }

       



    }
}
