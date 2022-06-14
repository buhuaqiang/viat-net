/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_cust_custgroup_pricegroupRepository编写代码
 */
using VIAT.Price.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Price.Repositories
{
    public partial class View_cust_custgroup_pricegroupRepository : RepositoryBase<View_cust_custgroup_pricegroup> , IView_cust_custgroup_pricegroupRepository
    {
    public View_cust_custgroup_pricegroupRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_cust_custgroup_pricegroupRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_cust_custgroup_pricegroupRepository>(); } }
    }
}
