/*
 *所有关于View_app_hp_contract类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_app_hp_contractService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Contract.Repositories;


namespace VIAT.Contract.Services
{
    public partial class View_app_hp_contractService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_app_hp_contractRepository _repository;//访问数据库
        private readonly IViat_app_hp_contractService _viat_app_hp_contractService;
        private readonly IViat_app_hp_contractRepository _viat_app_hp_contractRepository;

        [ActivatorUtilitiesConstructor]
        public View_app_hp_contractService(
            IView_app_hp_contractRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_hp_contractService viat_app_hp_contractService,
            IViat_app_hp_contractRepository viat_app_hp_contractRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_app_hp_contractService = viat_app_hp_contractService;
            _viat_app_hp_contractRepository = viat_app_hp_contractRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public string getContractNo()
        {
            string rule = "A" + $"{DateTime.Now.GetHashCode()}";
            return rule.Substring(0, 10);
        }
        //新增
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            string contractNo = getContractNo();
            Guid cust_dbid = Guid.NewGuid();
            saveDataModel.MainData["contract_no"] = contractNo;
            return _viat_app_hp_contractService.Add(saveDataModel);
        }
        //更新
        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _viat_app_hp_contractService.Update(saveModel);
        }
    }
}
