/*
 *所有关于Viat_app_power_contract_cust类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_app_power_contract_custService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;
using System.Linq;
using VOL.Core.Utilities;
using System.Linq.Expressions;
using VOL.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Contract.IRepositories;
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Filters;
using System.Collections.Generic;
using VOL.Core.EFDbContext;
using VOL.Core.DBManager;
using Newtonsoft.Json;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VOL.Core.Configuration;
using VOL.Core.Extensions;
using VOL.Core.Filters;
using VOL.Core.Services;
using VOL.Core.Utilities;
using VOL.Entity.DomainModels;
namespace VIAT.Contract.Services
{
    public partial class Viat_app_power_contract_custService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_app_power_contract_custRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_app_power_contract_custService(
            IViat_app_power_contract_custRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        //override PageGridData<Viat_app_power_contract_cust_select> GetPageData(PageDataOptions options)
        public override PageGridData<Viat_app_power_contract_cust_select> GetPageData(PageDataOptions options)
        {
            /*VOLContext context = DBServerProvider.GetEFDbContext();
            var dicData =  (from d in context.Set<Viat_app_power_contract_cust>() 
                                 join list in context.Set<Viat_com_cust>()
                                 on d.cust_dbid equals list.cust_dbid
                                 into t
                                 from list in t.DefaultIfEmpty()
                                 where d.powercont_dbid.Equals(powercont_dbid)
                                 select new { 
                                     d.powercont_dbid, 
                                     d.powercontcust_dbid,
                                     d.cust_dbid, 
                                     list.cust_id,
                                     list.cust_name
                                 }).ToListAsync();*/
            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    string sPowerContDbid = "";
                    foreach(SearchParameters sp in searchParametersList)
                    {
                        if(sp.Name.ToLower() == "powercont_dbid".ToLower())
                        {
                            sPowerContDbid = sp.Value;
                            continue;
                        }
                    }
                   
                    QuerySql = "select cus.*,comcus.cust_id,comcus.cust_name,comcus.territory_id from Viat_app_power_contract_cust cus " +
                "left join Viat_com_cust comcus on cus.cust_dbid=comcus.cust_dbid" +
                " where cus.powercont_dbid='" + sPowerContDbid + "'";
                }
            }

          
          

            return base.GetPageData(options);
        }


    }
}
