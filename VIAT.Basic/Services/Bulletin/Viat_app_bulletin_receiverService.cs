/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_bulletin_receiverService与IViat_app_bulletin_receiverService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_app_bulletin_receiverService : ServiceBase<Viat_app_bulletin_receiver, IViat_app_bulletin_receiverRepository>
    , IViat_app_bulletin_receiverService, IDependency
    {
    public Viat_app_bulletin_receiverService(IViat_app_bulletin_receiverRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_bulletin_receiverService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_bulletin_receiverService>(); } }
    }
 }
