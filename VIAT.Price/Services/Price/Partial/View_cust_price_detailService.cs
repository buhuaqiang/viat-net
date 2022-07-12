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
        public PageGridData<View_cust_price_detail> GetCustInvalidPageData(PageDataOptions options)
        {

            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    string sCustID = "";
                    string sProdID = "";
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "cust_id".ToLower())
                        {
                            sCustID = sp.Value;
                            continue;
                        }

                        if (sp.Name.ToLower() == "prod_id".ToLower())
                        {
                            sProdID = sp.Value;
                            continue;
                        }
                    }

                    QuerySql = @"
                        SELECT
                        custPrice.pricedetail_dbid AS custprice_dbid, '1' AS source_type,
	                        custPrice.prod_dbid , prod.prod_id, prod.prod_ename, custPrice.nhi_price ,
	                        custPrice.invoice_price ,	custPrice.net_price , custPrice.min_qty ,
	                        custPrice.start_date , custPrice.end_date , custPrice.status ,
                            cust.cust_id, cust.cust_name,	'' AS group_id,'' AS group_name
                        FROM
	                        viat_app_cust_price_detail AS custPrice
	                        INNER JOIN viat_com_cust AS cust ON custPrice.cust_dbid = cust.cust_dbid
	                        INNER JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid 
                        WHERE ( 1 = 1 )
	                        AND cust.cust_id = '" + sCustID + "' AND custPrice.status = 'Y' ";  /*filter Cust Id 必填 */

                    if (string.IsNullOrEmpty(sProdID) == false)
                    {
                        QuerySql += " AND prod.prod_id = '"+sProdID+"'";
                    }
                    QuerySql += @" AND prod.state = '1'	
                        UNION ALL
                        SELECT
	                        custGroup.custgroup_dbid AS custprice_dbid, '2' AS source_type,
	                        custPrice.prod_dbid , prod.prod_id, prod.prod_ename, custPrice.nhi_price ,
	                        custPrice.invoice_price ,	custPrice.net_price , custPrice.min_qty ,
	                        custPrice.start_date , custPrice.end_date , custPrice.status ,
                            cust.cust_id, cust.cust_name, priceGroup.group_id, priceGroup.group_name
                        FROM 			
	                        viat_app_cust_price AS custPrice
	                        INNER JOIN viat_app_cust_group AS custGroup ON custPrice.pricegroup_dbid = custGroup.pricegroup_dbid 
	                        INNER JOIN viat_com_cust AS cust ON custGroup.cust_dbid = cust.cust_dbid
	                        AND custPrice.prod_dbid =custGroup.prod_dbid	
                          LEFT OUTER JOIN viat_app_cust_price_group AS priceGroup ON custPrice.pricegroup_dbid = priceGroup.pricegroup_dbid
	                        INNER JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid
	                        WHERE ( 1 = 1 )
                            AND cust.cust_id = '" + sCustID + "' AND custPrice.status = 'Y'";
                    if (string.IsNullOrEmpty(sProdID) == false)
                    {
                        QuerySql += " AND prod.prod_id = '" + sProdID + " ' ";
                    }
                    QuerySql += " AND prod.state = '1' AND custGroup.status = 'Y'";
                }
            }


            return base.GetPageData(options);
        }

        /// <summary>
        /// 查询条件：产品可以多选查询，把查询列表中的prods换成prod_dbid
        /// </summary>
        /// <param name="options"></param>
        public void setQueryParameters()
        {
            QueryRelativeList = (searchParametersList) =>
            {
                for (int i = searchParametersList.Count - 1; i >= 0; i--)
                {
                    SearchParameters item = searchParametersList[i];

                    if (item.Name == "prods")
                    {
                        //替换成prod_id 
                        //先移除再添加
                        searchParametersList.Remove(item);

                        SearchParameters paraTmp = new SearchParameters();
                        paraTmp.Name = "prod_dbid";
                        paraTmp.Value = item.Value;
                        paraTmp.DisplayType = item.DisplayType;
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
                if (Convert.ToDateTime(entity.end_date.ToString("yyyy-MM-dd"), dtFormat) < Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"), dtFormat))
                {
                    entity.status = "N";
                }
                else
                {
                    entity.status = "Y";
                }


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
                            entity.status = "N";
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
                SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                dataResult.optionType = SaveModel.MainOptionType.update;
                dataResult.detailType = typeof(Viat_app_cust_price_detail);
                dataResult.DetailData = new List<Dictionary<string, object>> { dicEntity };
                saveModel.DetailListData.Add(dataResult);


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
            DownLoadTemplateColumns = x => new {x.cust_id, x.group_id, x.prod_id, x.nhi_price, x.net_price,x.gross_price, x.min_qty, x.start_date, x.end_date, x.remarks };
            return base.DownLoadTemplate();
        }

        public override WebResponseContent Import(List<IFormFile> files)
        {
            //如果下載模板指定了DownLoadTemplate,則在Import方法必須也要指定,並且字段要和下載模板裡指定的一致
            DownLoadTemplateColumns = x => new { x.cust_id, x.group_id, x.prod_id, x.nhi_price, x.net_price, x.gross_price, x.min_qty, x.start_date, x.end_date, x.remarks };
            return base.Import(files);
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


         

    }
}
