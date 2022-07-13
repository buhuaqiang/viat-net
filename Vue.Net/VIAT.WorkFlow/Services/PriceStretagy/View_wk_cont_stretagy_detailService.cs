/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_wk_cont_stretagy_detailService与IView_wk_cont_stretagy_detailService中编写
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.WorkFlow.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Services
{
    public partial class View_wk_cont_stretagy_detailService : ServiceBase<View_wk_cont_stretagy_detail, IView_wk_cont_stretagy_detailRepository>
    , IView_wk_cont_stretagy_detailService, IDependency
    {
    public View_wk_cont_stretagy_detailService(IView_wk_cont_stretagy_detailRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_wk_cont_stretagy_detailService Instance
    {
      get { return AutofacContainerModule.GetService<IView_wk_cont_stretagy_detailService>(); } }
    }
 }
