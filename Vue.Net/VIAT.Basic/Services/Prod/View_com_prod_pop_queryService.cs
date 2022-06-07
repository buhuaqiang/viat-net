/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_com_prod_pop_queryService与IView_com_prod_pop_queryService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class View_com_prod_pop_queryService : ServiceBase<View_com_prod_pop_query, IView_com_prod_pop_queryRepository>
    , IView_com_prod_pop_queryService, IDependency
    {
    public View_com_prod_pop_queryService(IView_com_prod_pop_queryRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_com_prod_pop_queryService Instance
    {
      get { return AutofacContainerModule.GetService<IView_com_prod_pop_queryService>(); } }
    }
 }
