/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_prod_entity_periodRepository编写代码
 */
using VIAT.Basic.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Repositories
{
    public partial class View_prod_entity_periodRepository : RepositoryBase<View_prod_entity_period> , IView_prod_entity_periodRepository
    {
    public View_prod_entity_periodRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_prod_entity_periodRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_prod_entity_periodRepository>(); } }
    }
}
