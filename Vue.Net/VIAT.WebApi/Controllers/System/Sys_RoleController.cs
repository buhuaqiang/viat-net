using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VIAT.Core.Controllers.Basic;
using VIAT.Core.Enums;
using VIAT.Core.Filters;
using VIAT.Entity.AttributeManager;
using VIAT.Entity.DomainModels;
using VIAT.System.IServices;

namespace VIAT.System.Controllers
{
    [Route("api/Sys_Role")]
    [PermissionTable(Name = "Sys_Role")]
    public partial class Sys_RoleController : ApiBaseController<ISys_RoleService>
    {
        public Sys_RoleController(ISys_RoleService service)
        : base("System", "System", "Sys_Role", service)
        {

        }
    }
}


