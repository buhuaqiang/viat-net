/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下viat_app_sales_transferService与Iviat_app_sales_transferService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class viat_app_sales_transferService : ServiceBase<viat_app_sales_transfer, Iviat_app_sales_transferRepository>
    , Iviat_app_sales_transferService, IDependency
    {
    public viat_app_sales_transferService(Iviat_app_sales_transferRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static Iviat_app_sales_transferService Instance
    {
      get { return AutofacContainerModule.GetService<Iviat_app_sales_transferService>(); } }
    }
 }
