/*
 *所有关于View_app_hp_share_table类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_app_hp_share_tableService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using System;

namespace VIAT.Contract.Services
{
    public partial class View_app_hp_share_tableService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_app_hp_share_tableRepository _repository;//访问数据库
        private readonly IViat_app_hp_contract_shareService _viat_app_hp_contract_shareService;
        private readonly IViat_app_hp_contract_shareRepository _viat_app_hp_contract_shareRepository;

        [ActivatorUtilitiesConstructor]
        public View_app_hp_share_tableService(
            IView_app_hp_share_tableRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_hp_contract_shareService viat_app_hp_contract_shareService,
            IViat_app_hp_contract_shareRepository viat_app_hp_contract_shareRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_app_hp_contract_shareService = viat_app_hp_contract_shareService;
            _viat_app_hp_contract_shareRepository = viat_app_hp_contract_shareRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        //新增
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            return _viat_app_hp_contract_shareService.Add(saveDataModel);
        }
        //更新
        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _viat_app_hp_contract_shareService.Update(saveModel);
        }
     

    }
}
