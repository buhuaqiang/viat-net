
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VIAT.Core.Controllers.Basic;
using VIAT.Entity.AttributeManager;
using VIAT.Entity.DomainModels;
using VIAT.System.IServices;

namespace VIAT.System.Controllers
{
    [Route("api/Sys_User")]
    [PermissionTable(Name = "Sys_User")]
    public partial class Sys_UserController : ApiBaseController<ISys_UserService>
    {
        public Sys_UserController(ISys_UserService service)
        : base("System", "System", "Sys_User", service)
        {
            //, IMemoryCache cache
        }
    }
}
