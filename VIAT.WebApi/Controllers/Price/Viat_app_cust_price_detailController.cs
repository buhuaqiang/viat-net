/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_cust_price_detailController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Price.IServices;
namespace VIAT.Price.Controllers
{
    [Route("api/Viat_app_cust_price_detail")]
    [PermissionTable(Name = "Viat_app_cust_price_detail")]
    public partial class Viat_app_cust_price_detailController : ApiBaseController<IViat_app_cust_price_detailService>
    {
        public Viat_app_cust_price_detailController(IViat_app_cust_price_detailService service)
        : base(service)
        {
        }
    }
}

