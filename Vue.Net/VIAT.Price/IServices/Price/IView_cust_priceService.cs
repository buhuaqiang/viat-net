/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VIAT.Core.BaseProvider;
using VIAT.Core.Utilities;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.IServices
{
    public partial interface IView_cust_priceService : IService<View_cust_price>
    {
        void setQueryParameters();

        WebResponseContent bathSaveCustPrice(object saveData);
    }
}
