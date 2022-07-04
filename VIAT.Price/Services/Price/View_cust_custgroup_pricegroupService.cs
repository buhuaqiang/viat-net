/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_cust_custgroup_pricegroupService与IView_cust_custgroup_pricegroupService中编写
 */
using VIAT.Price.IRepositories;
using VIAT.Price.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.Services
{
    public partial class View_cust_custgroup_pricegroupService : ServiceBase<View_cust_custgroup_pricegroup, IView_cust_custgroup_pricegroupRepository>
    , IView_cust_custgroup_pricegroupService, IDependency
    {
    public View_cust_custgroup_pricegroupService(IView_cust_custgroup_pricegroupRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_cust_custgroup_pricegroupService Instance
    {
      get { return AutofacContainerModule.GetService<IView_cust_custgroup_pricegroupService>(); } }
    }
 }
