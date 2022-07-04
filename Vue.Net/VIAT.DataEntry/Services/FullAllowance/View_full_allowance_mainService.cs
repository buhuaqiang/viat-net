/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_full_allowance_mainService与IView_full_allowance_mainService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class View_full_allowance_mainService : ServiceBase<View_full_allowance_main, IView_full_allowance_mainRepository>
    , IView_full_allowance_mainService, IDependency
    {
    public View_full_allowance_mainService(IView_full_allowance_mainRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_full_allowance_mainService Instance
    {
      get { return AutofacContainerModule.GetService<IView_full_allowance_mainService>(); } }
    }
 }
