/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_dist_mappingService与IViat_app_dist_mappingService中编写
 */
using VIAT.Price.IRepositories;
using VIAT.Price.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.Services
{
    public partial class Viat_app_dist_mappingService : ServiceBase<Viat_app_dist_mapping, IViat_app_dist_mappingRepository>
    , IViat_app_dist_mappingService, IDependency
    {
    public Viat_app_dist_mappingService(IViat_app_dist_mappingRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_dist_mappingService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_dist_mappingService>(); } }
    }
 }
