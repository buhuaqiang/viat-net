/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Sys_DictionaryListService与ISys_DictionaryListService中编写
 */
using VIAT.System.IRepositories;
using VIAT.System.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.System.Services
{
    public partial class Sys_DictionaryListService : ServiceBase<Sys_DictionaryList, ISys_DictionaryListRepository>
    , ISys_DictionaryListService, IDependency
    {
    public Sys_DictionaryListService(ISys_DictionaryListRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ISys_DictionaryListService Instance
    {
      get { return AutofacContainerModule.GetService<ISys_DictionaryListService>(); } }
    }
 }
