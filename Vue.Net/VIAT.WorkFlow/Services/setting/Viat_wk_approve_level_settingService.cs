/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_wk_approve_level_settingService与IViat_wk_approve_level_settingService中编写
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.WorkFlow.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Services
{
    public partial class Viat_wk_approve_level_settingService : ServiceBase<Viat_wk_approve_level_setting, IViat_wk_approve_level_settingRepository>
    , IViat_wk_approve_level_settingService, IDependency
    {
    public Viat_wk_approve_level_settingService(IViat_wk_approve_level_settingRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_wk_approve_level_settingService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_wk_approve_level_settingService>(); } }
    }
 }
