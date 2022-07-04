/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_cust_priceController编写
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Price.IServices;
using VIAT.Core.Filters;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.Controllers
{
    [Route("api/View_cust_price")]
    [PermissionTable(Name = "View_cust_price")]
    public partial class View_cust_priceController : ApiBaseController<IView_cust_priceService>
    {
        public View_cust_priceController(IView_cust_priceService service)
        : base(service)
        {
        }

        
    }
}

