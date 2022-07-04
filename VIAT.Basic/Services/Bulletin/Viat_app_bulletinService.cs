/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_bulletinService与IViat_app_bulletinService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_app_bulletinService : ServiceBase<Viat_app_bulletin, IViat_app_bulletinRepository>
    , IViat_app_bulletinService, IDependency
    {
    public Viat_app_bulletinService(IViat_app_bulletinRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_bulletinService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_bulletinService>(); } }
    }
 }
