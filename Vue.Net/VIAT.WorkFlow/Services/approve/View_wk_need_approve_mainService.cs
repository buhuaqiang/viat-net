/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_wk_need_approve_mainService与IView_wk_need_approve_mainService中编写
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.WorkFlow.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Services
{
    public partial class View_wk_need_approve_mainService : ServiceBase<View_wk_need_approve_main, IView_wk_need_approve_mainRepository>
    , IView_wk_need_approve_mainService, IDependency
    {
    public View_wk_need_approve_mainService(IView_wk_need_approve_mainRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_wk_need_approve_mainService Instance
    {
      get { return AutofacContainerModule.GetService<IView_wk_need_approve_mainService>(); } }
    }
 }
