/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_com_zip_cityService与IViat_com_zip_cityService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_zip_cityService : ServiceBase<Viat_com_zip_city, IViat_com_zip_cityRepository>
    , IViat_com_zip_cityService, IDependency
    {
    public Viat_com_zip_cityService(IViat_com_zip_cityRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_com_zip_cityService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_com_zip_cityService>(); } }
    }
 }
