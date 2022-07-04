/*
 *所有关于View_sys_deputy类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_sys_deputyService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
    public partial class View_sys_deputyService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_sys_deputyRepository _repository;//访问数据库
        private readonly IViat_sys_deputyService _viat_sys_DeputyService;
        private readonly IViat_sys_deputyRepository _viat_Sys_DeputyRepository;
        WebResponseContent webResponse = new WebResponseContent();

        [ActivatorUtilitiesConstructor]
        public View_sys_deputyService(
            IView_sys_deputyRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_sys_deputyService viat_Sys_Deputy,
            IViat_sys_deputyRepository viat_Sys_DeputyRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
            _viat_sys_DeputyService = viat_Sys_Deputy;
            _viat_Sys_DeputyRepository = viat_Sys_DeputyRepository;
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            return _viat_sys_DeputyService.Add(saveDataModel);
        }

        //重写更新方法，更新Viat_com_prod表
        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _viat_sys_DeputyService.Update(saveModel);
        }

        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            return _viat_sys_DeputyService.Del(keys, delList);
        }
    }
}
