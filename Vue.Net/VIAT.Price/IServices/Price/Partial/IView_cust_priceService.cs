/*
*所有关于View_cust_price类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
namespace VIAT.Price.IServices
{
    public partial interface IView_cust_priceService
    {
        
        /// <summary>
        /// 查詢群組內產品(customer join group頁面用的查詢方法)
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        public PageGridData<View_cust_price> getPriceGroupProducts(PageDataOptions pageData);

        /// <summary>
        /// 查詢客戶在群組內的產品(customer detach 頁面查詢方法)
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        public PageGridData<Viat_app_cust_group_for_detach> getCustomerProducts(PageDataOptions pageData);

        WebResponseContent excuteCustomerJoinGroup(SaveModel saveModel);

    }
 }
