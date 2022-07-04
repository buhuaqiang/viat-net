/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_full_allowance_reverseController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/View_full_allowance_reverse")]
    [PermissionTable(Name = "View_full_allowance_reverse")]
    public partial class View_full_allowance_reverseController : ApiBaseController<IView_full_allowance_reverseService>
    {
        public View_full_allowance_reverseController(IView_full_allowance_reverseService service)
        : base(service)
        {
        }
    }
}

