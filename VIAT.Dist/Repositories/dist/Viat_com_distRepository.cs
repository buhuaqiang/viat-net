/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_com_distRepository编写代码
 */
using VIAT.Dist.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Dist.Repositories
{
    public partial class Viat_com_distRepository : RepositoryBase<Viat_com_dist> , IViat_com_distRepository
    {
    public Viat_com_distRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_com_distRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_com_distRepository>(); } }
    }
}
