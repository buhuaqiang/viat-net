/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下App_NewsService与IApp_NewsService中编写
 */
using VIAT.AppManager.IRepositories;
using VIAT.AppManager.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.AppManager.Services
{
    public partial class App_NewsService : ServiceBase<App_News, IApp_NewsRepository>, IApp_NewsService, IDependency
    {
        public App_NewsService(IApp_NewsRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IApp_NewsService Instance
        {
           get { return AutofacContainerModule.GetService<IApp_NewsService>(); }
        }
    }
}
