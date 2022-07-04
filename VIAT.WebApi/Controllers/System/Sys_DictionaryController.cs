using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VIAT.Core.Controllers.Basic;
using VIAT.Core.Extensions;
using VIAT.Core.Filters;
using VIAT.System.IServices;

namespace VIAT.System.Controllers
{
    [Route("api/Sys_Dictionary")]
    public partial class Sys_DictionaryController : ApiBaseController<ISys_DictionaryService>
    {
        public Sys_DictionaryController(ISys_DictionaryService service)
        : base("System", "System", "Sys_Dictionary", service)
        {
        }
    }
}
