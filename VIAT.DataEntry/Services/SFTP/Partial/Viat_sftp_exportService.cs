/*
 *所有关于Viat_sftp_export类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_sftp_exportService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.DataEntry.IRepositories;
using System.Collections.Generic;
using VIAT.DataEntry.Utillity;

namespace VIAT.DataEntry.Services
{
    public partial class Viat_sftp_exportService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_sftp_exportRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_sftp_exportService(
            IViat_sftp_exportRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webResponse = new WebResponseContent();
        /// <summary>
        /// 获取SFTP信息
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override PageGridData<Viat_sftp_export> GetPageData(PageDataOptions options)
        { 
            PageGridData<Viat_sftp_export> pageData = new PageGridData<Viat_sftp_export>();
            List<Viat_sftp_export> SftpList = new List<Viat_sftp_export>();
            List<SearchParameters> searchParametersList = new List<SearchParameters>();

            string s_type = null;
            string s_Distributor = null;
            string start_date = "",end_date = "";
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "type".ToLower())
                        {
                            s_type = GetTypeName(sp.Value);
                            continue;
                        }
                        if (sp.Name.ToLower() == "dist_id".ToLower())
                        {
                            s_Distributor = GetDistEName(sp.Value);
                            continue;
                        }
                        if (sp.Name.ToLower() == "start_date".ToLower())
                        {
                            start_date = sp.Value;
                            continue;
                        }
                        if (sp.Name.ToLower() == "end_date".ToLower())
                        {
                            end_date = sp.Value;
                            continue;
                        }
                    }
                }
            }
            using (var sftpClient = new SftpClient())
            {
                //处理逻辑
                var ob = sftpClient.GetFileList("", ".csv");
            }
            pageData.total = SftpList.Count();
            pageData.rows = SftpList;
            return pageData;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public WebResponseContent Execute(SaveModel saveModel)
        {
            using (var sftpClient = new SftpClient())
            {

            }
            return webResponse.OK();
        }

        public string GetTypeName(string type)
        {
            string typeName = "";
            switch (type)
            {
                case "1":
                    type = "price";
                    break;
                case "2":
                    type = "customer";
                    break;
                case "3":
                    type = "order";
                    break;
                case "4":
                    type = "Allowance";
                    break;
                default:
                    typeName = "price,customer,order,Allowance";
                    break;
            }
            return typeName;
        }

        /// <summary>
        /// Distributor名称
        /// </summary>
        /// <param name="dist_id"></param>
        /// <returns></returns>
        public string GetDistEName(string dist_id)
        {
            string na = "";
            switch (dist_id)
            {
                case "1":
                    na = "ParkeDavis";
                    break;
                case "2":
                    na = "Zuellig";
                    break;
                case "3":
                    na = "Arich";
                    break;
                case "4":
                    na = "ShineSeng";
                    break;
                case "5":
                    na = "Holding";
                    break;
                case "6":
                    na = "grholddi";
                    break;
                case "8":
                    na = "Summit";
                    break;
                case "9":
                    na = "OrientEropharma";
                    break;
                case "A":
                    na = "AnChiang";
                    break;
                case "B":
                    na = "HuiMaw";
                    break;
                case "C":
                    na = "SingLong";
                    break;
                case "D":
                    na = "HorngWang";
                    break;
                case "E":
                    na = "EnHong";
                    break;
                case "G":
                    na = "CCPC";
                    break;
                case "H":
                    na = "CONMED";
                    break;
                case "I":
                    na = "keto";
                    break;
                case "J":
                    na = "zowhong";
                    break;
                case "K":
                    na = "medlion";
                    break;
                case "M":
                    na = "supermed";
                    break;
                case "N":
                    na = "astrong";
                    break;
                case "O":
                    na = "pingtin";
                    break;

            }
            return na.ToLower();
        }
    }
}
