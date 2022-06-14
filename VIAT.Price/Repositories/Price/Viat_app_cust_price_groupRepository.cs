/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_app_cust_price_groupRepository编写代码
 */
using VIAT.Price.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Price.Repositories
{
    public partial class Viat_app_cust_price_groupRepository : RepositoryBase<Viat_app_cust_price_group> , IViat_app_cust_price_groupRepository
    {
    public Viat_app_cust_price_groupRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_app_cust_price_groupRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_app_cust_price_groupRepository>(); } }
    }
}
