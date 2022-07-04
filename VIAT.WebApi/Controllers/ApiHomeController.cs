using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.EFDbContext;
using Microsoft.AspNetCore.Authorization;

namespace VIAT.WebApi.Controllers
{
    [AllowAnonymous]
    public class ApiHomeController : Controller
    {
        public IActionResult Index()
        {
            
            return new RedirectResult("/swagger/");
        }

    }
}