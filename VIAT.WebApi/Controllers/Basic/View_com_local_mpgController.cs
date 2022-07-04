/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_com_local_mpgController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_com_local_mpg")]
    [PermissionTable(Name = "View_com_local_mpg")]
    public partial class View_com_local_mpgController : ApiBaseController<IView_com_local_mpgService>
    {
        public View_com_local_mpgController(IView_com_local_mpgService service)
        : base(service)
        {
        }
    }
}

