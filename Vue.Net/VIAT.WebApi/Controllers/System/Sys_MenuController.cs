using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VIAT.Core.Controllers.Basic;
using VIAT.Core.Enums;
using VIAT.Core.Filters;
using VIAT.Entity.DomainModels;
using VIAT.System.IServices;

namespace VIAT.System.Controllers
{
    [Route("api/menu")]
    [ApiController, JWTAuthorize()]
    public partial class Sys_MenuController : ApiBaseController<ISys_MenuService>
    {
        private ISys_MenuService _service { get; set; }
        public Sys_MenuController(ISys_MenuService service) :
            base("System", "System", "Sys_Menu", service)
        {
            _service = service;
        } 
    }
}
