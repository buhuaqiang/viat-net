/*
*所有关于View_wk_cust_main类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
namespace VIAT.WorkFlow.IServices
{
    public partial interface IView_wk_cust_mainService
    {
        /// <summary>
        /// 批量退回
        /// </summary>
        /// <param name="bidmast_dbidLst"></param>
        /// <returns></returns>
        WebResponseContent processBack(string[] bidmast_dbidLst);

        WebResponseContent addSubmit(object saveModel);

        WebResponseContent Submit(object saveModel);

    }
}
