/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下view_dist_marginService与Iview_dist_marginService中编写
 */
using VIAT.Basic.IRepositories;
using VIAT.Basic.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.Services
{
    public partial class view_dist_marginService : ServiceBase<view_dist_margin, Iview_dist_marginRepository>
    , Iview_dist_marginService, IDependency
    {
    public view_dist_marginService(Iview_dist_marginRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static Iview_dist_marginService Instance
    {
      get { return AutofacContainerModule.GetService<Iview_dist_marginService>(); } }
    }
 }
