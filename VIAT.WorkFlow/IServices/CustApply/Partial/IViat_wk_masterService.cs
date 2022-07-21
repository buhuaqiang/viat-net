/*
*所有关于Viat_wk_master类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
namespace VIAT.WorkFlow.IServices
{
    public partial interface IViat_wk_masterService
    {
        string getBidNO();

        Viat_wk_master getMasterByDBID(string sBidMastDBID);
    }
 }
