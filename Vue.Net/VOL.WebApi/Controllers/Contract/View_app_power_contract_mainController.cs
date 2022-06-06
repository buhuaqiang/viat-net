/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_app_power_contract_mainController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Contract.IServices;
namespace VIAT.Contract.Controllers
{
    [Route("api/View_app_power_contract_main")]
    [PermissionTable(Name = "View_app_power_contract_main")]
    public partial class View_app_power_contract_mainController : ApiBaseController<IView_app_power_contract_mainService>
    {
        public View_app_power_contract_mainController(IView_app_power_contract_mainService service)
        : base(service)
        {
        }
    }
}

