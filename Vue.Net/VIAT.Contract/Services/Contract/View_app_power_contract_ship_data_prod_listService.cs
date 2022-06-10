/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_app_power_contract_ship_data_prod_listService与IView_app_power_contract_ship_data_prod_listService中编写
 */
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Contract.Services
{
    public partial class View_app_power_contract_ship_data_prod_listService : ServiceBase<View_app_power_contract_ship_data_prod_list, IView_app_power_contract_ship_data_prod_listRepository>
    , IView_app_power_contract_ship_data_prod_listService, IDependency
    {
    public View_app_power_contract_ship_data_prod_listService(IView_app_power_contract_ship_data_prod_listRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_app_power_contract_ship_data_prod_listService Instance
    {
      get { return AutofacContainerModule.GetService<IView_app_power_contract_ship_data_prod_listService>(); } }
    }
 }
