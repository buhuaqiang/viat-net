/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_com_notify_templateService与IView_com_notify_templateService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_com_notify_templateService : ServiceBase<View_com_notify_template, IView_com_notify_templateRepository>
    , IView_com_notify_templateService, IDependency
    {
    public View_com_notify_templateService(IView_com_notify_templateRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_com_notify_templateService Instance
    {
      get { return AutofacContainerModule.GetService<IView_com_notify_templateService>(); } }
    }
 }
