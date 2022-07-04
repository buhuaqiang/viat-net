/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_power_contractController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Contract.IServices;
using VIAT.Entity.DomainModels;
using VIAT.Core.Filters;

namespace VIAT.Contract.Controllers
{
    [Route("api/Viat_app_power_contract")]
    [PermissionTable(Name = "Viat_app_power_contract")]
    public partial class Viat_app_power_contractController : ApiBaseController<IViat_app_power_contractService>
    {
        public Viat_app_power_contractController(IViat_app_power_contractService service)
        : base(service)
        {
        }
       
    }
}

