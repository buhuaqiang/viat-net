/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_app_hp_share_tableService与IView_app_hp_share_tableService中编写
 */
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Contract.Services
{
    public partial class View_app_hp_share_tableService : ServiceBase<View_app_hp_share_table, IView_app_hp_share_tableRepository>
    , IView_app_hp_share_tableService, IDependency
    {
    public View_app_hp_share_tableService(IView_app_hp_share_tableRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_app_hp_share_tableService Instance
    {
      get { return AutofacContainerModule.GetService<IView_app_hp_share_tableService>(); } }
    }

}
