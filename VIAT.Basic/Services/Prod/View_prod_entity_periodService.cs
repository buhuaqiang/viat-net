/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_prod_entity_periodService与IView_prod_entity_periodService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_prod_entity_periodService : ServiceBase<View_prod_entity_period, IView_prod_entity_periodRepository>
    , IView_prod_entity_periodService, IDependency
    {
    public View_prod_entity_periodService(IView_prod_entity_periodRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_prod_entity_periodService Instance
    {
      get { return AutofacContainerModule.GetService<IView_prod_entity_periodService>(); } }
    }
 }
