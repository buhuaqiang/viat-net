/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_imp_error_logRepository编写代码
 */
using VIAT.DataEntry.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Repositories
{
    public partial class Viat_imp_error_logRepository : RepositoryBase<Viat_imp_error_log> , IViat_imp_error_logRepository
    {
    public Viat_imp_error_logRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_imp_error_logRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_imp_error_logRepository>(); } }
    }
}
