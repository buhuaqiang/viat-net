/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_com_cust_deliveryController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_com_cust_delivery")]
    [PermissionTable(Name = "View_com_cust_delivery")]
    public partial class View_com_cust_deliveryController : ApiBaseController<IView_com_cust_deliveryService>
    {
        public View_com_cust_deliveryController(IView_com_cust_deliveryService service)
        : base(service)
        {
        }
    }
}

