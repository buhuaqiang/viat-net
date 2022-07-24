/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Viat_app_cust_group",Enums.ActionPermissionOptions.Search)]
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
    public partial class Viat_app_cust_groupController
    {
        private readonly IViat_app_cust_groupService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Viat_app_cust_groupController(
            IViat_app_cust_groupService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        //getCustGroupIDAndANmeByCustDBID
        /// <summary>
        /// 取得Gross Price
        /// </summary>
        /// <param name="sProdID"></param>
        /// <returns></returns>
        ///   //取得bindno
        [ApiActionPermission]
        [HttpGet, Route("getCustGroupIDAndANmeByCustDBID")]
        public ActionResult GetGroupInvalidPageData(string cust_dbid)
        {
            return Json(_service.getCustGroupIDAndANmeByCustDBID(cust_dbid));
        }
    }
}
