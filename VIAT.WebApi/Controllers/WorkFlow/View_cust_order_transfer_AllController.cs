/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_cust_order_transferController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Core.Filters;
using VIAT.Entity.AttributeManager;
using VIAT.Entity.DomainModels;
using VIAT.WorkFlow.IServices;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/allOrderTransfer")]
    [PermissionTable(Name = "allOrderTransfer")]
    public partial class View_cust_order_transfer_AllController : ApiBaseController<IView_cust_order_transferService>
    {
        IView_cust_order_transferService transferService;
        public View_cust_order_transfer_AllController(IView_cust_order_transferService service)
        : base(service)
        {
            this.transferService = service;
        }

        [HttpPost, Route("GetPageData")]
        [ApiActionPermission()]
        public ActionResult GetPageData1([FromBody] PageDataOptions loadData)
        {
            
            return Json(transferService.GetAllPageData(loadData));
        }
    }
}

