/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_full_allowance_mainController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/View_full_allowance_main")]
    [PermissionTable(Name = "View_full_allowance_main")]
    public partial class View_full_allowance_mainController : ApiBaseController<IView_full_allowance_mainService>
    {
        public View_full_allowance_mainController(IView_full_allowance_mainService service)
        : base(service)
        {
        }
    }
}

