/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹App_TransactionController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.AppManager.IServices;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;

namespace VIAT.AppManager.Controllers
{
    [Route("api/App_Transaction")]
    [PermissionTable(Name = "App_Transaction")]
    public partial class App_TransactionController : ApiBaseController<IApp_TransactionService>
    {
        public App_TransactionController(IApp_TransactionService service)
        : base("AppManager","App","App_Transaction", service)
        {
        }
    }
}

