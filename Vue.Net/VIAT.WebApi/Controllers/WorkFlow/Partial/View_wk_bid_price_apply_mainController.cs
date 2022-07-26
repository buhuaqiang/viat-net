/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("View_wk_bid_price_apply_main",Enums.ActionPermissionOptions.Search)]
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
    public partial class View_wk_bid_price_apply_mainController
    {
        private readonly IView_wk_bid_price_apply_mainService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public View_wk_bid_price_apply_mainController(
            IView_wk_bid_price_apply_mainService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        [ApiActionPermission]
        [HttpPost, Route("addSubmit")]
        public ActionResult addSubmit([FromBody] SaveModel saveModel)
        {
            return Json(_service.addSubmit(saveModel));
        }


        [ApiActionPermission]
        [HttpPost, Route("Submit")]
        public ActionResult Submit([FromBody] object saveModel)
        {
            return Json(_service.Submit(saveModel));
        }
        [ApiActionPermission]
        [HttpPost, Route("doRollBack")]
        public ActionResult processBack([FromBody] string[] bidmast_dbidLst)
        {
            return Json(_service.processBack(bidmast_dbidLst));
        }

        [ApiActionPermission]
        [HttpGet, Route("getWkApplyMainByBidNO")]
        public IActionResult getWkApplyMainByBidNO(string bid_no)
        {
            return Json(_service.getWkApplyMainByBidNO(bid_no));
        }

        //[ApiActionPermission]
        [HttpGet, Route("RecentOrder")]
        public ActionResult RecentOrder(string prod_dbid, string cust_dbid, string pricegroup_dbid)
        {
            return Json(_service.RecentOrder(prod_dbid, cust_dbid, pricegroup_dbid));
        }
        [HttpGet, Route("ProductPrice")]
        public ActionResult ProductPrice(string prod_dbid, string pricegroup_dbid)
        {
            return Json(_service.ProductPrice(prod_dbid, pricegroup_dbid));
        }
    }
}
