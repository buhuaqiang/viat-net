/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_sys_deputyService与IView_sys_deputyService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_sys_deputyService : ServiceBase<View_sys_deputy, IView_sys_deputyRepository>
    , IView_sys_deputyService, IDependency
    {
    public View_sys_deputyService(IView_sys_deputyRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_sys_deputyService Instance
    {
      get { return AutofacContainerModule.GetService<IView_sys_deputyService>(); } }
    }
 }
