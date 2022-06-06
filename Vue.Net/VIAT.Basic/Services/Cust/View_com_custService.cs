/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_com_custService与IView_com_custService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_com_custService : ServiceBase<View_com_cust, IView_com_custRepository>
    , IView_com_custService, IDependency
    {
    public View_com_custService(IView_com_custRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_com_custService Instance
    {
      get { return AutofacContainerModule.GetService<IView_com_custService>(); } }
    }
 }
