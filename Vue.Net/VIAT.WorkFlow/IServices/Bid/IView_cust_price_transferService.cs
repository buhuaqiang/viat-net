/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using System.Collections.Generic;
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.IServices
{
    public partial interface IView_cust_price_transferService : IService<View_cust_price_transfer>
    {
        List<View_cust_price_detail> CustPriceDetailData(string pricegroup_dbid, string[] prod_dbid);
    }
}
