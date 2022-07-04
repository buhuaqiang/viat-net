/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下App_AppointmentService与IApp_AppointmentService中编写
 */
using VIAT.Order.IRepositories;
using VIAT.Order.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Order.Services
{
    public partial class App_AppointmentService : ServiceBase<App_Appointment, IApp_AppointmentRepository>, IApp_AppointmentService, IDependency
    {
        public App_AppointmentService(IApp_AppointmentRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IApp_AppointmentService Instance
        {
           get { return AutofacContainerModule.GetService<IApp_AppointmentService>(); }
        }
    }
}
