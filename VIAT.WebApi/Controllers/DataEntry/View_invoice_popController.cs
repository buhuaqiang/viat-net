/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_invoice_popController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
using VIAT.Core.Filters;
using VIAT.Entity.DomainModels;


namespace VIAT.DataEntry.Controllers
{
    [Route("api/View_invoice_pop")]
    [PermissionTable(Name = "View_invoice_pop")]
    public partial class View_invoice_popController : ApiBaseController<IView_invoice_popService>
    {
        public View_invoice_popController(IView_invoice_popService service)
        : base(service)
        {
        }

         [ApiActionPermission]
        [HttpPost, Route("GetInvoicePageData")]
        public ActionResult GetPopPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }
    }
}

