/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_price_distributor_mappingService与IView_price_distributor_mappingService中编写
 */
using VIAT.Price.IRepositories;
using VIAT.Price.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.Services
{
    public partial class View_price_distributor_mappingService : ServiceBase<View_price_distributor_mapping, IView_price_distributor_mappingRepository>
    , IView_price_distributor_mappingService, IDependency
    {
    public View_price_distributor_mappingService(IView_price_distributor_mappingRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_price_distributor_mappingService Instance
    {
      get { return AutofacContainerModule.GetService<IView_price_distributor_mappingService>(); } }
    }
 }
