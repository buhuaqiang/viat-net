/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_power_contract_custController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Contract.IServices;
using VOL.Core.Filters;
using VOL.Entity.DomainModels;

namespace VIAT.Contract.Controllers
{
    [Route("api/Viat_app_power_contract_cust")]
    [PermissionTable(Name = "Viat_app_power_contract_cust")]
    public partial class Viat_app_power_contract_custController : ApiBaseController<IViat_app_power_contract_custService>
    {
        public Viat_app_power_contract_custController(IViat_app_power_contract_custService service)
        : base(service)
        {
        }

        [HttpPost, Route("GetPageData")]
        [ApiActionPermission()]
        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }
    }
}

