/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹App_ReportPriceRepository编写代码
 */
using VIAT.AppManager.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.AppManager.Repositories
{
    public partial class App_ReportPriceRepository : RepositoryBase<App_ReportPrice> , IApp_ReportPriceRepository
    {
    public App_ReportPriceRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IApp_ReportPriceRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IApp_ReportPriceRepository>(); } }
    }
}
