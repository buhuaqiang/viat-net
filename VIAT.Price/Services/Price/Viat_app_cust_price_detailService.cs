/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_cust_price_detailService与IViat_app_cust_price_detailService中编写
 */
using VIAT.Price.IRepositories;
using VIAT.Price.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.Services
{
    public partial class Viat_app_cust_price_detailService : ServiceBase<Viat_app_cust_price_detail, IViat_app_cust_price_detailRepository>
    , IViat_app_cust_price_detailService, IDependency
    {
    public Viat_app_cust_price_detailService(IViat_app_cust_price_detailRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_cust_price_detailService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_cust_price_detailService>(); } }
    }
 }
