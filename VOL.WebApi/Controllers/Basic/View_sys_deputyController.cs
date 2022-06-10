/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_sys_deputyController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
using VOL.Core.Filters;
using VOL.Entity.DomainModels;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_sys_deputy")]
    [PermissionTable(Name = "View_sys_deputy")]
    public partial class View_sys_deputyController : ApiBaseController<IView_sys_deputyService>
    {
        public View_sys_deputyController(IView_sys_deputyService service)
        : base(service)
        {
        }
    }
}

