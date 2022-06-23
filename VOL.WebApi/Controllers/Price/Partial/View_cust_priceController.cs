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
using VOL.Entity.DomainModels;
using VIAT.Price.IServices;
using VOL.Core.Filters;
using VOL.Core.Utilities;

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

        [ApiActionPermission("View_cust_price", VOL.Core.Enums.ActionPermissionOptions.ProductDetach)]
        [HttpPost, Route("detachProductFromGroup")]
        public ActionResult detachProductFromGroup([FromBody] Guid[] keys)
        {
                       
            return Json(_baseWebResponseContent);
        }

        
        [ApiActionPermission]
        [HttpPost, Route("GetPopPageData")]
        public  ActionResult GetPopPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }


        [ApiActionPermission("View_cust_price", VOL.Core.Enums.ActionPermissionOptions.Invalid)]
        [HttpPost, Route("invalidData")]
        public ActionResult invalidData([FromBody] SaveModel saveModel)
        {
            return Json(_baseWebResponseContent);
        }
    }
    }
