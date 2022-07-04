/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_hp_contract_custController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Contract.IServices;
using VIAT.Core.Filters;
using VIAT.Entity.DomainModels;

namespace VIAT.Contract.Controllers
{
    [Route("api/Viat_app_hp_contract_cust")]
    [PermissionTable(Name = "Viat_app_hp_contract_cust")]
    public partial class Viat_app_hp_contract_custController : ApiBaseController<IViat_app_hp_contract_custService>
    {
        public Viat_app_hp_contract_custController(IViat_app_hp_contract_custService service)
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

