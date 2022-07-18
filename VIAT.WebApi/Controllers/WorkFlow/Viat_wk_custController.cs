/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_wk_custController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.WorkFlow.IServices;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/Viat_wk_cust")]
    [PermissionTable(Name = "Viat_wk_cust")]
    public partial class Viat_wk_custController : ApiBaseController<IViat_wk_custService>
    {
        public Viat_wk_custController(IViat_wk_custService service)
        : base(service)
        {
        }
    }
}

