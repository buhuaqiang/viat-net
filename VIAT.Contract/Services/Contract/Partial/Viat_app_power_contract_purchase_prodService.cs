/*
 *所有关于Viat_app_power_contract_purchase_prod类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_app_power_contract_purchase_prodService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Contract.IRepositories;
using Microsoft.AspNetCore.Mvc;
using VIAT.Core.Filters;
using System.Collections.Generic;
using VIAT.Core.EFDbContext;
using VIAT.Core.DBManager;
using Newtonsoft.Json;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VIAT.Core.Configuration;
using VIAT.Core.Extensions;
using VIAT.Core.Filters;
using VIAT.Core.Services;
using VIAT.Core.Utilities;
using VIAT.Entity.DomainModels;
namespace VIAT.Contract.Services
{
    public partial class Viat_app_power_contract_purchase_prodService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_app_power_contract_purchase_prodRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_app_power_contract_purchase_prodService(
            IViat_app_power_contract_purchase_prodRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override PageGridData<Viat_app_power_contract_purchase_prod_select> GetPageData(PageDataOptions options)
        {
          
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
                            sPowerContDbid = sp.Value ?? System.Guid.NewGuid().ToString() ?? sp.Value;
                            continue;
                        }
                    }
                    
                    QuerySql = @"SELECT
                                prod.*,
	                            comprod.prod_id,
	                            comprod.prod_ename
                                FROM
                                Viat_app_power_contract_purchase_prod prod
    LEFT JOIN Viat_com_prod comprod ON prod.prod_dbid = comprod.prod_dbid " +
                " where prod.powercont_dbid='" + sPowerContDbid + "'";
                }
            }

          
          

            return base.GetPageData(options);
        }


    }
}
