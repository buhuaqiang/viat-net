/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_imp_error_logService与IViat_imp_error_logService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class Viat_imp_error_logService : ServiceBase<Viat_imp_error_log, IViat_imp_error_logRepository>
    , IViat_imp_error_logService, IDependency
    {
    public Viat_imp_error_logService(IViat_imp_error_logRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_imp_error_logService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_imp_error_logService>(); } }
    }
 }
