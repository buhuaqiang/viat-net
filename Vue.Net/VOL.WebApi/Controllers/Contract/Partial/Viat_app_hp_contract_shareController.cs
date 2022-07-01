/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Viat_app_hp_contract_share",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Entity.DomainModels;
using VIAT.Contract.IServices;

namespace VIAT.Contract.Controllers
{
    public partial class Viat_app_hp_contract_shareController
    {
        private readonly IViat_app_hp_contract_shareService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Viat_app_hp_contract_shareController(
            IViat_app_hp_contract_shareService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost, Route("GetSumPercentByHpcontDBID")]
        public decimal  GetSumPercentByHpcontDBID(string hpcont_dbid)
        {
            return _service.GetSumPercentByHpcontDBID(hpcont_dbid);
        }
    }
}
