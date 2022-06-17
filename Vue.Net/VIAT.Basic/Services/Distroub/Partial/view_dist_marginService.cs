/*
 *所有关于view_dist_margin类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*view_dist_marginService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System.Collections.Generic;

namespace VIAT.Basic.Services
{
    public partial class view_dist_marginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Iview_dist_marginRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();

        private readonly IViat_app_dist_marginService _viat_app_dist_marginService;
        private readonly IViat_app_dist_marginRepository _viat_app_dist_marginRepository;

        [ActivatorUtilitiesConstructor]
        public view_dist_marginService(
            Iview_dist_marginRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_dist_marginService viat_app_dist_marginService,
            IViat_app_dist_marginRepository viat_app_dist_marginRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_app_dist_marginService = viat_app_dist_marginService;
            _viat_app_dist_marginRepository = viat_app_dist_marginRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            return _viat_app_dist_marginService.Add(saveDataModel);
        } 
        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecuting = (view_dist_margin order, object addList, object updateList, List<object> delKeys) =>
            {
                return webResponse.OK();
            };
            return _viat_app_dist_marginService.Update(saveModel);
        }

        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            return _viat_app_dist_marginService.Del(keys, delList);
        }
    }
}
