/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹App_AppointmentRepository编写代码
 */
using VIAT.Order.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Order.Repositories
{
    public partial class App_AppointmentRepository : RepositoryBase<App_Appointment> , IApp_AppointmentRepository
    {
    public App_AppointmentRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IApp_AppointmentRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IApp_AppointmentRepository>(); } }
    }
}
