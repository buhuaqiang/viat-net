/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_full_allowance_reverseRepository编写代码
 */
using VIAT.DataEntry.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Repositories
{
    public partial class View_full_allowance_reverseRepository : RepositoryBase<View_full_allowance_reverse> , IView_full_allowance_reverseRepository
    {
    public View_full_allowance_reverseRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_full_allowance_reverseRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_full_allowance_reverseRepository>(); } }
    }
}
