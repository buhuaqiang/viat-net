/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_app_power_contract_mainRepository编写代码
 */
using VIAT.Contract.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Contract.Repositories
{
    public partial class View_app_power_contract_mainRepository : RepositoryBase<View_app_power_contract_main> , IView_app_power_contract_mainRepository
    {
    public View_app_power_contract_mainRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_app_power_contract_mainRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_app_power_contract_mainRepository>(); } }
    }
}
