/*
 *所有关于Viat_wk_master类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_wk_masterService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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

namespace VIAT.WorkFlow.Services
{
    public partial class Viat_wk_masterService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_wk_masterRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_wk_masterService(
            IViat_wk_masterRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        /// <summary>
        /// 取得bidNO
        /// </summary>
        public string getBidNO()
        {
            //取得当前日期
            string sCurrentDate = System.DateTime.Now.ToString("yyyyMMdd");
            string sStart = "BID" + sCurrentDate + "-";
            string sSql = @"SELECT MAX (bid_no) AS max_bidno 
                            FROM viat_wk_master
                            WHERE LEN(bid_no) = 17
                                  AND bid_no LIKE '" + sStart + @"%'
                            ";
            object obj = _repository.DapperContext.ExecuteScalar(sSql, null);
            if (obj == null)
            {
                //当天第一个号码
                return sStart + "00001";
            }
            else
            {
                //取得当前最大序号 
                string sSerial = obj.ToString().Substring(11, 5);
                int nSerial = 0;
                int.TryParse(sSerial, out nSerial);
                return sStart + (nSerial + 1).ToString().PadLeft(5, '0');
            }
        }

        /// <summary>
        /// get master information
        /// </summary>
        /// <param name="sBidMastDBID"></param>
        /// <returns></returns>
        public Viat_wk_master getMasterByDBID(string sBidMastDBID)
        {
            string sSql = "select * from viat_wk_master where bidmast_dbid='" + sBidMastDBID + "'";
            return _repository.DapperContext.QueryFirst<Viat_wk_master>(sSql, null);
        }
    }
}
