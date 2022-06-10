/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下ViewDIstMarginService与IViewDIstMarginService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class ViewDIstMarginService : ServiceBase<ViewDIstMargin, IViewDIstMarginRepository>
    , IViewDIstMarginService, IDependency
    {
    public ViewDIstMarginService(IViewDIstMarginRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViewDIstMarginService Instance
    {
      get { return AutofacContainerModule.GetService<IViewDIstMarginService>(); } }
    }
 }
