/*
 *所有关于View_com_notify_template类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_com_notify_templateService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Basic.IServices;

namespace VIAT.Basic.Services
{
    public partial class View_com_notify_templateService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_com_notify_templateRepository _repository;//访问数据库
        private readonly IViat_com_notify_templateService _viat_com_notify_templateService;
        private readonly IViat_com_notify_templateRepository _viat_com_notify_templateRepository;

        [ActivatorUtilitiesConstructor]
        public View_com_notify_templateService(
            IView_com_notify_templateRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_com_notify_templateService viat_com_notify_templateService,
            IViat_com_notify_templateRepository viat_com_notify_templateRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_com_notify_templateService = viat_com_notify_templateService;
            _viat_com_notify_templateRepository = viat_com_notify_templateRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            return _viat_com_notify_templateService.Add(saveDataModel);
        }

        //重写更新方法，更新Viat_com_prod表
        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _viat_com_notify_templateService.Update(saveModel);
        }
    }
}
