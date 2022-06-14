/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_cust_custgroup_pricegroupController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Price.IServices;
using VOL.Entity.DomainModels;
using VOL.Core.Filters;

namespace VIAT.Price.Controllers
{
    [Route("api/View_cust_custgroup_pricegroup")]
    [PermissionTable(Name = "View_cust_custgroup_pricegroup")]
    public partial class View_cust_custgroup_pricegroupController : ApiBaseController<IView_cust_custgroup_pricegroupService>
    {
        public View_cust_custgroup_pricegroupController(IView_cust_custgroup_pricegroupService service)
        : base(service)
        {
        }

        [ApiActionPermission]
        [HttpPost, Route("GetPageData")]
        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }
    }
}

