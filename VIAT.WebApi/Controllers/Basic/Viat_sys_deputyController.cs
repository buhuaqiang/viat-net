/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_sys_deputyController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_sys_deputy")]
    [PermissionTable(Name = "Viat_sys_deputy")]
    public partial class Viat_sys_deputyController : ApiBaseController<IViat_sys_deputyService>
    {
        public Viat_sys_deputyController(IViat_sys_deputyService service)
        : base(service)
        {
        }
    }
}

