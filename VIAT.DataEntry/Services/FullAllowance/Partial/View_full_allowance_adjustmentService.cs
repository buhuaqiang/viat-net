/*
 *所有关于View_full_allowance_adjustment类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_full_allowance_adjustmentService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
    public partial class View_full_allowance_adjustmentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_full_allowance_adjustmentRepository _repository;//访问数据库
        private readonly IViat_app_hp_contract_allw_sumService _viat_app_hp_contract_allw_sumService;
        private readonly IViat_app_hp_contract_allw_sumRepository _viat_app_hp_contract_allw_sumRepository;
        WebResponseContent webResponse = new WebResponseContent();

        [ActivatorUtilitiesConstructor]
        public View_full_allowance_adjustmentService(
            IView_full_allowance_adjustmentRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_hp_contract_allw_sumService viat_app_hp_contract_allw_sumService,
            IViat_app_hp_contract_allw_sumRepository viat_app_hp_contract_allw_sumRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_app_hp_contract_allw_sumService = viat_app_hp_contract_allw_sumService;
            _viat_app_hp_contract_allw_sumRepository = viat_app_hp_contract_allw_sumRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }


        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            saveDataModel.MainData["action_type"] = '3';
            return _viat_app_hp_contract_allw_sumService.Add(saveDataModel);
        }

        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecuting = (View_full_allowance_adjustment order, object addList, object updateList, List<object> delKeys) =>
            {
                return webResponse.OK();
            };
            return _viat_app_hp_contract_allw_sumService.Update(saveModel);
        }

        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            return _viat_app_hp_contract_allw_sumService.Del(keys, delList);
        }
    }
}
