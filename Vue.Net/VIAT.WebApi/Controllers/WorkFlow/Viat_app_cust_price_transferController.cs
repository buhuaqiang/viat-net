/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_cust_price_transferController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.WorkFlow.IServices;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/Viat_app_cust_price_transfer")]
    [PermissionTable(Name = "Viat_app_cust_price_transfer")]
    public partial class Viat_app_cust_price_transferController : ApiBaseController<IViat_app_cust_price_transferService>
    {
        public Viat_app_cust_price_transferController(IViat_app_cust_price_transferService service)
        : base(service)
        {
        }
    }
}

