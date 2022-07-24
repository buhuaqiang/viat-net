/*
 *所有关于View_cust_order_transfer类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_cust_order_transferService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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

namespace VIAT.WorkFlow.Services
{
    public partial class View_cust_order_transferService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_cust_order_transferRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_cust_order_transferService(
            IView_cust_order_transferRepository dbRepository,
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
        /// 置无效数据查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public PageGridData<View_cust_order_transfer> GetPageDataByOrderNO(PageDataOptions pageData)
        {

            PageGridData<View_cust_order_transfer> pageGridData = new PageGridData<View_cust_order_transfer>();
            string bid_no = "";
            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(pageData.Wheres))
            {
                searchParametersList = pageData.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "bid_no".ToLower())
                        {
                            bid_no = sp.Value;
                            continue;
                        }

                    }
                }
            }
            QuerySql = @"SELECT 
             ROW_NUMBER()over(order by trs.dbid desc) as rowId,
            trs.* ,
            cust.cust_id,
            cust.cust_name,
            prod.localmpg_dbid,
            mpg.mpg_name,
            prod.prod_id,
            prod.prod_ename,
            prod.state as prodStatus,
			price.min_qty,
            '' as 'pendingReason'
            FROM viat_app_cust_order_transfer trs
            LEFT JOIN viat_com_prod prod on trs.prod_dbid=prod.prod_dbid
            left join viat_com_cust cust on cust.cust_dbid=trs.cust_dbid
            LEFT JOIN viat_com_local_mpg mpg on prod.localmpg_dbid=mpg.localmpg_dbid
            left join (SELECT prod_dbid,cust_dbid,min_qty
								from viat_app_cust_price_detail WHERE status='Y' AND  SysDateTime() >= start_date
								union 
								SELECT  g.prod_dbid,g.cust_dbid,p.min_qty from viat_app_cust_group g left join viat_app_cust_price p
								on g.pricegroup_dbid=p.pricegroup_dbid and p.prod_dbid=g.prod_dbid 
								WHERE p.status='Y' AND  g.status='Y' and SysDateTime() >= p.start_date)
						as price on price.prod_dbid=trs.prod_dbid and price.cust_dbid=trs.cust_dbid
	                            WHERE ( 1 = 1 )
		                            and trs.bid_no='" + bid_no + "'";
            

            string sql = "select count(1) from (" + QuerySql + ") a";
            pageGridData.total = repository.DapperContext.ExecuteScalar(sql, null).GetInt();

            // QuerySql += "  ORDER BY prod_id, modified_date"; 
            sql = @$"select * from (" +
                QuerySql + $" ) as s where s.rowId between {((pageData.Page - 1) * pageData.Rows + 1)} and {pageData.Page * pageData.Rows} ";
            pageGridData.rows = repository.DapperContext.QueryList<View_cust_order_transfer>(sql, null);

            

            return pageGridData;
        }
    }
}
