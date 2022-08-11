/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_stock_distController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/Viat_app_stock_dist")]
    [PermissionTable(Name = "Viat_app_stock_dist")]
    public partial class Viat_app_stock_distController : ApiBaseController<IViat_app_stock_distService>
    {
        public Viat_app_stock_distController(IViat_app_stock_distService service)
        : base(service)
        {
        }
    }
}

