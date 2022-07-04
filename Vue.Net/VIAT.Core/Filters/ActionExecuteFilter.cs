using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using VIAT.Core.Enums;
using VIAT.Core.Extensions;
using VIAT.Core.ObjectActionValidator;
using VIAT.Core.Services;
using VIAT.Core.Utilities;

namespace VIAT.Core.Filters
{
    public class ActionExecuteFilter : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //验证方法参数
            context.ActionParamsValidator();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}