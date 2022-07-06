/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_nhi_adjust_detailController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/View_nhi_adjust_detail")]
    [PermissionTable(Name = "View_nhi_adjust_detail")]
    public partial class View_nhi_adjust_detailController : ApiBaseController<IView_nhi_adjust_detailService>
    {
        public View_nhi_adjust_detailController(IView_nhi_adjust_detailService service)
        : base(service)
        {
        }
    }
}

