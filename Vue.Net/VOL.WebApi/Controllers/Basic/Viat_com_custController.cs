/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_com_custController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_com_cust")]
    [PermissionTable(Name = "Viat_com_cust")]
    public partial class Viat_com_custController : ApiBaseController<IViat_com_custService>
    {
        public Viat_com_custController(IViat_com_custService service)
        : base(service)
        {
        }
    }
}

