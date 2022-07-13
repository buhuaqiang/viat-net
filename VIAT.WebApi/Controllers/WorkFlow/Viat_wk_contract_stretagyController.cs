/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_wk_contract_stretagyController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.WorkFlow.IServices;
using VIAT.Core.Filters;
using VIAT.Entity.DomainModels;
namespace VIAT.WorkFlow.Controllers
{
    [Route("api/Viat_wk_contract_stretagy")]
    [PermissionTable(Name = "Viat_wk_contract_stretagy")]
    public partial class Viat_wk_contract_stretagyController : ApiBaseController<IViat_wk_contract_stretagyService>
    {
        public Viat_wk_contract_stretagyController(IViat_wk_contract_stretagyService service)
        : base(service)
        {
        }
    }
}

