/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_cust_price_transferController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.WorkFlow.IServices;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/View_cust_price_transfer")]
    [PermissionTable(Name = "View_cust_price_transfer")]
    public partial class View_cust_price_transferController : ApiBaseController<IView_cust_price_transferService>
    {
        public View_cust_price_transferController(IView_cust_price_transferService service)
        : base(service)
        {
        }
    }
}

