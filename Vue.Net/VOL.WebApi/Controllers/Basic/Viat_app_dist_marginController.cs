/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_dist_marginController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_app_dist_margin")]
    [PermissionTable(Name = "Viat_app_dist_margin")]
    public partial class Viat_app_dist_marginController : ApiBaseController<IViat_app_dist_marginService>
    {
        public Viat_app_dist_marginController(IViat_app_dist_marginService service)
        : base(service)
        {
        }
    }
}
