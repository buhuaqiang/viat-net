/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹view_dist_marginRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class view_dist_marginRepository : RepositoryBase<view_dist_margin> , Iview_dist_marginRepository
    {
    public view_dist_marginRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static Iview_dist_marginRepository Instance
    {
      get {  return AutofacContainerModule.GetService<Iview_dist_marginRepository>(); } }
    }
}
