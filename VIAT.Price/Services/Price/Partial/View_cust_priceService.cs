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


        /// <summary>
        /// 置无效数据查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public  PageGridData<View_cust_price> GetGroupInvalidPageData(PageDataOptions options)
        {

            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    string sGroupID = "";
                    string sProdID = "";
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "group_id".ToLower())
                        {
                            sGroupID = sp.Value;
                            continue;
                        }

                        if (sp.Name.ToLower() == "prod_id".ToLower())
                        {
                            sProdID = sp.Value;
                            continue;
                        }
                    }

                    QuerySql = @"SELECT custPrice.* 
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
		                                AND priceGroup.group_id = '" + sGroupID + "'";
                    if (string.IsNullOrEmpty(sProdID) == false)
                    {
                        QuerySql += " AND prod.prod_id = '" + sProdID +"'";
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
	                                AND (CONVERT(Date, GETDATE( )) <= CONVERT(Date, distMapping.end_date)) 
                                ORDER BY prod_id, modified_date";
                                                }
                                            }


            return base.GetPageData(options);
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


        #region 更新保存方法

        public override WebResponseContent Update(SaveModel saveModel)
        {

            UpdateOnExecute = (saveModel) =>
               {
                   DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                   dtFormat.ShortDatePattern = "yyyy-MM-dd";
                   //把编辑的数据转成实体
                   Viat_app_cust_price entity = JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(saveModel.MainData));
                   if (Convert.ToDateTime(entity.end_date.ToString("yyyy-MM-dd"), dtFormat) < Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"), dtFormat))
                   {
                       entity.status = "N";
                   }
                   else
                   {
                       entity.status = "Y";
                   }


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

                           if (oldPrice.end_date < Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"), dtFormat) == true)
                           {
                               entity.status = "N";
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
                       SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                       dataResult.optionType = SaveModel.MainOptionType.update;
                       dataResult.detailType = typeof(Viat_com_prod);
                       dataResult.DetailData = new List<Dictionary<string, object>> { dicProd };
                       saveModel.DetailListData.Add(dataResult);

                   }

                   //◆	更新本次修改價格資料
                   //把实休转为dictionary
                   Dictionary<string, object> dicEntity = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));
                   if (entity.status == "N" && Convert.ToDateTime(entity.start_date.ToString("yyyy-MM-dd"), dtFormat) > Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"), dtFormat))
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

        #region 保存全部方法
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
            SaveModel saveModel = new SaveModel();
            //构造需要保存的saveModel
            //计算表体和实体的值
            string sRowDatas = saveData.ToString();
            if (string.IsNullOrEmpty(sRowDatas) == false)
            {

                List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(typeof(Viat_app_cust_price), sRowDatas);
                saveModel.MainDatas = entityDic;
                saveModel.mainOptionType = SaveModel.MainOptionType.add;
                saveModel.MainFacType = typeof(Viat_app_cust_price);
            }
            else
            {
                webResponse.Error("no data save");
            }
            //处理保存
            foreach (Dictionary<string, object> dic in saveModel.MainDatas)
            {
                string sPriceGroupDBID = dic["pricegroup_dbid"].ToString();
                string sProdDBID = dic["prod_dbid"].ToString();
                /* string sStartDate = dic["start_date"].ToString();
                 string sEndDate = dic["end_date"].ToString();*/

                Viat_app_cust_price entity = JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(dic));
                entity.custprice_dbid = System.Guid.NewGuid();
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy-MM-dd";
                if (Convert.ToDateTime(entity.end_date.ToString(), dtFormat) < Convert.ToDateTime(System.DateTime.Now.ToString(), dtFormat))
                {
                    entity.status = "N";
                }

                //处理NHI逻辑
                AddCustPrice(entity, saveModel);

                //1、資料未存在相同資料，正常新增数据，不处理
                //2、時間檢查处理
                /*
                 2.1	無現行價格資料
                        若 未來價格有資料，需變更新增數據結束日，結束日=未來價格起始日-1天  
                 
                 */





            }

            base.CustomBatchProcessEntity(saveModel);
            return webResponse.OK();
        }


        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="saveData">该参数为前端传过来的json，需要转为dictinary</param>
        /// <returns></returns>
        public WebResponseContent bathSaveCustPriceBak(object saveData)
        {
            SaveModel saveModel = new SaveModel();
            //构造需要保存的saveModel
            //计算表体和实体的值
            string sRowDatas = saveData.ToString();
            if (string.IsNullOrEmpty(sRowDatas) == false)
            {

                List<Dictionary<string, object>> entityDic = base.CalcSameEntiryProperties(typeof(Viat_app_cust_price), sRowDatas);
                saveModel.MainDatas = entityDic;
                saveModel.mainOptionType = SaveModel.MainOptionType.add;
                saveModel.MainFacType = typeof(Viat_app_cust_price);
            }
            else
            {
                webResponse.Error("no data save");
            }
            //处理保存
            foreach (Dictionary<string, object> dic in saveModel.MainDatas)
            {
                string sPriceGroupDBID = dic["pricegroup_dbid"].ToString();
                string sProdDBID = dic["prod_dbid"].ToString();
                /* string sStartDate = dic["start_date"].ToString();
                 string sEndDate = dic["end_date"].ToString();*/

                Viat_app_cust_price entity = JsonConvert.DeserializeObject<Viat_app_cust_price>(JsonConvert.SerializeObject(dic));
                entity.custprice_dbid = System.Guid.NewGuid();
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy-MM-dd";
                if (Convert.ToDateTime(entity.end_date.ToString(), dtFormat) < Convert.ToDateTime(System.DateTime.Now.ToString(), dtFormat))
                {
                    entity.status = "N";
                }

                //处理NHI逻辑
                AddCustPrice(entity, saveModel);

                //1、資料未存在相同資料，正常新增数据，不处理
                //2、存在相同資料








                //1、如果没有结束日期大于新增的startdate日期，则取最小日期的数据，把end_date=新增startdate-1，
                //2、也没有未来价格
                //3、其他数据继续走modify逻辑
                //4、如果前数据有效数据，则不处理最小日期

                //最新计算方法
                /*
                 1、当前界面记录为无效数据，则接end_date最小日期且end_date>界面的start_date,create_date升序，，end_date=界面的start_date-1,再走modify2方法
                 2、当前界面记录为有效数据，则接end_date最小日期且end_date>界面的start_date，create_date升序，end_date=界面的start_date-1,再走modify2方法
                 3、当前界面记录为未来数据，则接end_date最大日期，create_date升序，end_date=界面的start_date-1,不走modify2方法
                 */
                // List<Viat_app_cust_price> priceList = getPriceEndDateLessStartDate(entity.pricegroup_dbid.ToString(), entity.prod_dbid.ToString(), entity.start_date, entity.end_date);
                ProcessPriceData(entity, saveModel);

               
            }

            base.CustomBatchProcessEntity(saveModel);
            return webResponse.OK();
        }

        /// <summary>
        /// 处理价格方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveModel"></param>
        private void ProcessPriceData(Viat_app_cust_price entity, SaveModel saveModel)
        {

            if (entity.start_date < System.DateTime.Now)
            {
                //不是未来价格数据
                Viat_app_cust_price entityPrice = getPrice(entity.pricegroup_dbid.ToString(), entity.prod_dbid.ToString(), entity.start_date, entity.custprice_dbid.ToString());
                if (entityPrice != null)
                {
                    entityPrice.end_date = entity.start_date.AddDays(-1);
                    if (entityPrice.start_date > entityPrice.end_date)
                    {
                        entityPrice.start_date = entityPrice.end_date;
                    }
                    if (entityPrice.end_date < DateTime.Now)
                    {
                        entityPrice.status = "N";
                    }

                    //更新price数据
                    Dictionary<string, object> dicPrice = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entityPrice));
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_app_cust_price);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dicPrice };
                    saveModel.DetailListData.Add(dataResult);
                }

                //取得过斯价格
                List<Viat_app_cust_price> expirePrice = getExpirePrice(entity.pricegroup_dbid.ToString(), entity.prod_dbid.ToString(), entity.start_date, entity.custprice_dbid.ToString());
                ModifyOldCustPrice(entity, expirePrice, saveModel);
            }
            else
            {
                //未来价格数据
                //处理目前最大的一条数据
                Viat_app_cust_price maxEndDatePrice = getMaxEndDataPrice(entity.pricegroup_dbid.ToString(), entity.prod_dbid.ToString(), entity.custprice_dbid.ToString());
                if (maxEndDatePrice != null)
                {
                    maxEndDatePrice.end_date = entity.start_date.AddDays(-1);
                    if (maxEndDatePrice.start_date > maxEndDatePrice.end_date)
                    {
                        maxEndDatePrice.start_date = maxEndDatePrice.end_date;
                    }
                    if (maxEndDatePrice.end_date < DateTime.Now)
                    {
                        maxEndDatePrice.status = "N";
                    }
                    //更新price数据
                    Dictionary<string, object> dicMaxEndPrice = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(maxEndDatePrice));
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_app_cust_price);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dicMaxEndPrice };
                    saveModel.DetailListData.Add(dataResult);
                }
            }
        }




        /// <summary>
        /// 取得需要处理的第一条数据
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private Viat_app_cust_price getPrice(string sPriceGroupDBID, string sProdDBID, DateTime dStartDate, string sGuiD)
        {
            string sSql = "select top(1) *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid " +
                " and custprice_dbid <> '" + sGuiD + "'" +
                " and end_date >'" + dStartDate + "' ORDER BY end_date,created_date ";
            Viat_app_cust_price entiryrice = _repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            return entiryrice;
        }

        /// <summary>
        /// 取得需要处理的第一条数据 最大end_date
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private Viat_app_cust_price getMaxEndDataPrice(string sPriceGroupDBID, string sProdDBID, string sGuiD)
        {
            string sSql = "select top(1) *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid " +
               " and custprice_dbid <> '" + sGuiD + "'" +
                " ORDER BY end_date desc";
            Viat_app_cust_price entiryrice = _repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            return entiryrice;
        }

        /// <summary>
        /// 取得进期价格的记录
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private List<Viat_app_cust_price> getOldPrice(string sPriceGroupDBID, string sProdDBID)
        {
            string sSql = "select *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid " +
                "AND end_date <= CONVERT(Date, GETDATE())" +
                " ORDER BY end_date DESC";
            List<Viat_app_cust_price> entiryOldPriceLst = _repository.DapperContext.QueryList<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            return entiryOldPriceLst;
        }


        /// <summary>
        /// 取得当前价格的记录
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private Viat_app_cust_price getCurrentPrice(string sPriceGroupDBID, string sProdDBID)
        {
            string sSql = "select TOP(1) *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid " +
                "AND start_date <= CONVERT(Date, GETDATE()) AND end_date >= CONVERT(Date, GETDATE()) ORDER BY end_date DESC";
            Viat_app_cust_price entiryCustPrice = _repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            return entiryCustPrice;
        }

        /// <summary>
        /// 取得未来价格的记录
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private Viat_app_cust_price getFuturePrice(string sPriceGroupDBID, string sProdDBID)
        {
            string sSql = "select TOP(1) *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid " +
                "AND start_date > CONVERT(Date, GETDATE()) ORDER BY end_date ";
            Viat_app_cust_price entiryFuture = _repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            return entiryFuture;
        }

        /*
                /// <summary>
                ///  是否都小于新增的startData
                /// 取得目前单价结束日期有大于新增的startdata数据
                /// </summary>
                /// <param name="sPriceGroupDBID"></param>
                /// <param name="sProdDBID"></param>
                /// <returns></returns>
                private List<Viat_app_cust_price> getPrice(string sPriceGroupDBID, string sProdDBID, DateTime dStartDate)
                {
                    string sSql = "select *  from viat_app_cust_price where    pricegroup_dbid='" + sPriceGroupDBID + "' and prod_dbid='" + sProdDBID + "' " +
                      // "AND start_date > '" + dStartDate + "'" +
                        " ORDER BY end_date DESC";
                    List<Viat_app_cust_price> entiryPriceLst = _repository.DapperContext.QueryList<Viat_app_cust_price>(sSql, null);

                    return entiryPriceLst;
                }*/


        /// <summary>
        ///  是否都小于新增的startData
        /// 取得目前单价结束日期有大于新增的startdata数据,并且数据库记录开始日期小于系统日期，保证不是未来价格
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>
        private List<Viat_app_cust_price> getPriceEndDateLessStartDate(string sPriceGroupDBID, string sProdDBID, DateTime dStartDate, DateTime dEndData)
        {
            string sSql = "select *  from viat_app_cust_price where    pricegroup_dbid='" + sPriceGroupDBID + "' and prod_dbid='" + sProdDBID + "' " +
                "AND  start_date <'" + dStartDate + "' and end_Date > '" + dStartDate + "'  and end_date<'" + dEndData + "'" +
                " ORDER BY end_date DESC";
            List<Viat_app_cust_price> entiryPriceLst = _repository.DapperContext.QueryList<Viat_app_cust_price>(sSql, null);

            return entiryPriceLst;
        }

        /// <summary>
        /// 找出(無效) and (end_date > 新增資料start_date) 的資料
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns>
        private List<Viat_app_cust_price> getExpirePrice(string sPriceGroupDBID, string sProdDBID, DateTime dStartDate, string sGuiD)
        {
            string sSql = "select *  from viat_app_cust_price where   pricegroup_dbid='" + sPriceGroupDBID + "' and prod_dbid='" + sProdDBID + "' " +
                "AND end_date > '" + dStartDate + "'" +
                " and custprice_dbid <> '" + sGuiD + "'" +
                " ORDER BY end_date DESC";
            List<Viat_app_cust_price> entiryExpirePriceLst = _repository.DapperContext.QueryList<Viat_app_cust_price>(sSql, null);

            return entiryExpirePriceLst;
        }
        /// <summary>
        /// 保存价格新增数据
        /// </summary>
        private void AddCustPrice(Viat_app_cust_price entity, SaveModel saveModel)
        {
            //处理NHI
            ProcessNHI(entity, saveModel);

            //增加price数据
            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entity));
            SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
            dataResult.optionType = SaveModel.MainOptionType.add;
            dataResult.detailType = typeof(Viat_app_cust_price);
            dataResult.DetailData = new List<Dictionary<string, object>> { dic };
            saveModel.DetailListData.Add(dataResult);

        }

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
        /// 处理过期数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveModel"></param>
        private void ModifyOldCustPrice(Viat_app_cust_price entity, List<Viat_app_cust_price> expirePriceList, SaveModel saveModel)
        {
            foreach (Viat_app_cust_price expirePrice in expirePriceList)
            {

                //如果第一条数据已处理，则跳过
                bool bFind = false;
                foreach (SaveModel.DetailListDataResult dResult in saveModel?.DetailListData)
                {
                    if (dResult.detailType == typeof(Viat_app_cust_price))
                    {

                        foreach (Dictionary<string, object> dicResult in dResult?.DetailData)
                            if (dicResult["custprice_dbid"].ToString() == expirePrice.custprice_dbid.ToString())
                            {
                                //第一条已处理
                                bFind = true;
                                break;
                            }
                        if (bFind == true)
                        {
                            break;
                        }
                    }
                }
                if (bFind == true)
                {
                    continue;
                }

                string old_start_date = expirePrice.start_date.ToString("yyyy-MM-dd");
                if (expirePrice.start_date > entity.start_date)
                {
                    //进期数据的日期比界面日期还大
                    expirePrice.org_start_date = expirePrice.start_date;
                    expirePrice.start_date = entity.start_date;
                }
                expirePrice.org_end_date = expirePrice.end_date;
                expirePrice.end_date = entity.start_date.AddDays(-1);

                if (expirePrice.end_date < expirePrice.start_date)
                {
                    expirePrice.end_date = expirePrice.start_date;
                }

                if ((expirePrice.org_start_date != null && expirePrice.start_date != expirePrice.org_start_date || expirePrice.org_end_date.Value.Year != 2099) && (expirePrice.org_end_date != expirePrice.end_date))
                {
                    expirePrice.remarks += entity.remarks  + " 原起迄日" + old_start_date + " ~ " + expirePrice.org_end_date.ToString("yyyy/mm/dd") + "  " + expirePrice.remarks;
                }

                if (expirePrice.end_date < DateTime.Now)
                {
                    expirePrice.status = "N";
                }
                //更新数据
                Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(expirePrice));
                SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                dataResult.optionType = SaveModel.MainOptionType.update;
                dataResult.detailType = typeof(Viat_app_cust_price);
                dataResult.DetailData = new List<Dictionary<string, object>> { dic };
                saveModel.DetailListData.Add(dataResult);
            }
        }

        /// <summary>
        /// 处理NHI数据
        /// </summary>
        private void ProcessNHI(Viat_app_cust_price entity, SaveModel saveModel)
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
                string sProd = @"SELECT TOP(1) *
                                    FROM viat_com_prod 
                                    WHERE prod_dbid = '" + entity.prod_dbid + "'";
                Viat_com_prod entityProd = _repository.DapperContext.QueryFirst<Viat_com_prod>(sProd, null);
                if (entityProd != null)
                {
                    entityProd.nhi_id = entity.nhi_id;
                    entityProd.nhi_price = entity.nhi_price;
                }

                Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(entityProd));
                SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                dataResult.optionType = SaveModel.MainOptionType.update;
                dataResult.detailType = typeof(Viat_com_prod);
                dataResult.DetailData = new List<Dictionary<string, object>> { dic };
                saveModel.DetailListData.Add(dataResult);
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
                DateTime dSysDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"), dtFormat);
                DateTime dPageDate = Convert.ToDateTime(sStartDate, dtFormat);
                if (CheckFuturePrice(sPriceGroupDBID, sProdDBID, sStartDate) == true)
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
        private bool CheckFuturePrice(string sPriceGroupDBID, string sProdDBID, string sStartDate)
        {
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            //当前系统日期
            DateTime dSysDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"), dtFormat);
            DateTime dPageDate = Convert.ToDateTime(sStartDate, dtFormat);
            if (dPageDate < dSysDate)
            {
                return false;
            }

            string sSql = "select TOP(1) *  from viat_app_cust_price where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid AND status = 'Y'ORDER BY end_date DESC";
            Viat_app_cust_price entiryCustPrice = _repository.DapperContext.QueryFirst<Viat_app_cust_price>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID });

            if (entiryCustPrice == null)
            {
                return false;
            }
            //数据库结束日期最大记录的开始日期
            DateTime dStartDate = Convert.ToDateTime(entiryCustPrice.start_date.ToString("yyyy-MM-dd"), dtFormat);

            if (dPageDate > dSysDate && dStartDate > dSysDate)
            {
                return true;
            }

            return false;
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
            string sRowsData = dicData["rows"].ToString();
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            DateTime dEndData = Convert.ToDateTime(dicData["invalid_date"].ToString(), dtFormat);
            string sRemarks = dicData["remark"].ToString();
            string isAll = dicData["isAll"].ToString();

            if (sSelectType == "0")
            {
                string sPriceGroupDBID = dicData["pricegroup_dbid"].ToString();
                string sProdDBID = dicData["prod_dbid"].ToString();
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
                        price.status = "N";
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
                string sSourceType = "";
                
                string sProdDBID = dicData["prod_dbid"].ToString();
                if (sSourceType == "1")
                {
                    string sPriceDetailDBID = dicData["pricedetail_dbid"].ToString();
                    //detail                  
                    //取得主界面值
                    List<Viat_app_cust_price_detail> entityList = new List<Viat_app_cust_price_detail>();
                    if (isAll == "0")
                    {
                        //取得列表勾选的值
                        entityList = JsonConvert.DeserializeObject<List<Viat_app_cust_price_detail>>(sRowsData);
                    }
                    else
                    {
                        //全无效
                        entityList = getAllPriceDetailByGroupAndProd(sPriceDetailDBID, sProdDBID);
                    }
                    if (entityList != null && entityList.Count > 0)
                    {
                        foreach (Viat_app_cust_price_detail price in entityList)
                        {
                            price.status = "N";
                            price.end_date = dEndData;
                            price.remarks = sRemarks;

                            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(price));
                            SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                            dataResult.optionType = SaveModel.MainOptionType.update;
                            dataResult.detailType = typeof(Viat_app_cust_price_detail);
                            dataResult.DetailData = new List<Dictionary<string, object>> { dic };
                            saveModel.DetailListData.Add(dataResult);
                        }
                    }
                }
                else if(sSourceType == "2")
                {
                    //cust price
                    string sCustGroupDBID = dicData["custgroup_dbid"].ToString();
                    //取得主界面值
                    List<Viat_app_cust_group> entityList = new List<Viat_app_cust_group>();
                    if (isAll == "0")
                    {
                        //取得列表勾选的值
                        entityList = JsonConvert.DeserializeObject<List<Viat_app_cust_group>>(sRowsData);
                    }
                    else
                    {
                        //全无效
                        entityList = getAllCustGroupByGroupAndProd(sCustGroupDBID, sProdDBID);
                    }
                    if (entityList != null && entityList.Count > 0)
                    {
                        foreach (Viat_app_cust_group price in entityList)
                        {
                            price.status = "N";
                            price.end_date = dEndData;
                            price.remarks = sRemarks;

                            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(price));
                            SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                            dataResult.optionType = SaveModel.MainOptionType.update;
                            dataResult.detailType = typeof(Viat_app_cust_group);
                            dataResult.DetailData = new List<Dictionary<string, object>> { dic };
                            saveModel.DetailListData.Add(dataResult);
                        }
                    }
                }

            }
            else if (sSelectType == "2")
            {
                //by prod
                string sProdDBID = dicData["prod_dbid"].ToString();
                Viat_com_prod prod = getProdByProdID(sProdDBID);
                if(prod != null)
                {

                    //viat_app_cust_group
                     List<Viat_app_cust_group> custGroupPriceList = getAllCustGroupByProd(sProdDBID);
                    if (custGroupPriceList != null)
                    {
                        foreach (Viat_app_cust_group groupPrice in custGroupPriceList)
                        {
                            groupPrice.end_date = dEndData;
                            groupPrice.status = "N";
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
                    if(groupPriceList != null)
                    {
                        foreach(Viat_app_cust_price groupPrice in groupPriceList)
                        {
                            groupPrice.end_date = dEndData;
                            groupPrice.status = "N";
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
                    List<Viat_app_cust_price_detail>  custPriceList = getAllCustPriceByProd(sProdDBID);
                    if (custPriceList != null)
                    {
                        foreach (Viat_app_cust_price_detail groupPrice in custPriceList)
                        {
                            groupPrice.end_date = dEndData;
                            groupPrice.status = "N";
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

            }

            base.CustomBatchProcessEntity(saveModel);
            return webResponse.OK();

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

        private List<Viat_app_cust_price_detail> getAllPriceDetailByGroupAndProd(string sPriceDetailDBID, string sProdDBID)
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
            string sSql = @"select * from Viat_app_cust_price where 1=1 and status = 'Y'";
            if (string.IsNullOrEmpty(sProdDBID) == false)
            {
                sSql += " and prod_dbid='" + sProdDBID + "'";
            }

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

        private List<Viat_app_cust_group> getAllCustGroupByProd(string sProdDBID)
        {
            string sSql = @"select * from viat_app_cust_group where 1=1 and status = 'Y'";
            if (string.IsNullOrEmpty(sProdDBID) == false)
            {
                sSql += " and prod_dbid='" + sProdDBID + "'";
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
            DownLoadTemplateColumns = x => new { x.group_id, x.prod_id, x.nhi_price,x.net_price,x.min_qty,x.start_date,x.end_date,x.remarks };
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

        public override WebResponseContent Import(List<IFormFile> files)
        {
            //如果下載模板指定了DownLoadTemplate,則在Import方法必須也要指定,並且字段要和下載模板裡指定的一致
            DownLoadTemplateColumns = x => new { x.group_id, x.prod_id, x.nhi_price, x.net_price, x.min_qty, x.start_date, x.end_date, x.remarks };
            return base.Import(files);
        }

        /*public override WebResponseContent Export(PageDataOptions pageData)
        {
            ExportColumns = x => new {  };
            return base.Export(pageData);
        }*/
    }
}
