/*
*所有关于View_app_power_contract_main类的业务代码接口应在此处编写
*/
using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels;
using VOL.Core.Utilities;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace VIAT.Contract.IServices
{
    public partial interface IView_app_power_contract_mainService
    {
        Task<WebResponseContent> close(string[] ids);
    }
 }
