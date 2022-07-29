/*
*所有关于View_price_distributor_mapping类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace VIAT.Price.IServices
{
    public partial interface IView_price_distributor_mappingService
    {
        List<View_price_distributor_mapping> PriceDistributorMappingData(string prod_id, string price_channel, string group_id, string cust_id);
    }
 }
