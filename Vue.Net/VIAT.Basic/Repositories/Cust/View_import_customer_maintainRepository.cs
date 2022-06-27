/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_import_customer_maintainRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class View_import_customer_maintainRepository : RepositoryBase<View_import_customer_maintain> , IView_import_customer_maintainRepository
    {
    public View_import_customer_maintainRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_import_customer_maintainRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_import_customer_maintainRepository>(); } }
    }
}
