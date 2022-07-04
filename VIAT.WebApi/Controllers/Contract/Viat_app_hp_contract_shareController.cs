/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_app_hp_contract_shareController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Contract.IServices;
namespace VIAT.Contract.Controllers
{
    [Route("api/Viat_app_hp_contract_share")]
    [PermissionTable(Name = "Viat_app_hp_contract_share")]
    public partial class Viat_app_hp_contract_shareController : ApiBaseController<IViat_app_hp_contract_shareService>
    {
        public Viat_app_hp_contract_shareController(IViat_app_hp_contract_shareService service)
        : base(service)
        {
        }
    }
}

