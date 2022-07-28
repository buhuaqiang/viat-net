/*
 *所有关于View_cust_price_detail类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_cust_price_detailService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Price.IRepositories;
using VIAT.Price.IServices;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Globalization;
using VIAT.Core.Enums;

namespace VIAT.Price.Services
{
    public partial class View_cust_price_detailService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_cust_price_detailRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();
        private readonly IViat_app_cust_price_detailService _viat_app_cust_price_detailService;


        [ActivatorUtilitiesConstructor]
        public View_cust_price_detailService(
            IView_cust_price_detailRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_cust_price_detailService viat_app_cust_price_detailService
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
            _viat_app_cust_price_detailService = viat_app_cust_price_detailService;
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            return _viat_app_cust_price_detailService.Add(saveDataModel);
        }


        /// <summary>
        /// 置无效数据查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public  PageGridData<View_cust_price_detail> GetCustInvalidPageData(PageDataOptions pageData)
        {

            PageGridData<View_cust_price_detail> pageGridData = new PageGridData<View_cust_price_detail>();

            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(pageData.Wheres))
            {
                searchParametersList = pageData.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    string sCustID = "";
                    string sProdID = "";
                    string sChannel = "";
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "cust_dbid".ToLower())
                        {
                            sCustID = sp.Value;
                            continue;
                        }

                        if (sp.Name.ToLower() == "prod_dbid".ToLower())
                        {
                            sProdID = sp.Value;
                            continue;
                        }
                        //channelValue
                        if (sp.Name.ToLower() == "channelValue".ToLower())
                        {
                            sChannel = sp.Value;
                            continue;
                        }
                    }

                    QuerySql = @"
                        SELECT 
                        custPrice.pricedetail_dbid AS pricedetail_dbid, '1' AS source_type,
	                        custPrice.prod_dbid , prod.prod_id, prod.prod_ename, custPrice.nhi_price ,
	                        custPrice.invoice_price ,	custPrice.net_price , custPrice.min_qty ,
	                        custPrice.start_date , custPrice.end_date , custPrice.status ,
                            cust.cust_dbid, cust.cust_id, cust.cust_name,	'' AS group_id,'' AS group_name
                        FROM
	                        viat_app_cust_price_detail AS custPrice
	                        INNER JOIN viat_com_cust AS cust ON custPrice.cust_dbid = cust.cust_dbid
	                        INNER JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid 
                        WHERE ( 1 = 1 )  AND custPrice.status = 'Y' ";  /*filter Cust Id 必填 */

                    if (string.IsNullOrEmpty(sCustID) == false)
                    {
                        QuerySql += " AND custPrice.cust_dbid = '" + sCustID + "'";
                    }
                    if (string.IsNullOrEmpty(sProdID) == false)
                    {
                        QuerySql += " AND prod.prod_dbid = '" + sProdID+"'";
                    }
                    if (string.IsNullOrEmpty(sChannel) == false)
                    {
                        QuerySql += "  and custPrice.cust_dbid in ( select comCust.cust_dbid from viat_com_doh_type doh  inner join viat_com_cust comCust on" +
                    " doh.doh_type=comCust.doh_type where doh.channel='" + sChannel + "')";
                    }
                    QuerySql += @" AND prod.state = '1'	
                        UNION ALL
                        SELECT  
	                        custGroup.custgroup_dbid AS pricedetail_dbid, '2' AS source_type,
	                        custPrice.prod_dbid , prod.prod_id, prod.prod_ename, custPrice.nhi_price ,
	                        custPrice.invoice_price ,	custPrice.net_price , custPrice.min_qty ,
	                        custPrice.start_date , custPrice.end_date , custPrice.status ,
                            cust.cust_dbid,cust.cust_id, cust.cust_name, priceGroup.group_id, priceGroup.group_name
                        FROM 			
	                        viat_app_cust_price AS custPrice
	                        INNER JOIN viat_app_cust_group AS custGroup ON custPrice.pricegroup_dbid = custGroup.pricegroup_dbid 
	                        INNER JOIN viat_com_cust AS cust ON custGroup.cust_dbid = cust.cust_dbid
	                        AND custPrice.prod_dbid =custGroup.prod_dbid	
                          LEFT OUTER JOIN viat_app_cust_price_group AS priceGroup ON custPrice.pricegroup_dbid = priceGroup.pricegroup_dbid
	                        INNER JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid
	                        WHERE ( 1 = 1 ) AND custPrice.status = 'Y'";
                    if (string.IsNullOrEmpty(sCustID) == false)
                    {
                        QuerySql += " AND custGroup.cust_dbid = '" + sCustID + "'";
                    }
                    if (string.IsNullOrEmpty(sProdID) == false)
                    {
                        QuerySql += " AND prod.prod_dbid = '" + sProdID + " ' ";
                    }
                    if (string.IsNullOrEmpty(sChannel) == false)
                    {
                        QuerySql += "  and custGroup.cust_dbid in ( select comCust.cust_dbid from viat_com_doh_type doh  inner join viat_com_cust comCust on" +
                    " doh.doh_type=comCust.doh_type where doh.channel='" + sChannel + "')";
                    }
                    QuerySql += " AND prod.state = '1' AND custGroup.status = 'Y'";
 
                }
            }
                      
            string sql = "select count(1) from (" + QuerySql + ") a";
            pageGridData.total = repository.DapperContext.ExecuteScalar(sql, null).GetInt();

            sql = @$" select * from ( select d.*,ROW_NUMBER()over(order by d.pricedetail_dbid desc) as rowId from (" + 
                QuerySql + $") as d )as s where s.rowId between {((pageData.Page - 1) * pageData.Rows + 1)} and {pageData.Page * pageData.Rows} ";
                pageGridData.rows = repository.DapperContext.QueryList<View_cust_price_detail>(sql, null);

            return pageGridData;
        }




        /// <summary>
        /// 置无效数据查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public List<View_cust_price_detail> GetCustInvalidList(string cust_dbid, string prod_dbid, string channel)
        {
            string sSql = @"
                        SELECT ROW_NUMBER()over(order by custPrice.pricedetail_dbid desc) as rowId,
                        custPrice.pricedetail_dbid AS pricedetail_dbid, '1' AS source_type,
	                        custPrice.prod_dbid , prod.prod_id, prod.prod_ename, custPrice.nhi_price ,
	                        custPrice.invoice_price ,	custPrice.net_price , custPrice.min_qty ,
	                        custPrice.start_date , custPrice.end_date , custPrice.status ,
                            cust.cust_dbid, cust.cust_id, cust.cust_name,	'' AS group_id,'' AS group_name
                        FROM
	                        viat_app_cust_price_detail AS custPrice
	                        INNER JOIN viat_com_cust AS cust ON custPrice.cust_dbid = cust.cust_dbid
	                        INNER JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid 
                        WHERE ( 1 = 1 )  AND custPrice.status = 'Y' ";
            if (string.IsNullOrEmpty(cust_dbid) == false)
            {
                sSql += " AND custPrice.cust_dbid = '" + cust_dbid + "'";      
            } 
            if (string.IsNullOrEmpty(prod_dbid) == false)
            {
                sSql += " AND prod.prod_dbid = '" + prod_dbid + "'";
            }
            if(string.IsNullOrEmpty(channel) == false)
            {
                sSql += "  and custPrice.cust_dbid in ( select comCust.cust_dbid from viat_com_doh_type doh  inner join viat_com_cust comCust on" +
                    " doh.doh_type=comCust.doh_type where doh.channel='"+channel+"')";
            }
            sSql += @" AND prod.state = '1'	
                        UNION ALL
                        SELECT ROW_NUMBER()over(order by custGroup.custgroup_dbid desc) as rowId,
	                        custGroup.custgroup_dbid AS pricedetail_dbid, '2' AS source_type,
	                        custPrice.prod_dbid , prod.prod_id, prod.prod_ename, custPrice.nhi_price ,
	                        custPrice.invoice_price ,	custPrice.net_price , custPrice.min_qty ,
	                        custPrice.start_date , custPrice.end_date , custPrice.status ,
                            cust.cust_dbid,cust.cust_id, cust.cust_name, priceGroup.group_id, priceGroup.group_name
                        FROM 			
	                        viat_app_cust_price AS custPrice
	                        INNER JOIN viat_app_cust_group AS custGroup ON custPrice.pricegroup_dbid = custGroup.pricegroup_dbid 
	                        INNER JOIN viat_com_cust AS cust ON custGroup.cust_dbid = cust.cust_dbid
	                        AND custPrice.prod_dbid =custGroup.prod_dbid	
                          LEFT OUTER JOIN viat_app_cust_price_group AS priceGroup ON custPrice.pricegroup_dbid = priceGroup.pricegroup_dbid
	                        INNER JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid
	                        WHERE ( 1 = 1 ) AND custPrice.status = 'Y'";                            
            if (string.IsNullOrEmpty(cust_dbid) == false)
            {
                sSql += " AND custGroup.cust_dbid = '" + cust_dbid + "'";
            }
            if (string.IsNullOrEmpty(prod_dbid) == false)
            {
                sSql += " AND prod.prod_dbid = '" + prod_dbid + "' ";
            }
            if (string.IsNullOrEmpty(channel) == false)
            {
                sSql += "  and custGroup.cust_dbid in ( select comCust.cust_dbid from viat_com_doh_type doh  inner join viat_com_cust comCust on" +
                    " doh.doh_type=comCust.doh_type where doh.channel='" + channel + "')";
            }
            sSql += " AND prod.state = '1' AND custGroup.status = 'Y'";
             

            return repository.DapperContext.QueryList<View_cust_price_detail>(sSql, null);

        }



        public override PageGridData<View_cust_price_detail> GetPageData(PageDataOptions options)
        {
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
            setQueryParametersNew(searchParametersList);

            Dictionary<string, string> detailsAlias = new Dictionary<string, string>() {
                { "cust_id", "cust" },{ "start_date","custPrice"} ,{ "end_date","custPrice"},{ "updated_date","custPrice"},
                 { "prod_id", "prod" },{ "cust_dbid","custPrice"} ,{ "status","custPrice"} ,
                { "state","prod"}
            };
            Dictionary<string, string> groupAlias = new Dictionary<string, string>() {
                { "cust_id", "cust" },{ "start_date","custPrice"} ,{ "end_date","custPrice"},{ "updated_date","custPrice"},
                 { "prod_id", "prod" },{ "cust_dbid","custGroup"} ,{ "status","custPrice"},{ "state","prod"}
            };
            string sDetailConditon = getWhereCondition(searchParametersList, detailsAlias);            //处理查询条件
            string sGroupConditon =getWhereCondition(searchParametersList, groupAlias);// sDetailConditon;//查詢條件是一樣的,所以直接拿這個拼接好的sql,如果查詢條件不一樣需要重新 getWhereCondition(in的時候字符串會再多一層'')    

            QuerySql = @"SELECT
	                    custPrice.pricedetail_dbid AS pricedetail_dbid,
	                    '1' AS source_type,
	                    '' AS group_id,
	                    '' AS group_name,
                      cust.cust_dbid,
	                    cust.cust_id,
	                    cust.cust_name,
                     CONCAT(cust.cust_id,' ',cust.cust_name) AS cust_dbidname,
	                    '' as prods,
	                    prod.prod_dbid,
	                    prod.prod_id,
	                    prod.prod_ename,
	                    CONCAT(prod.prod_id,' ',prod.prod_ename) AS prod_dbidname,
	                    custPrice.nhi_price,
	                    custPrice.invoice_price,
	                    custPrice.net_price,
	                    custPrice.gross_price,
	                    custPrice.reserv_price,
	                    custPrice.min_qty,
	                    custPrice.status,
	                    custPrice.start_date,
	                    custPrice.end_date,
	                    custPrice.modified_date,
                        custPrice.updated_date,
                        custPrice.modified_username,
	                    custPrice.remarks,
	                    custPrice.bid_no,
	                    prod.state,
	                    '' AS cust_group_status,
	                    emp.emp_ename,
	                    cust.status as custStatus,
                    '' as ShowInvalidProd,
                    '' as QueryStatus
                    FROM
	                    viat_app_cust_price_detail AS custPrice
                    LEFT JOIN viat_com_cust AS cust ON custPrice.cust_dbid = cust.cust_dbid
                    LEFT JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid
                    LEFT JOIN viat_com_employee AS emp ON custPrice.modified_user = emp.dbid
                    WHERE 1=1  ";
            QuerySql += sDetailConditon;
            QuerySql += " union  all";
            QuerySql += @" SELECT
                        custPrice.custprice_dbid AS pricedetail_dbid,
	                    '2' AS source_type,
                        priceGroup.group_id,
	                    priceGroup.group_name,
	                    cust.cust_dbid,
	                    cust.cust_id,
	                    cust.cust_name,
                    CONCAT(cust.cust_id, ' ', cust.cust_name) AS cust_dbidname,
                    '' as prods,
                      prod.prod_dbid,
	                    prod.prod_id,
	                    prod.prod_ename,
                    CONCAT(prod.prod_id, ' ', prod.prod_ename) AS prod_dbidname,
                          custPrice.nhi_price,
	                    custPrice.invoice_price,
	                    custPrice.net_price,
	                    0 AS gross_price,
                        custPrice.reserv_price,
	                    custPrice.min_qty,
                        custGroup.status,
	                   
	                    custGroup.start_date,
	                    custGroup.end_date,
	                    custGroup.modified_date,
                        custGroup.updated_date,
                        custGroup.modified_username,
	                    custPrice.remarks,
	                    '' as bid_no,
	                    prod.state,
	                     custPrice.status priceStatus,
	                    '' AS emp_ename,
                        cust.status custStatus,
                    '' as ShowInvalidProd,
                    '' as QueryStatus
                    FROM
                        viat_app_cust_group AS custGroup
                    JOIN viat_app_cust_price AS custPrice ON custPrice.pricegroup_dbid = custGroup.pricegroup_dbid
                    AND custPrice.prod_dbid = custGroup.prod_dbid
                    JOIN viat_app_cust_price_group AS priceGroup ON custPrice.pricegroup_dbid = priceGroup.pricegroup_dbid 
                    AND priceGroup.status = 'Y'
                    JOIN viat_com_prod AS prod ON custGroup.prod_dbid = prod.prod_dbid
                    JOIN viat_com_cust AS cust ON custGroup.cust_dbid = cust.cust_dbid where 1=1";
            QuerySql += sGroupConditon;



            /*base.OrderByExpression = x => new Dictionary<object, QueryOrderBy>() {
                {
                    x.prod_id,QueryOrderBy.Asc
                },{
                    x.updated_date,QueryOrderBy.Asc
                }
            };*/
            setQueryParameters();
            return base.GetPageData(options);
        }


        /// <summary>
        /// 查询条件：产品可以多选查询，把查询列表中的prods换成prod_dbid
        /// </summary>
        /// <param name="options"></param>
        public void setQueryParametersNew(List<SearchParameters> searchParametersList)
        {

            Boolean isShowInvalidProd = false;
            for (int i = searchParametersList.Count - 1; i >= 0; i--)
            {
                SearchParameters item = searchParametersList[i];

                if (item.Name == "prods")
                {
                    //替换成prod_id 
                    //先移除再添加
                    searchParametersList.Remove(item);

                    SearchParameters paraTmp = new SearchParameters();
                    paraTmp.Name = "prod_id";
                    paraTmp.Value = item.Value;
                    paraTmp.DisplayType = "selectList";
                    searchParametersList.Add(paraTmp);

                }
                if (item.Name == "QueryStatus")
                {
                    searchParametersList.Remove(item);
                    //Valid(Current) 开始日期小于等于系统日期，结束日期大于等于系统日期
                    if (item.Value == "1")
                    {
                        SearchParameters paraTmpStartDate = new SearchParameters();
                        paraTmpStartDate.Name = "start_date";
                        paraTmpStartDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                        paraTmpStartDate.DisplayType = "lessorequal";
                        searchParametersList.Add(paraTmpStartDate);

                        SearchParameters paraTmpEndDate = new SearchParameters();
                        paraTmpEndDate.Name = "end_date";
                        paraTmpEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                        paraTmpEndDate.DisplayType = "thanorequal";
                        searchParametersList.Add(paraTmpEndDate);

                        SearchParameters paraTmpStatus = new SearchParameters();
                        paraTmpStatus.Name = "status";
                        paraTmpStatus.Value = "Y";
                        paraTmpStatus.DisplayType = "";
                        searchParametersList.Add(paraTmpStatus);
                    }
                    //InValid History
                    else if (item.Value == "2")
                    {
                        SearchParameters paraTmpStatus = new SearchParameters();
                        paraTmpStatus.Name = "status";
                        paraTmpStatus.Value = "N";
                        paraTmpStatus.DisplayType = "";
                        searchParametersList.Add(paraTmpStatus);
                    }
                    //Valid future
                    else if (item.Value == "3")
                    {
                        SearchParameters paraTmpStartDate = new SearchParameters();
                        paraTmpStartDate.Name = "start_date";
                        paraTmpStartDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                        paraTmpStartDate.DisplayType = "thanorequal";
                        searchParametersList.Add(paraTmpStartDate);

                        SearchParameters paraTmpStatus = new SearchParameters();
                        paraTmpStatus.Name = "status";
                        paraTmpStatus.Value = "Y";
                        paraTmpStatus.DisplayType = "";
                        searchParametersList.Add(paraTmpStatus);
                    }
                }
                if (item.Name == "ShowInvalidProd")
                {
                    searchParametersList.Remove(item);
                    if (item.Value == "1")
                    {
                        //isShowInvalidProd = true;                           
                    }
                    else
                    {
                        SearchParameters paraTmpStatus = new SearchParameters();
                        paraTmpStatus.Name = "state";
                        paraTmpStatus.Value = "1";
                        paraTmpStatus.DisplayType = "";
                        searchParametersList.Add(paraTmpStatus);
                    }


                }
            }
            //如果没有勾选页面的show invalid products则默认查询 产品的state=1
            if (!isShowInvalidProd)
            {
                
            }
        }

        /// <summary>
        /// 查询条件：产品可以多选查询，把查询列表中的prods换成prod_dbid
        /// </summary>
        /// <param name="options"></param>
        public void setQueryParameters()
        {
            QueryRelativeList = (searchParametersList) =>
            {
                Boolean isShowInvalidProd = false;
                for (int i = searchParametersList.Count - 1; i >= 0; i--)
                {
                    SearchParameters item = searchParametersList[i];

                    if (item.Name == "prods")
                    {
                        //替换成prod_id 
                        //先移除再添加
                        searchParametersList.Remove(item);

                        SearchParameters paraTmp = new SearchParameters();
                        paraTmp.Name = "prod_id";
                        paraTmp.Value = item.Value;
                        paraTmp.DisplayType = "selectList";
                        searchParametersList.Add(paraTmp);

                        break;
                    }
                    if (item.Name == "QueryStatus")
                    {
                        searchParametersList.Remove(item);
                        //Valid(Current) 开始日期小于等于系统日期，结束日期大于等于系统日期
                        if (item.Value == "1")
                        {
                            SearchParameters paraTmpStartDate = new SearchParameters();
                            paraTmpStartDate.Name = "start_date";
                            paraTmpStartDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                            paraTmpStartDate.DisplayType = "lessorequal";
                            searchParametersList.Add(paraTmpStartDate);

                            SearchParameters paraTmpEndDate = new SearchParameters();
                            paraTmpEndDate.Name = "end_date";
                            paraTmpEndDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                            paraTmpEndDate.DisplayType = "thanorequal";
                            searchParametersList.Add(paraTmpEndDate);

                            SearchParameters paraTmpStatus = new SearchParameters();
                            paraTmpStatus.Name = "status";
                            paraTmpStatus.Value = "Y";
                            paraTmpStatus.DisplayType = "";
                            searchParametersList.Add(paraTmpStatus);
                        }
                        //InValid History
                        else if (item.Value == "2")
                        {
                            SearchParameters paraTmpStatus = new SearchParameters();
                            paraTmpStatus.Name = "status";
                            paraTmpStatus.Value = "N";
                            paraTmpStatus.DisplayType = "";
                            searchParametersList.Add(paraTmpStatus);
                        }
                        //Valid future
                        else if (item.Value == "3")
                        {
                            SearchParameters paraTmpStartDate = new SearchParameters();
                            paraTmpStartDate.Name = "start_date";
                            paraTmpStartDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                            paraTmpStartDate.DisplayType = "thanorequal";
                            searchParametersList.Add(paraTmpStartDate);

                            SearchParameters paraTmpStatus = new SearchParameters();
                            paraTmpStatus.Name = "status";
                            paraTmpStatus.Value = "Y";
                            paraTmpStatus.DisplayType = "";
                            searchParametersList.Add(paraTmpStatus);
                        }
                    }
                    if (item.Name == "ShowInvalidProd")
                    {
                        searchParametersList.Remove(item);
                        if (item.Value == "1")
                        {
                            isShowInvalidProd = true;

                        }
                    }
                }
                //如果没有勾选页面的show invalid products则默认查询 产品的state=1
                if (!isShowInvalidProd)
                {
                    SearchParameters paraTmpStatus = new SearchParameters();
                    paraTmpStatus.Name = "state";
                    paraTmpStatus.Value = "1";
                    paraTmpStatus.DisplayType = "";
                    searchParametersList.Add(paraTmpStatus);
                }              
            };
        }

        #region update
        public override WebResponseContent Update(SaveModel saveModel)
        {

            UpdateOnExecute = (saveModel) =>
            {
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy-MM-dd";
                //把编辑的数据转成实体
                Viat_app_cust_price_detail entity = JsonConvert.DeserializeObject<Viat_app_cust_price_detail>(JsonConvert.SerializeObject(saveModel.MainData));
                /*if (Convert.ToDateTime(entity.end_date.ToString("yyyy-MM-dd"), dtFormat) < Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"), dtFormat))
                {
                    entity.status = "N";
                }
                else
                {
                    entity.status = "Y";
                }*/


                //◆	判斷是否有過去的價格資料
                Viat_app_cust_price_detail oldPrice = getOldPriceForEdit(entity);
                if (oldPrice != null)
                {
                    //有旧数据
                    if (entity.status == "Y" && entity.start_date < oldPrice.start_date)
                    {
                        webResponse.Code = "-1";
                        return webResponse.Error("Start date can't not less than " + oldPrice.start_date.ToString("yyyy/MM/dd"));

                    }

                    if (entity.start_date < oldPrice.end_date)
                    {
                        if (entity.start_date.AddDays(-1) < oldPrice.start_date)
                        {
                            oldPrice.end_date = entity.start_date;
                        }
                        else
                        {
                            oldPrice.end_date = entity.start_date.AddDays(-1);
                        }

                        if (oldPrice.end_date < Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"), dtFormat) == true)
                        {
                            oldPrice.status = "N";
                        }

                        //把实休转为dictionary
                        Dictionary<string, object> dicOldPrice = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(oldPrice));

                        //修改旧数据
                        SaveModel.DetailListDataResult dataOldResult = new SaveModel.DetailListDataResult();
                        dataOldResult.optionType = SaveModel.MainOptionType.update;
                        dataOldResult.detailType = typeof(Viat_app_cust_price_detail);
                        dataOldResult.DetailData = new List<Dictionary<string, object>> { dicOldPrice };
                        saveModel.DetailListData.Add(dataOldResult);
                    }
                }

                //◆	更新本次修改價格資料
                //把实休转为dictionary
                Dictionary<string, object> dicEntity = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));
                //更新本身的数据
               /* SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                dataResult.optionType = SaveModel.MainOptionType.update;
                dataResult.detailType = typeof(Viat_app_cust_price_detail);
                dataResult.DetailData = new List<Dictionary<string, object>> { dicEntity };
                saveModel.DetailListData.Add(dataResult);*/
                if (entity.status == "N" && Convert.ToDateTime(entity.start_date.ToString("yyyy-MM-dd"), dtFormat) > Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"), dtFormat))
                {
                    //如果本次修改為未來價格且Status = Invalid，自動刪除該筆資料              
                    //增加修改
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.delete;
                    dataResult.detailType = typeof(Viat_app_cust_price_detail);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dicEntity };
                    saveModel.DetailListData.Add(dataResult);
                }
                else
                {
                    //更新本身的数据
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_app_cust_price_detail);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dicEntity };
                    saveModel.DetailListData.Add(dataResult);
                }

                base.CustomBatchProcessEntity(saveModel);

                webResponse.Code = "-1";
                return webResponse.OK();
            };

            return base.Update(saveModel);
        }

        /// <summary>
        /// 過去的價格資料,开始日期最接近编辑的开始日期
        /// </summary>
        /// <param name="entityParameter"></param>
        /// <returns></returns>
        private Viat_app_cust_price_detail getOldPriceForEdit(Viat_app_cust_price_detail entityParameter)
        {

            string sSql = @"SELECT TOP(1) *
                                FROM viat_app_cust_price_detail
	                               WHERE cust_dbid = '" + entityParameter.cust_dbid + @"'
　　　                            AND prod_dbid =  '" + entityParameter.prod_dbid + @"' 
                            AND (CONVERT(Date, start_date)  <= CONVERT(Date, GETDATE()))
                            AND  pricedetail_dbid <>  '" + entityParameter.pricedetail_dbid + @"' 
                                ORDER BY start_date DESC
                            ";

            return _repository.DapperContext.QueryFirst<Viat_app_cust_price_detail>(sSql, null);

        }

         

        #endregion
        public override WebResponseContent DownLoadTemplate()
        {
            DownLoadTemplateColumns = x => new {
                x.cust_id,  
                x.cust_name,
                x.prod_id,
                x.prod_ename,
                x.nhi_price, 
                x.net_price,
                x.invoice_price, 
                x.reserv_price,
                x.gross_price,
                x.min_qty, 
                x.start_date,
                x.end_date, 
                x.remarks };
            return base.DownLoadTemplate();
        }

     
        /// <summary>
        /// 2.	取得新的Bid No
        /// Filter條件為系統日 example :20220601
        ///10碼，取得最大碼序號+1，帶入Bid No欄位
        /// </summary>
        /// <returns></returns>
        public string getMaxBindNo()
        {

            //取得当前日期
            string sCurrentDate = System.DateTime.Now.ToString("yyyyMMdd");
            string sSql = @"SELECT MAX (bid_no) AS max_bidno 
                                FROM viat_app_cust_price_detail
                                WHERE LEN(bid_no) = 10
                                  AND bid_no LIKE '" + sCurrentDate + @"%'
                            ";
            object obj = _repository.DapperContext.ExecuteScalar(sSql, null);
            if (obj == null)
            {
                //当天第一个号码
                return sCurrentDate + "01";
            }
            else
            {
                //取得当前最大序号 
                string sSerial = obj.ToString().Substring(8, 2);
                int nSerial = 0;
                int.TryParse(sSerial, out nSerial);
                return sCurrentDate + (nSerial + 1).ToString().PadLeft(2, '0');
            }
        }


        /*
         判斷Cust Id是否為Expfizer Cust Id         
         */
        public bool IsExpfizer(string sCustID)
        {
            string sSql = @"SELECT COUNT(*)
                            FROM
	                            viat_com_dist AS comDist
	                            INNER JOIN viat_com_system_value AS sysValue ON comDist.dist_id = sysValue.sys_key
	                            INNER JOIN viat_com_cust AS cust ON comDist.cust_dbid = cust.cust_dbid 
                            WHERE
	                            sysValue.status = 'Y'
	                            AND sysValue.category_id = 'DistID'
                            AND LOWER ( cust.cust_id ) = '" + sCustID + @"'";
            object obj = _repository.DapperContext.ExecuteScalar(sSql, null);
            if (obj == null || obj.ToString() == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        } 

        #region 保存方法新


        #region 对前台数据校验
        /// <summary>
        /// //◆檢查 Group + Product / Customer + Product 在Add DataGrid中是否有重覆資料         
        //◆	檢查是否有未來價格資料
        /// </summary>
        /// <returns></returns>
        public WebResponseContent checkData(List<Dictionary<string, object>> entityDic)
        {
            foreach (Dictionary<string, object> dic in entityDic)
            {
                //校验必填项,走框架
                Type type = typeof(Viat_app_cust_price_detail);
                string sMessage = type.ValidateDicInEntity(dic, true, false, UserIgnoreFields);
                if (string.IsNullOrEmpty(sMessage) == false)
                {
                    return webResponse.Error(sMessage);
                }


                //◆檢查 Group + Product / Customer + Product 在Add DataGrid中是否有重覆資料
                string sCust_dbid = dic["cust_dbid"].ToString();
                string sProdDBID = dic["prod_dbid"].ToString();
                string sStartDate = dic["start_date"].ToString();
                string sEndDate = dic["end_date"].ToString();
                string sProdEName = "";// dic["prod_ename"].ToString();

            
                //检查是否触发未来价的卡控：不能同时有两个未来价
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy-MM-dd";
                DateTime dSysDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"), dtFormat);
                DateTime dPageDate = Convert.ToDateTime(sStartDate, dtFormat);
                Viat_app_cust_price_detail futurePrice = CheckFuturePrice(sCust_dbid, sProdDBID, sStartDate);
                if (futurePrice!= null && futurePrice.status=="Y")
                {
                    //当前增加为未来价，系统已存在未来价
                    webResponse.Code = "-1";
                    return webResponse.Error("Prod:" + sProdEName + " Future prices already exists, please Invalid the future price");
                }
            }

            return webResponse.OK();
        }  

        /// <summary>
        /// ◆	檢查是否有未來價格資料   , string sStartDate, string sEnddate
        /// 存在未来价格返回true,不存在返回false
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <param name="sEnddate"></param>
        /// <returns></returns>
        private Viat_app_cust_price_detail CheckFuturePrice(string sCustDBID, string sProdDBID, string sStartDate)
        {
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            //当前系统日期
            DateTime dSysDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"), dtFormat);
            DateTime dPageDate = Convert.ToDateTime(sStartDate, dtFormat);
            if (dPageDate < dSysDate)
            {
                return null;
            }

           /* string sSql = "select TOP(1) *  from viat_app_cust_price_detail where cust_dbid=@cust_dbid and prod_dbid=@prod_dbid AND status = 'Y'ORDER BY end_date DESC";
            */
            //Viat_app_cust_price_detail entiryCustPrice = _repository.DapperContext.QueryFirst<Viat_app_cust_price_detail>(sSql, new { cust_dbid = sCustDBID, prod_dbid = sProdDBID });
            Viat_app_cust_price_detail entiryCustPrice = getFuturePriceData(sCustDBID, sProdDBID); //_repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });
            return entiryCustPrice;
            /*if (entiryCustPrice == null)
            {
                return false;
            }
            //数据库结束日期最大记录的开始日期
            DateTime dStartDate = Convert.ToDateTime(entiryCustPrice.start_date.ToString("yyyy-MM-dd"), dtFormat);

            if (dPageDate > dSysDate && dStartDate > dSysDate)
            {
                return true;
            }*/

           // return false;
        }
        #endregion

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="saveData">该参数为前端传过来的json，需要转为dictinary</param>
        /// <returns></returns>
        public WebResponseContent bathSaveCheckData(object saveData)
        {
            SaveModel saveModel = new SaveModel();
            string sRowDatas = saveData.ToString();
            if (string.IsNullOrEmpty(sRowDatas) == false)
            {
                List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(typeof(Viat_app_cust_price_detail), sRowDatas);

                //逻辑检查
                webResponse = checkData(entityDic);
                if (webResponse.Status == false)
                {
                    return webResponse;
                }

                //检查通过，返回需要保存的数据
                saveModel.MainDatas = entityDic;
                saveModel.mainOptionType = SaveModel.MainOptionType.add;
                saveModel.MainFacType = typeof(Viat_app_cust_price_detail);
            }
            else
            {
                webResponse.Error("no data save");
            }

            webResponse.Data = saveData;
            return webResponse.OK();
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="saveData">该参数为前端传过来的json，需要转为dictinary</param>
        /// <returns></returns>
        public WebResponseContent bathSaveCustPrice(object saveData)
        {
            //取得界面数据
            SaveModel saveModel = new SaveModel();
            //构造需要保存的saveModel
            //计算表体和实体的值
            string sRowDatas = saveData.ToString();
            if (string.IsNullOrEmpty(sRowDatas) == false)
            {

                List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(typeof(Viat_app_cust_price_detail), sRowDatas); //JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(sRowDatas)); //base.CalcSameEntiryProperties(typeof(Viat_app_cust_price), sRowDatas);
                saveModel.MainDatas = entityDic;
                saveModel.mainOptionType = SaveModel.MainOptionType.add;
                saveModel.MainFacType = typeof(Viat_app_cust_price_detail);
            }
            else
            {
                webResponse.Error("no data save");
            }

            processData(saveModel);
            base.CustomBatchProcessEntity(saveModel);
            return webResponse.OK("save successfule");
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="saveData">该参数为前端传过来的json，需要转为dictinary</param>
        /// <returns></returns>
        public void processData(SaveModel saveModel)
        {
            //处理保存
            foreach (Dictionary<string, object> dic in saveModel.MainDatas)
            {
                Viat_app_cust_price_detail entity = JsonConvert.DeserializeObject<Viat_app_cust_price_detail>(JsonConvert.SerializeObject(dic));

                //1.1 資料未存在相同資料 → AddCustPrice()
                if (IsExistsSameData(entity) == false)
                {
                    //处理后，直接处理下一条
                    AddCustPriceData(entity, saveModel);
                    continue;
                }

                //1.2 存在相同資料,则处理其他数据时间
                //2.1	無現行價格資料 若 未來價格有資料，需變更新增數據結束日，結束日=未來價格起始日-1天 新增價格資料AddCustPrice()
                Viat_app_cust_price_detail currentPriceEntity = getCurrentPriceData(entity.cust_dbid?.ToString(), entity.prod_dbid?.ToString());
                if (currentPriceEntity == null)
                {
                    //无现行价格
                    //检查是否有未來價格有資料
                    Viat_app_cust_price_detail futurePriceEntity = getFuturePriceData(entity.cust_dbid?.ToString(), entity.prod_dbid?.ToString());
                    if (futurePriceEntity != null)
                    {
                        entity.end_date = futurePriceEntity.start_date.AddDays(-1);


                    }
                    AddCustPriceData(entity, saveModel);
                    //处理后，直接处理下一条
                    continue;
                }

                //2.2	有現行價格資料
                //2.2.1	找出價格資料內，符合Group+Prod價格資料 且 結束日 > 新增數據起始日 且 狀態為無效的資料(多筆)
                List<Viat_app_cust_price_detail> invalidPriceData = getInValidPriceData(entity.cust_dbid.ToString(), entity.prod_dbid?.ToString(), entity.start_date);
                if (invalidPriceData != null && invalidPriceData.Count > 0)
                {
                    ProcessPriceData(entity, invalidPriceData, saveModel);
                }

                //2.2.2	判斷過去價格資料
                List<Viat_app_cust_price_detail> oldPriceData = getOldPriceData(entity.cust_dbid?.ToString(), entity.prod_dbid?.ToString());
                if (oldPriceData != null && oldPriceData.Count > 0)
                {
                    ProcessPriceData(entity, oldPriceData, saveModel);
                }

                //2.2.3	判斷未來價格資料
                Viat_app_cust_price_detail futurePriceData = getFuturePriceData(entity.cust_dbid?.ToString(), entity.prod_dbid?.ToString());
                if (futurePriceData != null)
                {
                    ProcessPriceData(entity, new List<Viat_app_cust_price_detail> { futurePriceData }, saveModel);
                }

                //2.2.4   判斷現行價格起始日
                if (getFormatYYYYMMDD(currentPriceEntity.start_date) <= getFormatYYYYMMDD(entity.start_date))
                {
                    //現行價格起始日<= 新增數據起始日 現行價格起始日<= 新增數據起始日-1
                    currentPriceEntity.end_date = entity.start_date.AddDays(-1);
                    if (getFormatYYYYMMDD(DateTime.Now) > getFormatYYYYMMDD(currentPriceEntity.end_date))
                    {
                        currentPriceEntity.status = "N";
                    }
                    else
                    {
                        currentPriceEntity.status = "Y";
                    }
                }

                /*若 現行價格結束日< 現行價格起始日
                     現行價格狀態 = 無效
                     現行價格結束日= 現行價格起始日
                  更新價格資料檔
                */
                if (getFormatYYYYMMDD(currentPriceEntity.end_date) < getFormatYYYYMMDD(currentPriceEntity.start_date))
                {
                    currentPriceEntity.status = "N";
                    currentPriceEntity.end_date = currentPriceEntity.start_date;
                }

                //現行價格起始日> 新增數據起始日
                if (getFormatYYYYMMDD(currentPriceEntity.start_date) > getFormatYYYYMMDD(entity.start_date))
                {
                    ProcessPriceData(entity, new List<Viat_app_cust_price_detail> { currentPriceEntity }, saveModel);
                }

                //更新价格
                if (isExistData(currentPriceEntity, saveModel) == false)
                {
                    Dictionary<string, object> dicCurrent = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(currentPriceEntity));
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_app_cust_price_detail);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dicCurrent };
                    saveModel.DetailListData.Add(dataResult);
                }
                //如果没有特殊情况，新增本身资料
                //处理后，直接处理下一条
                AddCustPriceData(entity, saveModel);
            }

        }

        /// <summary>
        /// 存在的数据不再增加处理
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        private bool isExistData(Viat_app_cust_price_detail entity, SaveModel saveModel)
        {
            //如果数据已处理，则跳过，因为框架对于同一条更新，会报错

            foreach (SaveModel.DetailListDataResult dResult in saveModel?.DetailListData)
            {
                if (dResult.detailType == typeof(Viat_app_cust_price_detail))
                {
                    foreach (Dictionary<string, object> dicResult in dResult?.DetailData)
                        if (dicResult["pricedetail_dbid"].ToString() == entity.pricedetail_dbid.ToString())
                        {
                            return true;
                        }
                }
            }

            return false;
        }



        /// <summary>
        /// 保存价格新增数据
        /// </summary>
        private void AddCustPriceData(Viat_app_cust_price_detail entity, SaveModel saveModel)
        {
            //增加price数据,增加前先处理
            entity.pricedetail_dbid = System.Guid.NewGuid();
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            if (Convert.ToDateTime(entity.end_date.ToString(), dtFormat) < Convert.ToDateTime(System.DateTime.Now.ToString(), dtFormat))
            {
                entity.status = "N";
            }
            else
            {
                entity.status = "Y";
            }
            entity.SetModifyDefaultVal();
            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));
            SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
            dataResult.optionType = SaveModel.MainOptionType.add;
            dataResult.detailType = typeof(Viat_app_cust_price_detail);
            dataResult.DetailData = new List<Dictionary<string, object>> { dic };
            saveModel.DetailListData.Add(dataResult);

        }

        /// <summary>
        /// 处理价格方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveModel"></param>
        private void ProcessPriceData(Viat_app_cust_price_detail currentEntity, List<Viat_app_cust_price_detail> processEntityList, SaveModel saveModel)
        {

            if (processEntityList != null)
            {
                foreach (Viat_app_cust_price_detail processEntity in processEntityList)
                {

                   if(isExistData(processEntity,saveModel)==true)
                    {
                        continue;
                    }

                    // 結束日 > 新增數據起始日
                    if (getFormatYYYYMMDD(currentEntity.start_date) >= getFormatYYYYMMDD(processEntity.end_date))
                    {
                        continue;
                    }

                    /**
                     * 舊價格起始日 = 價格起始日
                        舊價格結束日 = 價格結束日
                     */
                    DateTime dProcessStartData = getFormatYYYYMMDD(processEntity.start_date);
                    DateTime dProcessEndData = getFormatYYYYMMDD(processEntity.end_date);
                    //若 價格起始日 > 新增數據起始日
                    if (getFormatYYYYMMDD(processEntity.start_date) > getFormatYYYYMMDD(currentEntity.start_date))
                    {
                        //價格起始日 = 新增數據起始日
                        processEntity.start_date = currentEntity.start_date;
                    }
                    //價格起始日 = 新增數據起始日
                    processEntity.end_date = currentEntity.start_date.AddDays(-1);

                    //若 價格結束日 < 價格起始日 價格結束日 = 價格起始日
                    if (getFormatYYYYMMDD(processEntity.end_date) < getFormatYYYYMMDD(processEntity.start_date))
                    {
                        processEntity.end_date = processEntity.start_date;
                    }

                    //若 舊價格起始日<> 價格起始日 且 舊價格結束日<> 價格結束日, 需標記價格舊價格起始日及舊價格結束日及更新備註,更新價格資枓檔
                    if ((dProcessStartData != null && getFormatYYYYMMDD(dProcessStartData) != getFormatYYYYMMDD(processEntity.start_date) || dProcessEndData.Year != 2099) &&
                         (getFormatYYYYMMDD(dProcessEndData) != getFormatYYYYMMDD(processEntity.end_date)))
                    {
                        processEntity.remarks =processEntity.remarks +" 原起迄日" + getFormatYYYYMMDD(dProcessStartData).ToString("yyyy-MM-dd") + " ~ " + getFormatYYYYMMDD(dProcessEndData).ToString("yyyy-MM-dd");
                        processEntity.org_start_date = dProcessStartData;
                        processEntity.org_end_date = dProcessEndData;
                    }

                  
                    processEntity.status = "N";
                

                    //更新数据
                    Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(processEntity));
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_app_cust_price_detail);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dic };
                    saveModel.DetailListData.Add(dataResult);
                }
            }

        }

        /// <summary>
        ///  資料未存在相同資料
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool IsExistsSameData(Viat_app_cust_price_detail entity)
        {
            string sSql = "select count(*) from viat_app_cust_price_detail where cust_dbid=@cust_dbid and prod_dbid=@prod_dbid";
            object obj = _repository.DapperContext.ExecuteScalar(sSql, new { cust_dbid = entity.cust_dbid, prod_dbid = entity.prod_dbid });

            return (((int)obj) == 0) ? false : true;
        }

        /// <summary>
        /// 過去價格 = 結束日<系統日(多筆，以結束日降冪排序)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private List<Viat_app_cust_price_detail> getOldPriceData(string sCustDBID, string sProdDBID)
        {
            string sSql = "select *  from viat_app_cust_price_detail where cust_dbid=@cust_dbid and prod_dbid=@prod_dbid " +
                "AND end_date <'"+ getFormatYYYYMMDD(DateTime.Now) + "' ORDER BY end_date DESC";
            List<Viat_app_cust_price_detail> entiryOldPriceLst = _repository.DapperContext.QueryList<Viat_app_cust_price_detail>(sSql, new { cust_dbid = sCustDBID, prod_dbid = sProdDBID });

            return entiryOldPriceLst;
        }

        /// <summary>
        /// 現行價格 = 系統日在起訖日期中(取最大結束日一筆)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private Viat_app_cust_price_detail getCurrentPriceData(string sCustDBID, string sProdDBID)
        {
            string sSql = "select TOP(1) *  from viat_app_cust_price_detail where cust_dbid=@cust_dbid and prod_dbid=@prod_dbid " +
                "AND start_date   <=  '" + getFormatYYYYMMDD(DateTime.Now) + "' AND  end_date >='" + getFormatYYYYMMDD(DateTime.Now) + "' ORDER BY end_date DESC";
            Viat_app_cust_price_detail entiryCustPrice = _repository.DapperContext.QueryFirst<Viat_app_cust_price_detail>(sSql, new { cust_dbid = sCustDBID, prod_dbid = sProdDBID });
            if (entiryCustPrice == null)
            {
                sSql = "select TOP(1) *  from viat_app_cust_price_detail where cust_dbid=@cust_dbid and prod_dbid=@prod_dbid  ORDER BY end_date ";

                entiryCustPrice = _repository.DapperContext.QueryFirst<Viat_app_cust_price_detail>(sSql, new { cust_dbid = sCustDBID, prod_dbid = sProdDBID });

            }
            return entiryCustPrice;
        }

        /// <summary>
        /// 未來價格 = 起始日>系統日(取最小結束日一筆)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private Viat_app_cust_price_detail getFuturePriceData(string sCustDBID, string sProdDBID)
        {
            string sSql = "select TOP(1) *  from viat_app_cust_price_detail where cust_dbid=@cust_dbid and prod_dbid=@prod_dbid " +
                "AND start_date >'" + getFormatYYYYMMDD(DateTime.Now) + "'  ORDER BY end_date ";
            Viat_app_cust_price_detail entiryFuture = _repository.DapperContext.QueryFirst<Viat_app_cust_price_detail>(sSql, new { cust_dbid = sCustDBID, prod_dbid = sProdDBID });

            return entiryFuture;
        }

        /// <summary>
        /// 2.2.1	找出價格資料內，符合Group+Prod價格資料 且 結束日 > 新增數據起始日 且 狀態為無效的資料(多筆)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>
        private List<Viat_app_cust_price_detail> getInValidPriceData(string sCustDBID, string sProdDBID, DateTime dStartDate)
        {
            string sSql = "select *  from viat_app_cust_price_detail where   cust_dbid='" + sCustDBID + "' and prod_dbid='" + sProdDBID + "' " +
                "   and status='N' " +
                "AND  end_date > '" + getFormatYYYYMMDD(dStartDate) + "'" +
                " ORDER BY end_date DESC";
            List<Viat_app_cust_price_detail> entiryExpirePriceLst = _repository.DapperContext.QueryList<Viat_app_cust_price_detail>(sSql, null);

            return entiryExpirePriceLst;
        }



        #endregion

        #region 导入

        /// <summary>
        /// 导入校验
        /// </summary>
        /// <returns></returns>
        private WebResponseContent checkImport(List<View_cust_price_detail> list)
        {
            int nLoop = 1;
            //数据初始化处理
            foreach (View_cust_price_detail group in list)
            {
                if (string.IsNullOrEmpty(group.prod_id) == false)
                {
                    Viat_com_prod prod = getProd(group.prod_id, "");
                    if (prod != null)
                    {
                        group.nhi_price = prod.nhi_price;
                    }
                }

                if (group.end_date == null)
                {
                    group.end_date = getFormatYYYYMMDD("2099-12-31");
                }
            }

            #region check1
            string sMessageBulider1 = "";
            foreach (View_cust_price_detail group in list)
            {
                string sColumns = "";
                #region 非空校验  check1
                //逐筆檢查Import內容Cust Id, Group Id, Inovie Price, Net Price, Min Qty, Start Date不可空白Msg為所有筆數檢查後結果
                
                if (group.cust_id == null)
                {
                    sColumns += "cust_id ID empty,";
                }
                if (group.prod_id == null)
                {
                    sColumns += "Prod ID empty,";
                }
                if (group.invoice_price == null)
                {
                    sColumns += "invoice_price empty,";
                }
                if (group.net_price == null)
                {
                    sColumns += "net_price empty,";
                }
                if (group.min_qty == null || group.min_qty < 1)
                {
                    sColumns += "Min Qty empty or Min Qty <1,";
                }
                if (group.start_date == null || group.start_date == DateTime.MinValue)
                {
                    sColumns += "Start Date format error,";
                }
                if (group.end_date == null || group.end_date == DateTime.MinValue)
                {
                    sColumns += "End Date format error,";
                }

                if (group.start_date > group.end_date)
                {
                    sColumns += "End Date < Start Date,";
                }

                if (group.nhi_price == null)
                {
                    sColumns += " Can't  get NHI Price by prod:'" + group.prod_id;
                }

                if (string.IsNullOrEmpty(sColumns) == false)
                {
                    sMessageBulider1 += ("column(s):[" + sColumns + "] at row read " + nLoop) + "<br/>";
                }

                nLoop++;
                #endregion
            }

            if (string.IsNullOrEmpty(sMessageBulider1) == false)
            {
                return webResponse.Error(sMessageBulider1);
            }
            #endregion
            #region check2 逐筆檢查NHI Price , Invoice Price , Net price, Gross Price關係
             
              
           

            #region check3 判斷Cust Id是否為Expfizer Cust Id                   
            //判斷Cust Id是否為Expfizer Cust Id
            string sCheckMessage3 = "";
            foreach (View_cust_price_detail group in list)
            {
                if(IsExpfizer(group.cust_id) == false)
                {
                    if(group.net_price>group.invoice_price)
                    {
                        sCheckMessage3 += "Net Price can’t > Invoice Price: " + "<br/>";
                        sCheckMessage3 += "Cust Id:" + group.cust_id + ",Prod Id:" + group.prod_id + "<br/>";
                    }
                    //无值，清空gross
                    group.gross_price = null;
                }      
                
            } 

           /* if(string.IsNullOrEmpty(sCheckMessage3)==false)
            {
                return webResponse.Error("Net Price can’t > Invoice Price <br/> "+ sCheckMessage3);
            }*/

                #endregion

                #region Check4 逐筆判斷Cust Id、Group Id、Prod Id是否存在

                string sMessageBulid4 = "";
            foreach (View_cust_price_detail group in list)
            {
                if (string.IsNullOrEmpty(group.reserv_price?.ToString()) == false)
                {
                    if (group.reserv_price > group.net_price)
                    {
                        sMessageBulid4 += "Reserve Price can't > Net Price: " + "<br/>";
                        sMessageBulid4 += "Cust Id: " + group.cust_id + ",Prod Id: " + group.prod_id + "<br/>";

                    }
                }
        

                //判斷產品是否存在
                Viat_com_prod prod = getProd(group.prod_id, "1");
                if (prod == null)
                {
                    sMessageBulid4 += "ItemCode:" + group.prod_id + " is not exist" + "<br/>";
                }
                else
                {
                    group.prod_dbid = prod.prod_dbid;
                }

                //判斷客户是否存在
                Viat_com_cust cust = getCust(group.cust_id);
                if (cust == null)
                {
                    sMessageBulid4 += "CustId:" + group.cust_id + " is not exist" + "<br/>";
                }
                else
                {
                    group.cust_dbid = cust.cust_dbid;
                }

                if (string.IsNullOrEmpty(sMessageBulid4) == true)
                {
                    //检查是否已存在未来价格
                    Viat_app_cust_price_detail futurePrice = CheckFuturePrice(group.cust_dbid?.ToString(), group.prod_dbid?.ToString(), group.start_date.ToString("yyyy-MM-dd"));
                    if (futurePrice != null && futurePrice.status == "Y")
                    {
                        //当前增加为未来价，系统已存在未来价
                        sMessageBulid4 += "Prod:" + group.prod_id + " Future prices already exists, please Invalid the future price";
                    }
                }

                if ((getFormatYYYYMMDD(DateTime.Now) >= getFormatYYYYMMDD(group.start_date) 
                    && getFormatYYYYMMDD(DateTime.Now)<=getFormatYYYYMMDD(group.end_date))|| getFormatYYYYMMDD(group.start_date)>getFormatYYYYMMDD(DateTime.Now))
                {
                    group.status = "Y";
                }
                else
                {
                    group.status = "N";
                }
            }
            if (string.IsNullOrEmpty(sCheckMessage3) == false || string.IsNullOrEmpty(sMessageBulid4) == false)
            {
                return webResponse.Error(sCheckMessage3 + "<br/>" + sMessageBulid4);
            }


            webResponse = checkConfirmData(list);
            if (webResponse.Code == "-2")
            {
                return webResponse;
            }
            else
            {
                importData(list);
            }

            #endregion


            #endregion

            return webResponse.OK();
        }

        private WebResponseContent checkConfirmData(List<View_cust_price_detail> list)
        {
            string sConformMessage = "";
            foreach (View_cust_price_detail group in list)
            {
                string sMessage1 = "";
                string sMessage2 = "";
                string sMessage3 = "";
                string sMessage4 = "";
                if (group.invoice_price > group.nhi_price)
                {
                    sMessage1 = "Cust Id:" + group.cust_id + ",Prod Id:" + group.prod_id + "<br/>";
                }
                if (group.nhi_price >0 && group.invoice_price >0 && group.nhi_price != group.invoice_price && group.net_price == group.invoice_price)
                {
                    sMessage2 = "Cust Id:" + group.cust_id + ",Prod Id:" + group.prod_id + "<br/>";
                }
                if(group.gross_price>0 && group.net_price>0 && group.gross_price != null && group.gross_price < group.net_price )
                {
                    sMessage3 = "Cust Id:" + group.cust_id + ",Prod Id:" + group.prod_id + "<br/>";
                }
                if (group.gross_price != null && group.gross_price > group.nhi_price)
                {
                    sMessage4 = "Cust Id:" + group.cust_id + ",Prod Id:" + group.prod_id + "<br/>";
                }

                if (string.IsNullOrEmpty(sMessage1) == false)
                {
                    sMessage1 = "Invoice price > NHI price1." + "<br/>" + sMessage1;
                   
                }
                if (string.IsNullOrEmpty(sMessage2) == false)
                {
                    sMessage2 = "Invoice price ≠ NHI price but Invoice Price = Net Price." + "<br/>" + sMessage2;
                }
                if (string.IsNullOrEmpty(sMessage3) == false)
                {
                    sMessage3 = "Gross price < Net price<br/><p>" + "<br/>" + sMessage3 ;
                }
                if (string.IsNullOrEmpty(sMessage4) == false)
                {
                    sMessage4 = "Gross price > NHI price1 " + " <br/> " + sMessage4;
                     
                }

                sConformMessage += sMessage1 + sMessage2 + sMessage3 + sMessage4;
               /* if (string.IsNullOrEmpty(sMessage1) == false || string.IsNullOrEmpty(sMessage2) == false)
                {
                    sConfirmMessage += sMessage1 + sMessage2 + "'<br/>";                    
                }

                if (string.IsNullOrEmpty(sMessage3) == false)
                {
                      sConfirmMessage += sMessage3 + "'<br/>";
                   
                }
                if (string.IsNullOrEmpty(sMessage4) == false)
                {
                    sConfirmMessage += sMessage4 + "'<br/>";

                }*/
            }
            if (string.IsNullOrEmpty(sConformMessage) == false)
            {
                //View_cust_price_detail
            
                sConformMessage += " <br/> " + " Do you want to import data?";
            
                webResponse.Code = "-2";
                webResponse.Url = "/api/View_cust_price_detail/importData";
                webResponse.Data = list;
                return webResponse.Error(sConformMessage);
            }

            return webResponse.OK();
        }

        /// <summary>
        /// ◆	判斷本次修改group id是否為NHI
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        private Viat_com_prod getProd(string prod_id, string state)
        {
            string sSql = @"SELECT TOP(1) *
                            FROM viat_com_prod
                            WHERE prod_id = '" + prod_id + "'";
            if (string.IsNullOrEmpty(state) == false)
            {
                sSql += " and state='" + state + "'";
            }

            Viat_com_prod prod = _repository.DapperContext.QueryFirst<Viat_com_prod>(sSql, null);
            return prod;
        }

        /// <summary>
        /// ◆	判斷本次修改group id是否為NHI
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        public Viat_com_cust getCust(string cust_id)
        {
            string sSql = @"SELECT TOP(1) *
                            FROM viat_com_cust
                            WHERE  LOWER ( cust_id )  = '" + cust_id + "' and status='Y'";


            Viat_com_cust cust = _repository.DapperContext.QueryFirst<Viat_com_cust>(sSql, null);
            return cust;
        }

        public override WebResponseContent Import(List<IFormFile> files)
        {
            //如果下載模板指定了DownLoadTemplate,則在Import方法必須也要指定,並且字段要和下載模板裡指定的一致
            DownLoadTemplateColumns = x => new { x.cust_id, x.prod_id, x.nhi_price,x.invoice_price, x.net_price,x.reserv_price, x.gross_price, x.min_qty, x.start_date, x.end_date, x.remarks };

            ImportOnExecutBefore = () =>
            {
                bCheckImportCustom = true;
                return webResponse.OK();
            };

            ImportOnExecuting = (list) =>
            {
                webResponse = checkImport(list);
                if (webResponse.Status == false)
                {
                    return webResponse;
                }

                //新增
                //进行数据处理
               // webResponse = this.bathSaveCustPrice(JsonConvert.SerializeObject(list));
                webResponse.Code = "-1";
                return webResponse;
            };
            return base.Import(files);
        }


        /// <summary>
        /// 正式导入数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public WebResponseContent importData(List<View_cust_price_detail> list)
        {
            //新增
            //进行数据处理
            webResponse = this.bathSaveCustPrice(JsonConvert.SerializeObject(list));
            webResponse.Code = "-1";
            return webResponse;
        }
        #endregion

        public PageGridData<View_cust_price_detail> GetPriceDataForTransfer(PageDataOptions pageData)
        {
            PageGridData<View_cust_price_detail> pageGridData = new PageGridData<View_cust_price_detail>();
            string prod_id = "";
            string cust_id = "";
            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(pageData.Wheres))
            {
                searchParametersList = pageData.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "prod_id".ToLower())
                        {
                            prod_id = sp.Value;
                            continue;
                        }
                        if (sp.Name.ToLower() == "cust_id".ToLower())
                        {
                            cust_id = sp.Value;
                            continue;
                        }

                    }
                }
            }
            string where = "";
            if (string.IsNullOrEmpty(prod_id) == false)
            {
                where += " and  prod.prod_id ='" + prod_id + "'";
            }
            if (string.IsNullOrEmpty(cust_id) == false)
            {
                where += " and  cust.cust_id ='" + cust_id + "'";
            }

            QuerySql = @"SELECT
	row_number () OVER (ORDER BY price.prod_ename ASC) AS rowId,
	price.*
FROM
	(
		(
			SELECT
				*
			FROM
				(
					SELECT
						'1' AS source_type,
						MAX (custPrice_d.dbid) AS dbid,
						MAX (custPrice_d.created_user) AS created_user,
						MAX (custPrice_d.created_client) AS created_client,
						MAX (custPrice_d.created_date) AS created_date,
						MAX (custPrice_d.modified_user) AS modified_user,
						MAX (
							custPrice_d.modified_client
						) AS modified_client,
						MAX (custPrice_d.modified_date) AS modified_date,
						MAX (custPrice_d.division) AS division,
						
						'' AS group_id,
						'' AS group_name,
						custPrice_d.prod_dbid,
						MAX (prod.prod_id) AS prod_id,
						MAX (prod.prod_ename) AS prod_ename,
						MAX (custPrice_d.nhi_price) AS nhi_price,
						MAX (custPrice_d.invoice_price) AS invoice_price,
						MAX (custPrice_d.net_price) AS net_price,
						MAX (custPrice_d.min_qty) AS min_qty,
						MAX (custPrice_d.start_date) AS start_date,
						MAX (custPrice_d.end_date) AS end_date,
						custPrice_d.status,
						MAX (custPrice_d.source) AS source,
						MAX (custPrice_d.remarks) AS remarks,
						MAX (cust.cust_id) AS cust_id,
						MAX (cust.cust_name) AS cust_name,
						MAX (prod.state) AS prod_status,
						custPrice_d.cust_dbid
					FROM
						viat_app_cust_price_detail AS custPrice_d
					LEFT JOIN viat_com_prod AS prod ON custPrice_d.prod_dbid = prod.prod_dbid
					LEFT JOIN viat_com_cust AS cust ON custPrice_d.cust_dbid = cust.cust_dbid
					WHERE
						custPrice_d.status = 'Y' 
        "+where + @"
					GROUP BY
						custPrice_d.prod_dbid,
						custPrice_d.cust_dbid,
						custPrice_d.status
				) AS cp_d
		)
		UNION
			(
				SELECT
					*
				FROM
					(
						SELECT
							'0' AS source_type,
							MAX (custPrice.dbid) AS dbid,
							MAX (custPrice.created_user) AS created_user,
							MAX (custPrice.created_client) AS created_client,
							MAX (custPrice.created_date) AS created_date,
							MAX (custPrice.modified_user) AS modified_user,
							MAX (custPrice.modified_client) AS modified_client,
							MAX (custPrice.modified_date) AS modified_date,
							MAX (custPrice.division) AS division,
							
							priceGroup.group_id,
							priceGroup.group_name,
							custPrice.prod_dbid,
							MAX (prod.prod_id) AS prod_id,
							MAX (prod.prod_ename) AS prod_ename,
							MAX (custPrice.nhi_price) AS nhi_price,
							MAX (custPrice.invoice_price) AS invoice_price,
							MAX (custPrice.net_price) AS net_price,
							MAX (custPrice.min_qty) AS min_qty,
							MAX (custPrice.start_date) AS start_date,
							MAX (custPrice.end_date) AS end_date,
							custPrice.status,
							MAX (custPrice.source) AS source,
							MAX (custPrice.remarks) AS remarks,
							MAX (cust.cust_id) AS cust_id,
							MAX (cust.cust_name) AS cust_name,
							MAX (prod.state) AS prod_status,
							custGroup.cust_dbid
						FROM
							viat_app_cust_price AS custPrice
						JOIN viat_app_cust_group AS custGroup ON custPrice.pricegroup_dbid = custGroup.pricegroup_dbid
						AND custPrice.prod_dbid = custGroup.prod_dbid
						LEFT JOIN viat_app_cust_price_group AS priceGroup ON custPrice.pricegroup_dbid = priceGroup.pricegroup_dbid
						LEFT JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid
						LEFT JOIN viat_com_cust AS cust ON custGroup.cust_dbid = cust.cust_dbid
						LEFT JOIN viat_com_dist AS dist ON cust.cust_dbid = dist.cust_dbid
						WHERE
							custGroup.status = 'Y'
						AND prod.prod_dbid NOT IN (
							SELECT
								priceDetail.prod_dbid
							FROM
								viat_app_cust_price_detail AS priceDetail
							WHERE
								priceDetail.cust_dbid = custGroup.cust_dbid
							AND priceDetail.status = 'Y'
						)
						AND custPrice.status = 'Y'
"+where +@"
						GROUP BY
							custPrice.pricegroup_dbid,
							group_id,
							group_name,
							custPrice.prod_dbid,
							custGroup.cust_dbid,
							custPrice.status
					) AS cp
			)
	) AS price";


            string sql = "select count(1) from (" + QuerySql + ") a";
            pageGridData.total = repository.DapperContext.ExecuteScalar(sql, null).GetInt();

            // QuerySql += "  ORDER BY prod_id, modified_date"; 
            sql = @$"select * from (" +
                QuerySql + $" ) as s where s.rowId between {((pageData.Page - 1) * pageData.Rows + 1)} and {pageData.Page * pageData.Rows} ";
            pageGridData.rows = repository.DapperContext.QueryList<View_cust_price_detail>(sql, null);
            return pageGridData;
        }

    }
}
