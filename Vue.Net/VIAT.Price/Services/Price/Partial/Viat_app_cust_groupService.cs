/*
 *所有关于Viat_app_cust_group类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_app_cust_groupService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Globalization;
using System;

namespace VIAT.Price.Services
{
    public partial class Viat_app_cust_groupService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_app_cust_groupRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_app_cust_groupService(
            IViat_app_cust_groupRepository dbRepository,
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
        /// 取得group信息
        /// </summary>
        /// <param name="sCustDBID"></param>
        /// <returns></returns>
        public Viat_app_cust_group getCustGroupByCustDBID(string sCustDBID)
        {
            string sSql = " select top(1) * from viat_app_cust_group where cust_dbid = '"+ sCustDBID+"' order by created_date desc";
            return _repository.DapperContext.QueryFirst<Viat_app_cust_group>(sSql, null);
        }

        /// <summary>
        /// 取得group信息
        /// </summary>
        /// <param name="sCustDBID"></param>
        /// <returns></returns>
        public Viat_app_cust_price_group getCustGroupIDAndANmeByCustDBID(string sCustDBID)
        {
            string sSql = @" select top(1) pg.* from viat_app_cust_price_group pg
                            inner join viat_app_cust_group cg on pg.pricegroup_dbid = cg.pricegroup_dbid
                            where pg.status = 'Y' and cg.status = 'Y' and  cg.cust_dbid='" + sCustDBID + @"' 
                            order by created_date desc ";
            return _repository.DapperContext.QueryFirst<Viat_app_cust_price_group>(sSql, null);
        }
        public void processData(SaveModel saveModel)
        {
            foreach (Dictionary<string, object> dic in saveModel.DetailsData)
            {
                if (dic.ContainsKey("custgroup_dbid") == false)
                {
                    dic.Add("custgroup_dbid", "");
                }
                Viat_app_cust_group entity = JsonConvert.DeserializeObject<Viat_app_cust_group>(JsonConvert.SerializeObject(dic));

                //1.1 資料未存在相同資料 → AddCustGroup()
                if (!IsExistsSameData(entity))
                {
                    AddCustGroupData(entity, saveModel);
                    continue;
                }
                //1.2 存在相同資料,则处理其他数据时间
                //2.1	無現行價格資料 若 未來價格有資料，需變更新增數據結束日，結束日=未來價格起始日-1天 AddCustGroup()
                Viat_app_cust_group currentGroupEntity = getCurrentGroupData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString(),entity.cust_dbid?.ToString());
                if (currentGroupEntity == null)
                {
                    //无现行价格
                    //检查是否有未來價格有資料
                    Viat_app_cust_group futureGroupEntity = getFutureGroupData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString(), entity.cust_dbid?.ToString());
                    if (futureGroupEntity != null)
                    {
                        DateTime dt = (DateTime)futureGroupEntity.start_date;
                        entity.end_date = dt.AddDays(-1);
                    }
                    //处理后，直接处理下一条
                    AddCustGroupData(entity, saveModel);
                    continue;
                }
                //2.2	有現行價格資料
                //2.2.1	找出價格資料內，符合Group+Prod價格資料 且 結束日 > 新增數據起始日 且 狀態為無效的資料(多筆)
                List<Viat_app_cust_group> invalidGroupData = getInValidGroupData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString(),entity.cust_dbid?.ToString(), (DateTime)entity.start_date);
                if (invalidGroupData != null && invalidGroupData.Count > 0)
                {
                    ProcessGroupData(entity, invalidGroupData, saveModel);
                }
                //2.2.2	判斷過去價格資料
                List<Viat_app_cust_group> oldGroupData = getOldGroupData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString(),entity.cust_dbid?.ToString());
                if (oldGroupData != null && oldGroupData.Count > 0)
                {
                    ProcessGroupData(entity, oldGroupData, saveModel);
                }
                //2.2.3	判斷未來價格資料
                Viat_app_cust_group futureGroupData = getFutureGroupData(entity.pricegroup_dbid?.ToString(), entity.prod_dbid?.ToString(),entity.cust_dbid?.ToString());
                if (futureGroupData != null)
                {
                    ProcessGroupData(entity, new List<Viat_app_cust_group> { futureGroupData }, saveModel);
                }
                //2.2.4   判斷現行價格起始日
                if (getFormatYYYYMMDD(currentGroupEntity.start_date) <= getFormatYYYYMMDD(entity.start_date))
                {
                    //現行價格起始日<= 新增數據起始日 現行價格起始日<= 新增數據起始日-1
                    currentGroupEntity.end_date = ((DateTime)entity.start_date).AddDays(-1);
                    if (getFormatYYYYMMDD(DateTime.Now) > getFormatYYYYMMDD(currentGroupEntity.end_date))
                    {
                        currentGroupEntity.status = "N";
                    }
                    else
                    {
                        currentGroupEntity.status = "Y";
                    }
                }
                /*若 現行價格結束日< 現行價格起始日
                     現行價格狀態 = 無效
                     現行價格結束日= 現行價格起始日
                  更新價格資料檔
                */
                if (getFormatYYYYMMDD(currentGroupEntity.end_date) < getFormatYYYYMMDD(currentGroupEntity.start_date))
                {
                    currentGroupEntity.status = "N";
                    currentGroupEntity.end_date = currentGroupEntity.start_date;
                }

                //現行價格起始日> 新增數據起始日
                if (getFormatYYYYMMDD(currentGroupEntity.start_date) > getFormatYYYYMMDD(entity.start_date))
                {
                    ProcessGroupData(entity, new List<Viat_app_cust_group> { currentGroupEntity }, saveModel);
                }
                //如果没有特殊情况，新增本身资料
                //处理后，直接处理下一条
                AddCustGroupData(entity, saveModel);
                //更新价格
                if (isExistData(currentGroupEntity, saveModel) == false)
                {
                    Dictionary<string, object> dicCurrent = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(currentGroupEntity));
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_app_cust_group);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dicCurrent };
                    saveModel.DetailListData.Add(dataResult);
                }
            }
        }
        /// <summary>
        ///  資料未存在相同資料
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool IsExistsSameData(Viat_app_cust_group entity)
        {
            string sSql = "select count(*) from Viat_app_cust_group where pricegroup_dbid=@pricegroup_dbid and cust_dbid = @cust_dbid and prod_dbid=@prod_dbid";
            object obj = _repository.DapperContext.ExecuteScalar(sSql, new { pricegroup_dbid = entity.pricegroup_dbid, prod_dbid = entity.prod_dbid,cust_dbid = entity.cust_dbid });

            return (((int)obj) == 0) ? false : true;
        }
        private void AddCustGroupData(Viat_app_cust_group entity, SaveModel saveModel)
        {
            entity.custgroup_dbid = System.Guid.NewGuid();
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
            dataResult.detailType = typeof(Viat_app_cust_group);
            dataResult.DetailData = new List<Dictionary<string, object>> { dic };
            saveModel.DetailListData.Add(dataResult);
        }
        /// <summary>
        /// 現行價格 = 系統日在起訖日期中(取最大結束日一筆)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private Viat_app_cust_group getCurrentGroupData(string sPriceGroupDBID, string sProdDBID,string custDBID)
        {
            string sSql = "select TOP(1) *  from Viat_app_cust_group where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid and cust_dbid = @cust_dbid " +
                "AND   start_date   <=  '" + getFormatYYYYMMDD(DateTime.Now) + "' AND  end_date >='" + getFormatYYYYMMDD(DateTime.Now) + "' ORDER BY end_date DESC";
            Viat_app_cust_group entiryCustPrice = _repository.DapperContext.QueryFirst<Viat_app_cust_group>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID, cust_dbid = custDBID });

            if (entiryCustPrice == null)
            {
                sSql = "select TOP(1) *  from Viat_app_cust_group where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid and cust_dbid = @cust_dbid ORDER BY end_date ";

                entiryCustPrice = _repository.DapperContext.QueryFirst<Viat_app_cust_group>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID, cust_dbid = custDBID });

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
        private Viat_app_cust_group getFutureGroupData(string sPriceGroupDBID, string sProdDBID,string custDBID)
        {
            string sSql = "select TOP(1) *  from Viat_app_cust_group where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid and cust_dbid = @cust_dbid " +
                "AND start_date > '" + getFormatYYYYMMDD(DateTime.Now) + "' ORDER BY end_date ";
            Viat_app_cust_group entiryFuture = _repository.DapperContext.QueryFirst<Viat_app_cust_group>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID, cust_dbid = custDBID });

            return entiryFuture;
        }
        /// <summary>
        /// 2.2.1	找出價格資料內，符合Group+Prod價格資料 且 結束日 > 新增數據起始日 且 狀態為無效的資料(多筆)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <returns></returns> 
        private List<Viat_app_cust_group> getInValidGroupData(string sPriceGroupDBID, string sProdDBID,string custDBID, DateTime dStartDate)
        {
            string sSql = "select *  from Viat_app_cust_group where   pricegroup_dbid='" + sPriceGroupDBID + "' and prod_dbid='" + sProdDBID + "' and cust_dbid = '" + custDBID + "' " +
                "   and status='N' " +
                "AND  end_date > '" + getFormatYYYYMMDD(dStartDate) + "'" +
                " ORDER BY end_date DESC";
            List<Viat_app_cust_group> entiryExpirePriceLst = _repository.DapperContext.QueryList<Viat_app_cust_group>(sSql, null);

            return entiryExpirePriceLst;
        }
        /// <summary>
        /// 处理价格方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveModel"></param>
        private void ProcessGroupData(Viat_app_cust_group currentEntity, List<Viat_app_cust_group> processEntityList, SaveModel saveModel)
        {

            if (processEntityList != null)
            {
                foreach (Viat_app_cust_group processEntity in processEntityList)
                {

                    if (isExistData(processEntity, saveModel) == true)
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
                    processEntity.end_date = ((DateTime)currentEntity.start_date).AddDays(-1);

                    //若 價格結束日 < 價格起始日 價格結束日 = 價格起始日
                    if (getFormatYYYYMMDD(processEntity.end_date) < getFormatYYYYMMDD(processEntity.start_date))
                    {
                        processEntity.end_date = processEntity.start_date;
                    }

                    //若 舊價格起始日<> 價格起始日 且 舊價格結束日<> 價格結束日, 需標記價格舊價格起始日及舊價格結束日及更新備註, 更新價格資枓檔
                    if ((dProcessStartData != null && getFormatYYYYMMDD(dProcessStartData) != getFormatYYYYMMDD(processEntity.start_date) || dProcessEndData.Year != 2099) &&
                         (getFormatYYYYMMDD(dProcessEndData) != getFormatYYYYMMDD(processEntity.end_date)))
                    {
                        processEntity.remarks = processEntity.remarks + " 原起迄日" + getFormatYYYYMMDD(dProcessStartData).ToString("yyyy-MM-dd") + " ~ " + getFormatYYYYMMDD(dProcessEndData).ToString("yyyy-MM-dd");
                        //processEntity.org_start_date = dProcessStartData;
                        //processEntity.org_end_date = dProcessEndData;
                    }

                    processEntity.status = "N";
                    //更新数据
                    Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(processEntity));
                    SaveModel.DetailListDataResult dataResult = new SaveModel.DetailListDataResult();
                    dataResult.optionType = SaveModel.MainOptionType.update;
                    dataResult.detailType = typeof(Viat_app_cust_group);
                    dataResult.DetailData = new List<Dictionary<string, object>> { dic };
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
        private bool isExistData(Viat_app_cust_group entity, SaveModel saveModel)
        {
            //如果数据已处理，则跳过，因为框架对于同一条更新，会报错

            foreach (SaveModel.DetailListDataResult dResult in saveModel?.DetailListData)
            {
                if (dResult.detailType == typeof(Viat_app_cust_group))
                {
                    foreach (Dictionary<string, object> dicResult in dResult?.DetailData)
                        if (dicResult["custgroup_dbid"].ToString() == entity.custgroup_dbid.ToString())
                        {
                            return true;
                        }
                }
            }

            return false;
        }
        /// <summary>
        /// 過去價格 = 結束日<系統日(多筆，以結束日降冪排序)
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <param name="sProdDBID"></param>
        /// <param name="sStartDate"></param>
        /// <returns></returns>
        private List<Viat_app_cust_group> getOldGroupData(string sPriceGroupDBID, string sProdDBID,string custDBID)
        {
            string sSql = "select *  from viat_app_cust_group where pricegroup_dbid=@pricegroup_dbid and prod_dbid=@prod_dbid and cust_dbid = @cust_dbid " +
                "AND  end_date  < '" + getFormatYYYYMMDD(DateTime.Now) + "' ORDER BY end_date DESC";
            List<Viat_app_cust_group> entiryOldPriceLst = _repository.DapperContext.QueryList<Viat_app_cust_group>(sSql, new { pricegroup_dbid = sPriceGroupDBID, prod_dbid = sProdDBID, cust_dbid = custDBID });

            return entiryOldPriceLst;
        }
    }
}
