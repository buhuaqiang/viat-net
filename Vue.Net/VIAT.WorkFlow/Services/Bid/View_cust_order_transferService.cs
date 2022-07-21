/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_cust_order_transferService与IView_cust_order_transferService中编写
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.WorkFlow.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Services
{
    public partial class View_cust_order_transferService : ServiceBase<View_cust_order_transfer, IView_cust_order_transferRepository>
    , IView_cust_order_transferService, IDependency
    {
    public View_cust_order_transferService(IView_cust_order_transferRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_cust_order_transferService Instance
    {
      get { return AutofacContainerModule.GetService<IView_cust_order_transferService>(); } }
    }
 }
