/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹test2019Repository编写代码
 */
using VIAT.AppManager.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.AppManager.Repositories
{
    public partial class test2019Repository : RepositoryBase<test2019> , Itest2019Repository
    {
    public test2019Repository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static Itest2019Repository Instance
    {
      get {  return AutofacContainerModule.GetService<Itest2019Repository>(); } }
    }
}
