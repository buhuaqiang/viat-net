/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels;

namespace VIAT.Basic.IServices
{
    public partial interface IViat_com_prodService : IService<Viat_com_prod>
    {
        Viat_com_prod getProdByProdID(string prod_id);
    }
}
