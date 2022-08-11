/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_stock_viatrisController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/Viat_app_stock_viatris")]
    [PermissionTable(Name = "Viat_app_stock_viatris")]
    public partial class Viat_app_stock_viatrisController : ApiBaseController<IViat_app_stock_viatrisService>
    {
        public Viat_app_stock_viatrisController(IViat_app_stock_viatrisService service)
        : base(service)
        {
        }
    }
}

