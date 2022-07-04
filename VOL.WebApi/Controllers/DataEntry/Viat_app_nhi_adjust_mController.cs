/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_nhi_adjust_mController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/Viat_app_nhi_adjust_m")]
    [PermissionTable(Name = "Viat_app_nhi_adjust_m")]
    public partial class Viat_app_nhi_adjust_mController : ApiBaseController<IViat_app_nhi_adjust_mService>
    {
        public Viat_app_nhi_adjust_mController(IViat_app_nhi_adjust_mService service)
        : base(service)
        {
        }
    }
}

