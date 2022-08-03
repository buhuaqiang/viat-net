/*
*所有关于Viat_wk_contract_stretagy类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace VIAT.WorkFlow.IServices
{
    public partial interface IViat_wk_contract_stretagyService
    {
        WebResponseContent StretagyImport(List<IFormFile> files);
        WebResponseContent DownLoadTemp();
    }
 }
