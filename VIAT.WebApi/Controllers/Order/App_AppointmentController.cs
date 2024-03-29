/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹App_AppointmentController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Order.IServices;
namespace VIAT.Order.Controllers
{
    [Route("api/App_Appointment")]
    [PermissionTable(Name = "App_Appointment")]
    public partial class App_AppointmentController : ApiBaseController<IApp_AppointmentService>
    {
        public App_AppointmentController(IApp_AppointmentService service)
        : base("Order","Appointment","App_Appointment", service)
        {
        }
    }
}

