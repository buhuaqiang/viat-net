/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_sys_deputyService与IViat_sys_deputyService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_sys_deputyService : ServiceBase<Viat_sys_deputy, IViat_sys_deputyRepository>
    , IViat_sys_deputyService, IDependency
    {
    public Viat_sys_deputyService(IViat_sys_deputyRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_sys_deputyService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_sys_deputyService>(); } }
    }
 }
