/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_wk_cont_stretagy_detail_mainRepository编写代码
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Repositories
{
    public partial class View_wk_cont_stretagy_detail_mainRepository : RepositoryBase<View_wk_cont_stretagy_detail_main> , IView_wk_cont_stretagy_detail_mainRepository
    {
    public View_wk_cont_stretagy_detail_mainRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_wk_cont_stretagy_detail_mainRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_wk_cont_stretagy_detail_mainRepository>(); } }
    }
}
