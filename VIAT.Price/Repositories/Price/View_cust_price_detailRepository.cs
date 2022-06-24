/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_cust_price_detailRepository编写代码
 */
using VIAT.Price.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Price.Repositories
{
    public partial class View_cust_price_detailRepository : RepositoryBase<View_cust_price_detail> , IView_cust_price_detailRepository
    {
    public View_cust_price_detailRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_cust_price_detailRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_cust_price_detailRepository>(); } }
    }
}
