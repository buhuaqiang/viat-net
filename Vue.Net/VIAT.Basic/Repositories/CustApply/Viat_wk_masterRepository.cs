/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_wk_masterRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class Viat_wk_masterRepository : RepositoryBase<Viat_wk_master> , IViat_wk_masterRepository
    {
    public Viat_wk_masterRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_wk_masterRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_wk_masterRepository>(); } }
    }
}
