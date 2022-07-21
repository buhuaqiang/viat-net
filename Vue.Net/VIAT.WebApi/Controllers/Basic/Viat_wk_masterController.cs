/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_wk_masterController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_wk_master")]
    [PermissionTable(Name = "Viat_wk_master")]
    public partial class Viat_wk_masterController : ApiBaseController<IViat_wk_masterService>
    {
        public Viat_wk_masterController(IViat_wk_masterService service)
        : base(service)
        {
        }
    }
}

