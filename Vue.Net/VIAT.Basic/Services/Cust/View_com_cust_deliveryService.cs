/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_com_cust_deliveryService与IView_com_cust_deliveryService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_com_cust_deliveryService : ServiceBase<View_com_cust_delivery, IView_com_cust_deliveryRepository>
    , IView_com_cust_deliveryService, IDependency
    {
    public View_com_cust_deliveryService(IView_com_cust_deliveryRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_com_cust_deliveryService Instance
    {
      get { return AutofacContainerModule.GetService<IView_com_cust_deliveryService>(); } }
    }
 }
