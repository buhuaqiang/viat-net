/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("View_cust_price_detail",Enums.ActionPermissionOptions.Search)]
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
    public partial class View_cust_price_detailController
    {
        private readonly IView_cust_price_detailService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public View_cust_price_detailController(
            IView_cust_price_detailService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 3.	判斷是否為ExpfizerCust
        /// </summary>
        /// <param name="cust_id"></param>
        /// <returns></returns>

        [ApiActionPermission]
        [HttpGet, Route("IsExpfizer")]
        public bool IsExpfizer(string cust_id)
        {
            return _service.IsExpfizer(cust_id);
        }

        //GetCustInvalidPageData
        // 
        /// <summary>
        /// 取得Gross Price
        /// </summary>
        /// <param name="sProdID"></param>
        /// <returns></returns>
        ///   //取得bindno
        [ApiActionPermission]
        [HttpPost, Route("GetCustInvalidPageData")]
        public ActionResult GetCustInvalidPageData([FromBody] PageDataOptions options)
        {
            return Json(_service.GetCustInvalidPageData(options));

        }


        //批量新增价格群组商品
        [ApiActionPermission]
        [HttpPost, Route("bathSaveCheckData")]
        public ActionResult bathSaveCheckData([FromBody] object saveModel)
        {
            return Json(_service.bathSaveCheckData(saveModel));
        }


        //批量新增价格群组商品
        [ApiActionPermission]
        [HttpPost, Route("bathSaveCustPrice")]
        public ActionResult bathSaveCustPrice([FromBody] object saveModel)
        {
            return Json(_service.bathSaveCustPrice(saveModel));
        }


        //查詢價格for transfer彈窗
        [ApiActionPermission]
        [HttpPost, Route("GetPriceDataForTransfer")]
        public ActionResult GetPriceDataForTransfer([FromBody] PageDataOptions options)
        {
            return Json(_service.GetPriceDataForTransfer(options));

        }

    }
}
