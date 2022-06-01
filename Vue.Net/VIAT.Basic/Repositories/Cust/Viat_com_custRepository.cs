/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_com_custRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class Viat_com_custRepository : RepositoryBase<Viat_com_cust> , IViat_com_custRepository
    {
    public Viat_com_custRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_com_custRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_com_custRepository>(); } }
    }
}
