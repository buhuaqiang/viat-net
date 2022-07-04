/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_com_prod_pop_queryRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class View_com_prod_pop_queryRepository : RepositoryBase<View_com_prod_pop_query> , IView_com_prod_pop_queryRepository
    {
    public View_com_prod_pop_queryRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_com_prod_pop_queryRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_com_prod_pop_queryRepository>(); } }
    }
}
