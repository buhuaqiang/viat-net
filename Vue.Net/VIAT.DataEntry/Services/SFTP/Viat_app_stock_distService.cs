/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_stock_distService与IViat_app_stock_distService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class Viat_app_stock_distService : ServiceBase<Viat_app_stock_dist, IViat_app_stock_distRepository>
    , IViat_app_stock_distService, IDependency
    {
    public Viat_app_stock_distService(IViat_app_stock_distRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_stock_distService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_stock_distService>(); } }
    }
 }
