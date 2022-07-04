/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_power_contract_free_prodService与IViat_app_power_contract_free_prodService中编写
 */
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Contract.Services
{
    public partial class Viat_app_power_contract_free_prodService : ServiceBase<Viat_app_power_contract_free_prod_select, IViat_app_power_contract_free_prodRepository>
    , IViat_app_power_contract_free_prodService, IDependency
    {
    public Viat_app_power_contract_free_prodService(IViat_app_power_contract_free_prodRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_power_contract_free_prodService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_power_contract_free_prodService>(); } }
    }


 }
