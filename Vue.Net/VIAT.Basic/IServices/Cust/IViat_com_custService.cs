/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.IServices
{
    public partial interface IViat_com_custService : IService<Viat_com_cust>
    {
        Viat_com_cust getCustByCustDBID(string cust_dbid);
    }
}
