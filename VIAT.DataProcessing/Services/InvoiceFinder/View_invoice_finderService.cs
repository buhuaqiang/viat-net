/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_invoice_finderService与IView_invoice_finderService中编写
 */
using VIAT.DataProcessing.IRepositories;
using VIAT.DataProcessing.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataProcessing.Services
{
    public partial class View_invoice_finderService : ServiceBase<View_invoice_finder, IView_invoice_finderRepository>
    , IView_invoice_finderService, IDependency
    {
    public View_invoice_finderService(IView_invoice_finderRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_invoice_finderService Instance
    {
      get { return AutofacContainerModule.GetService<IView_invoice_finderService>(); } }
    }
 }
