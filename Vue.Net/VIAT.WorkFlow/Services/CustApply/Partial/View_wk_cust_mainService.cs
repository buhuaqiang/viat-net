/*
 *所有关于View_wk_cust_main类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_wk_cust_mainService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.WorkFlow.IRepositories;
using VIAT.WorkFlow.IServices;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace VIAT.WorkFlow.Services
{
    public partial class View_wk_cust_mainService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_wk_cust_mainRepository _repository;//访问数据库
        private readonly IViat_wk_custService _viat_wk_custService;
        private readonly IViat_wk_custRepository _viat_wk_custRepository;


        [ActivatorUtilitiesConstructor]
        public View_wk_cust_mainService(
            IView_wk_cust_mainRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_wk_custService viat_wk_custService,
            IViat_wk_custRepository viat_wk_custRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_wk_custService = viat_wk_custService;
            _viat_wk_custRepository = viat_wk_custRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public string getCustCode()
        {
            string rule = "C" + $"D{DateTime.Now.GetHashCode()}";
            return rule.Substring(0, 10);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            string code = getCustCode();
            Guid wkcust_dbid = Guid.NewGuid();

            saveDataModel.MainData["wkcust_dbid"] = wkcust_dbid;

            if (saveDataModel.MainData.GetValue("apply_type")?.ToString()=="01") {
                saveDataModel.MainData["cust_id"] = code;
            }
           // saveDataModel.MainData["cust_id"] = code;

            return _viat_wk_custService.Add(saveDataModel);
        }

        public override WebResponseContent Update(SaveModel saveModel)
        {
           
            return _viat_wk_custService.Update(saveModel);
        }
        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            return _viat_wk_custService.Del(keys, delList);
        }


       
    }
}
