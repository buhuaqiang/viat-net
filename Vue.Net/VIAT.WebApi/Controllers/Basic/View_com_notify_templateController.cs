/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_com_notify_templateController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_com_notify_template")]
    [PermissionTable(Name = "View_com_notify_template")]
    public partial class View_com_notify_templateController : ApiBaseController<IView_com_notify_templateService>
    {
        public View_com_notify_templateController(IView_com_notify_templateService service)
        : base(service)
        {
        }
    }
}

