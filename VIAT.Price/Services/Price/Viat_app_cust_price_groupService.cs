/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_cust_price_groupService与IViat_app_cust_price_groupService中编写
 */
using VIAT.Price.IRepositories;
using VIAT.Price.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Price.Services
{
    public partial class Viat_app_cust_price_groupService : ServiceBase<Viat_app_cust_price_group, IViat_app_cust_price_groupRepository>
    , IViat_app_cust_price_groupService, IDependency
    {
    public Viat_app_cust_price_groupService(IViat_app_cust_price_groupRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_cust_price_groupService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_cust_price_groupService>(); } }
    }

   
}
