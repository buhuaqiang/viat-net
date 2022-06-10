/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹ViewDIstMarginController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/ViewDIstMargin")]
    [PermissionTable(Name = "ViewDIstMargin")]
    public partial class ViewDIstMarginController : ApiBaseController<IViewDIstMarginService>
    {
        public ViewDIstMarginController(IViewDIstMarginService service)
        : base(service)
        {
        }
    }
}

