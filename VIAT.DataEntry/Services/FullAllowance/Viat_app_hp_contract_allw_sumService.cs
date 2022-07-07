/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_app_hp_contract_allw_sumService与IViat_app_hp_contract_allw_sumService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class Viat_app_hp_contract_allw_sumService : ServiceBase<Viat_app_hp_contract_allw_sum, IViat_app_hp_contract_allw_sumRepository>
    , IViat_app_hp_contract_allw_sumService, IDependency
    {
    public Viat_app_hp_contract_allw_sumService(IViat_app_hp_contract_allw_sumRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_app_hp_contract_allw_sumService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_app_hp_contract_allw_sumService>(); } }
    }
 }
