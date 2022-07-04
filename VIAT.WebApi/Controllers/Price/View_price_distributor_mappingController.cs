/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_price_distributor_mappingController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Price.IServices;
namespace VIAT.Price.Controllers
{
    [Route("api/View_price_distributor_mapping")]
    [PermissionTable(Name = "View_price_distributor_mapping")]
    public partial class View_price_distributor_mappingController : ApiBaseController<IView_price_distributor_mappingService>
    {
        public View_price_distributor_mappingController(IView_price_distributor_mappingService service)
        : base(service)
        {
        }
    }
}

