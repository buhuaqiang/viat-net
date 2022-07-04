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
    }
 }
