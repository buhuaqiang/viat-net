/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_com_close_periodService与IViat_com_close_periodService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_close_periodService : ServiceBase<Viat_com_close_period, IViat_com_close_periodRepository>
    , IViat_com_close_periodService, IDependency
    {
    public Viat_com_close_periodService(IViat_com_close_periodRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_com_close_periodService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_com_close_periodService>(); } }
    }
 }
