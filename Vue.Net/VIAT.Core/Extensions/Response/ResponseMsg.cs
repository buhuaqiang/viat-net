using VIAT.Core.Enums;

namespace VIAT.Core.Extensions
{
    public static class ResponseMsg
    {
        public static string GetMsg(this ResponseType  responseType)
        {
            string msg;
            switch (responseType)
            {
                case ResponseType.LoginExpiration:
                    msg = "Login has expired, please log in again"; break;
                case ResponseType.TokenExpiration:
                    msg = "Token has expired, please log in again"; break;
                case ResponseType.AccountLocked:
                    msg = "Account is locked"; break;
                case ResponseType.LoginSuccess:
                    msg = "Login successfully"; break;
                case ResponseType.ParametersLack:
                    msg = "Incomplete parameters"; break;
                case ResponseType.NoPermissions:
                    msg = "No permission to operate"; break;
                case ResponseType.NoRolePermissions:
                    msg = "Role does not have permission to operate"; break;
                case ResponseType.ServerError:
                    msg = "The server responded Exception"; break;
                case ResponseType.LoginError:
                    msg = "wrong user name or password"; break;
                case ResponseType.SaveSuccess:
                    msg = "Saved successfully"; break;
                case ResponseType.NoKey:
                    msg = "Cannot edit without primary key"; break;
                case ResponseType.NoKeyDel:
                    msg = "Cannot delete without primary key"; break;
                case ResponseType.KeyError:
                    msg = "Incorrect primary key or no primary key passed in"; break;
                case ResponseType.EidtSuccess:
                    msg = "Edited successfully"; break;
                case ResponseType.DelSuccess:
                    msg = "Deleted successfully"; break;
                case ResponseType.RegisterSuccess:
                    msg = "注册成功"; break;
                case ResponseType.AuditSuccess:
                    msg = "审核成功"; break;
                case ResponseType.ModifyPwdSuccess:
                    msg = "密码修改成功"; break;
                case ResponseType.OperSuccess:
                    msg = "操作成功"; break;
                case ResponseType.PINError:
                    msg = "验证码不正确"; break;
                    
                default: msg = responseType.ToString(); break;
            }
            return msg;
        }

    }
}
