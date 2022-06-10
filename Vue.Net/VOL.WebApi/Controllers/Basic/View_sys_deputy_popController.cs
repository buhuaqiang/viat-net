/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_sys_deputy_popController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_sys_deputy_pop")]
    [PermissionTable(Name = "View_sys_deputy_pop")]
    public partial class View_sys_deputy_popController : ApiBaseController<IView_sys_deputy_popService>
    {
        public View_sys_deputy_popController(IView_sys_deputy_popService service)
        : base(service)
        {
        }
    }
}

