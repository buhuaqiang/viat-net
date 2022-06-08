/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_com_custController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
using VOL.Core.Filters;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Controllers
{
    [Route("api/View_com_cust")]
    [PermissionTable(Name = "View_com_cust")]
    public partial class View_com_custController : ApiBaseController<IView_com_custService>
    {
        public View_com_custController(IView_com_custService service)
        : base(service)
        {
        }

        [ApiActionPermission]
        [HttpPost, Route("GetPopPageData")]
        public ActionResult GetPopPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }
    }
}

