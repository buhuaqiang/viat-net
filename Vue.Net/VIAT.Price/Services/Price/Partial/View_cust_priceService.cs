/*
 *所有关于View_cust_price类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_cust_priceService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text;
using VIAT.Core.Enums;

namespace VIAT.Price.Services
{
    public partial class View_cust_priceService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_cust_priceRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();
        private readonly IViat_app_cust_priceService _cust_priceService;


        [ActivatorUtilitiesConstructor]
        public View_cust_priceService(
            IView_cust_priceRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_cust_priceService cust_priceService
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
            _cust_priceService = cust_priceService;
        }


        public override PageGridData<View_cust_price> GetPageData(PageDataOptions options)
        {
            //指定多个字段进行排序
            /* base.OrderByExpression = x => new Dictionary<object, QueryOrderBy>() {*//**//*
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
        /// 置无效数据查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public PageGridData<View_cust_price> GetGroupInvalidPageData(PageDataOptions pageData)
        {

            PageGridData<View_cust_price> pageGridData = new PageGridData<View_cust_price>();

            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(pageData.Wheres))
            {
                searchParametersList = pageData.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    string sGroupID = "";
                    string sProdID = "";
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "pricegroup_dbid".ToLower())
                        {
                            sGroupID = sp.Value;
                            continue;
                        }

                        if (sp.Name.ToLower() == "prod_dbid".ToLower())
                        {
                            sProdID = sp.Value;
                            continue;
                        }
                    }

                    QuerySql = @"SELECT custPrice.*,ROW_NUMBER()over(order by custPrice.custprice_dbid desc) as rowId
                                FROM
	                                (
	                                SELECT custPrice.*,
		                                priceGroup.group_id, priceGroup.group_name,
		                                prod.prod_id, prod.prod_ename
	                                FROM
		                                viat_app_cust_price AS custPrice
		                                INNER JOIN viat_app_cust_price_group AS priceGroup ON custPrice.pricegroup_dbid = priceGroup.pricegroup_dbid
		                                INNER JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid 
	                                WHERE ( 1 = 1 )
		                                AND priceGroup.pricegroup_dbid = '" + sGroupID + "'";
                    if (string.IsNullOrEmpty(sProdID) == false)
                    {
                        QuerySql += " AND prod.prod_dbid = '" + sProdID + "'";
                    }
                    QuerySql += @" AND prod.state = '1' 
                                AND custPrice.status = 'Y'
                                AND (CONVERT(Date, GETDATE()) >= CONVERT(Date, custPrice.start_date))
                                AND (CONVERT(Date, GETDATE()) <= CONVERT(Date, custPrice.end_date))
	                                ) custPrice
	                                LEFT OUTER JOIN viat_app_dist_mapping AS distMapping ON distMapping.status = 'Y' 
	                                AND distMapping.pricegroup_dbid = custPrice.pricegroup_dbid 
	                                AND distMapping.prod_dbid = custPrice.prod_dbid 
	                                AND (CONVERT(Date, GETDATE( )) >= CONVERT(Date, distMapping.start_date)) 
	                                AND (CONVERT(Date, GETDATE( )) <= CONVERT(Date, distMapping.end_date))";
                              
                }
            }

            string sql = "select count(1) from (" + QuerySql + ") a";
            pageGridData.total = repository.DapperContext.ExecuteScalar(sql, null).GetInt();

          // QuerySql += "  ORDER BY prod_id, modified_date"; 
            sql = @$"select * from (" +
                QuerySql + $" ) as s where s.rowId between {((pageData.Page - 1) * pageData.Rows + 1)} and {pageData.Page * pageData.Rows} ";
            pageGridData.rows = repository.DapperContext.QueryList<View_cust_price>(sql, null);

            
            return pageGridData;
        }


       

        /// <summary>
        /// 置无效数据查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public List<View_cust_price> GetGroupInvalidList(string group_id, string prod_id)
        {


            string sSql = @"SELECT custPrice.* 
                                FROM
	                                (
	                                SELECT custPrice.*,
		                                priceGroup.group_id, priceGroup.group_name,
		                                prod.prod_id, prod.prod_ename
	                                FROM
		                                viat_app_cust_price AS custPrice
		                                INNER JOIN viat_app_cust_price_group AS priceGroup ON custPrice.pricegroup_dbid = priceGroup.pricegroup_dbid
		                                INNER JOIN viat_com_prod AS prod ON custPrice.prod_dbid = prod.prod_dbid 
	                                WHERE ( 1 = 1 )
		                                AND priceGroup.group_id = '" + group_id + "'";
            if (string.IsNullOrEmpty(prod_id) == false)
            {
                sSql += " AND prod.prod_id = '" + prod_id + "'";
            }
            sSql += @" AND prod.state = '1' 
                                AND custPrice.status = 'Y'
                                AND (CONVERT(Date, GETDATE()) >= CONVERT(Date, custPrice.start_date))
                                AND (CONVERT(Date, GETDATE()) <= CONVERT(Date, custPrice.end_date))
	                                ) custPrice
	                                LEFT OUTER JOIN viat_app_dist_mapping AS distMapping ON distMapping.status = 'Y' 
	                                AND distMapping.pricegroup_dbid = custPrice.pricegroup_dbid 
	                                AND distMapping.prod_dbid = custPrice.prod_dbid 
	                                AND (CONVERT(Date, GETDATE( )) >= CONVERT(Date, distMapping.start_date)) 
	                                AND (CONVERT(Date, GETDATE( )) <= CONVERT(Date, distMapping.end_date)) 
                                ORDER BY prod_id, modified_date";

            return repository.DapperContext.QueryList<View_cust_price>(sSql, null);

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
                            FROM viat_app_cust_price
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
                    if(item.Name== "ShowInvalidProd")
                    {
                        searchParametersList.Remove(item);
                        if (item.Value == "1")
                        { 
                            isShowInvalidProd = true;                           
                        }
                        else
                        {
                            
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


        #region 更新保存方法

        public override WebResponseContent Update(SaveModel saveModel)
        {

            UpdateOnExecute = (saveModel) =>
               {
                   DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                   dtFormat.ShortDatePattern = "yyyy-MM-dd";
                   //把编辑的数据转成实体
                   Viat_app_cust_price entity = JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(saveModel.MainData));
                   /*if (Convert.ToDateTime(entity.end_date.ToString("yyyy-MM-dd"), dtFormat) < Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"), dtFormat))
                   {
                       entity.status = "N";
                   }
                   else
                   {
                       entity.status = "Y";
                   }*/
                  
                   //◆	判斷是否有過去的價格資料
                   Viat_app_cust_price oldPrice = getOldPriceForEdit(entity);
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

                           if (getFormatYYYYMMDD(oldPrice.end_date) < getFormatYYYYMMDD(System.DateTime.Now) == true)
                           {
                               oldPrice.status = "N";
                           }

                           //把实休转为dictionary
                           Dictionary<string, object> dicOldPrice = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(oldPrice));

                           //修改旧数据
                           SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                           dataResult.optionType = SaveModel.MainOptionType.update;
                           dataResult.detailType = typeof(Viat_app_cust_price);
                           dataResult.DetailData = new List<Dictionary<string, object>> { dicOldPrice };
                           saveModel.DetailListData.Add(dataResult);
                       }
                   }

                   //◆	判斷本次修改group id是否為NHI
                   Viat_com_prod prod = getProdByProdID(entity.prod_dbid.ToString());
                   if (prod != null)
                   {
                       prod.nhi_id = entity.nhi_id;

                       //把实休转为dictionary
                       Dictionary<string, object> dicProd = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(prod));

                       //增加修改
                       SaveModel.DetailListDataResult dicProdResult = new SaveModel.DetailListDataResult();
                       dicProdResult.optionType = SaveModel.MainOptionType.update;
                       dicProdResult.detailType = typeof(Viat_com_prod);
                       dicProdResult.DetailData = new List<Dictionary<string, object>> { dicProd };
                       saveModel.DetailListData.Add(dicProdResult);

                   }

                   //◆	更新本次修改價格資料
                   //把实休转为dictionary
                   /*     Dictionary<string, object> dicEntity = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));
                        //更新本身的数据
                        SaveModel.DetailListDataResult dataCurrResult = new SaveModel.DetailListDataResult();
                        dataCurrResult.optionType = SaveModel.MainOptionType.update;
                        dataCurrResult.detailType = typeof(Viat_app_cust_price);
                        dataCurrResult.DetailData = new List<Dictionary<string, object>> { dicEntity };
                        saveModel.DetailListData.Add(dataCurrResult);*/
                   Dictionary<string, object> dicEntity = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));
                   if (entity.status == "N" && getFormatYYYYMMDD(entity.start_date) > getFormatYYYYMMDD(System.DateTime.Now))
                   {
                       //如果本次修改為未來價格且Status = Invalid，自動刪除該筆資料              
                       //增加修改
                       SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                       dataResult.optionType = SaveModel.MainOptionType.delete;
                       dataResult.detailType = typeof(Viat_app_cust_price);
                       dataResult.DetailData = new List<Dictionary<string, object>> { dicEntity };
                       saveModel.DetailListData.Add(dataResult);
                   }
                   else
                   {
                       //更新本身的数据
                       SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                       dataResult.optionType = SaveModel.MainOptionType.update;
                       dataResult.detailType = typeof(Viat_app_cust_price);
                       dataResult.DetailData = new List<Dictionary<string, object>> { dicEntity };
                       saveModel.DetailListData.Add(dataResult);
                   }

                   base.CustomBatchProcessEntity(saveModel);

                   webResponse.Code = "-1";
                   return webResponse.OK("Update successful");
               };

            return base.Update(saveModel);
        }

        /// <summary>
        /// 過去的價格資料,开始日期最接近编辑的开始日期
        /// </summary>
        /// <param name="entityParameter"></param>
        /// <returns></returns>
        private Viat_app_cust_price getOldPriceForEdit(Viat_app_cust_price entityParameter)
        {

            string sSql = @"SELECT TOP(1) *
                                FROM viat_app_cust_price
	                               WHERE pricegroup_dbid = '" + entityParameter.pricegroup_dbid + @"'
　　　                            AND prod_dbid =  '" + entityParameter.prod_dbid + @"' 
                            AND (CONVERT(Date, start_date)  <= CONVERT(Date, GETDATE()))
                            AND custprice_dbid <>  '" + entityParameter.custprice_dbid + @"' 
                                ORDER BY start_date DESC
                            ";

            return _repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, null);

        }

        /// <summary>
        /// ◆	判斷本次修改group id是否為NHI
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        private Viat_com_prod getProdByProdID(string prod_dbid)
        {
            string sSql = @"SELECT TOP(1) *
                            FROM viat_com_prod
                            WHERE prod_dbid = '" + prod_dbid + "'";

            Viat_com_prod prod = _repository.DapperContext.QueryFirst<Viat_com_prod>(sSql, null);
            return prod;
        }
        #endregion



        #region 保存方法新

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
                List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(typeof(Viat_app_cust_price), sRowDatas);

                //逻辑检查
                webResponse = checkData(entityDic);
                if (webResponse.Status == false)
                {
                    return webResponse;
                }

                //检查通过，返回需要保存的数据
                saveModel.MainDatas = entityDic;
                saveModel.mainOptionType = SaveModel.MainOptionType.add;
                saveModel.MainFacType = typeof(Viat_app_cust_price);
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

                List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(typeof(Viat_app_cust_price), sRowDatas); // JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(sRowDatas)); //base.CalcSameEntiryProperties(typeof(Viat_app_cust_price), sRowDatas);
                saveModel.MainDatas = entityDic;
                saveModel.mainOptionType = SaveModel.MainOptionType.add;
                saveModel.MainFacType = typeof(Viat_app_cust_price);
            }
            else
            {
                webResponse.Error("no data save");
            }

            processData(saveModel);

            base.CustomBatchProcessEntity(saveModel);
            return webResponse.OK("save successful");
        }

        /// <summary>
        /// 处理本条以外的数据
        /// </summary>
        /// <param name="saveModel"></param>
        public void processData(SaveModel saveModel)
        {
            //处理保存
            foreach (Dictionary<string, object> dic in saveModel.MainDatas)
            {

                if (dic.ContainsKey("custprice_dbid") == false)
                {
                    dic.Add("custprice_dbid", "");
                }
                if (dic["custprice_dbid"] != null && string.IsNullOrEmpty(dic["custprice_dbid"].ToString()) == true)
                {
                    dic["custprice_dbid"] = getDefaultGuid(typeof(Viat_wk_contract_stretagy));
                }

                Viat_app_cust_price entity = JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(dic));

                //1.1 資料未存在相同資料 → AddCustPrice()
                if (IsExistsSameData(entity) == false)
                {
                    //处理后，直接处理下一条
                    AddCustPriceData(entity, saveModel);
                    continue;
                }

                //1.2 存在相同資料,则处理其他数据时间
                //2.1	無現行價格資料 若 未來價格有資料，需變更新增數據結束日，結束日=未來價格起始日-1天 新增價格資料AddCustPrice()
                Viat_app_cust_price currentPriceEntity = getCurrentPriceData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString());
                if (currentPriceEntity == null)
                {
                    //无现行价格
                    //检查是否有未來價格有資料
                    Viat_app_cust_price futurePriceEntity = getFuturePriceData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString());
                    if (futurePriceEntity != null)
                    {
                        entity.end_date = futurePriceEntity.start_date.AddDays(-1);
                        //处理后，直接处理下一条                       
                    }

                    AddCustPriceData(entity, saveModel);
                    continue;
                }

                //2.2	有現行價格資料
                //2.2.1	找出價格資料內，符合Group+Prod價格資料 且 結束日 > 新增數據起始日 且 狀態為無效的資料(多筆)
                List<Viat_app_cust_price> invalidPriceData = getInValidPriceData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString(), entity.start_date);
                if (invalidPriceData != null && invalidPriceData.Count > 0)
                {
                    ProcessPriceData(entity, invalidPriceData, saveModel);
                }

                //2.2.2	判斷過去價格資料
                List<Viat_app_cust_price> oldPriceData = getOldPriceData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString());
                if (oldPriceData != null && oldPriceData.Count > 0)
                {
                    ProcessPriceData(entity, oldPriceData, saveModel);
                }

                //2.2.3	判斷未來價格資料
                Viat_app_cust_price futurePriceData = getFuturePriceData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString());
                if (futurePriceData != null)
                {
                    ProcessPriceData(entity, new List<Viat_app_cust_price> { futurePriceData }, saveModel);
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
                    ProcessPriceData(entity, new List<Viat_app_cust_price> { currentPriceEntity }, saveModel);
                }


                //如果没有特殊情况，新增本身资料
                //处理后，直接处理下一条
                AddCustPriceData(entity, saveModel);

                //更新价格
                if (isExistData(currentPriceEntity, saveModel) == false)
                {
                    Dictionary<string, object> dicCurrent = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(currentPriceEntity));
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_app_cust_price);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dicCurrent };
                    saveModel.DetailListData.Add(dataResult);
                }
            }
        }


        /// <summary>
        /// 存在的数据不再增加处理
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        private bool isExistData(Viat_app_cust_price entity, SaveModel saveModel)
        {
            //如果数据已处理，则跳过，因为框架对于同一条更新，会报错
           
            foreach (SaveModel.DetailListDataResult dResult in saveModel?.DetailListData)
            {
                if (dResult.detailType == typeof(Viat_app_cust_price))
                {
                    foreach (Dictionary<string, object> dicResult in dResult?.DetailData)
                        if (dicResult["custprice_dbid"].ToString() == entity.custprice_dbid.ToString())
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
        private void AddCustPriceData(Viat_app_cust_price entity, SaveModel saveModel)
        {
            if(entity.pricegroup_dbid != null)
            {
                //处理NHI
                ProcessNHI(entity, saveModel);
            }

            //增加price数据,增加前先处理
            entity.custprice_dbid = System.Guid.NewGuid();
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            if (getFormatYYYYMMDD(entity.end_date.ToString()) < getFormatYYYYMMDD(System.DateTime.Now))
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
            dataResult.detailType = typeof(Viat_app_cust_price);
            dataResult.DetailData = new List<Dictionary<string, object>> { dic };
            saveModel.DetailListData.Add(dataResult);

        }

        /// <summary>
        /// 处理价格方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveModel"></param>
        private void ProcessPriceData(Viat_app_cust_price currentEntity, List<Viat_app_cust_price> processEntityList, SaveModel saveModel)
        {

            if (processEntityList != null)
            {
                foreach (Viat_app_cust_price processEntity in processEntityList)
                {

                    if(isExistData(processEntity, saveModel) == true)
                    {
                        continue;
                    }

                    // 結束日 > 新增數據起始日
                    if(getFormatYYYYMMDD(currentEntity.start_date) >= getFormatYYYYMMDD(processEntity.end_date))
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
                        processEntity.remarks = processEntity.remarks +" 原起迄日" + getFormatYYYYMMDD(dProcessStartData).ToString("yyyy-MM-dd") + " ~ " + getFormatYYYYMMDD(dProcessEndData).ToString("yyyy-MM-dd");
                        processEntity.org_start_date = dProcessStartData;
                        processEntity.org_end_date = dProcessEndData;
                    }

                    processEntity.status = "N";
                    //更新数据
                    Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(processEntity));
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_app_cust_price);
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
        public bool IsExistsSameData(Viat_app_cust_price entity)
        {
            string sSql = "select count(*) from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid";
            object obj = _repository.DapperContext.ExecuteScalar(sSql, new { pricegroup_dbid = entity.pricegroup_dbid, prod_dbid = entity.prod_dbid });

            return (((int)obj) == 0) ? false : true;
        }

        /// <summary>
        /// 過去價格 = 結束日<系統日(多筆，以結束日降冪排序)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private List<Viat_app_cust_price> getOldPriceData(string sPriceGroupDBID, string sProdDBID)
        {
            string sSql = "select *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid " +
                "AND  end_date  < '"+ getFormatYYYYMMDD(DateTime.Now) + "' ORDER BY end_date DESC";
            List<Viat_app_cust_price> entiryOldPriceLst = _repository.DapperContext.QueryList<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            return entiryOldPriceLst;
        }

        /// <summary>
        /// 現行價格 = 系統日在起訖日期中(取最大結束日一筆)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private Viat_app_cust_price getCurrentPriceData(string sPriceGroupDBID, string sProdDBID)
        {
            string sSql = "select TOP(1) *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid " +
                "AND   start_date   <=  '" + getFormatYYYYMMDD(DateTime.Now) +  "' AND  end_date >='" + getFormatYYYYMMDD(DateTime.Now) + "' ORDER BY end_date DESC";
            Viat_app_cust_price entiryCustPrice = _repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            if(entiryCustPrice == null)
            {
                sSql = "select TOP(1) *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid  ORDER BY end_date ";
            
                    entiryCustPrice = _repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

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
        private Viat_app_cust_price getFuturePriceData(string sPriceGroupDBID, string sProdDBID)
        {
            string sSql = "select TOP(1) *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid " +
                "AND start_date > '"+ getFormatYYYYMMDD(DateTime.Now) + "' ORDER BY end_date ";
            Viat_app_cust_price entiryFuture = _repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            return entiryFuture;
        }

        /// <summary>
        /// 2.2.1	找出價格資料內，符合Group+Prod價格資料 且 結束日 > 新增數據起始日 且 狀態為無效的資料(多筆)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns> 
        private List<Viat_app_cust_price> getInValidPriceData(string sPriceGroupDBID, string sProdDBID, DateTime dStartDate)
        {
            string sSql = "select *  from viat_app_cust_price where   pricegroup_dbid='" + sPriceGroupDBID + "' and prod_dbid='" + sProdDBID + "' " +
                "   and status='N' " +
                "AND  end_date > '" + getFormatYYYYMMDD(dStartDate) + "'" +            
                " ORDER BY end_date DESC";
            List<Viat_app_cust_price> entiryExpirePriceLst = _repository.DapperContext.QueryList<Viat_app_cust_price>(sSql, null);

            return entiryExpirePriceLst;
        }


        
        #endregion

        #region 保存全部方法
       
 
          

        /// <summary>
        /// 保存价格新增数据
        /// </summary>
        private void UpdateCustPrice(Viat_app_cust_price entity, SaveModel saveModel)
        {
            //处理NHI
            ProcessNHI(entity, saveModel);

            //增加price数据
            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));
            SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
            dataResult.optionType = SaveModel.MainOptionType.update;
            dataResult.detailType = typeof(Viat_app_cust_price);
            dataResult.DetailData = new List<Dictionary<string, object>> { dic };
            saveModel.DetailListData.Add(dataResult);

        }

         
        /// <summary>
        /// 处理NHI数据
        /// </summary>
        private void ProcessNHI(Viat_app_cust_price entity, SaveModel saveModel)
        {
            /*增加判断，当前记录是否current*/
            if (getFormatYYYYMMDD(entity.start_date) <= getFormatYYYYMMDD(DateTime.Now) && getFormatYYYYMMDD(entity.end_date) >= getFormatYYYYMMDD(DateTime.Now))
            {

                string sSql = @"SELECT TOP(1) *
                            FROM viat_app_cust_price_group
                            WHERE group_id = 'NHI' and pricegroup_dbid ='" + entity.pricegroup_dbid + "'";

                Viat_app_cust_price_group entityGroup = _repository.DapperContext.QueryFirst<Viat_app_cust_price_group>(sSql, null);
                if (entityGroup == null)
                {
                    return;
                }
                else
                {
                    entity.nhi_price = entity.net_price;
                    string sProd = @"SELECT TOP(1) *
                                    FROM viat_com_prod 
                                    WHERE prod_dbid = '" + entity.prod_dbid + "'";
                    Viat_com_prod entityProd = _repository.DapperContext.QueryFirst<Viat_com_prod>(sProd, null);
                    if (entityProd != null)
                    {
                        entityProd.nhi_id = entity.nhi_id;
                        entityProd.nhi_price = entity.net_price;
                    }

                    Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entityProd));
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_com_prod);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dic };
                    saveModel.DetailListData.Add(dataResult);
                }
            }
        }

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
                Type type = typeof(Viat_app_cust_price);
                string sMessage = type.ValidateDicInEntity(dic, true, false, UserIgnoreFields);
                if (string.IsNullOrEmpty(sMessage) == false)
                {
                    return webResponse.Error(sMessage);
                }


                //◆檢查 Group + Product / Customer + Product 在Add DataGrid中是否有重覆資料
                string sPriceGroupDBID = dic["pricegroup_dbid"].ToString();
                string sProdDBID = dic["prod_dbid"].ToString();
                string sStartDate = dic["start_date"].ToString();
                string sEndDate = dic["end_date"].ToString();
                string sProdEName = "";// dic["prod_ename"].ToString();

                /* if (CheckPriceBookExists(sPriceGroupDBID, sProdDBID) == true)
                 {
                     //后台数据库已存在
                     webResponse.Code = "-1";
                     return webResponse.Error("Prod already exists in database");
                 }*/


                //检查是否触发未来价的卡控：不能同时有两个未来价
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy-MM-dd";
                DateTime dSysDate = getFormatYYYYMMDD(DateTime.Now);
                DateTime dPageDate = getFormatYYYYMMDD(sStartDate);
                Viat_app_cust_price futurePrice = CheckFuturePrice(sPriceGroupDBID, sProdDBID, sStartDate);
                if (futurePrice != null && futurePrice.status=="Y")
                {
                    //当前增加为未来价，系统已存在未来价
                    webResponse.Code = "-1";
                    return webResponse.Error("Prod:" + sProdEName + " Future prices already exists, please Invalid the future price");
                }

            }

            return webResponse.OK();
        }

        /// <summary>
        /// 檢查 Group + Product / Customer + Product 在Add DataGrid中是否有重覆資料
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>
        private bool CheckPriceBookExists(string sPriceGroupDBID, string sProdDBID)
        {
            string sSql = "select count(*) from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid";
            object obj = _repository.DapperContext.ExecuteScalar(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            return (((int)obj) == 0) ? false : true;

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
        private Viat_app_cust_price CheckFuturePrice(string sPriceGroupDBID, string sProdDBID, string sStartDate)
        {
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            //当前系统日期
            DateTime dSysDate = getFormatYYYYMMDD(DateTime.Now);
            DateTime dPageDate = getFormatYYYYMMDD(sStartDate);
            if (dPageDate < dSysDate)
            {
                return null;
            }

            //string sSql = "select TOP(1) *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid ORDER BY end_date DESC";
            Viat_app_cust_price entiryCustPrice = getFuturePriceData(sPriceGroupDBID, sProdDBID); //_repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });
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
            }

            return null;*/
        }
        #endregion



        #endregion

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //
            return _cust_priceService.Add(saveDataModel);
        }


        #region invalid

        public WebResponseContent invalidData(object saveData)
        {
            SaveModel saveModel = new SaveModel();
            Dictionary<string, object> dicData = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(saveData));
            string sSelectType = dicData["selectType"].ToString();
            string sRowsData = "";
            if (dicData.ContainsKey("rows") == true)
            {
                sRowsData = dicData["rows"].ToString();
            }
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            DateTime dEndData = getFormatYYYYMMDD(dicData["invalid_date"].ToString()).ToLocalTime();
            string sStatus = "Y";
            if(base.getFormatYYYYMMDD(dEndData) <= base.getFormatYYYYMMDD(System.DateTime.Now))
            {
                sStatus = "N";
            }

            string sRemarks = "";
            if(dicData.ContainsKey("remark") == true)
            {
                sRemarks = dicData["remark"]?.ToString();
            }
            string sProdDBID = "";
            if (dicData.ContainsKey("prod_dbid") == true)
            {
                sProdDBID = dicData["prod_dbid"]?.ToString();
            }
            string isAll = dicData["isAll"].ToString();

            if (sSelectType == "0")
            {
                string sPriceGroupDBID = dicData["pricegroup_dbid"].ToString();               
                //取得主界面值
                List<Viat_app_cust_price> entityList = new List<Viat_app_cust_price>();
                if (isAll == "0")
                {
                    //取得列表勾选的值
                    entityList = JsonConvert.DeserializeObject<List<Viat_app_cust_price>>(sRowsData);
                }
                else
                {
                    //全无效
                    entityList = getAllGroupPriceByGroupAndProd(sPriceGroupDBID, sProdDBID);
                }
                if (entityList != null && entityList.Count > 0)
                {
                    foreach (Viat_app_cust_price price in entityList)
                    {

                        price.status = sStatus;
                        price.end_date = dEndData;
                        price.remarks = sRemarks;

                        Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(price));
                        SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                        dataResult.optionType = SaveModel.MainOptionType.update;
                        dataResult.detailType = typeof(Viat_app_cust_price);
                        dataResult.DetailData = new List<Dictionary<string, object>> { dic };
                        saveModel.DetailListData.Add(dataResult);
                    }
                }

            }
            else if (sSelectType == "1")
            {
                /*1 detail    2 cust_price*/
                //cust price
                string sCustGroupDBID = dicData["cust_dbid"].ToString();
              
                List<View_cust_price_detail> entityList = new List<View_cust_price_detail>();
                if (isAll == "0")
                {
                    //取得列表勾选的值
                    entityList = JsonConvert.DeserializeObject<List<View_cust_price_detail>>(sRowsData);
                }
                else if (isAll == "1")
                {
                    //从后台查数据
                    entityList = View_cust_price_detailService.Instance.GetCustInvalidList(sCustGroupDBID, sProdDBID,"");
                }

                ProcessInvalidCustAndGroup(entityList, saveModel, dEndData, sRemarks, sStatus);
              
            }
            else if (sSelectType == "2")
            {
                //by prod              
                Viat_com_prod prod = getProdByProdID(sProdDBID);
                if (prod != null)
                {

                    //viat_app_cust_group
                    List<Viat_app_cust_group> custGroupPriceList = getAllCustGroupByProd(sProdDBID,"","");
                    if (custGroupPriceList != null)
                    {
                        foreach (Viat_app_cust_group groupPrice in custGroupPriceList)
                        {
                            groupPrice.end_date = dEndData;
                            groupPrice.status = sStatus;
                            groupPrice.remarks = sRemarks;

                            Dictionary<string, object> dicGroupPrice = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(groupPrice));
                            SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                            dataResult.optionType = SaveModel.MainOptionType.update;
                            dataResult.detailType = typeof(Viat_app_cust_group);
                            dataResult.DetailData = new List<Dictionary<string, object>> { dicGroupPrice };
                            saveModel.DetailListData.Add(dataResult);
                        }
                    }

                    //viat_app_cust_price 
                    List<Viat_app_cust_price> groupPriceList = getAllGroupPriceByProd(sProdDBID);
                    if (groupPriceList != null)
                    {
                        foreach (Viat_app_cust_price groupPrice in groupPriceList)
                        {
                            groupPrice.end_date = dEndData;
                            groupPrice.status = sStatus;
                            groupPrice.remarks = sRemarks;

                            Dictionary<string, object> dicGroupPrice = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(groupPrice));
                            SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                            dataResult.optionType = SaveModel.MainOptionType.update;
                            dataResult.detailType = typeof(Viat_app_cust_price);
                            dataResult.DetailData = new List<Dictionary<string, object>> { dicGroupPrice };
                            saveModel.DetailListData.Add(dataResult);
                        }
                    }

                    //viat_app_cust_price_detai
                    List<Viat_app_cust_price_detail> custPriceList = getAllCustPriceByProd(sProdDBID);
                    if (custPriceList != null)
                    {
                        foreach (Viat_app_cust_price_detail groupPrice in custPriceList)
                        {
                            groupPrice.end_date = dEndData;
                            groupPrice.status = sStatus;
                            groupPrice.remarks = sRemarks;

                            Dictionary<string, object> dicGroupPrice = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(groupPrice));
                            SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                            dataResult.optionType = SaveModel.MainOptionType.update;
                            dataResult.detailType = typeof(Viat_app_cust_price_detail);
                            dataResult.DetailData = new List<Dictionary<string, object>> { dicGroupPrice };
                            saveModel.DetailListData.Add(dataResult);
                        }
                    }

                }
            }
            else if (sSelectType == "3")
            {
                //by channel
                //根据channel,从viat_com_doh_type中取得匹配channel，取得多条信息，信息 包含 doh_type健保類別
                //根据doh_type匹配表viat_com_cust doh_type,匹配出cust_dbid
                string sChannel = "";
                if(dicData.ContainsKey("channelValue") == true)
                {
                    sChannel = dicData["channelValue"].ToString();
                }
                List<View_cust_price_detail> entityList = new List<View_cust_price_detail>();
                if (isAll == "0")
                {
                    //取得列表勾选的值
                    entityList = JsonConvert.DeserializeObject<List<View_cust_price_detail>>(sRowsData);
                }
                else if (isAll == "1")
                {
                    //从后台查数据
                    entityList = View_cust_price_detailService.Instance.GetCustInvalidList("", sProdDBID, sChannel);
                }

                ProcessInvalidCustAndGroup(entityList, saveModel, dEndData, sRemarks,sStatus);
            }

            base.CustomBatchProcessEntity(saveModel);
            return webResponse.OK("invalid successful");

        }

        /// <summary>
        /// 需要处理group和detail
        /// </summary>
        /// <param name="entityList"></param>
        /// <param name="saveModel"></param>
        private void ProcessInvalidCustAndGroup(List<View_cust_price_detail> entityList, SaveModel saveModel, DateTime dEndData, string sRemarks, string sStatus)
        {
            if (entityList != null && entityList.Count > 0)
            {
                foreach (View_cust_price_detail price in entityList)
                {
                    //拷贝
                    if (price.source_type == "1")
                    {
                        //detail
                        Viat_app_cust_price_detail detail = new Viat_app_cust_price_detail();
                        detail = JsonConvert.DeserializeObject<Viat_app_cust_price_detail>(JsonConvert.SerializeObject(price));
                        
                         
                        detail.status = sStatus;
                        detail.end_date = dEndData;
                        detail.remarks = sRemarks;

                        Dictionary<string, object> dicDetail = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(detail));
                        SaveModel.DetailListDataResult dataDetailResult = new SaveModel.DetailListDataResult();
                        dataDetailResult.optionType = SaveModel.MainOptionType.update;
                        dataDetailResult.detailType = typeof(Viat_app_cust_price_detail);
                        dataDetailResult.DetailData = new List<Dictionary<string, object>> { dicDetail };
                        saveModel.DetailListData.Add(dataDetailResult);
                    }
                    else if (price.source_type == "2")
                    {
                        //group
                        Viat_app_cust_group detail = new Viat_app_cust_group();
                        detail = JsonConvert.DeserializeObject<Viat_app_cust_group>(JsonConvert.SerializeObject(price));
                        detail.custgroup_dbid = price.pricedetail_dbid;

                        detail.status = sStatus;
                        detail.end_date = dEndData;
                        detail.remarks = sRemarks;

                        bool bFind = false;
                        foreach(SaveModel.DetailListDataResult resutl in saveModel.DetailListData)
                        {
                            foreach(Dictionary<string, object> dic in resutl.DetailData)
                            {
                                if(dic.ContainsKey("custgroup_dbid") == true)
                                {
                                    if(dic["custgroup_dbid"].ToString() == detail.custgroup_dbid.ToString())
                                    {
                                        bFind = true;
                                        break;
                                    }
                                }
                            }

                            if(bFind == true)
                            {
                                break;
                            }
                        }

                        if (bFind == false)
                        {
                            Dictionary<string, object> dicDetail = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(detail));
                            SaveModel.DetailListDataResult dataDetailResult = new SaveModel.DetailListDataResult();
                            dataDetailResult.optionType = SaveModel.MainOptionType.update;
                            dataDetailResult.detailType = typeof(Viat_app_cust_group);
                            dataDetailResult.DetailData = new List<Dictionary<string, object>> { dicDetail };
                            saveModel.DetailListData.Add(dataDetailResult);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 全部置无效时，取提grouppricedata
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>

        private List<Viat_app_cust_price> getAllGroupPriceByGroupAndProd(string sPriceGroupDBID, string sProdDBID)
        {
            string sSql = @"select * from Viat_app_cust_price where 1=1 ";
            if (string.IsNullOrEmpty(sPriceGroupDBID) == false)
            {
                sSql += " and pricegroup_dbid='" + sPriceGroupDBID + "'";
            }
            if (string.IsNullOrEmpty(sProdDBID) == false)
            {
                sSql += " and prod_dbid='" + sProdDBID + "'";
            }

            return _repository.DapperContext.QueryList<Viat_app_cust_price>(sSql, null);
        }

        /// <summary>
        /// 全部置无效时，取提grouppricedata
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>

        private List<Viat_app_cust_price> getAllCustPriceByGroupAndProd(string sPriceGroupDBID, string sProdDBID)
        {
            string sSql = @"select * from Viat_app_cust_price where 1=1 ";
            if (string.IsNullOrEmpty(sPriceGroupDBID) == false)
            {
                sSql += " and pricegroup_dbid='" + sPriceGroupDBID + "'";
            }
            if (string.IsNullOrEmpty(sProdDBID) == false)
            {
                sSql += " and prod_dbid='" + sProdDBID + "'";
            }

            return _repository.DapperContext.QueryList<Viat_app_cust_price>(sSql, null);
        }


        /// <summary>
        /// 全部置无效时，取提grouppricedata
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>
        public List<Viat_app_cust_price_detail> getAllPriceDetailByGroupAndProd(string sPriceDetailDBID, string sProdDBID,string cust_dbid,string pricegroup_dbid)
        {
            string sSql = @"select * from viat_app_cust_price_detail where 1=1 ";
            if (string.IsNullOrEmpty(sPriceDetailDBID) == false)
            {
                sSql += " and pricedetail_dbid='" + sPriceDetailDBID + "'";
            }
            if (string.IsNullOrEmpty(sProdDBID) == false)
            {
                sSql += " and prod_dbid='" + sProdDBID + "'";
            }
            if (!string.IsNullOrEmpty(cust_dbid))
            {
                sSql += $" and cust_dbid = '{cust_dbid}' and status = 'Y'";
            }
           /* if (!string.IsNullOrEmpty(pricegroup_dbid))
            {
                sSql += $" and pricegroup_dbid = '{pricegroup_dbid}'";
            }*/

            return _repository.DapperContext.QueryList<Viat_app_cust_price_detail>(sSql, null);
        }

        /// <summary>
        /// 全部置无效时，取提grouppricedata
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>

        private List<Viat_app_cust_group> getAllCustGroupByGroupAndProd(string sCustGroupDBID, string sProdDBID)
        {
            string sSql = @"select * from viat_app_cust_group where 1=1 ";
            if (string.IsNullOrEmpty(sCustGroupDBID) == false)
            {
                sSql += " and custgroup_dbid='" + sCustGroupDBID + "'";
            }
            if (string.IsNullOrEmpty(sProdDBID) == false)
            {
                sSql += " and prod_dbid='" + sProdDBID + "'";
            }

            return _repository.DapperContext.QueryList<Viat_app_cust_group>(sSql, null);
        }


        /// <summary>
        /// 全部置无效时，取提grouppricedata
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>

        private List<Viat_app_cust_price> getAllGroupPriceByProd(string sProdDBID)
        {
            string sSql = @"select * from Viat_app_cust_price custprice where 1=1 and custprice.status = 'Y'";
            if (string.IsNullOrEmpty(sProdDBID) == false)
            {
                sSql += " and custprice.prod_dbid='" + sProdDBID + "'";
            }
            sSql += @" AND NOT EXISTS (SELECT * FROM viat_app_cust_price_group AS pricegroup 
                        WHERE group_id  IN('NHI', 'GROSS')
                        AND custprice.pricegroup_dbid = pricegroup.pricegroup_dbid)";

            return _repository.DapperContext.QueryList<Viat_app_cust_price>(sSql, null);
        }

        /// <summary>
        /// 全部置无效时，取提custpricedata
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>

        private List<Viat_app_cust_price_detail> getAllCustPriceByProd(string sProdDBID)
        {
            string sSql = @"select * from viat_app_cust_price_detail where 1=1 and status = 'Y'";
            if (string.IsNullOrEmpty(sProdDBID) == false)
            {
                sSql += " and prod_dbid='" + sProdDBID + "'";
            }

            return _repository.DapperContext.QueryList<Viat_app_cust_price_detail>(sSql, null);
        }

        /// <summary>
        /// 全部置无效时，取提custpricedata
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>

        private List<Viat_app_cust_group> getAllCustGroupByProd(string sProdDBID,string cust_dbid,string custgroup_dbids)
        {
            string sSql = @"select * from viat_app_cust_group where 1=1 and status = 'Y'";
            if (string.IsNullOrEmpty(sProdDBID) == false)
            {
                sSql += " and prod_dbid='" + sProdDBID + "'";
            }
            if (!string.IsNullOrEmpty(cust_dbid))
            {
                sSql += $" and cust_dbid = '{cust_dbid}'";
            }
            if (!string.IsNullOrEmpty(custgroup_dbids))
            {
                sSql += $" and custgroup_dbid in ({custgroup_dbids})";
            }
            return _repository.DapperContext.QueryList<Viat_app_cust_group>(sSql, null);
        }


        #endregion
        public WebResponseContent detachProducts(SaveModel saveModel)
        {
            return null;
        }

        public override WebResponseContent DownLoadTemplate()
        {
            DownLoadTemplateColumns = x => new {
                x.group_id, 
                x.group_name,
                x.prod_id, 
                x.prod_ename,
                x.nhi_price,
                x.net_price,
                x.invoice_price,
                x.reserv_price,
                x.min_qty,
                x.start_date,
                x.end_date,
                x.remarks };
            return base.DownLoadTemplate();
        }



        /// <summary>
        /// 取得Gross Price
        /// </summary>
        /// <param name="sProdID">产品ID</param>
        /// <returns></returns>
        public decimal getNetPriceByProdID(string sProdID)
        {
            string sSql = @"SELECT
	                    custprice.net_price 
                    FROM
	                    viat_app_cust_price AS custprice
	                    INNER JOIN viat_app_cust_price_group AS pricegroup ON custprice.pricegroup_dbid = pricegroup.pricegroup_dbid
	                    INNER JOIN viat_com_prod AS prod ON custprice.prod_dbid = prod.prod_dbid 
                    WHERE
	                    ( 1 = 1 ) 
	                    AND ( pricegroup.group_id = 'GROSS' ) 
	                    AND ( custprice.status =  'Y' ) 
	                    AND (CONVERT(Date,  SysDateTime ( )) >= CONVERT(Date, custprice.start_date))
	                    AND (CONVERT(Date,  SysDateTime ( )) <= CONVERT(Date, custprice.end_date))
	                    AND prod.prod_id =  '" + sProdID + "'";
            object obj = _repository.DapperContext.ExecuteScalar(sSql, null);
            if (obj == null)
            {
                //当天第一个号码
                return 0;
            }
            else
            {
                return (decimal)obj;
            }

        }

        /// <summary>
        /// 取得Gross Price
        /// </summary>
        /// <param name="sProdID">产品ID</param>
        /// <returns></returns>
        public decimal getNetPriceByProdDBID(string sProdDBID)
        {
            string sSql = @"SELECT
	                    custprice.net_price 
                    FROM
	                    viat_app_cust_price AS custprice
	                    INNER JOIN viat_app_cust_price_group AS pricegroup ON custprice.pricegroup_dbid = pricegroup.pricegroup_dbid
	                    INNER JOIN viat_com_prod AS prod ON custprice.prod_dbid = prod.prod_dbid 
                    WHERE
	                    ( 1 = 1 ) 
	                    AND ( pricegroup.group_id = 'GROSS' ) 
	                    AND ( custprice.status =  'Y' ) 
	                    AND (CONVERT(Date,  SysDateTime ( )) >= CONVERT(Date, custprice.start_date))
	                    AND (CONVERT(Date,  SysDateTime ( )) <= CONVERT(Date, custprice.end_date))
	                    AND prod.prod_dbid =  '" + sProdDBID + "'";
            object obj = _repository.DapperContext.ExecuteScalar(sSql, null);
            if (obj == null)
            {
                //当天第一个号码
                return 0;
            }
            else
            {
                return (decimal)obj;
            }

        }

        #region 导入

        /// <summary>
        /// 导入校验
        /// </summary>
        /// <returns></returns>
        private WebResponseContent checkImport(List<View_cust_price> list)
        {
            int nLoop = 1;

             
            //数据初始化处理
            foreach (View_cust_price group in list)
            {
                if (string.IsNullOrEmpty(group.prod_id) == false)
                {
                    Viat_com_prod prod = getProd(group.prod_id,"");
                    //
                    if (prod != null)
                    {
                        //decimal nhiprice = NhiPriceData(prod.prod_dbid.ToString(), group.start_date.ToString());
                        //group.nhi_price = prod.nhi_price;
                        group.nhi_price = NhiPriceData(prod.prod_dbid.ToString(), group.start_date.ToString());
                    }
                }

                if (group.end_date == null)
                {
                    group.end_date = getFormatYYYYMMDD("2099-12-31");
                }
            }

            #region check1
            string sMessageBulider1 = "";
            foreach (View_cust_price group in list)
            {
                string sColumns = "";
                #region 非空校验  check1
                //逐筆檢查Import內容Cust Id, Group Id, Inovie Price, Net Price, Min Qty, Start Date不可空白Msg為所有筆數檢查後結果
                if (group.group_id == null)
                {
                    sColumns += "group_id ID empty,";
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
                if (group.min_qty == null || group.min_qty<1)
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

                if(group.start_date>group.end_date)
                {
                    sColumns += "End Date < Start Date,";
                }

                if(group.group_id != "NHI" && group.nhi_price == null)
                {
                    sColumns += " Can't  get NHI Price by prod:'" + group.prod_id;
                }                
               
                if(string.IsNullOrEmpty(sColumns) == false)
                {
                    sMessageBulider1 += ("column(s):[" + sColumns + "] at row read " + nLoop) + "<br/>";
                }
                nLoop++;
                #endregion
            }
            if(string.IsNullOrEmpty(sMessageBulider1) ==false)
            {
                return webResponse.Error(sMessageBulider1);
            }

           
            #endregion
            #region check2 逐筆檢查NHI Price , Invoice Price , Net price, Gross Price關係

            
           
            #region check3 判斷Cust Id是否為Expfizer Cust Id                   


            #endregion

            #region Check4 逐筆判斷Cust Id、Group Id、Prod Id是否存在

            string sMessageBulid4 = "";
            foreach (View_cust_price group in list)
            {
                if(string.IsNullOrEmpty(group.reserv_price?.ToString()) ==false)
                {
                    if(group.reserv_price>group.net_price)
                    {
                        sMessageBulid4 += "Reserve Price can't > Net Price: " + "<br/>";
                        sMessageBulid4 += "Group Id: " + group.group_id + ",Prod Id: " + group.prod_id + "<br/>";

                    }
                }

                if (group.net_price > group.invoice_price)
                {
                    sMessageBulid4 += "Net Price can’t > Invoice Price: " + "<br/>";
                    sMessageBulid4 += "Group Id: " + group.group_id + ",Prod Id: " + group.prod_id + "<br/>";
                }

                //判斷產品是否存在
                Viat_com_prod prod = getProd(group.prod_id,"1");
                if(prod == null)
                {
                    sMessageBulid4 += "ItemCode:" + group.prod_id + " is not exist" + "<br/>";
                }
                else
                {
                    group.prod_dbid = prod.prod_dbid;
                }

                //判斷群組是否存在
                Viat_app_cust_price_group priceGroup = getGroup(group.group_id);
                if(priceGroup == null)
                {
                    sMessageBulid4+="ItemCode:" + group.group_id + " is not exist" + "<br/>";
                }
                else
                {
                    group.pricegroup_dbid = priceGroup.pricegroup_dbid;
                }


                if (string.IsNullOrEmpty(sMessageBulid4) == true)
                {
                    Viat_app_cust_price FuturePrice = CheckFuturePrice(group.pricegroup_dbid?.ToString(), group.prod_dbid.ToString(), group.start_date.ToString("yyyy-MM-dd"));
                    //检查是否已存在未来价格
                    if (FuturePrice != null && FuturePrice.status == "Y")
                    {
                        //当前增加为未来价，系统已存在未来价
                        sMessageBulid4 += "Prod:" + group.prod_id + " Future prices already exists, please Invalid the future price";
                    }
                }
                if ((getFormatYYYYMMDD(DateTime.Now) >= getFormatYYYYMMDD(group.start_date)
                   && getFormatYYYYMMDD(DateTime.Now) <= getFormatYYYYMMDD(group.end_date)) || getFormatYYYYMMDD(group.start_date) > getFormatYYYYMMDD(DateTime.Now))
                {
                    group.status = "Y";
                }
                else
                {
                    group.status = "N";
                }
            }
            if(string.IsNullOrEmpty(sMessageBulid4) == false)
            {
                return webResponse.Error(sMessageBulid4);
            }            


            webResponse = checkConfirmData(list);    
            if(webResponse.Code =="-2")
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

        private WebResponseContent checkConfirmData(List<View_cust_price> list)
        {
           
            string sConfirmMessage = "";
            foreach (View_cust_price group in list)
            {
                string sMessage1 = "";
                string sMessage2 = "";
                string sMessage3 = "";
                string sMessage4 = "";
                if (group.invoice_price > group.nhi_price)
                {
                    sMessage1 = " Group Id:" + group.group_id + ",Prod Id:" + group.prod_id + "<br/> ";
                }
                if (group.nhi_price >0 && group.invoice_price>0 && group.nhi_price != group.invoice_price && group.net_price == group.invoice_price)
                {
                    sMessage2 = " Group Id:" + group.group_id + ",Prod Id:" + group.prod_id + "<br/> ";
                }

                if (string.IsNullOrEmpty(sMessage1) == false)
                {
                    sMessage1 = "<p> Invoice price > NHI price." + " <br/>" + sMessage1 ;                   
                }
                if (string.IsNullOrEmpty(sMessage2) == false)
                {
                    sMessage2 = "<p> Invoice price ≠ NHI price but Invoice Price = Net Price." + "<br/>" + sMessage2;
                }

                sConfirmMessage += sMessage1 + sMessage2;
            }

            if (string.IsNullOrEmpty(sConfirmMessage) == false)
            {
                //View_cust_price_detail
              
                sConfirmMessage += "<br/>" + " Do you want to import data?";
               

                webResponse.Code = "-2";
                webResponse.Url = "/api/View_cust_price/importData";
                webResponse.Data = list;
                return webResponse.Error(sConfirmMessage);
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
            if(string.IsNullOrEmpty(state) ==false)
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
        private Viat_app_cust_price_group getGroup(string group_id)
        {
            string sSql = @"SELECT TOP(1) *
                            FROM viat_app_cust_price_group
                            WHERE  LOWER ( group_id )  = '" + group_id + "'";
            

            Viat_app_cust_price_group group = _repository.DapperContext.QueryFirst<Viat_app_cust_price_group>(sSql, null);
            return group;
        }

        public override WebResponseContent Import(List<IFormFile> files)
        {
            //如果下載模板指定了DownLoadTemplate,則在Import方法必須也要指定,並且字段要和下載模板裡指定的一致
            DownLoadTemplateColumns = x => new {
                x.group_id,
                x.group_name,
                x.prod_id,
                x.prod_ename,
                x.nhi_price,
                x.net_price,
                x.invoice_price,
                x.reserv_price,
                x.min_qty,
                x.start_date,
                x.end_date,
                x.remarks
            };
           

            ImportOnExecutBefore = () =>
             {
                 bCheckImportCustom = true;
                 return webResponse.OK();
             };

            ImportOnExecuting = (list) =>
            {
                webResponse = checkImport(list);
                if(webResponse.Status == false)
                {
                    return webResponse;
                }

                //新增
                //进行数据处理
                //webResponse = this.bathSaveCustPrice(JsonConvert.SerializeObject(list));                
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
        public WebResponseContent importData(List<View_cust_price> list)
        {
            //新增
            //进行数据处理
            webResponse = this.bathSaveCustPrice(JsonConvert.SerializeObject(list));
            webResponse.Code = "-1";
            return webResponse;             
            }

        #endregion

        public decimal NhiPriceData(string prod_dbid, string start_date)
        {
            string sql = $@"select top 1 nhi_price from viat_app_cust_price where pricegroup_dbid =(select pricegroup_dbid from viat_app_cust_price_group where group_id = 'NHI')
	                        and prod_dbid = '{prod_dbid}'
	                        and (CONVERT(date,'{start_date}') >= CONVERT(date,start_date))
	                        and (CONVERT(date,'{start_date}') <= CONVERT(date,end_date))
	                         ORDER BY start_date,end_date desc ";
            var priceData = repository.DapperContext.ExecuteScalar(sql, null);
            if (priceData != null)
            {
                return (decimal)priceData;
            }
            sql = $"select top 1 nhi_price from viat_com_prod where prod_dbid = '{prod_dbid}'";
            priceData = repository.DapperContext.ExecuteScalar(sql, null);
            if (priceData != null)
            {
                return (decimal)priceData;
            }
            return 0;
        }


        public PageGridData<View_cust_price> getPriceGroupProducts(PageDataOptions pageData)
        {
            PageGridData<View_cust_price> pageGridData = new PageGridData<View_cust_price>();
            string sGroupID = "";
            string sCustID = "";
            string custpriceDBIDS="";
            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(pageData.Wheres))
            {
                searchParametersList = pageData.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                   
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "pricegroup_dbid".ToLower())
                        {
                            sGroupID = sp.Value;
                            continue;
                        }

                        if (sp.Name.ToLower() == "cust_dbid".ToLower())
                        {
                            sCustID = sp.Value;
                            continue;
                        }
                        //
                        if (sp.Name.ToLower() == "custprice_dbids".ToLower())
                        {
                            custpriceDBIDS =string.Format("'{0}'", sp.Value.Replace(",", "','"));
                            continue;
                        }
                    }
                }
            }
            QuerySql = @"
                SELECT
                    ROW_NUMBER()over(order by prod.prod_ename ) as rowId,
	                custprice.*, 
                    prod.prod_id,
	                prod.prod_ename,
	                prod.prod_cname,
	                prod.state
                FROM
	                viat_app_cust_price AS custprice
                INNER JOIN viat_com_prod AS prod ON custprice.prod_dbid = prod.prod_dbid
                WHERE
	                custprice.status = 'Y'
                AND prod.state = '1'
                ";
            if (string.IsNullOrEmpty(sGroupID) == false)
            {
                QuerySql += @" and custprice.pricegroup_dbid='"+@sGroupID+"'";
            }
            
            if (string.IsNullOrEmpty(custpriceDBIDS) == false)
            {
                QuerySql += @" and custprice.custprice_dbid not in (" + @custpriceDBIDS + ")";
            }
            if (string.IsNullOrEmpty(sCustID) == false)
            {
                QuerySql += @"
                        AND (
	                        NOT EXISTS (
		                        SELECT
			                        1 AS C1
		                        FROM
			                        (
				                        SELECT DISTINCT
					                        custgroup.prod_dbid
				                        FROM
					                        viat_app_cust_group AS custgroup
				                        WHERE
					                        custgroup.cust_dbid = '"+sCustID+@"'  AND custgroup.pricegroup_dbid = '"+sGroupID+@"'
                                        AND custgroup.status = 'Y'
			                        ) AS custgroup
		                        WHERE
			                        custprice.prod_dbid = custgroup.prod_dbid
	                        )
                        )

                    ";
            }
           
            string sql = "select count(1) from (" + QuerySql + ") a";


            pageGridData.total = repository.DapperContext.ExecuteScalar(sql, null).GetInt();

            sql = @$"select * from (" +
                QuerySql + $" ) as s where s.rowId between {((pageData.Page - 1) * pageData.Rows + 1)} and {pageData.Page * pageData.Rows} ";
            pageGridData.rows = repository.DapperContext.QueryList<View_cust_price>(sql, null);
            return pageGridData;

        }

        public PageGridData<Viat_app_cust_group_for_detach> getCustomerProducts(PageDataOptions pageData)
        {
            PageGridData<Viat_app_cust_group_for_detach> pageGridData = new PageGridData<Viat_app_cust_group_for_detach>();
            string sProdID = "";
            string sCustID = "";
            string show_invalid = "";

            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(pageData.Wheres))
            {
                searchParametersList = pageData.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {

                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "prod_dbid".ToLower())
                        {
                            sProdID = sp.Value;
                            continue;
                        }

                        if (sp.Name.ToLower() == "cust_dbid".ToLower())
                        {
                            sCustID = sp.Value;
                            continue;
                        }
                        if (sp.Name.ToLower() == "show_invalid".ToLower())
                        {
                            show_invalid = sp.Value;
                            continue;
                        }
                    }
                }
            }
            QuerySql = @"
               SELECT
                ROW_NUMBER()over(order by prod.prod_ename ) as rowId,
	            custgroup.custgroup_dbid,
	            custgroup.cust_dbid,
	            custgroup.prod_dbid,
	            custprice.nhi_price,
	            custprice.invoice_price,
	            custprice.net_price,
	            custprice.min_qty,
	            custprice.start_date,
	            custprice.end_date,
	            custprice.status,
	            prod.prod_id,
	            prod.prod_ename,
	            pricegroup.group_id,
	            pricegroup.group_name
            FROM
	            viat_app_cust_group AS custgroup
            LEFT JOIN viat_app_cust_price AS custprice ON custprice.pricegroup_dbid = custgroup.pricegroup_dbid
            AND custprice.prod_dbid = custgroup.prod_dbid
            AND custprice.status = 'Y'
            LEFT JOIN viat_app_cust_price_group AS pricegroup ON custgroup.pricegroup_dbid = pricegroup.pricegroup_dbid
            INNER JOIN viat_com_prod AS prod ON custgroup.prod_dbid = prod.prod_dbid
            WHERE
	            (
		            NOT EXISTS (
			            SELECT
				            1 AS C1
			            FROM
				            viat_app_cust_price_detail AS pricedetail
			            WHERE
				            pricedetail.cust_dbid = custgroup.cust_dbid
			            AND pricedetail.status = 'Y'
			            AND pricedetail.prod_dbid = prod.prod_dbid
		            )
	            )
            AND custgroup.status = 'Y'
                ";
            if (string.IsNullOrEmpty(sProdID) == false)
            {
                QuerySql += @" and custgroup.prod_dbid='" + sProdID + "'";
            }
            if (string.IsNullOrEmpty(sCustID) == false)
            {
                QuerySql += @" and custgroup.cust_dbid='" + sCustID + "'";
            }
            if (string.IsNullOrEmpty(show_invalid) == false && show_invalid == "1")
            {
                QuerySql += @" AND prod.state = '1' ";
            }

            string sql = "select count(1) from (" + QuerySql + ") a";

            pageGridData.total = repository.DapperContext.ExecuteScalar(sql, null).GetInt();

            sql = @$"select * from (" +
                QuerySql + $" ) as s where s.rowId between {((pageData.Page - 1) * pageData.Rows + 1)} and {pageData.Page * pageData.Rows} ";
            pageGridData.rows = repository.DapperContext.QueryList<Viat_app_cust_group_for_detach>(sql, null);
            return pageGridData;
        }
        /*  public override WebResponseContent Export(PageDataOptions pageData)
          {
              ExportColumns = x => new { };
              return base.Export(pageData);
          }*/

        #region Customer Join to Group Price->Execute

        /// <summary>
        /// Customer Join to Group Price->Execute
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public WebResponseContent excuteCustomerJoinGroup(SaveModel saveModel)
        {
            string s_cust_dbid = saveModel.MainData["cust_dbid"]?.ToString();
            string s_prod = "";
            if (saveModel.DetailData != null && saveModel.DetailData.Count()>0)
            {
                foreach (Dictionary<string,object> item in saveModel.DetailData)
                {
                    if (item["key"]?.ToString() == "selectedJoinRowData")
                    {
                        s_prod = item["value"]?.ToString();
                        ProcessGroupOrDetail(saveModel, s_prod, s_cust_dbid);
                    }
                }
            }
            return base.CustomBatchProcessEntity(saveModel);
        }

        public void ProcessGroupOrDetail(SaveModel saveModel, string group, string cust_dbid)
        {
            if (!string.IsNullOrEmpty(group))
            {
                string remark = "",start_date = "",end_date = "";
                if (saveModel.MainData.ContainsKey("remark"))
                {
                    remark = saveModel.MainData["remark"].ToString();
                }
                if (!string.IsNullOrEmpty(saveModel.MainData["start_date"].ToString()))
                {
                    start_date = saveModel.MainData["start_date"].ToString();
                }
                if (!string.IsNullOrEmpty(saveModel.MainData["end_date"].ToString()))
                {
                    end_date = saveModel.MainData["end_date"].ToString();
                }
                Guid? custdbid = new Guid(cust_dbid);
                List<Viat_app_cust_group> lstGroup = JsonConvert.DeserializeObject<List<Viat_app_cust_group>>(group);
                UserInfo userInfo = Core.ManageUser.UserContext.Current.UserInfo;
                foreach (var item in lstGroup)
                {
                    ProceeGroup(saveModel, item, cust_dbid);
                    ProceeDetail(saveModel, item, cust_dbid, start_date);
                    SaveModel.DetailListDataResult custGroupResult = new SaveModel.DetailListDataResult();
                    item.cust_dbid = custdbid;
                    item.remarks = remark;
                    item.start_date = getFormatYYYYMMDD(start_date);
                    item.end_date = getFormatYYYYMMDD(end_date);
                    item.modified_date = getFormatYYYYMMDD(DateTime.Now);
                    item.modified_user = userInfo.User_Id;
                    item.bid_no = "";
                    custGroupResult.optionType = SaveModel.MainOptionType.add;
                    custGroupResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    custGroupResult.detailType = typeof(Viat_app_cust_group);
                    saveModel.DetailListData.Add(custGroupResult);
                }
            }
        }
        /// <summary>
        /// edit Viat_app_cust_group
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="cust_group"></param>
        /// <param name="cust_dbid"></param>
        public void ProceeGroup(SaveModel saveModel,Viat_app_cust_group cust_group,string cust_dbid)
        {
            List<Viat_app_cust_group> lstCustGroup = getAllCustGroupByProd(cust_group.prod_dbid.ToString(), cust_dbid,"");
            if (lstCustGroup.Count() > 0)
            {
                foreach (var item in lstCustGroup)
                {
                    SaveModel.DetailListDataResult custGroupResult = new SaveModel.DetailListDataResult();
                    custGroupResult.optionType = SaveModel.MainOptionType.update;
                    item.status = "N";
                    Dictionary<string, object> dicCustGroup = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item));
                    //custGroupResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    custGroupResult.detailType = typeof(Viat_app_cust_group);
                    custGroupResult.DetailData = new List<Dictionary<string, object>> { dicCustGroup };
                    saveModel.DetailListData.Add(custGroupResult);
                }
            }
        }
        /// <summary>
        /// edit Viat_app_cust_group
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="cust_group"></param>
        /// <param name="cust_dbid"></param>
        public void ProceeDetail(SaveModel saveModel, Viat_app_cust_group entiy, string cust_dbid,string start_date)
        {
            List<Viat_app_cust_price_detail> lstPriceDetail = getAllPriceDetailByGroupAndProd("", entiy.prod_dbid.ToString(), cust_dbid,"");
            if (lstPriceDetail.Count()>0)
            {
                foreach (var item in lstPriceDetail)
                {
                    SaveModel.DetailListDataResult custPiceDetailResult = new SaveModel.DetailListDataResult();
                    custPiceDetailResult.optionType = SaveModel.MainOptionType.update;
                    item.status = "N";
                    item.end_date = Convert.ToDateTime(start_date).AddDays(-1);
                    custPiceDetailResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    custPiceDetailResult.detailType = typeof(Viat_app_cust_price_detail);
                    saveModel.DetailListData.Add(custPiceDetailResult);
                }
            }
        }
        #endregion

        #region Customer Detach->Detach Selected
        public WebResponseContent excuteCustomerDetachGroup(SaveModel saveModel)
        {
            ProcessGroup(saveModel);
            return base.CustomBatchProcessEntity(saveModel);
        }

        public void ProcessGroup(SaveModel saveModel)
        {
            string custgroup_dbids = saveModel.MainData["detachKeys"]?.ToString();
            string custgroup_dbid = string.Format("'{0}'", custgroup_dbids.Replace(",", "','"));
            string detach_date = Convert.ToDateTime(saveModel.MainData["detach_date"]).ToString("yyyy-MM-dd");
            string remark = "";
            if (saveModel.MainData.ContainsKey("remark"))
            {
                remark = saveModel.MainData["remark"].ToString();
            }
            List<Viat_app_cust_group> lstCustGroup = getAllCustGroupByProd("", "", custgroup_dbid);
            if (lstCustGroup.Count()>0)
            {
                foreach (var item in lstCustGroup)
                {
                    //ProceeDetail(saveModel, item, item.cust_dbid.ToString());
                    DetachDetail(saveModel, item, item.cust_dbid.ToString(), detach_date);
                    item.end_date = getFormatYYYYMMDD(detach_date).AddDays(-1);
                    if (getFormatYYYYMMDD(item.end_date) < getFormatYYYYMMDD(item.start_date))
                    {
                        item.start_date = item.end_date;
                    }
                    item.status = "N";
                    item.remarks += " " + remark;
                    SaveModel.DetailListDataResult custGroupResult = new SaveModel.DetailListDataResult();
                    custGroupResult.optionType = SaveModel.MainOptionType.update;
                    custGroupResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    custGroupResult.detailType = typeof(Viat_app_cust_group);
                    saveModel.DetailListData.Add(custGroupResult);
                }
            }
        }

        /// <summary>
        /// edit Viat_app_cust_group
        /// </summary>
        /// <param name="saveModel"></param>
        /// <param name="cust_group"></param>
        /// <param name="cust_dbid"></param>
        public void DetachDetail(SaveModel saveModel, Viat_app_cust_group entiy, string cust_dbid,string detach_date)
        {
            List<Viat_app_cust_price_detail> lstPriceDetail = getAllPriceDetailByGroupAndProd("", entiy.prod_dbid.ToString(), cust_dbid,"");
            if (lstPriceDetail.Count() > 0)
            {
                foreach (var item in lstPriceDetail)
                {
                    SaveModel.DetailListDataResult custPiceDetailResult = new SaveModel.DetailListDataResult();
                    custPiceDetailResult.optionType = SaveModel.MainOptionType.update;
                    if (getFormatYYYYMMDD(detach_date) < getFormatYYYYMMDD(DateTime.Now))
                    {
                        item.status = "C";
                    }
                    else
                    {
                        item.status = "N";
                    }
                    custPiceDetailResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(item)));
                    custPiceDetailResult.detailType = typeof(Viat_app_cust_price_detail);
                    saveModel.DetailListData.Add(custPiceDetailResult);
                }
            }
        }
        #endregion
    }
}
