/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_prod_entity_periodController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Basic.IServices;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_prod_entity_period")]
    [PermissionTable(Name = "View_prod_entity_period")]
    public partial class View_prod_entity_periodController : ApiBaseController<IView_prod_entity_periodService>
    {
        public View_prod_entity_periodController(IView_prod_entity_periodService service)
        : base(service)
        {
        }
    }
}

