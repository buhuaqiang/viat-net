/*
 *所有关于View_full_allowance_main类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_full_allowance_mainService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
    public partial class View_full_allowance_mainService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_full_allowance_mainRepository _repository;//访问数据库
       

        [ActivatorUtilitiesConstructor]
        public View_full_allowance_mainService(
            IView_full_allowance_mainRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
           
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }


        public override PageGridData<View_full_allowance_main> GetPageData(PageDataOptions options)
        {

            PageGridData<View_full_allowance_main> pageGridData = new PageGridData<View_full_allowance_main>();
            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            string contractNo = "";
            string startDate = "";
            string endDate = "";
            string groupDbid = "";
            string custDbid = "";
            string cpProdDbid = "";
            string cfProdDbid = "";
            string status = "";
            string innerCust = "";
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "contract_no".ToLower())
                        {
                            contractNo = " and hp_contract.contract_no like '%" + sp.Value + "%' ";
                            continue;
                        }
                        if (sp.Name.ToLower() == "start_date".ToLower())
                        {
                            startDate = " and hp_contract.start_date>='" + sp.Value+"'";
                            continue;
                        }
                        if (sp.Name.ToLower() == "end_date".ToLower())
                        {
                            endDate = " and hp_contract.end_date<='" + sp.Value+"'";
                            continue;
                        }
                        if (sp.Name.ToLower() == "pricegroup_dbid".ToLower())
                        {
                            groupDbid = " and hp_contract.pricegroup_dbid='" + sp.Value+"'" ;
                            continue;
                        }
                        if (sp.Name.ToLower() == "cust_dbid".ToLower())
                        {
                            custDbid = " and c_cust.cust_dbid='" + sp.Value+"'" ;
                            innerCust = " INNER JOIN viat_app_hp_contract_cust c_cust ON c_cust.hpcont_dbid = hp_contract.hpcont_dbid ";
                            continue;
                        }
                        if (sp.Name.ToLower() == "p_prod_dbid".ToLower())
                        {
                            cpProdDbid = " 	and ( EXISTS (SELECT 1 AS C1 FROM viat_app_hp_contract_purchase_prod p_prod WHERE p_prod.prod_dbid='" + sp.Value + "' AND p_prod.hpcont_dbid=hp_contract.hpcont_dbid ))";
                            continue;
                        }
                        if (sp.Name.ToLower() == "f_prod_dbid".ToLower())
                        {
                            cfProdDbid = " and ( EXISTS (SELECT 1 AS C1 FROM viat_app_hp_contract_free_prod f_prod WHERE f_prod.prod_dbid='" + sp.Value + "' AND f_prod.hpcont_dbid=hp_contract.hpcont_dbid )) ";
                            continue;
                        }
                        if (sp.Name.ToLower() == "state".ToLower())
                        {
                            status = " and hp_contract.state='" + sp.Value+"'";
                            continue;
                        }
                    }
                }
            }


            QuerySql = "select ROW_NUMBER()over(order by tab4.created_date desc) as rowId,  tab4.*, " +
                " (select top 1 case when tab4.pricegroup_dbid is null then cust_id else '' end cust_id from viat_app_hp_contract_cust c where c.hpcont_dbid= tab4.hpcont_dbid order by created_date desc ) as cust_id," +
                " (select top 1 case when tab4.pricegroup_dbid is null then cust_name else '' end cust_name  from viat_app_hp_contract_cust c where c.hpcont_dbid= tab4.hpcont_dbid order by created_date desc ) as cust_name," +
                " (select substring(prod_id,0,len(prod_id)) prod_id from (select (select CONVERT(NVARCHAR, prod_id)+' , ' from ( " +
                "select  prod.prod_id from  viat_app_hp_contract_free_prod f_prod left join viat_com_prod prod on f_prod.prod_dbid=prod.prod_dbid and  f_prod.hpcont_dbid =  tab4.hpcont_dbid " +
                " ) a FOR XML PATH ('') ) prod_id) c) as prod_id," +
                " (select substring(prod_ename,0,len(prod_ename)) prod_name from (select (select CONVERT(NVARCHAR, prod_ename)+' , ' from (" +
                "  select  prod.prod_ename from  viat_app_hp_contract_free_prod f_prod left join viat_com_prod prod on f_prod.prod_dbid=prod.prod_dbid  and  f_prod.hpcont_dbid =  tab4.hpcont_dbid " +
                " ) a FOR XML PATH ('') ) prod_ename) c) as prod_ename ," +
                " Null as p_prod_dbid,Null as f_prod_dbid from (  " +
                "select  tab.* ,tab2.cust_dbid,tab3.prod_dbid from ( " +
                "SELECT  hp_contract.*,allw_sum1.A1 as C1,allw_sum2.A1 AS C2,allw_sum3.A1 AS C3 ,price_group.group_id,price_group.group_name " +
                "FROM  viat_app_hp_contract hp_contract " +
                "LEFT OUTER JOIN( select  allw_sum.hpcont_dbid as K1,	SUM(allw_sum.amount) AS A1  from  viat_app_hp_contract_allw_sum allw_sum   " +
                "where allw_sum.hpcont_dbid is not null  and allw_sum.action_type='1' and allw_sum.trans_date<=SysDateTime() " +
                "	group by allw_sum.hpcont_dbid )as allw_sum1 on allw_sum1.K1=hp_contract.hpcont_dbid " +
                "LEFT OUTER JOIN( select  allw_sum.hpcont_dbid as K1,	SUM(allw_sum.amount) AS A1  from  viat_app_hp_contract_allw_sum allw_sum " +
                "where allw_sum.hpcont_dbid is not null  and allw_sum.action_type='2' group by allw_sum.hpcont_dbid )as allw_sum2 on allw_sum2.K1=hp_contract.hpcont_dbid " +
                "LEFT OUTER JOIN( select  allw_sum.hpcont_dbid as K1,	SUM(allw_sum.amount) AS A1  from  viat_app_hp_contract_allw_sum allw_sum " +
                "where allw_sum.hpcont_dbid is not null  and allw_sum.action_type='3' group by allw_sum.hpcont_dbid)as allw_sum3  on allw_sum3.K1=hp_contract.hpcont_dbid  " +
                "LEFT OUTER JOIN viat_app_cust_price_group price_group ON price_group.pricegroup_dbid = hp_contract.pricegroup_dbid " +

                innerCust +
                " where 1=1  " +
                contractNo +
                startDate +
                endDate +
                groupDbid +
                custDbid +
                cpProdDbid +
                cfProdDbid +
                status +
                " )tab outer apply ( " +
                "select top 1  contract_cust.cust_dbid  " +
                "from  viat_app_hp_contract_cust contract_cust	INNER JOIN viat_com_cust cust ON contract_cust.cust_dbid = cust.cust_dbid  " +
                "where contract_cust.hpcont_dbid=tab.hpcont_dbid and contract_cust.status='Y' AND cust.status='Y') tab2  " +
                " OUTER APPLY(select   top 1  free_prod.prod_dbid  from viat_app_hp_contract_free_prod free_prod " +
                "where free_prod.hpcont_dbid=tab.hpcont_dbid )as tab3  " +
                "	)tab4 " +
                "LEFT OUTER JOIN viat_com_cust cust on tab4.cust_dbid= cust.cust_dbid  " +
                "LEFT OUTER JOIN viat_com_prod prod on tab4.prod_dbid=prod.prod_dbid ";

            string sql = "select count(1) from (" + QuerySql + ") a";
            pageGridData.total = repository.DapperContext.ExecuteScalar(sql, null).GetInt();

            sql = @$"select * from (" +
                QuerySql + $" ) as s where s.rowId between {((options.Page - 1) * options.Rows + 1)} and {options.Page * options.Rows} ";
            pageGridData.rows = repository.DapperContext.QueryList<View_full_allowance_main>(sql, null);

            return pageGridData;

            //return base.GetPageData(options);
        }


    }
}
