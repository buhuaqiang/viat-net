/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_wk_bid_detailService与IViat_wk_bid_detailService中编写
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.WorkFlow.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Services
{
    public partial class Viat_wk_bid_detailService : ServiceBase<Viat_wk_bid_detail, IViat_wk_bid_detailRepository>
    , IViat_wk_bid_detailService, IDependency
    {
    public Viat_wk_bid_detailService(IViat_wk_bid_detailRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_wk_bid_detailService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_wk_bid_detailService>(); } }
    }
 }
