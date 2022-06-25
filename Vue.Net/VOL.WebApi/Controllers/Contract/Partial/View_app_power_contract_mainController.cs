/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("View_app_power_contract_main",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Entity.DomainModels;
using VIAT.Contract.IServices;
using VOL.Core.Filters;

namespace VIAT.Contract.Controllers
{
    public partial class View_app_power_contract_mainController
    {
        private readonly IView_app_power_contract_mainService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public View_app_power_contract_mainController(
            IView_app_power_contract_mainService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
       

        /// 關閉GP合約

        [HttpPost, Route("close")]
        [ApiActionPermission]
        public async Task<ActionResult> close([FromBody]  string[] ids)
        {
            return Json(await _service.close(ids));
        }
    }
}
