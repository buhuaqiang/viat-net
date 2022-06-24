/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_app_hp_contractService与IView_app_hp_contractService中编写
 */
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Contract.Services
{
    public partial class View_app_hp_contractService : ServiceBase<View_app_hp_contract, IView_app_hp_contractRepository>
    , IView_app_hp_contractService, IDependency
    {
    public View_app_hp_contractService(IView_app_hp_contractRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_app_hp_contractService Instance
    {
      get { return AutofacContainerModule.GetService<IView_app_hp_contractService>(); } }
    }
 }
