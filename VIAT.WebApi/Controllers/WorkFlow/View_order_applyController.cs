/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_order_applyController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.WorkFlow.IServices;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/View_order_apply")]
    [PermissionTable(Name = "View_order_apply")]
    public partial class View_order_applyController : ApiBaseController<IView_order_applyService>
    {
        public View_order_applyController(IView_order_applyService service)
        : base(service)
        {
        }
    }
}

