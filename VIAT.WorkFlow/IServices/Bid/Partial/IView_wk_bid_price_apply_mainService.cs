/*
*所有关于View_wk_bid_price_apply_main类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
namespace VIAT.WorkFlow.IServices
{
    public partial interface IView_wk_bid_price_apply_mainService
    {
        WebResponseContent addSubmit(SaveModel saveModel);

        WebResponseContent Submit(object saveModel);
    }
 }
