/*
 *所有关于View_full_allowance_summary类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_full_allowance_summaryService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using Newtonsoft.Json;

namespace VIAT.DataEntry.Services
{
    public partial class View_full_allowance_summaryService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_full_allowance_summaryRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_full_allowance_summaryService(
            IView_full_allowance_summaryRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override PageGridData<View_full_allowance_summary> GetPageData(PageDataOptions options)
        {
            PageGridData<View_full_allowance_summary> pageGridData = new PageGridData<View_full_allowance_summary>();
            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            string hpcont_dbid = "";
            string hpcont_dbid1 = "";
            string hpcont_dbid2 = "";
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "hpcont_dbid".ToLower())
                        {
                            hpcont_dbid = " and allw_sum.hpcont_dbid='" + sp.Value + "'";
                            hpcont_dbid1 = " and share.hpcont_dbid='" + sp.Value + "'";
                            hpcont_dbid2 = " and hpcont_dbid='" + sp.Value + "'";
                            continue;
                        }
                    }
                }

            }

            QuerySql = "select  * from " +
                "(select  ROW_NUMBER()over(order by cust_id desc) as rowId, 'Share' as action_type,tab4.cust_dbid, tab4.cust_id, tab4.cust_name, tab4.prod_id, tab4.prod_ename, tab4.amount from( " +
                "select  tab.*, cust.cust_id, cust.cust_name, cust.status, prod.prod_id, prod.prod_ename, prod.state, tab2.amount, tab3.[percent] as [percent] from( " +
               " select allw_sum.prod_dbid as prod_dbid, allw_sum.cust_dbid as cust_dbid, sum(allw_sum.amount) as A1 from viat_app_hp_contract_allw_sum allw_sum " +
                "  left outer join Sys_User s_user  on s_user.User_Id = allw_sum.modified_user " +
                "left outer join viat_com_employee employee on employee.emp_dbid = s_user.emp_dbid " +
                "where allw_sum.prod_dbid is not null and allw_sum.cust_dbid is not null and allw_sum.action_type = '1'  " +
                hpcont_dbid+
               " group by allw_sum.prod_dbid, allw_sum.cust_dbid " +
                ")tab " +
                "LEFT OUTER JOIN  viat_com_cust cust on cust.cust_dbid = tab.cust_dbid " +
               " left outer join viat_com_prod prod on prod.prod_dbid = tab.prod_dbid " +
               " outer apply(select  top 1 allw_sum.amount as amount from viat_app_hp_contract_allw_sum allw_sum where tab.cust_dbid = allw_sum.cust_dbid and tab.prod_dbid = allw_sum.prod_dbid) as tab2 " +
               " outer apply(select top 1 share.[percent] as [percent]  from viat_app_hp_contract_share share where share.cust_dbid = tab.cust_dbid and share.prod_dbid = tab.prod_dbid " +
               hpcont_dbid1+
               " ) as tab3 " +
                ")tab4 " +
                ")tab5 " +
               " union " +
              "  (select  ROW_NUMBER()over(order by cust_id desc) as rowId,case when allw_sum.action_type = '2' then 'Reverse' else 'Adjust' end as action_type ,cust.cust_dbid,cust.cust_id,cust.cust_name,prod.prod_id,prod.prod_ename,allw_sum.amount from viat_app_hp_contract_allw_sum allw_sum " +
               " inner join viat_com_cust cust on cust.cust_dbid = allw_sum.cust_dbid " +
               " inner join viat_com_prod prod on prod.prod_dbid = allw_sum.prod_dbid " +
               " left outer join Sys_User s_user on s_user.User_Id = allw_sum.modified_user " +
               " left outer join viat_com_employee employee on employee.emp_dbid = s_user.emp_dbid " +
               " where allw_sum.action_type in ('2', '3') " +
               hpcont_dbid2+
               " )";

          
            string sql = "select count(1) from (" + QuerySql + ") a";
            pageGridData.total = repository.DapperContext.ExecuteScalar(sql, null).GetInt();

            sql = @$"select * from (" +
                QuerySql + $" ) as s where s.rowId between {((options.Page - 1) * options.Rows + 1)} and {options.Page * options.Rows} ";
            pageGridData.rows = repository.DapperContext.QueryList<View_full_allowance_summary>(sql, null);

            return pageGridData;
        }
    }
}
