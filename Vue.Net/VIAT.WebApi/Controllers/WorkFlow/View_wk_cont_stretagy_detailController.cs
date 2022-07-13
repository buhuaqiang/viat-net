/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_wk_cont_stretagy_detailController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.WorkFlow.IServices;
using VIAT.Core.Filters;
using VIAT.Entity.DomainModels;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/View_wk_cont_stretagy_detail")]
    [PermissionTable(Name = "View_wk_cont_stretagy_detail")]
    public partial class View_wk_cont_stretagy_detailController : ApiBaseController<IView_wk_cont_stretagy_detailService>
    {
        public View_wk_cont_stretagy_detailController(IView_wk_cont_stretagy_detailService service)
        : base(service)
        {
        }
        [ApiActionPermission]
        [HttpPost, Route("GetStretagyDetailPageData")]
        public ActionResult GetStretagyDetailPageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }
    }
}

