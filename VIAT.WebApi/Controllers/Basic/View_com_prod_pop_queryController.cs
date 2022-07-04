/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_com_prod_pop_queryController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
using VIAT.Core.Filters;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Controllers
{
    [Route("api/View_com_prod_pop_query")]
    [PermissionTable(Name = "View_com_prod_pop_query")]
    public partial class View_com_prod_pop_queryController : ApiBaseController<IView_com_prod_pop_queryService>
    {
        public View_com_prod_pop_queryController(IView_com_prod_pop_queryService service)
        : base(service)
        {
        }
         [ApiActionPermission]
        [HttpPost, Route("GetProdPageData")]
        public ActionResult GetPopPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }

    }
}

