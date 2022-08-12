/*
*所有关于Viat_sftp_import类的业务代码接口应在此处编写
*/
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace VIAT.DataEntry.IServices
{
    public partial interface IViat_sftp_importService
    {
        /// <summary>
        /// 從SFTP查詢檔案清單
        /// </summary>
        /// <param name="distId"></param>
        /// <returns></returns>
        public List<Viat_sftp_export> queryCSVFromSftp(string distId, string source);

        /// <summary>
        /// 匯入SFTP上檔案內容
        /// </summary>
        /// <param name="distId"></param>
        /// <param name="fileNames"></param>
        public void doImportCSVFromSftp(string distId, string[] fileNames);


        /// <summary>
        /// 匯入檔案內容
        /// </summary>
        /// <param name="tempPath"></param>
        /// <param name="fileNames"></param>
        public void doImportCSVFromFile(string tempPath, string[] fileNames);

        /// <summary>
        /// 匯入檔案內容
        /// </summary>
        /// <param name="fileFullPaths"></param>
        public void doImportCSVFromFile(List<IFormFile> fileFullPaths);
        WebResponseContent ImportBatch(IHeaderDictionary header);
    }
 }
