/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_invoice_finderController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataProcessing.IServices;
namespace VIAT.DataProcessing.Controllers
{
    [Route("api/View_invoice_finder")]
    [PermissionTable(Name = "View_invoice_finder")]
    public partial class View_invoice_finderController : ApiBaseController<IView_invoice_finderService>
    {
        public View_invoice_finderController(IView_invoice_finderService service)
        : base(service)
        {
        }
    }
}

