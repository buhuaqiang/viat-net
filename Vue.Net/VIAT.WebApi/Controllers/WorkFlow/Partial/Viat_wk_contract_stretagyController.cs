/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Viat_wk_contract_stretagy",Enums.ActionPermissionOptions.Search)]
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
    public partial class Viat_wk_contract_stretagyController
    {
        private readonly IViat_wk_contract_stretagyService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Viat_wk_contract_stretagyController(
            IViat_wk_contract_stretagyService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [ApiActionPermission]
        [HttpPost, Route("StretagyImport")]
        public ActionResult StretagyImport([FromBody] List<IFormFile> files)
        {
            return Json(_service.StretagyImport(files));
        }

        [ApiActionPermission]
        [HttpGet, Route("DownLoadTemp")]
        public ActionResult DownLoadTemp()
        {
            return Json(_service.DownLoadTemp());   
        }

    }
}
