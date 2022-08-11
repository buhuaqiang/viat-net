/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹viat_app_sales_transferController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.DataEntry.IServices;
namespace VIAT.DataEntry.Controllers
{
    [Route("api/viat_app_sales_transfer")]
    [PermissionTable(Name = "viat_app_sales_transfer")]
    public partial class viat_app_sales_transferController : ApiBaseController<Iviat_app_sales_transferService>
    {
        public viat_app_sales_transferController(Iviat_app_sales_transferService service)
        : base(service)
        {
        }
    }
}

