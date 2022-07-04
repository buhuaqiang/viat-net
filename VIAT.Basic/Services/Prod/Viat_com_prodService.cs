/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_com_prodService与IViat_com_prodService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_prodService : ServiceBase<Viat_com_prod, IViat_com_prodRepository>
    , IViat_com_prodService, IDependency
    {
    public Viat_com_prodService(IViat_com_prodRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_com_prodService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_com_prodService>(); } }
    }
 }
