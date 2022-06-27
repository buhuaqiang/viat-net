/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_app_cust_delivery_transferService与IView_app_cust_delivery_transferService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_app_cust_delivery_transferService : ServiceBase<View_app_cust_delivery_transfer, IView_app_cust_delivery_transferRepository>
    , IView_app_cust_delivery_transferService, IDependency
    {
    public View_app_cust_delivery_transferService(IView_app_cust_delivery_transferRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_app_cust_delivery_transferService Instance
    {
      get { return AutofacContainerModule.GetService<IView_app_cust_delivery_transferService>(); } }
    }
 }
