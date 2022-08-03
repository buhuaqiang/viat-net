/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_sftp_importController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/Viat_sftp_import")]
    [PermissionTable(Name = "Viat_sftp_import")]
    public partial class Viat_sftp_importController : ApiBaseController<IViat_sftp_importService>
    {
        public Viat_sftp_importController(IViat_sftp_importService service)
        : base(service)
        {
        }
    }
}

