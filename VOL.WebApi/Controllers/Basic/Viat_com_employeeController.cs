/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_com_employeeController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
using VOL.Core.Filters;
using VOL.Entity.DomainModels;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_com_employee")]
    [PermissionTable(Name = "Viat_com_employee")]
    public partial class Viat_com_employeeController : ApiBaseController<IViat_com_employeeService>
    {
        public Viat_com_employeeController(IViat_com_employeeService service)
        : base(service)
        {
        }

          [ApiActionPermission()]
        [HttpPost, Route("GetEmployData")]
        public ActionResult GetEmployData([FromBody] PageDataOptions loadData)
        {
            return base.GetPageData(loadData);
        }
    }
}

