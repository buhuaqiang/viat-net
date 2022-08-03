/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_order_applyService与IView_order_applyService中编写
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.WorkFlow.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Services
{
    public partial class View_order_applyService : ServiceBase<View_order_apply, IView_order_applyRepository>
    , IView_order_applyService, IDependency
    {
    public View_order_applyService(IView_order_applyRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_order_applyService Instance
    {
      get { return AutofacContainerModule.GetService<IView_order_applyService>(); } }
    }
 }
