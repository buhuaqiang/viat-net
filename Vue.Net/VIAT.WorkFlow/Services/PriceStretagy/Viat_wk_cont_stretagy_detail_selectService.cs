/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_wk_cont_stretagy_detailService与IViat_wk_cont_stretagy_detailService中编写
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.WorkFlow.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Services
{
    public partial class Viat_wk_cont_stretagy_detail_selectService : ServiceBase<Viat_wk_cont_stretagy_detail_select, IViat_wk_cont_stretagy_detail_selectRepository>
    , IViat_wk_cont_stretagy_detail_selectService, IDependency
    {
    public Viat_wk_cont_stretagy_detail_selectService(IViat_wk_cont_stretagy_detail_selectRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_wk_cont_stretagy_detail_selectService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_wk_cont_stretagy_detail_selectService>(); } }
    }
 }
