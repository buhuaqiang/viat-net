/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_full_allowance_adjustmentService与IView_full_allowance_adjustmentService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class View_full_allowance_adjustmentService : ServiceBase<View_full_allowance_adjustment, IView_full_allowance_adjustmentRepository>
    , IView_full_allowance_adjustmentService, IDependency
    {
    public View_full_allowance_adjustmentService(IView_full_allowance_adjustmentRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_full_allowance_adjustmentService Instance
    {
      get { return AutofacContainerModule.GetService<IView_full_allowance_adjustmentService>(); } }
    }
 }
