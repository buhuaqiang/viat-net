/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("View_price_distributor_mapping",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Entity.DomainModels;
using VIAT.Price.IServices;
using VIAT.Core.Filters;

namespace VIAT.Price.Controllers
{
    public partial class View_price_distributor_mappingController
    {
        private readonly IView_price_distributor_mappingService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public View_price_distributor_mappingController(
            IView_price_distributor_mappingService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        
        [HttpGet, Route("PriceMapingData")]
        public ActionResult PriceDistributorMappingData(string prod_id, string price_channel, string group_id, string cust_id)
        {
            return Json(_service.PriceDistributorMappingData(prod_id, price_channel, group_id, cust_id));
        }
    }
}
