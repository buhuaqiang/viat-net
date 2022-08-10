using VIAT.Core.BaseProvider;
using VIAT.Core.Utilities;
using VIAT.Entity.DomainModels;
using System.Threading.Tasks;
using VIAT.Entity.DomainModels.System;

namespace VIAT.System.IServices
{
    public partial interface ISys_UserService
    {

        Task<WebResponseContent> Login(LoginInfo loginInfo, bool verificationCode = true);
        Task<WebResponseContent> ReplaceToken();
        Task<WebResponseContent> ModifyPwd(string oldPwd, string newPwd);
        Task<WebResponseContent> GetCurrentUserInfo();

        Task<WebResponseContent> getChangeUserImformation(string sChangeUserName);

        Viat_Sys_Org_Level_Detail GetLevelDetail(string emp_dbid);
    }
}

