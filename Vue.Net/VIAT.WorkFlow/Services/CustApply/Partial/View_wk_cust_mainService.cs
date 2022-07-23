/*
 *所有关于View_wk_cust_main类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_wk_cust_mainService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.WorkFlow.IServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace VIAT.WorkFlow.Services
{
    public partial class View_wk_cust_mainService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_wk_cust_mainRepository _repository;//访问数据库
        private readonly IViat_wk_custService _viat_wk_custService;
        private readonly IViat_wk_custRepository _viat_wk_custRepository;


        [ActivatorUtilitiesConstructor]
        public View_wk_cust_mainService(
            IView_wk_cust_mainRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_wk_custService viat_wk_custService,
            IViat_wk_custRepository viat_wk_custRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_wk_custService = viat_wk_custService;
            _viat_wk_custRepository = viat_wk_custRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webRespose = new WebResponseContent();

        public string getCustCode()
        {
            string rule = "C" + $"D{DateTime.Now.GetHashCode()}";
            return rule.Substring(0, 10);
        }

        /// <summary>
        /// add
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            addWKMaster(saveDataModel,"00");

            
            return base.CustomBatchProcessEntity(saveDataModel);          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>

       public override WebResponseContent Update(SaveModel saveModel)
        {

            updateWKMaster(saveModel,"00");
            return base.CustomBatchProcessEntity(saveModel);
        }
        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            List<string> delLst = new List<string>();
            foreach(string bidmast_dbid in keys)
            {
                string sDelWKMaster = "delete from viat_wk_master where bidmast_dbid='" + bidmast_dbid + "'";
                string sDelWKCust = "delete from viat_wk_cust where bidmast_dbid='" + bidmast_dbid + "'";
                delLst.Add(sDelWKMaster);
                delLst.Add(sDelWKCust);
            }

            return base.CustomExcuteBySql(delLst, "");
        }

        /// <summary>
        /// 提交邏輯
        /// </summary>
        /// <returns></returns>
        public WebResponseContent Submit([FromBody] object saveModelData)
        {
           
            List<Dictionary<string,object>> lst = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(saveModelData.ToString());
            if(lst == null || lst.Count==0)
            {
                return webRespose.Error("no data");
            }
            SaveModel saveModel = new SaveModel();
            saveModel.MainData = lst[0];

            updateWKMaster(saveModel,"03");
            processCustTransferAndDelivery(saveModel);
            
            return base.CustomBatchProcessEntity(saveModel);
        }

        /// <summary>
        /// addsubmit
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public WebResponseContent addSubmit([FromBody]  object saveModelData)
        {
            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(saveModelData.ToString());
            
            SaveModel saveModel = new SaveModel();
            saveModel.MainData = dic;

            //判断是否为新增还是编辑
            string sbidmast_dbid =  saveModel.MainData["bidmast_dbid"].ToString();
            if(string.IsNullOrEmpty(sbidmast_dbid) == false)
            {
                updateWKMaster(saveModel,"03");
            }
            else
            {
                addWKMaster(saveModel,"03");
            }

            processCustTransferAndDelivery(saveModel);


            return base.CustomBatchProcessEntity(saveModel);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public WebResponseContent processBack(string[] bidmast_dbidLst)
        {

            SaveModel saveModel = new SaveModel();            
            SaveModel.DetailListDataResult backResult = new SaveModel.DetailListDataResult();
            saveModel.DetailListData.Add(backResult);
            foreach (string bidmast_dbid in bidmast_dbidLst)
            {
                Viat_wk_master master = Viat_wk_masterService.Instance.getMasterByDBID(bidmast_dbid);
                master.status = "02";

                backResult.optionType = SaveModel.MainOptionType.update;
                backResult.detailType = typeof(Viat_wk_master);
                backResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(master)));                
            }

            return base.CustomBatchProcessEntity(saveModel);
        }

        #region 

        /// <summary>
        /// add master
        /// </summary>
        /// <param name="saveModel"></param>
        private void addWKMaster(SaveModel saveDataModel, string sStatus)
        {
            string code = getCustCode();
            string sBinNo = Viat_wk_masterService.Instance.getBidNO();
            Guid bidMastDBID = Guid.NewGuid();
            Guid wkCustDBID = Guid.NewGuid();
            saveDataModel.MainData["wkcust_dbid"] = wkCustDBID;
            saveDataModel.MainData["bidmast_dbid"] = bidMastDBID;
            saveDataModel.MainData["bid_no"] = sBinNo;
            saveDataModel.MainData["status"] = sStatus;
            saveDataModel.MainData["start_date"] = getFormatYYYYMMDD(DateTime.Now.ToString("yyyy-MM-dd"));
            if (saveDataModel.MainData.GetValue("apply_type")?.ToString() == "01")
            {
                saveDataModel.MainData["cust_id"] = code;
            }

            //增加master数据
            SaveModel.DetailListDataResult masterResult = new SaveModel.DetailListDataResult();
            masterResult.DetailData.Add(saveDataModel.MainData);
            masterResult.optionType = SaveModel.MainOptionType.add;
            masterResult.detailType = typeof(Viat_wk_master);
            saveDataModel.DetailListData.Add(masterResult);

            //增加cust
            Viat_wk_cust cust = JsonConvert.DeserializeObject<Viat_wk_cust>(JsonConvert.SerializeObject(saveDataModel.MainData));
            cust.wkcust_dbid = wkCustDBID;
            cust.bidmast_dbid = bidMastDBID;
            SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
            custResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(cust)));
            custResult.optionType = SaveModel.MainOptionType.add;
            custResult.detailType = typeof(Viat_wk_cust);
            saveDataModel.DetailListData.Add(custResult);
        }

        /// <summary>
        /// add master
        /// </summary>
        /// <param name="saveModel"></param>
        private void updateWKMaster(SaveModel saveModel,string sStatus)
        {
            //根據主鍵取得master數據,只更新狀態
            string sbidmast_dbid = saveModel.MainData["bidmast_dbid"].ToString();
            string sApplyType = saveModel.MainData["apply_type"].ToString();
            Viat_wk_master master = Viat_wk_masterService.Instance.getMasterByDBID(sbidmast_dbid);             
            master.apply_type = sApplyType;
            master.status = sStatus;
            //修改master数据
            SaveModel.DetailListDataResult masterResult = new SaveModel.DetailListDataResult();
            masterResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(master)));
            masterResult.optionType = SaveModel.MainOptionType.update;
            masterResult.detailType = typeof(Viat_wk_master);
            saveModel.DetailListData.Add(masterResult);

            //更新cust表數據
            Viat_wk_cust cust = JsonConvert.DeserializeObject<Viat_wk_cust>(JsonConvert.SerializeObject(saveModel.MainData));
            cust.bidmast_dbid = master.bidmast_dbid;
            SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
            custResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(cust)));
            custResult.optionType = SaveModel.MainOptionType.update;
            custResult.detailType = typeof(Viat_wk_cust);
            saveModel.DetailListData.Add(custResult);
        }

  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveModel"></param>
        private void processCustTransferAndDelivery(SaveModel saveModel)
        {

            //把cust記錄寫入transfer, delivery transfer
            Viat_app_cust_transfer transfer = JsonConvert.DeserializeObject<Viat_app_cust_transfer>(JsonConvert.SerializeObject(saveModel.MainData));
            transfer.custtransfer_dbid = System.Guid.NewGuid();
            transfer.state = "0";
            transfer.status = "Y";
            transfer.bid_no = transfer.bid_no.Trim();
            SaveModel.DetailListDataResult transferResult = new SaveModel.DetailListDataResult();
            transferResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(transfer)));
            transferResult.optionType = SaveModel.MainOptionType.add;
            transferResult.detailType = typeof(Viat_app_cust_transfer);
            saveModel.DetailListData.Add(transferResult);

            // 把cust記錄寫入 delivery transfer
            Viat_app_cust_delivery_transfer delivery = JsonConvert.DeserializeObject<Viat_app_cust_delivery_transfer>(JsonConvert.SerializeObject(saveModel.MainData));
            delivery.custtransfer_dbid = transfer.custtransfer_dbid;
            delivery.custdeltransfer_dbid = System.Guid.NewGuid();            
            SaveModel.DetailListDataResult deliveryResult = new SaveModel.DetailListDataResult();
            deliveryResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(delivery)));
            deliveryResult.optionType = SaveModel.MainOptionType.add;
            deliveryResult.detailType = typeof(Viat_app_cust_delivery_transfer);
            saveModel.DetailListData.Add(deliveryResult);
        }

        

        #endregion

    }
}
