/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_bulletin_receiverController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_app_bulletin_receiver")]
    [PermissionTable(Name = "Viat_app_bulletin_receiver")]
    public partial class Viat_app_bulletin_receiverController : ApiBaseController<IViat_app_bulletin_receiverService>
    {
        public Viat_app_bulletin_receiverController(IViat_app_bulletin_receiverService service)
        : base(service)
        {
        }
    }
}

