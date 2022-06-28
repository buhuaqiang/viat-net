/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_dist_mappingController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Price.IServices;
namespace VIAT.Price.Controllers
{
    [Route("api/Viat_app_dist_mapping")]
    [PermissionTable(Name = "Viat_app_dist_mapping")]
    public partial class Viat_app_dist_mappingController : ApiBaseController<IViat_app_dist_mappingService>
    {
        public Viat_app_dist_mappingController(IViat_app_dist_mappingService service)
        : base(service)
        {
        }
    }
}

