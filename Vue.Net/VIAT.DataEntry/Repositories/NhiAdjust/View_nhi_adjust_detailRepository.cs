/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_nhi_adjust_detailRepository编写代码
 */
using VIAT.DataEntry.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Repositories
{
    public partial class View_nhi_adjust_detailRepository : RepositoryBase<View_nhi_adjust_detail> , IView_nhi_adjust_detailRepository
    {
    public View_nhi_adjust_detailRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_nhi_adjust_detailRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_nhi_adjust_detailRepository>(); } }
    }
}
