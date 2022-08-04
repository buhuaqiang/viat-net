/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("View_cust_price",Enums.ActionPermissionOptions.Search)]
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
using VIAT.Core.Utilities;

namespace VIAT.Price.Controllers
{
    public partial class View_cust_priceController
    {
        private readonly IView_cust_priceService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private WebResponseContent _baseWebResponseContent { get; set; }

        [ActivatorUtilitiesConstructor]
        public View_cust_priceController(
            IView_cust_priceService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        //查詢當前價格群組商品
        [ApiActionPermission]
        [HttpPost, Route("getPriceGroupProducts")]
        public ActionResult getPriceGroupProducts([FromBody] PageDataOptions loadData)
        {
            return Json(_service.getPriceGroupProducts(loadData));
        }

        //查詢客戶在群組內的產品
        [ApiActionPermission]
        [HttpPost, Route("getCustomerProducts")]
        public ActionResult getCustomerProducts([FromBody] PageDataOptions loadData)
        {
            return Json(_service.getCustomerProducts(loadData));
        }

        
        //copy price list頁面查詢方法
        [ApiActionPermission]
        [HttpPost, Route("getOrginalDataFromCustOrGroup")]
        public ActionResult getOrginalDataFromCustOrGroup([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }

        [ApiActionPermission("View_cust_price", VIAT.Core.Enums.ActionPermissionOptions.ProductDetach)]
        [HttpPost, Route("detachProductFromGroup")]
        public ActionResult detachProductFromGroup([FromBody] Guid[] keys)
        {

            return Json(_baseWebResponseContent);
        }

        [ApiActionPermission("View_cust_price", VIAT.Core.Enums.ActionPermissionOptions.detachAll)]
        [HttpPost, Route("detachAll")]
        public ActionResult detachAll([FromBody] SaveModel saveModel)
        {

            return Json(_baseWebResponseContent);
        }

        [ApiActionPermission]
        [HttpPost, Route("GetPopPageData")]
        public ActionResult GetPopPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }


        [ApiActionPermission]
        [HttpPost, Route("invalidData")]
        public ActionResult invalidData([FromBody] object saveModel)
        {
            return Json(_service.invalidData(saveModel));
        }


        [ApiActionPermission]
        [HttpPost, Route("excuteCustomerJoinGroup")]
        public ActionResult excuteCustomerJoinGroup([FromBody] SaveModel saveModel)
        {
            return Json(_baseWebResponseContent);
        }

        [ApiActionPermission]
        [HttpPost, Route("excuteCustomerDetachGroup")]
        public ActionResult excuteCustomerDetachGroup([FromBody] SaveModel saveModel)
        {
            return Json(_baseWebResponseContent);
        }


        [ApiActionPermission]
        [HttpPost, Route("copyPriceList")]
        public ActionResult copyPriceList([FromBody] SaveModel saveModel)
        {
            return Json(_baseWebResponseContent);
        }



        //新增价格群组商品前检验
        [ApiActionPermission]
        [HttpPost, Route("checkCustPriceData")]
        public ActionResult checkCustPriceData([FromBody] SaveModel saveModel)
        {
            return Json(_baseWebResponseContent);
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


        
        //取得bindno
        [ApiActionPermission]
        [HttpPost, Route("getMaxBindNo")]
        public string getMaxBindNo()
        {
            return _service.getMaxBindNo();
        }

        /// <summary>
        /// 取得Gross Price
        /// </summary>
        /// <param name="sProdID"></param>
        /// <returns></returns>
        ///   //取得bindno
        [ApiActionPermission]
        [HttpPost, Route("getNetPriceByProdID")]
        public decimal getNetPriceByProdID(string prod_id)
        {
            return _service.getNetPriceByProdID(prod_id);
        }



        //GetGroupInvalidPageData
        /// <summary>
        /// 取得Gross Price
        /// </summary>
        /// <param name="sProdID"></param>
        /// <returns></returns>
        ///   //取得bindno
        [ApiActionPermission]
        [HttpPost, Route("GetGroupInvalidPageData")]
        public ActionResult GetGroupInvalidPageData([FromBody]  PageDataOptions options)
        {
            return Json(_service.GetGroupInvalidPageData(options));
        }

        [ApiActionPermission]
        [HttpPost, Route("importData")]
        public ActionResult importData([FromBody] List<View_cust_price> list)
        {
            return Json(_service.importData(list));
        }

        [HttpPost, Route("NhiPriceData")]
        public decimal NhiPriceData(string prod_dbid,string start_date)
        {
            return _service.NhiPriceData(prod_dbid, start_date);
        }
    }
}