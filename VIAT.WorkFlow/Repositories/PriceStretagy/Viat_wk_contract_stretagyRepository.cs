/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_wk_contract_stretagyRepository编写代码
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Repositories
{
    public partial class Viat_wk_contract_stretagyRepository : RepositoryBase<Viat_wk_contract_stretagy> , IViat_wk_contract_stretagyRepository
    {
    public Viat_wk_contract_stretagyRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_wk_contract_stretagyRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_wk_contract_stretagyRepository>(); } }
    }
}
