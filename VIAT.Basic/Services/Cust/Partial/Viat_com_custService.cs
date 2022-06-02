/*
 *所有关于Viat_com_cust类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_com_custService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_custService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_com_custRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();

        [ActivatorUtilitiesConstructor]
        public Viat_com_custService(
            IViat_com_custRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }


        public override WebResponseContent Add(SaveModel saveDataModel)
        {

            string code = getCustCode();
            saveDataModel.MainData["cust_id"] = code;
            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            AddOnExecuting = (Viat_com_cust order, object list) =>
            {
                order.cust_id = code;

                return webResponse.OK();
            };

            return base.Add(saveDataModel);
        }

        public string getCustCode()
        {
            string rule = "C" + $"D{DateTime.Now.GetHashCode()}";
            return rule.Substring(0, 10);
        }
    }
}
