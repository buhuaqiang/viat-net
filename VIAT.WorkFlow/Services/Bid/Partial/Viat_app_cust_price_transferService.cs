/*
 *所有关于Viat_app_cust_price_transfer类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_app_cust_price_transferService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;
using System.Linq;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using VIAT.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.WorkFlow.IRepositories;
using System.Collections.Generic;
using System;
using System.IO;

namespace VIAT.WorkFlow.Services
{
    public partial class Viat_app_cust_price_transferService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_app_cust_price_transferRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_app_cust_price_transferService(
            IViat_app_cust_price_transferRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webRespose = new WebResponseContent();
        /// <summary>
        /// 取得数据
        /// </summary>
        /// <param name="price_transfer_dbid"></param>
        /// <returns></returns>
        public Viat_app_cust_price_transfer getPriceTransferByDBID(string price_transfer_dbid)
        {
            string sSql = "select * from Viat_app_cust_price_transfer where price_transfer_dbid='" + price_transfer_dbid + "'";

            return _repository.DapperContext.QueryFirst<Viat_app_cust_price_transfer>(sSql, null);
        }
        public WebResponseContent ImportData(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return new WebResponseContent { Code = "-2", Status = true, Message = "please select file" };
            IFormFile formFile = files[0];
            string dicPath = $"Upload/{DateTime.Now.ToString("yyyMMdd")}/{typeof(Viat_app_cust_price_transfer).Name}/".MapPath();
            if (!Directory.Exists(dicPath)) Directory.CreateDirectory(dicPath);
            dicPath = $"{dicPath}{Guid.NewGuid().ToString()}_{formFile.FileName}";

            using (var stream = new FileStream(dicPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            try
            {
                webRespose = EPPlusHelper.ReadToDataTable<Viat_app_cust_price_transfer>(bCheckImportCustom, dicPath, DownLoadTemplateColumns, GetIgnoreTemplate());
            }
            catch (Exception)
            {
                return new WebResponseContent { Code = "-2", Status = true, Message = "please check file correct" };
            }

            //List<Viat_app_cust_price_transfer> list = webRespose.Data as List<Viat_app_cust_price_transfer>;
            //if (list != null && list.Count > 0)
            //{ 

            //}
            webRespose.Code = "-1";
            return webRespose;
        }
        private static string[] auditFields = new string[] { "auditid", "auditstatus", "auditor", "auditdate", "auditreason" };
        private List<string> GetIgnoreTemplate()
        {
            //忽略创建人、修改人、审核等字段
            List<string> ignoreTemplate = UserIgnoreFields.ToList();
            ignoreTemplate.AddRange(auditFields.ToList());
            return ignoreTemplate;
        }
    }
}
