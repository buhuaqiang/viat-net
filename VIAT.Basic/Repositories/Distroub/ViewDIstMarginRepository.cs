/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹ViewDIstMarginRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class ViewDIstMarginRepository : RepositoryBase<ViewDIstMargin> , IViewDIstMarginRepository
    {
    public ViewDIstMarginRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViewDIstMarginRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViewDIstMarginRepository>(); } }
    }
}
