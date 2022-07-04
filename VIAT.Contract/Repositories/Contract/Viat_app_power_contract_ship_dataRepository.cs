/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_app_power_contract_ship_dataRepository编写代码
 */
using VIAT.Contract.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Contract.Repositories
{
    public partial class Viat_app_power_contract_ship_dataRepository : RepositoryBase<Viat_app_power_contract_ship_data> , IViat_app_power_contract_ship_dataRepository
    {
    public Viat_app_power_contract_ship_dataRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_app_power_contract_ship_dataRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_app_power_contract_ship_dataRepository>(); } }
    }
}
