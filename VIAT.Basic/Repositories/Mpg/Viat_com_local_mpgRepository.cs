/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_com_local_mpgRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class Viat_com_local_mpgRepository : RepositoryBase<Viat_com_local_mpg> , IViat_com_local_mpgRepository
    {
    public Viat_com_local_mpgRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_com_local_mpgRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_com_local_mpgRepository>(); } }
    }
}
