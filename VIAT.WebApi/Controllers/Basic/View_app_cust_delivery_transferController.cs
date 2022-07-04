/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_app_cust_delivery_transferController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_app_cust_delivery_transfer")]
    [PermissionTable(Name = "View_app_cust_delivery_transfer")]
    public partial class View_app_cust_delivery_transferController : ApiBaseController<IView_app_cust_delivery_transferService>
    {
        public View_app_cust_delivery_transferController(IView_app_cust_delivery_transferService service)
        : base(service)
        {
        }
    }
}

