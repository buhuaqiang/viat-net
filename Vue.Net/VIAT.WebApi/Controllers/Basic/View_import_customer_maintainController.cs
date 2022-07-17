/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_import_customer_maintainController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_import_customer_maintain")]
    [PermissionTable(Name = "View_import_customer_maintain")]
    public partial class View_import_customer_maintainController : ApiBaseController<IView_import_customer_maintainService>
    {
        public View_import_customer_maintainController(IView_import_customer_maintainService service)
        : base(service)
        {
        }



    }
}

