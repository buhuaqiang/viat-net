/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_wk_cust_mainRepository编写代码
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Repositories
{
    public partial class View_wk_cust_mainRepository : RepositoryBase<View_wk_cust_main> , IView_wk_cust_mainRepository
    {
    public View_wk_cust_mainRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_wk_cust_mainRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_wk_cust_mainRepository>(); } }
    }
}
