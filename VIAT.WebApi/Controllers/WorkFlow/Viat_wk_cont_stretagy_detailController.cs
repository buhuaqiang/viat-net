/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_wk_cont_stretagy_detailController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.WorkFlow.IServices;
using VIAT.Core.Filters;
using VIAT.Entity.DomainModels;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/Viat_wk_cont_stretagy_detail")]
    [PermissionTable(Name = "Viat_wk_cont_stretagy_detail")]
    public partial class Viat_wk_cont_stretagy_detailController : ApiBaseController<IViat_wk_cont_stretagy_detailService>
    {
        public Viat_wk_cont_stretagy_detailController(IViat_wk_cont_stretagy_detailService service)
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

