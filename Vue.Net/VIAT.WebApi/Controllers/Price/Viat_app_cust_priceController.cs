/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_cust_priceController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Price.IServices;
namespace VIAT.Price.Controllers
{
    [Route("api/Viat_app_cust_price")]
    [PermissionTable(Name = "Viat_app_cust_price")]
    public partial class Viat_app_cust_priceController : ApiBaseController<IViat_app_cust_priceService>
    {
        public Viat_app_cust_priceController(IViat_app_cust_priceService service)
        : base(service)
        {
        }
    }
}

