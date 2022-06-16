/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_hp_contractService与IViat_app_hp_contractService中编写
 */
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Contract.Services
{
    public partial class Viat_app_hp_contractService : ServiceBase<Viat_app_hp_contract, IViat_app_hp_contractRepository>
    , IViat_app_hp_contractService, IDependency
    {
    public Viat_app_hp_contractService(IViat_app_hp_contractRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_hp_contractService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_hp_contractService>(); } }
    }
 }
