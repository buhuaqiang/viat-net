/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Viat_app_power_contract_purchase_prod",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Entity.DomainModels;
using VIAT.Contract.IServices;
using VIAT.Core.Filters;

namespace VIAT.Contract.Controllers
{
    public partial class Viat_app_power_contract_purchase_prodController
    {
        private readonly IViat_app_power_contract_purchase_prodService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Viat_app_power_contract_purchase_prodController(
            IViat_app_power_contract_purchase_prodService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

/*
        [HttpPost, Route("GetPageDatapurchase_prod")]
        [ApiActionPermission()]
        public object GetPageDataCus(PageDataOptions options)
        {
            //根据后端user的值进行数据查询 


            return Json(_service.GetPageDataCus(options));
        }*/
    }
}
