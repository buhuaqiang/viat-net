/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_power_contract_ship_dataController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Contract.IServices;
using VOL.Core.Filters;
using VOL.Entity.DomainModels;

namespace VIAT.Contract.Controllers
{
    [Route("api/Viat_app_power_contract_ship_data")]
    [PermissionTable(Name = "Viat_app_power_contract_ship_data")]
    public partial class Viat_app_power_contract_ship_dataController : ApiBaseController<IViat_app_power_contract_ship_dataService>
    {
        public Viat_app_power_contract_ship_dataController(IViat_app_power_contract_ship_dataService service)
        : base(service)
        {
        }

        [ApiActionPermission]
        [HttpPost, Route("GetPageData")]
        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }

        [ApiActionPermission]
        [HttpPost, Route("Add")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override ActionResult Add([FromBody] SaveModel saveModel)
        {
            return base.Add(saveModel);
        }
        [ApiActionPermission]
        [HttpPost, Route("Update")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override ActionResult Update([FromBody] SaveModel saveModel)
        {
            return base.Update(saveModel);
        }
    }
}

