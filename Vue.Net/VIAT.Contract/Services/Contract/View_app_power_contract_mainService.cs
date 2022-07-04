/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_app_power_contract_mainService与IView_app_power_contract_mainService中编写
 */
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Contract.Services
{
    public partial class View_app_power_contract_mainService : ServiceBase<View_app_power_contract_main, IView_app_power_contract_mainRepository>
    , IView_app_power_contract_mainService, IDependency
    {
    public View_app_power_contract_mainService(IView_app_power_contract_mainRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_app_power_contract_mainService Instance
    {
      get { return AutofacContainerModule.GetService<IView_app_power_contract_mainService>(); } }
    }
 }
