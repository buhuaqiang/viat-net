/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_full_allowance_summaryService与IView_full_allowance_summaryService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class View_full_allowance_summaryService : ServiceBase<View_full_allowance_summary, IView_full_allowance_summaryRepository>
    , IView_full_allowance_summaryService, IDependency
    {
    public View_full_allowance_summaryService(IView_full_allowance_summaryRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_full_allowance_summaryService Instance
    {
      get { return AutofacContainerModule.GetService<IView_full_allowance_summaryService>(); } }
    }
 }
