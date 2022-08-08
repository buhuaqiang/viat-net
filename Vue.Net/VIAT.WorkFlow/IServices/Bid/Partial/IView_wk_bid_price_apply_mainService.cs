/*
*所有关于View_wk_bid_price_apply_main类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace VIAT.WorkFlow.IServices
{
    public partial interface IView_wk_bid_price_apply_mainService
    {
        WebResponseContent addSubmit(SaveModel saveModel);

        WebResponseContent Submit(object saveModel);

        View_wk_bid_price_apply_main getWkApplyMainByBidNO(string bid_no);

        WebResponseContent processBack(string[] bidmast_dbidLst);

       // List<Viat_app_cust_order> RecentOrder(string prod_dbid, string cust_dbid, string pricegroup_dbid);

        public PageGridData<Viat_app_cust_order> RecentOrder(PageDataOptions pageData);

        Viat_app_cust_price ProductPrice(string prod_dbid, string pricegroup_dbid);

        WebResponseContent CustPriceTransferImport(List<IFormFile> files, string cust_id, string group_dbid);
        Sys_User SysUserData();
    }
 }
