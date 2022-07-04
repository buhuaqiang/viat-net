/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_app_hp_contractRepository编写代码
 */
using VIAT.Contract.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Contract.Repositories
{
    public partial class View_app_hp_contractRepository : RepositoryBase<View_app_hp_contract> , IView_app_hp_contractRepository
    {
    public View_app_hp_contractRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_app_hp_contractRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_app_hp_contractRepository>(); } }
    }
}
