/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_full_allowance_summaryController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/View_full_allowance_summary")]
    [PermissionTable(Name = "View_full_allowance_summary")]
    public partial class View_full_allowance_summaryController : ApiBaseController<IView_full_allowance_summaryService>
    {
        public View_full_allowance_summaryController(IView_full_allowance_summaryService service)
        : base(service)
        {
        }
    }
}

