/*
*所有关于Viat_com_cust类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace VIAT.Basic.IServices
{
    public partial interface IViat_com_custService
    {
        Viat_com_cust getCustByCustID(string sCustID);

        List<Viat_com_cust> GetCustListByPriceGroupDBID(string sPriceGroupDBID);
    }
 }
