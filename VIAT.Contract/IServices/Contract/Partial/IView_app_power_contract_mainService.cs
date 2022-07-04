/*
*所有关于View_app_power_contract_main类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace VIAT.Contract.IServices
{
    public partial interface IView_app_power_contract_mainService
    {
        WebResponseContent close(string[] ids);
    }
 }
