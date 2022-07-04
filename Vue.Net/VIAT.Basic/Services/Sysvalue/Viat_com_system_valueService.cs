/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_com_system_valueService与IViat_com_system_valueService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_system_valueService : ServiceBase<Viat_com_system_value, IViat_com_system_valueRepository>
    , IViat_com_system_valueService, IDependency
    {
    public Viat_com_system_valueService(IViat_com_system_valueRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_com_system_valueService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_com_system_valueService>(); } }
    }
 }
