/*
 *所有关于View_com_cust类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_com_custService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System;
using System.Collections.Generic;

namespace VIAT.Basic.Services
{
    public partial class View_com_custService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_com_custRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();

        private readonly IViat_com_custService _viat_com_custService;
        private readonly IViat_com_custRepository _viat_com_custRepository;

        [ActivatorUtilitiesConstructor]
        public View_com_custService(
            IView_com_custRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_com_custService viat_com_custService,
            IViat_com_custRepository viat_com_custRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_com_custService = viat_com_custService;
            _viat_com_custRepository = viat_com_custRepository;
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
            Guid cust_dbid = Guid.NewGuid();

            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            /* AddOnExecuting = (View_com_cust order, object list) => 
             {

                 Viat_com_cust cust = new Viat_com_cust()
                 {
                     cust_dbid = cust_dbid,
                     cust_id=code,
                     cust_address=order.cust_address,
                     invoice_address = order.invoice_address,
                     own_hospital=order.own_hospital,
                     delv_group= order.delv_group,
                     bmp_zip_id=order.bmp_zip_id,
                     zip_id=order.zip_id,


                 };

                 List<Viat_com_cust_delivery> Viat_com_cust_delivery = list as List<Viat_com_cust_delivery>;
                 //  
                 foreach (var item in Viat_com_cust_delivery)
                 {
                     item.cust_dbid = cust_dbid;
                 }
                 cust.Viat_com_cust_delivery = Viat_com_cust_delivery;

                 webResponse.Code = "-1";

                 return webResponse.OK();
             };*/

            saveDataModel.MainData["cust_id"] = code;
            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            AddOnExecuting = (View_com_cust order, object list) =>
            {
                order.cust_id = code;

                return webResponse.OK();
            };

            return _viat_com_custService.Add(saveDataModel);
        }


        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _viat_com_custService.Update(saveModel);
        }
    }
}
