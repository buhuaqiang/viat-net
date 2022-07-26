/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using System.Collections.Generic;
using VIAT.Core.BaseProvider;
using VIAT.Core.Utilities;
using VIAT.Entity.DomainModels;

namespace VIAT.Price.IServices
{
    public partial interface IView_cust_price_detailService : IService<View_cust_price_detail>
    {
        bool IsExpfizer(string sCustID);
        void setQueryParameters();

        WebResponseContent bathSaveCustPrice(object saveData);

        WebResponseContent bathSaveCheckData(object saveData);

        PageGridData<View_cust_price_detail> GetCustInvalidPageData(PageDataOptions options);

        List<View_cust_price_detail> GetCustInvalidList(string cust_dbid, string prod_dbid,string channel);


        WebResponseContent importData(List<View_cust_price> list);

    }
}
