/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Viat_com_prod_entity_periodController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/Viat_com_prod_entity_period")]
    [PermissionTable(Name = "Viat_com_prod_entity_period")]
    public partial class Viat_com_prod_entity_periodController : ApiBaseController<IViat_com_prod_entity_periodService>
    {
        public Viat_com_prod_entity_periodController(IViat_com_prod_entity_periodService service)
        : base(service)
        {
        }
    }
}

