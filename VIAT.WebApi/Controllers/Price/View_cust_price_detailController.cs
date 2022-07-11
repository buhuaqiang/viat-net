/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_cust_price_detailController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Price.IServices;
using VIAT.Entity.DomainModels;
using VIAT.Core.Filters;

namespace VIAT.Price.Controllers
{
    [Route("api/View_cust_price_detail")]
    [PermissionTable(Name = "View_cust_price_detail")]
    public partial class View_cust_price_detailController : ApiBaseController<IView_cust_price_detailService>
    {
        public View_cust_price_detailController(IView_cust_price_detailService service)
        : base(service)
        {
        }


        [HttpPost, Route("GetPageData")]
        [ApiActionPermission()]
        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            //处理Prods
            _service.setQueryParameters();
            return base.GetPageData(loadData);
        }
    }
}

