/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Viat_app_cust_price_group",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Entity.DomainModels;
using VIAT.Price.IServices;

namespace VIAT.Price.Controllers
{
    public partial class Viat_app_cust_price_groupController
    {
        private readonly IViat_app_cust_price_groupService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Viat_app_cust_price_groupController(
            IViat_app_cust_price_groupService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet, Route("getPriceGroupByGroupID")]
        public IActionResult getPriceGroupByGroupID(string group_id)
        {
            return Json(_service.getPriceGroupByGroupID(group_id));
        }



        [HttpGet, Route("getPriceGroupByCustAndProd")]
        public IActionResult getPriceGroupByCustAndProd(string prod_dbid,string cust_dbid)
        {
            return Json(_service.getPriceGroupByCustAndProd(prod_dbid,cust_dbid));
        }

        
    }
}
