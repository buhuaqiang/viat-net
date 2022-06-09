/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_com_distRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class View_com_distRepository : RepositoryBase<View_com_dist> , IView_com_distRepository
    {
    public View_com_distRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_com_distRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_com_distRepository>(); } }
    }
}
