/*
*所有关于View_cust_price_transfer类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace VIAT.WorkFlow.IServices
{
    public partial interface IView_cust_price_transferService
    {
        void processBidAndOrder(SaveModel saveDataModel, string Cust);
        List<View_cust_price_detail> CustPriceDetailData(string pricegroup_dbid, string[] prod_dbid, string cust_dbid);
    }
 }
