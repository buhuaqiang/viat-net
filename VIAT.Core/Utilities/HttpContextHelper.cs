using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VIAT.Core.Configuration;

namespace VIAT.Core.Utilities
{
    public class HttpContextHelper
    {
        public static WebResponseContent HttpContextBase(IHeaderDictionary header)
        {
            var keys = header.Keys;
            var values = header.Values;
            bool key = keys.Any((id) =>
            {
                return AppSetting.quartzHeader.Name.Equals(id, StringComparison.OrdinalIgnoreCase);
            });
            bool value = values.Any((id) =>
            {
                return AppSetting.quartzHeader.Password.Equals(id, StringComparison.OrdinalIgnoreCase);
            });
            if (!key)
            {
                return new WebResponseContent { Message = "人员不存在，没有权限", Status = false };
            }
            if (!value)
            {
                return new WebResponseContent { Message = "密码不对，没有权限", Status = false };
            }
            return new WebResponseContent { Status = true };
        }
    }
}
