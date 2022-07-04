/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_full_allowance_sharingService与IView_full_allowance_sharingService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class View_full_allowance_sharingService : ServiceBase<View_full_allowance_sharing, IView_full_allowance_sharingRepository>
    , IView_full_allowance_sharingService, IDependency
    {
    public View_full_allowance_sharingService(IView_full_allowance_sharingRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_full_allowance_sharingService Instance
    {
      get { return AutofacContainerModule.GetService<IView_full_allowance_sharingService>(); } }
    }
 }
