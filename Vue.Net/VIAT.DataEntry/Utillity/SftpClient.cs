using System;
using System.Collections.Generic;
using System.IO;
using Tamir.SharpSsh.jsch;
using VIAT.Core.Configuration;

namespace VIAT.DataEntry.Utillity
{
    public class SftpClient : IDisposable
    {
        #region Properties

        /// <summary>
        /// 主机名或IP
        /// </summary>
        public string HostName { get; private set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 端口号(默认端口为22)
        /// </summary>
        public int Port { get; private set; }

        #endregion

        private static readonly string defRemotePath = "/";//默认操作是都是从根目录开始。
        private Session m_session;
        private ChannelSftp m_sftp;
        Channel m_channel;
        /// <summary>
        /// 从配置文件中加载凭证信息
        /// </summary>       
        public SftpClient()
        {
            this.HostName = AppSetting.SftpSite.HostName;
            this.UserName = AppSetting.SftpSite.UserName;
            this.Password = AppSetting.SftpSite.Password;
            this.Port = 22;//默认端口为22    
            this.ConnectSftp();
        }
        /// <summary>
        /// 连接SFTP   
        /// </summary>
        public void ConnectSftp()
        {
            JSch jsch = new JSch();   //利用java实现的通讯包  
            m_session = jsch.getSession(this.UserName, this.HostName, this.Port);
            m_session.setHost(this.HostName);
            MyUserInfo ui = new MyUserInfo();
            ui.setPassword(this.Password);
            m_session.setUserInfo(ui);

            if (!m_session.isConnected())
            {
                m_session.connect();
                m_channel = m_session.openChannel("sftp");
                m_channel.connect();
                m_sftp = (ChannelSftp)m_channel;
            }
        }

        //登录验证信息            
        private class MyUserInfo : UserInfo
        {
            String passwd;
            public String getPassword() { return passwd; }
            public void setPassword(String passwd) { this.passwd = passwd; }

            public String getPassphrase() { return null; }
            public bool promptPassphrase(String message) { return true; }

            public bool promptPassword(String message) { return true; }
            public bool promptYesNo(String message) { return true; }
            public void showMessage(String message) { }
        }
        /// <summary>
        /// 获取SFTP文件列表   
        /// </summary>
        /// <param name="remotePath"></param>
        /// <param name="fileType">文件后缀名称(.txt)</param>
        /// <returns></returns>
        public List<string> GetFileList(string remotePath, string fileType)
        {
            List<string> objList = new List<string>();
            string fullRemotePath = defRemotePath + remotePath.TrimStart('/');
            if (DirExist(fullRemotePath))
            {
                Tamir.SharpSsh.java.util.Vector vvv = m_sftp.ls(fullRemotePath);
                foreach (Tamir.SharpSsh.jsch.ChannelSftp.LsEntry qqq in vvv)
                {
                    string sss = qqq.getFilename();
                    if (fileType.Contains(Path.GetExtension(sss)))
                    {
                        objList.Add(sss);
                    }
                }
            }
            return objList;
        }

        /// <summary>
        ///SFTP存放文件   
        /// </summary>
        /// <param name="localPath"></param>
        /// <param name="remotePath"></param>
        /// <returns></returns>
        public void Put(string localPath, string remotePath)
        {
            Tamir.SharpSsh.java.String src = new Tamir.SharpSsh.java.String(localPath);
            string fullRemotePath = defRemotePath + remotePath.TrimStart('/');
            Tamir.SharpSsh.java.String dst = new Tamir.SharpSsh.java.String(fullRemotePath);
            m_sftp.put(src, dst);
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="dirName">目录名称必须从根开始</param>
        /// <returns></returns>
        public void Mkdir(string dirName)
        {
            Tamir.SharpSsh.java.util.Vector vvv = m_sftp.ls(defRemotePath);
            foreach (Tamir.SharpSsh.jsch.ChannelSftp.LsEntry fileName in vvv)
            {
                string name = fileName.getFilename();
                if (name == dirName)
                {
                    throw new Exception("dir is exist");
                }
            }
            m_sftp.mkdir(defRemotePath + dirName.TrimStart('/'));
        }

        /// <summary>
        /// 目录是否存在
        /// </summary>
        /// <param name="dirName">目录名称必须从根开始</param>
        /// <returns></returns>
        public bool DirExist(string dirName)
        {
            try
            {
                m_sftp.ls(defRemotePath + dirName.TrimStart('/'));
                return true;
            }
            catch (Tamir.SharpSsh.jsch.SftpException)
            {
                return false;//执行ls命令时出错，则目录不存在。
            }
        }

        /// <summary>
        /// 断开SFTP    
        /// </summary>
        public void DisconnectSftp()
        {
            if (m_session.isConnected())
            {
                m_channel.disconnect();
                m_session.disconnect();
            }
        }

        public void Dispose()
        {
            this.DisconnectSftp();
            this.m_channel = null;
            this.m_session = null;
            this.m_sftp = null;
        }
    }
}
