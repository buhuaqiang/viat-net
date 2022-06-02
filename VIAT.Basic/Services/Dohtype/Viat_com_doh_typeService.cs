/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_com_doh_typeService与IViat_com_doh_typeService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_doh_typeService : ServiceBase<Viat_com_doh_type, IViat_com_doh_typeRepository>
    , IViat_com_doh_typeService, IDependency
    {
    public Viat_com_doh_typeService(IViat_com_doh_typeRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_com_doh_typeService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_com_doh_typeService>(); } }
    }
 }
