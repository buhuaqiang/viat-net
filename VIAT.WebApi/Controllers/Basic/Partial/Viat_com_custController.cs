/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Viat_com_cust",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Entity.DomainModels;
using VIAT.Basic.IServices;

namespace VIAT.Basic.Controllers
{
  
    public partial class Viat_com_custController
    {
        private readonly IViat_com_custService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Viat_com_custController(
            IViat_com_custService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet, Route("getCustByCustID")]
        public IActionResult getCustByCustID(string cust_id)
        {
            return Json(_service.getCustByCustID(cust_id));
        }

        [HttpGet, Route("GetCustListByPriceGroupDBID")]
        public List<Viat_com_cust> GetCustListByPriceGroupDBID(string sPriceGroupDBID)
        {
            return _service.GetCustListByPriceGroupDBID(sPriceGroupDBID);
        }
    }
}
