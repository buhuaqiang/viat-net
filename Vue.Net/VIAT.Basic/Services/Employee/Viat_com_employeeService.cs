/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_com_employeeService与IViat_com_employeeService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_employeeService : ServiceBase<Viat_com_employee, IViat_com_employeeRepository>
    , IViat_com_employeeService, IDependency
    {
    public Viat_com_employeeService(IViat_com_employeeRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_com_employeeService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_com_employeeService>(); } }
    }
 }
