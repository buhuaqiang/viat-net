/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_order_applyRepository编写代码
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Repositories
{
    public partial class View_order_applyRepository : RepositoryBase<View_order_apply> , IView_order_applyRepository
    {
    public View_order_applyRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_order_applyRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_order_applyRepository>(); } }
    }
}
