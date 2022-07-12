/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_cust_groupService与IViat_app_cust_groupService中编写
 */
using VIAT.Price.IRepositories;
using VIAT.Price.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.Services
{
    public partial class Viat_app_cust_groupService : ServiceBase<Viat_app_cust_group, IViat_app_cust_groupRepository>
    , IViat_app_cust_groupService, IDependency
    {
    public Viat_app_cust_groupService(IViat_app_cust_groupRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_cust_groupService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_cust_groupService>(); } }
    }
 }
