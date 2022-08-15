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
using VIAT.Price.IServices;

namespace VIAT.WorkFlow.Controllers
{
    public partial class View_wk_bid_price_apply_mainController
    {
        private readonly IView_wk_bid_price_apply_mainService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_cust_price_detailService _view_cust_price_detailService;//

        [ActivatorUtilitiesConstructor]
        public View_wk_bid_price_apply_mainController(
            IView_wk_bid_price_apply_mainService service,
            IHttpContextAccessor httpContextAccessor,
            IView_cust_price_detailService view_cust_price_detailService
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _view_cust_price_detailService = view_cust_price_detailService;
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
       /* [HttpPost, Route("RecentOrder")]
        public ActionResult RecentOrder(string prod_dbid, string cust_dbid, string pricegroup_dbid)
        {
            return Json(_service.RecentOrder(prod_dbid, cust_dbid, pricegroup_dbid));
        }*/

        //查詢價格for transfer彈窗
        [ApiActionPermission]
        [HttpPost, Route("RecentOrder")]
        public ActionResult RecentOrder([FromBody] PageDataOptions options)
        {
            return Json(_service.RecentOrder(options));

        }

        //查詢Bid order Apply價格彈窗
        [ApiActionPermission]
        [HttpPost, Route("GetPriceDataForApply")]
        public ActionResult GetPriceDataForApply([FromBody] PageDataOptions options)
        {
            return Json(_view_cust_price_detailService.GetPriceDataForTransfer(options));

        }


        [HttpGet, Route("ProductPrice")]
        public ActionResult ProductPrice(string prod_dbid, string pricegroup_dbid)
        {
            return Json(_service.ProductPrice(prod_dbid, pricegroup_dbid));
        }
        [ApiActionPermission]
        [HttpPost, Route("PriceTansferImport")]
        public ActionResult CustPriceTransferImport(List<IFormFile> files, string cust_id, string group_dbid)
        {
            return Json(_service.CustPriceTransferImport(files, cust_id, group_dbid));
        }
        [ApiActionPermission]
        [HttpPost, Route("SysUserData")]
        public ActionResult SysUserData()
        {
            return Json(_service.SysUserData());
        }
        [ApiActionPermission]
        [HttpPost, Route("LevelDetailData")]
        public ActionResult LevelDetailData(string org_id)
        {
            return Json(_service.LevelDetailData(org_id));
        }
    }
}
