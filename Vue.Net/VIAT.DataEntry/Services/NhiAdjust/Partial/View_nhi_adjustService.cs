/*
 *所有关于View_nhi_adjust类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_nhi_adjustService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.DataEntry.IServices;
using System.Collections.Generic;

namespace VIAT.DataEntry.Services
{
    public partial class View_nhi_adjustService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_nhi_adjustRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();

        private readonly IViat_app_nhi_adjust_mService _viat_app_nhi_adjust_mService;
        private readonly IViat_app_nhi_adjust_mRepository _viat_app_nhi_adjust_mRepository;

        [ActivatorUtilitiesConstructor]
        public View_nhi_adjustService(
            IView_nhi_adjustRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_nhi_adjust_mService viat_app_nhi_adjust_mService,
            IViat_app_nhi_adjust_mRepository viat_app_nhi_adjust_mRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_app_nhi_adjust_mService = viat_app_nhi_adjust_mService;
            _viat_app_nhi_adjust_mRepository = viat_app_nhi_adjust_mRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            return _viat_app_nhi_adjust_mService.Add(saveDataModel);
        }

        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecuting = (View_nhi_adjust order, object addList, object updateList, List<object> delKeys) =>
            {
                return webResponse.OK();
            };
            return _viat_app_nhi_adjust_mService.Update(saveModel);
        }

        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            return _viat_app_nhi_adjust_mService.Del(keys, delList);
        }
    }
}
