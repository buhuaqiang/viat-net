/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Viat_com_employeeRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class Viat_com_employeeRepository : RepositoryBase<Viat_com_employee> , IViat_com_employeeRepository
    {
    public Viat_com_employeeRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IViat_com_employeeRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IViat_com_employeeRepository>(); } }
    }
}
