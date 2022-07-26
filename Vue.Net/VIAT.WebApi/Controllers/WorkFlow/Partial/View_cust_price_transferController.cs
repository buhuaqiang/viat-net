/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("View_cust_price_transfer",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Entity.DomainModels;
using VIAT.WorkFlow.IServices;
using VIAT.Core.Filters;

namespace VIAT.WorkFlow.Controllers
{
    public partial class View_cust_price_transferController
    {
        private readonly IView_cust_price_transferService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public View_cust_price_transferController(
            IView_cust_price_transferService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [ApiActionPermission]
        [HttpPost, Route("addSubmit")]
        public ActionResult CustPriceDetailData(string pricegroup_dbid, string[] prod_dbid)
        {
            return Json(_service.CustPriceDetailData(pricegroup_dbid, prod_dbid));
        }
    }
}
