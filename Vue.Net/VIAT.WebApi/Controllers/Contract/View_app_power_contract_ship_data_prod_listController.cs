/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_app_power_contract_ship_data_prod_listController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Contract.IServices;
using VIAT.Entity.DomainModels;
using VIAT.Core.Filters;

namespace VIAT.Contract.Controllers
{
    [Route("api/View_app_power_contract_ship_data_prod_list")]
    [PermissionTable(Name = "View_app_power_contract_ship_data_prod_list")]
    public partial class View_app_power_contract_ship_data_prod_listController : ApiBaseController<IView_app_power_contract_ship_data_prod_listService>
    {
        public View_app_power_contract_ship_data_prod_listController(IView_app_power_contract_ship_data_prod_listService service)
        : base(service)
        {
        }
        [ApiActionPermission]
        [HttpPost, Route("GetPageData")]
        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }
    }
}

