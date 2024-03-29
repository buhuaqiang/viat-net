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
        void processData(SaveModel saveModel);
        void setQueryParameters();

        WebResponseContent bathSaveCustPrice(object saveData);

        WebResponseContent bathSaveCheckData(object saveData);

        string getMaxBindNo();

        decimal getNetPriceByProdID(string prod_id);

        decimal getNetPriceByProdDBID(string sProdDBID);

        WebResponseContent invalidData(object saveData);

        PageGridData<View_cust_price> GetGroupInvalidPageData(PageDataOptions options);

        WebResponseContent importData(List<View_cust_price> list);

        decimal NhiPriceData(string prod_dbid, string start_date);
        List<Viat_app_cust_price_detail> getAllPriceDetailByGroupAndProd(string sPriceDetailDBID, string sProdDBID, string cust_dbid,string pricegroup_dbid);
    }
}
