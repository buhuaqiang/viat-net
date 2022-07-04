/*
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下test2019Service与Itest2019Service中编写
 */
using VIAT.AppManager.IRepositories;
using VIAT.AppManager.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.AppManager.Services
{
    public partial class test2019Service : ServiceBase<test2019, Itest2019Repository>, Itest2019Service, IDependency
    {
        public test2019Service(Itest2019Repository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static Itest2019Service Instance
        {
           get { return AutofacContainerModule.GetService<Itest2019Service>(); }
        }
    }
}
