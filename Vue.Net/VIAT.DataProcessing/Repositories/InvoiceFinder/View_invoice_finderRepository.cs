/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_invoice_finderRepository编写代码
 */
using VIAT.DataProcessing.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataProcessing.Repositories
{
    public partial class View_invoice_finderRepository : RepositoryBase<View_invoice_finder> , IView_invoice_finderRepository
    {
    public View_invoice_finderRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_invoice_finderRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_invoice_finderRepository>(); } }
    }
}
