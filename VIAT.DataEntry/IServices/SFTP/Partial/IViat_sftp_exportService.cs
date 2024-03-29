/*
*所有关于Viat_sftp_export类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace VIAT.DataEntry.IServices
{
    public partial interface IViat_sftp_exportService
    {

        WebResponseContent Execute(SaveModel saveModel);
        WebResponseContent ExecuteBatch();
        Stream ExecuteRow(string file_name);
        string GetDistEName(string dist_id);
    }
 }
