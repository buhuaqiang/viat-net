/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_price_distributor_mappingRepository编写代码
 */
using VIAT.Price.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Price.Repositories
{
    public partial class View_price_distributor_mappingRepository : RepositoryBase<View_price_distributor_mapping> , IView_price_distributor_mappingRepository
    {
    public View_price_distributor_mappingRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_price_distributor_mappingRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_price_distributor_mappingRepository>(); } }
    }
}
