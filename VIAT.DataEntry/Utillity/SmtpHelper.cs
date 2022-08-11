using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using VIAT.Core.Configuration;
using System.Linq;

namespace VIAT.DataEntry.Utillity
{
    public class SmtpHelper
    {
        private string from;
        private string smtpServer;
        private string smtpUsername;
        private string smtpPasswd;

        /// <summary>
        /// 禾設定SMTP相關訊息
        /// </summary>
        public const string SMTP_RESULT_SETTING_ISNULL = "0";

        /// <summary>
        /// 寄件完成
        /// </summary>
        public const string SMTP_RESULT_SUCCESS = "1";

        /// <summary>
        /// 無收件者
        /// </summary>
        public const string SMTP_RESULT_RECEIVER_ISNULL = "2";

        /// <summary>
        /// 寄件失敗
        /// </summary>
        public const string SMTP_RESULT_FAIL = "3";

        public SmtpHelper()
        {
            if(AppSetting.Smtp != null)
            {
                from = AppSetting.Smtp.SendFrom;
                smtpServer = AppSetting.Smtp.SmtpServer;
                smtpUsername = AppSetting.Smtp.SmtpUsername;
                smtpPasswd = AppSetting.Smtp.SmtpPasswd;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <returns> 
        /// 參數1：結果
        /// 0:未設定SMTP相關訊息
        /// 1:寄件完成
        /// 2:無收件者
        /// 3:寄件失敗
        /// 參數2: 錯誤訊息
        /// </returns>
        public Tuple<string, string> sendMail(string address, string subject, string content)
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(smtpUsername) )
            {
                //未設定SMTP相關訊息
                return Tuple.Create( SMTP_RESULT_SETTING_ISNULL, "未設定SMTP相關訊息");
            }
            try
            {
                MailMessage msg = new MailMessage();
                if (string.IsNullOrEmpty(address))
                {
                    return Tuple.Create(SMTP_RESULT_RECEIVER_ISNULL, "無收件者"); ;
                }

                char[] charSeparators = new char[] { ';', ',' };
                address.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList().ForEach(t =>
                {
                    msg.To.Add(t);
                });
                //郵件標題 
                msg.Subject = subject;

                msg.From = new MailAddress(from, from);

                //郵件標題編碼  
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                //郵件內容
                msg.Body = content;
                msg.IsBodyHtml = true;
                msg.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼 
                msg.Priority = MailPriority.Normal;//郵件優先級 

                AlternateView alt = AlternateView.CreateAlternateViewFromString(content, Encoding.UTF8, "text/html");
                msg.AlternateViews.Add(alt);

                

                SmtpClient MySmtp = new SmtpClient(smtpServer, 587);
                //設定你的帳號密碼
                //MySmtp.Timeout = 5000;
                if(string.IsNullOrEmpty(smtpPasswd)==false)
                {
                    MySmtp.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPasswd);
                }
                
                //Gmial 的 smtp 使用 SSL
                //MySmtp.EnableSsl = true;
                MySmtp.Send(msg);
                return  Tuple.Create(SMTP_RESULT_SUCCESS,"");
            }
            catch (Exception err)
            {
                return Tuple.Create(SMTP_RESULT_FAIL, err.Message);
            }
        }
    }
}
