/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_com_zip_cityController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_com_zip_city")]
    [PermissionTable(Name = "Viat_com_zip_city")]
    public partial class Viat_com_zip_cityController : ApiBaseController<IViat_com_zip_cityService>
    {
        public Viat_com_zip_cityController(IViat_com_zip_cityService service)
        : base(service)
        {
        }
    }
}

