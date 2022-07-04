/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_nhi_adjustService与IView_nhi_adjustService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class View_nhi_adjustService : ServiceBase<View_nhi_adjust, IView_nhi_adjustRepository>
    , IView_nhi_adjustService, IDependency
    {
    public View_nhi_adjustService(IView_nhi_adjustRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_nhi_adjustService Instance
    {
      get { return AutofacContainerModule.GetService<IView_nhi_adjustService>(); } }
    }
 }
