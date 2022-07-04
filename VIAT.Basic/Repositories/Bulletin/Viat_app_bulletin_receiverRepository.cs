/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_app_bulletin_receiverRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class Viat_app_bulletin_receiverRepository : RepositoryBase<Viat_app_bulletin_receiver> , IViat_app_bulletin_receiverRepository
    {
    public Viat_app_bulletin_receiverRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_app_bulletin_receiverRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_app_bulletin_receiverRepository>(); } }
    }
}
