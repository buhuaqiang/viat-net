/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_cust_priceRepository编写代码
 */
using VIAT.Price.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.Repositories
{
    public partial class View_cust_priceRepository : RepositoryBase<View_cust_price> , IView_cust_priceRepository
    {
    public View_cust_priceRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_cust_priceRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_cust_priceRepository>(); } }
    }
}
