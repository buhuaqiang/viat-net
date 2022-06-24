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
    [Route("api/Viat_app_power_contract_purchase_prod")]
    [PermissionTable(Name = "Viat_app_power_contract_purchase_prod")]
    public partial class Viat_app_power_contract_purchase_prodController : ApiBaseController<IViat_app_power_contract_purchase_prodService>
    {
        public Viat_app_power_contract_purchase_prodController(IViat_app_power_contract_purchase_prodService service)
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

