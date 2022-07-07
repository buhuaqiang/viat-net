/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_app_hp_contract_allw_sumRepository编写代码
 */
using VIAT.DataEntry.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Repositories
{
    public partial class Viat_app_hp_contract_allw_sumRepository : RepositoryBase<Viat_app_hp_contract_allw_sum> , IViat_app_hp_contract_allw_sumRepository
    {
    public Viat_app_hp_contract_allw_sumRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_app_hp_contract_allw_sumRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_app_hp_contract_allw_sumRepository>(); } }
    }
}
