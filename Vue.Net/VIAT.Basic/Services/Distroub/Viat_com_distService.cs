/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_com_distService与IViat_com_distService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_distService : ServiceBase<Viat_com_dist, IViat_com_distRepository>
    , IViat_com_distService, IDependency
    {
    public Viat_com_distService(IViat_com_distRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_com_distService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_com_distService>(); } }
    }
 }
