/*
*所有关于Viat_wk_bid_detail类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace VIAT.WorkFlow.IServices
{
    public partial interface IViat_wk_bid_detailService
    {
        List<Viat_wk_bid_detail> getDataByBidMasterDBID(string bidmast_dbid);
    }
 }
