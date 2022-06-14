/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_com_close_period_marginController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_com_close_period_margin")]
    [PermissionTable(Name = "View_com_close_period_margin")]
    public partial class View_com_close_period_marginController : ApiBaseController<IView_com_close_period_marginService>
    {
        public View_com_close_period_marginController(IView_com_close_period_marginService service)
        : base(service)
        {
        }
    }
}

