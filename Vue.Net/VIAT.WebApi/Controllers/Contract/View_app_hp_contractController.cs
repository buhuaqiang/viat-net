/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_app_hp_contractController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Contract.IServices;
namespace VIAT.Contract.Controllers
{
    [Route("api/View_app_hp_contract")]
    [PermissionTable(Name = "View_app_hp_contract")]
    public partial class View_app_hp_contractController : ApiBaseController<IView_app_hp_contractService>
    {
        public View_app_hp_contractController(IView_app_hp_contractService service)
        : base(service)
        {
        }
    }
}

