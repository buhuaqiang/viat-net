/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_cust_price_groupController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Price.IServices;
using VIAT.Entity.DomainModels;
using VIAT.Core.Filters;

namespace VIAT.Price.Controllers
{
    [Route("api/Viat_app_cust_price_group")]
    [PermissionTable(Name = "Viat_app_cust_price_group")]
    public partial class Viat_app_cust_price_groupController : ApiBaseController<IViat_app_cust_price_groupService>
    {
        public Viat_app_cust_price_groupController(IViat_app_cust_price_groupService service)
        : base(service)
        {
        }
        [ApiActionPermission]
        [HttpPost, Route("GetPopPageData")]
        public  ActionResult GetPopPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }
    }
}

