/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹view_dist_marginController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/view_dist_margin")]
    [PermissionTable(Name = "view_dist_margin")]
    public partial class view_dist_marginController : ApiBaseController<Iview_dist_marginService>
    {
        public view_dist_marginController(Iview_dist_marginService service)
        : base(service)
        {
        }
    }
}

