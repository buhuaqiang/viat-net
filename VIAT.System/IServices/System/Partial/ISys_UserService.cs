using VIAT.Core.BaseProvider;
using VIAT.Core.Utilities;
using VIAT.Entity.DomainModels;
using System.Threading.Tasks;

namespace VIAT.System.IServices
{
    public partial interface ISys_UserService
    {

        Task<WebResponseContent> Login(LoginInfo loginInfo, bool verificationCode = true);
        Task<WebResponseContent> ReplaceToken();
        Task<WebResponseContent> ModifyPwd(string oldPwd, string newPwd);
        Task<WebResponseContent> GetCurrentUserInfo();

        Task<WebResponseContent> getChangeUserImformation(string sChangeUserName);
    }
}

