/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_hp_contract_allw_sumController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/Viat_app_hp_contract_allw_sum")]
    [PermissionTable(Name = "Viat_app_hp_contract_allw_sum")]
    public partial class Viat_app_hp_contract_allw_sumController : ApiBaseController<IViat_app_hp_contract_allw_sumService>
    {
        public Viat_app_hp_contract_allw_sumController(IViat_app_hp_contract_allw_sumService service)
        : base(service)
        {
        }
    }
}

