/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_imp_error_logController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/Viat_imp_error_log")]
    [PermissionTable(Name = "Viat_imp_error_log")]
    public partial class Viat_imp_error_logController : ApiBaseController<IViat_imp_error_logService>
    {
        public Viat_imp_error_logController(IViat_imp_error_logService service)
        : base(service)
        {
        }
    }
}

