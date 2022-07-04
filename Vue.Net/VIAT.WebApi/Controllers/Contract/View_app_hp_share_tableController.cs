/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_app_hp_share_tableController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Contract.IServices;
using VIAT.Core.Filters;
using VIAT.Entity.DomainModels;


namespace VIAT.Contract.Controllers
{
    [Route("api/View_app_hp_share_table")]
    [PermissionTable(Name = "View_app_hp_share_table")]
    public partial class View_app_hp_share_tableController : ApiBaseController<IView_app_hp_share_tableService>
    {
        public View_app_hp_share_tableController(IView_app_hp_share_tableService service)
        : base(service)
        {
        }
        [ApiActionPermission]
        [HttpPost, Route("GetShareTablePageData")]
        public ActionResult GetShareTablePageData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }
    }
}

