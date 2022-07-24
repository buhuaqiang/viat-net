/*
*所有关于View_cust_price_detail类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
namespace VIAT.Price.IServices
{
    public partial interface IView_cust_price_detailService
    {
        public PageGridData<View_cust_price_detail> GetPriceDataForTransfer(PageDataOptions pageData);

        void processData(SaveModel saveModel);
    }
 }
