/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹viat_app_sales_transferRepository编写代码
 */
using VIAT.DataEntry.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Repositories
{
    public partial class viat_app_sales_transferRepository : RepositoryBase<viat_app_sales_transfer> , Iviat_app_sales_transferRepository
    {
    public viat_app_sales_transferRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static Iviat_app_sales_transferRepository Instance
    {
      get {  return AutofacContainerModule.GetService<Iviat_app_sales_transferRepository>(); } }
    }
}
