/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹App_NewsRepository编写代码
 */
using VIAT.AppManager.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.AppManager.Repositories
{
    public partial class App_NewsRepository : RepositoryBase<App_News> , IApp_NewsRepository
    {
    public App_NewsRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IApp_NewsRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IApp_NewsRepository>(); } }
    }
}
