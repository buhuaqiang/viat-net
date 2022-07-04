/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹SellOrderListController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.AppManager.IServices;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Order.IServices;
namespace VIAT.Order.Controllers
{
    [Route("api/SellOrderList")]
    [PermissionTable(Name = "SellOrderList")]
    public partial class SellOrderListController : ApiBaseController<ISellOrderListService>
    {
        public SellOrderListController(ISellOrderListService service)
        : base("Order","Order","SellOrderList", service)
        {
        }
    }
}

