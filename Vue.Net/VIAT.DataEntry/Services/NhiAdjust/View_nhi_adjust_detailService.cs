/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_nhi_adjust_detailService与IView_nhi_adjust_detailService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class View_nhi_adjust_detailService : ServiceBase<View_nhi_adjust_detail, IView_nhi_adjust_detailRepository>
    , IView_nhi_adjust_detailService, IDependency
    {
    public View_nhi_adjust_detailService(IView_nhi_adjust_detailRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_nhi_adjust_detailService Instance
    {
      get { return AutofacContainerModule.GetService<IView_nhi_adjust_detailService>(); } }
    }
 }
