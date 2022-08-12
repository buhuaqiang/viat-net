/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Viat_sftp_export",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Entity.DomainModels;
using VIAT.DataEntry.IServices;
using VIAT.Core.Filters;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Linq;

namespace VIAT.DataEntry.Controllers
{
    public partial class Viat_sftp_exportController
    {
        private readonly IViat_sftp_exportService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Viat_sftp_exportController(
            IViat_sftp_exportService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [ApiActionPermission]
        [HttpPost, Route("Execute")]
        public ActionResult Execute([FromBody] SaveModel saveModel)
        {
            return Json(_service.Execute(saveModel));
        }
        [HttpPost, Route("ExecuteBatch"), AllowAnonymous]
        public ActionResult ExecuteBatch()
        {
            return Json(_service.ExecuteBatch(HttpContext.Request.Headers));
        }
        [ApiActionPermission]
        [HttpPost, Route("ExecuteRow")]
        public ActionResult ExecuteRow(string file_name)
        {
            return Json(_service.ExecuteRow(file_name));
        }
    }
}
