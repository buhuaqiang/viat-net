/*
 *所有关于View_com_local_mpg类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_com_local_mpgService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Basic.IServices;

namespace VIAT.Basic.Services
{
    public partial class View_com_local_mpgService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_com_local_mpgRepository _repository;//访问数据库

        private readonly IViat_com_local_mpgService _viat_Com_Local_MpgService;

        [ActivatorUtilitiesConstructor]
        public View_com_local_mpgService(
            IView_com_local_mpgRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_com_local_mpgService viat_Com_Local_MpgService
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_Com_Local_MpgService = viat_Com_Local_MpgService;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            return _viat_Com_Local_MpgService.Add(saveDataModel);
        }

        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _viat_Com_Local_MpgService.Update(saveModel);
        }

    }
}
