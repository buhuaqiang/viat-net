using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VIAT.Core.Configuration;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Utillity
{
    public class SFTPHelper :IDisposable
    {
        #region 字段或属性
        private SftpClient sftp;
        /// <summary>
        /// SFTP连接状态
        /// </summary>
        public bool Connected { get { return sftp.IsConnected; } }
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">端口</param>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        public SFTPHelper()
        {
            sftp = new SftpClient(AppSetting.SftpSite.HostName, 22, AppSetting.SftpSite.UserName, AppSetting.SftpSite.Password);
            Connect();
        }
        ~SFTPHelper()
        {
            Disconnect();
        }
        #endregion
        #region 连接SFTP
        /// <summary>
        /// 连接SFTP
        /// </summary>
        /// <returns>true成功</returns>
        public bool Connect()
        {
            try
            {
                if (!Connected)
                {
                    sftp.Connect();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("连接SFTP失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region 断开SFTP
        /// <summary>
        /// 断开SFTP
        /// </summary> 
        public void Disconnect()
        {
            try
            {
                if (sftp != null && Connected)
                {
                    sftp.Disconnect();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("断开SFTP失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region 创建目录
        /// <summary>
        /// 循环创建目录
        /// </summary>
        /// <param name="remotePath">远程目录</param>
        public void CreateDirectory(string remotePath)
        {
            try
            {
                string[] paths = remotePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string curPath = "/";
                for (int i = 0; i < paths.Length; i++)
                {
                    curPath += paths[i];
                    if (!sftp.Exists(curPath))
                    {
                        sftp.CreateDirectory(curPath);
                    }
                    if (i < paths.Length - 1)
                    {
                        curPath += "/";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("创建目录失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region SFTP上传文件
        /// <summary>
        /// SFTP上传文件
        /// </summary>
        /// <param name="localPath">本地文件全路径 例：G:\\Project\\logo.png</param>
        /// <param name="remotePath">远程路径  例：/logo.png</param>
        public bool Put(string localPath, string remotePath)
        {
            try
            {
                using (var file = File.OpenRead(localPath))
                {
                    Connect();
                    //CreateDirectory(remotePath);
                    sftp.UploadFile(file, remotePath);
                    Disconnect();
                }
                return true;
            }
            catch (Exception ex)
            {
                Disconnect();
                return false;
            }
        }
        #endregion
        #region SFTP获取文件
        /// <summary>
        /// SFTP获取文件
        /// </summary>
        /// <param name="remotePath">远程路径</param>
        /// <param name="localPath">本地路径</param>
        public void Get(string remotePath, string localPath)
        {
            try
            {
                Connect();
                var byt = sftp.ReadAllBytes(remotePath);
                File.WriteAllBytes(localPath, byt);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SFTP文件获取失败，原因：{0}", ex.Message));
            }

        }
        #endregion

        #region 获取SFTP文件列表
        /// <summary>
        /// 获取SFTP文件列表
        /// </summary>
        /// <param name="remotePath">远程目录</param>
        /// <param name="fileSuffix">文件后缀</param>
        /// <returns></returns>
        public List<Viat_sftp_export> GetFileList(string remotePath, string fileSuffix)
        {
            try
            {
                Connect();
                var files = sftp.ListDirectory(remotePath);
                Disconnect();
                var objList = new List<string>();
                List < Viat_sftp_export > sftp_ExportList = new List<Viat_sftp_export>();
                foreach (var file in files)
                {
                    Viat_sftp_export sftp_Export = new Viat_sftp_export();
                    string name = file.Name;
                    if (name.Length > (fileSuffix.Length + 1) && fileSuffix == name.Substring(name.Length - fileSuffix.Length))
                    {
                        sftp_Export.file_name = file.Name;
                        sftp_Export.file_size = file.Length;
                        sftp_Export.modified_date = file.LastWriteTimeUtc;
                        sftp_ExportList.Add(sftp_Export);
                    }
                }
                return sftp_ExportList;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw new Exception(string.Format("SFTP文件列表获取失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region 删除SFTP文件
        /// <summary>
        /// 删除SFTP文件 
        /// </summary>
        /// <param name="remoteFile">远程路径</param>
        public void Delete(string remoteFile)
        {
            try
            {
                Connect();
                sftp.Delete(remoteFile);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SFTP文件删除失败，原因：{0}", ex.Message));
            }
        }

        public void Dispose()
        {
            Disconnect();
        }
        #endregion
    }
}
