/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_sys_deputyRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class View_sys_deputyRepository : RepositoryBase<View_sys_deputy> , IView_sys_deputyRepository
    {
    public View_sys_deputyRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_sys_deputyRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_sys_deputyRepository>(); } }
    }
}
