/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_invoice_popService与IView_invoice_popService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class View_invoice_popService : ServiceBase<View_invoice_pop, IView_invoice_popRepository>
    , IView_invoice_popService, IDependency
    {
    public View_invoice_popService(IView_invoice_popRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_invoice_popService Instance
    {
      get { return AutofacContainerModule.GetService<IView_invoice_popService>(); } }
    }
 }
