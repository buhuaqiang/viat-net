/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("View_cust_order_transfer",Enums.ActionPermissionOptions.Search)]
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
    public partial class View_cust_order_transferController
    {
        private readonly IView_cust_order_transferService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public View_cust_order_transferController(
            IView_cust_order_transferService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        //根據bid no查詢當前批次訂單信息
        [ApiActionPermission]
        [HttpPost, Route("getOrderDataByBidNo")]
        public ActionResult getPriceGroupProducts([FromBody] PageDataOptions loadData)
        {
            return Json(_service.GetPageDataByOrderNO(loadData));
        }
    }
}
