/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_import_customer_maintainService与IView_import_customer_maintainService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_import_customer_maintainService : ServiceBase<View_import_customer_maintain, IView_import_customer_maintainRepository>
    , IView_import_customer_maintainService, IDependency
    {
    public View_import_customer_maintainService(IView_import_customer_maintainRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_import_customer_maintainService Instance
    {
      get { return AutofacContainerModule.GetService<IView_import_customer_maintainService>(); } }
    }
 }
