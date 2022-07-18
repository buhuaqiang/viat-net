/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_wk_cont_stretagy_detail_mainController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Core.Filters;
using VIAT.Entity.AttributeManager;
using VIAT.Entity.DomainModels;
using VIAT.WorkFlow.IServices;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/View_wk_cont_stretagy_detail_main")]
    [PermissionTable(Name = "View_wk_cont_stretagy_detail_main")]
    public partial class View_wk_cont_stretagy_detail_mainController : ApiBaseController<IView_wk_cont_stretagy_detail_mainService>
    {
        public View_wk_cont_stretagy_detail_mainController(IView_wk_cont_stretagy_detail_mainService service)
        : base(service)
        {
        }

        [HttpPost, Route("GetPageData")]
        [ApiActionPermission()]
        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {

            return base.GetPageData(loadData);
        }
    }
}

