/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_com_cust_deliveryController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_com_cust_delivery")]
    [PermissionTable(Name = "Viat_com_cust_delivery")]
    public partial class Viat_com_cust_deliveryController : ApiBaseController<IViat_com_cust_deliveryService>
    {
        public Viat_com_cust_deliveryController(IViat_com_cust_deliveryService service)
        : base(service)
        {
        }
    }
}

