/*
*所有关于Viat_app_cust_price_group类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
namespace VIAT.Price.IServices
{
    public partial interface IViat_app_cust_price_groupService
    {
        Viat_app_cust_price_group getPriceGroupByGroupID(string group_id);

        /// <summary>
        /// 根據產品dbid和客戶dbid查詢所在價格群組信息
        /// </summary>
        /// <param name="prod_id"></param>
        /// <param name="cust_id"></param>
        /// <returns></returns>
        Viat_app_cust_price_group getPriceGroupByCustAndProd(string prod_dbid, string cust_dbid);
    }
 }
