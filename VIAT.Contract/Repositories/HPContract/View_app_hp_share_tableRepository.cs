/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_app_hp_share_tableRepository编写代码
 */
using VIAT.Contract.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Contract.Repositories
{
    public partial class View_app_hp_share_tableRepository : RepositoryBase<View_app_hp_share_table> , IView_app_hp_share_tableRepository
    {
    public View_app_hp_share_tableRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_app_hp_share_tableRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_app_hp_share_tableRepository>(); } }
    }
}
