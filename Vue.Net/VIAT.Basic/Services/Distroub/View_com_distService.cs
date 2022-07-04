/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_com_distService与IView_com_distService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_com_distService : ServiceBase<View_com_dist, IView_com_distRepository>
    , IView_com_distService, IDependency
    {
    public View_com_distService(IView_com_distRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_com_distService Instance
    {
      get { return AutofacContainerModule.GetService<IView_com_distService>(); } }
    }
 }
