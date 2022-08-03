/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_sftp_importRepository编写代码
 */
using VIAT.DataEntry.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Repositories
{
    public partial class Viat_sftp_importRepository : RepositoryBase<Viat_sftp_import> , IViat_sftp_importRepository
    {
    public Viat_sftp_importRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_sftp_importRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_sftp_importRepository>(); } }
    }
}
