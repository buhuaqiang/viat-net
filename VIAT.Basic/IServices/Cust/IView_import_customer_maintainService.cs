/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.BaseProvider;
using VIAT.Core.Utilities;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.IServices
{
    public partial interface IView_import_customer_maintainService : IService<View_import_customer_maintain>
    {
        WebResponseContent processIngore(string[] custtransfer_dbid);
    }
}
