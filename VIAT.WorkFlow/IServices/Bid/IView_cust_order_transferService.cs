/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;

namespace VIAT.WorkFlow.IServices
{
    public partial interface IView_cust_order_transferService : IService<View_cust_order_transfer>
    {
        PageGridData<View_cust_order_transfer> GetPageDataByOrderNO(PageDataOptions options);
    }
}
