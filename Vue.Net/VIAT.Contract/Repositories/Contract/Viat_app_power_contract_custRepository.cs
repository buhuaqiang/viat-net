/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_app_power_contract_custRepository编写代码
 */
using VIAT.Contract.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Contract.Repositories
{
    public partial class Viat_app_power_contract_custRepository : RepositoryBase<Viat_app_power_contract_cust> , IViat_app_power_contract_custRepository
    {
    public Viat_app_power_contract_custRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_app_power_contract_custRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_app_power_contract_custRepository>(); } }
    }
}
