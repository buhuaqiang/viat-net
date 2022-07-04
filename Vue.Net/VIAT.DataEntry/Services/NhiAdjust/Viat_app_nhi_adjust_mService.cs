/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_nhi_adjust_mService与IViat_app_nhi_adjust_mService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class Viat_app_nhi_adjust_mService : ServiceBase<Viat_app_nhi_adjust_m, IViat_app_nhi_adjust_mRepository>
    , IViat_app_nhi_adjust_mService, IDependency
    {
    public Viat_app_nhi_adjust_mService(IViat_app_nhi_adjust_mRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_nhi_adjust_mService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_nhi_adjust_mService>(); } }
    }
 }
