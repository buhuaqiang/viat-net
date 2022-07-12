/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_app_cust_groupRepository编写代码
 */
using VIAT.Price.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.Repositories
{
    public partial class Viat_app_cust_groupRepository : RepositoryBase<Viat_app_cust_group> , IViat_app_cust_groupRepository
    {
    public Viat_app_cust_groupRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_app_cust_groupRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_app_cust_groupRepository>(); } }
    }
}
