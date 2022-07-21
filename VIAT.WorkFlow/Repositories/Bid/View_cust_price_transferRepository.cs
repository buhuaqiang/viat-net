/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_cust_price_transferRepository编写代码
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Repositories
{
    public partial class View_cust_price_transferRepository : RepositoryBase<View_cust_price_transfer> , IView_cust_price_transferRepository
    {
    public View_cust_price_transferRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_cust_price_transferRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_cust_price_transferRepository>(); } }
    }
}
