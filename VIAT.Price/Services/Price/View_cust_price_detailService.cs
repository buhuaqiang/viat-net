/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_cust_price_detailService与IView_cust_price_detailService中编写
 */
using VIAT.Price.IRepositories;
using VIAT.Price.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Price.Services
{
    public partial class View_cust_price_detailService : ServiceBase<View_cust_price_detail, IView_cust_price_detailRepository>
    , IView_cust_price_detailService, IDependency
    {
    public View_cust_price_detailService(IView_cust_price_detailRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_cust_price_detailService Instance
    {
      get { return AutofacContainerModule.GetService<IView_cust_price_detailService>(); } }
    }
 }
