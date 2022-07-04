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
    [Route("api/Viat_app_hp_contract_free_prod")]
    [PermissionTable(Name = "Viat_app_hp_contract_free_prod")]
    public partial class Viat_app_hp_contract_free_prodController : ApiBaseController<IViat_app_hp_contract_free_prodService>
    {
        public Viat_app_hp_contract_free_prodController(IViat_app_hp_contract_free_prodService service)
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

