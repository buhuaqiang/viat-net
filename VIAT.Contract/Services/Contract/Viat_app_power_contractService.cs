/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_power_contractService与IViat_app_power_contractService中编写
 */
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Contract.Services
{
    public partial class Viat_app_power_contractService : ServiceBase<Viat_app_power_contract, IViat_app_power_contractRepository>
    , IViat_app_power_contractService, IDependency
    {
    public Viat_app_power_contractService(IViat_app_power_contractRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_power_contractService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_power_contractService>(); } }
    }
 }
