/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_cust_order_transferController编写
 */
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VIAT.Core.Controllers.Basic;
using VIAT.Core.Filters;
using VIAT.Entity.AttributeManager;
using VIAT.Entity.DomainModels;
using VIAT.WorkFlow.IServices;
namespace VIAT.WorkFlow.Controllers
{
   
    public partial class View_cust_order_transfer_AllController : ApiBaseController<IView_cust_order_transferService>
    {
        private readonly IView_cust_order_transferService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public View_cust_order_transfer_AllController(
            IView_cust_order_transferService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        [ApiActionPermission]
        [HttpPost, Route("GetPageData")]
        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            return Json(_service.GetAllPageData(loadData));
        }


    }
}

