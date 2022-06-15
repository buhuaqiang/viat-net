/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_bulletinController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_app_bulletin")]
    [PermissionTable(Name = "Viat_app_bulletin")]
    public partial class Viat_app_bulletinController : ApiBaseController<IViat_app_bulletinService>
    {
        public Viat_app_bulletinController(IViat_app_bulletinService service)
        : base(service)
        {
        }
    }
}

