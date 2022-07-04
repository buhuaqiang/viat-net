/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Sys_DictionaryListRepository编写代码
 */
using VIAT.System.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.System.Repositories
{
    public partial class Sys_DictionaryListRepository : RepositoryBase<Sys_DictionaryList> , ISys_DictionaryListRepository
    {
    public Sys_DictionaryListRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static ISys_DictionaryListRepository Instance
    {
      get {  return AutofacContainerModule.GetService<ISys_DictionaryListRepository>(); } }
    }
}
