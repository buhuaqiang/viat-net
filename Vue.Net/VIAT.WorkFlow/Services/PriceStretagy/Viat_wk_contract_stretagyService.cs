/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_wk_contract_stretagyService与IViat_wk_contract_stretagyService中编写
 */
using VIAT.WorkFlow.IRepositories;
using VIAT.WorkFlow.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.Services
{
    public partial class Viat_wk_contract_stretagyService : ServiceBase<Viat_wk_contract_stretagy, IViat_wk_contract_stretagyRepository>
    , IViat_wk_contract_stretagyService, IDependency
    {
    public Viat_wk_contract_stretagyService(IViat_wk_contract_stretagyRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_wk_contract_stretagyService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_wk_contract_stretagyService>(); } }
    }
 }
