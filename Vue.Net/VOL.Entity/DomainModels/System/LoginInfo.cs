using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VOL.Entity.DomainModels
{
    public class LoginInfo
    {


        [Display(Name = "用户名")]
        [MaxLength(50)]
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
        [MaxLength(50)]
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
        [MaxLength(6)]
        [Display(Name = "验证码")]
        [Required(ErrorMessage = "验证码不能为空")]
        public string VerificationCode { get; set; }
        [Required(ErrorMessage = "参数不完整")]
        /// <summary>
        /// 2020.06.12增加验证码
        /// </summary>
        public string UUID { get; set; }
        /*增加代理人信息*/
        /// <summary>
        /// 代理人ID
        /// </summary>
        public int ClientID { get; set; }
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
