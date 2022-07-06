/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_invoice_popRepository编写代码
 */
using VIAT.DataEntry.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Repositories
{
    public partial class View_invoice_popRepository : RepositoryBase<View_invoice_pop> , IView_invoice_popRepository
    {
    public View_invoice_popRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_invoice_popRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_invoice_popRepository>(); } }
    }
}
