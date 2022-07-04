/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_nhi_adjustController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/View_nhi_adjust")]
    [PermissionTable(Name = "View_nhi_adjust")]
    public partial class View_nhi_adjustController : ApiBaseController<IView_nhi_adjustService>
    {
        public View_nhi_adjustController(IView_nhi_adjustService service)
        : base(service)
        {
        }
    }
}

