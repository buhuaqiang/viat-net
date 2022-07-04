using VIAT.Entity.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIAT.Entity.DomainModels
{
    public class UserInfo
    {
        public int User_Id { get; set; }
        /// <summary>
        /// 多个角色ID
        /// </summary>
        public int Role_Id { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string UserTrueName { get; set; }
        public int  Enable { get; set; }
        public string Token { get; set; }

        /*增加代理人信息*/
        /// <summary>
        /// 代理人ID
        /// </summary>
        public int? ClientID { get; set; }
        /// <summary>
        /// 代理人账号
        /// </summary>
        public string ClientUserName { get; set; }
        /// <summary>
        /// 代理人名称
        /// </summary>
        public string ClientTrueUserName { get; set; }
    }
}
