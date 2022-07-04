/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_com_close_period_marginService与IView_com_close_period_marginService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_com_close_period_marginService : ServiceBase<View_com_close_period_margin, IView_com_close_period_marginRepository>
    , IView_com_close_period_marginService, IDependency
    {
    public View_com_close_period_marginService(IView_com_close_period_marginRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_com_close_period_marginService Instance
    {
      get { return AutofacContainerModule.GetService<IView_com_close_period_marginService>(); } }
    }
 }
