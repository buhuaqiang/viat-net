/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_wk_approve_level_settingController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.WorkFlow.IServices;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/Viat_wk_approve_level_setting")]
    [PermissionTable(Name = "Viat_wk_approve_level_setting")]
    public partial class Viat_wk_approve_level_settingController : ApiBaseController<IViat_wk_approve_level_settingService>
    {
        public Viat_wk_approve_level_settingController(IViat_wk_approve_level_settingService service)
        : base(service)
        {
        }
    }
}

