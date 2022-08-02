/*
 *所有关于Viat_wk_contract_stretagy类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_wk_contract_stretagyService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using VIAT.WorkFlow.IServices;

namespace VIAT.WorkFlow.Services
{
    public partial class Viat_wk_contract_stretagyService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_wk_contract_stretagyRepository _repository;//访问数据库
        private readonly IView_wk_cont_stretagy_detailService _DetailService;

        [ActivatorUtilitiesConstructor]
        public Viat_wk_contract_stretagyService(
            IViat_wk_contract_stretagyRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IView_wk_cont_stretagy_detailService DetailService
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _DetailService = DetailService;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webResponse = new WebResponseContent();

        /// <summary>
        /// add
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            return processData(saveDataModel);
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            return processData(saveModel);
        }


        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public WebResponseContent processData(SaveModel saveDataModel)
        {
            //解析数据
            //处理表头
            SaveModel.DetailListDataResult headResult = new SaveModel.DetailListDataResult();
            string contstret_dbid = "";
 
            if(saveDataModel.MainData.ContainsKey("contstret_dbid")==false)
            {
                saveDataModel.MainData.Add("contstret_dbid", "");
            }
            #region 增加stretagy_id唯一判断
            string stretagy_id = saveDataModel.MainData["cont_stretagy_id"] != null ? saveDataModel.MainData["cont_stretagy_id"].ToString() : "";
            PageGridData<Viat_wk_contract_stretagy> detailGrid = new PageGridData<Viat_wk_contract_stretagy>();
            string sql = "select count(1) from Viat_wk_contract_stretagy where cont_stretagy_id = '"+ stretagy_id + "'";
            if (saveDataModel.MainData.ContainsKey("contstret_dbid"))
            {
                if (!string.IsNullOrEmpty(saveDataModel.MainData["contstret_dbid"].ToString()))
                {
                    sql += " and contstret_dbid <> '" + saveDataModel.MainData["contstret_dbid"].ToString() + "'";
                }
            }
            detailGrid.total = repository.DapperContext.ExecuteScalar(sql, null).ToInt();
            if (detailGrid.total > 0)
            {
                return webResponse.Error(stretagy_id + " Already Exists");
            }
            #endregion
            if (saveDataModel.MainData["contstret_dbid"] != null && string.IsNullOrEmpty(saveDataModel.MainData["contstret_dbid"].ToString()) == true)
            {
                saveDataModel.MainData["contstret_dbid"] = getDefaultGuid(typeof(Viat_wk_contract_stretagy));
            }
            if (saveDataModel.MainData["contstret_dbid"] != null && saveDataModel.MainData["contstret_dbid"].ToString() != getDefaultGuid(typeof(Viat_wk_contract_stretagy)))
            {
                //更新
                contstret_dbid = saveDataModel.MainData["contstret_dbid"].ToString();
                headResult.optionType = SaveModel.MainOptionType.update;
            }
            else
            {
                contstret_dbid = System.Guid.NewGuid().ToString();
                //新增
                headResult.optionType = SaveModel.MainOptionType.add;
                saveDataModel.MainData["contstret_dbid"] = contstret_dbid;
            }
            headResult.detailType = typeof(Viat_wk_contract_stretagy);
            //增加表头处理
            headResult.DetailData.Add(saveDataModel.MainData);
            saveDataModel.DetailListData.Add(headResult);

            //处理表体
            if (saveDataModel.DetailData != null && saveDataModel.DetailData.Count > 0)
            {
                //新增
                SaveModel.DetailListDataResult insertResult = new SaveModel.DetailListDataResult();
                insertResult.optionType = SaveModel.MainOptionType.add;
                insertResult.detailType = typeof(Viat_wk_cont_stretagy_detail);
                saveDataModel.DetailListData.Add(insertResult);
                SaveModel.DetailListDataResult updateResult = new SaveModel.DetailListDataResult();
                updateResult.optionType = SaveModel.MainOptionType.update;
                updateResult.detailType = typeof(Viat_wk_cont_stretagy_detail);
                saveDataModel.DetailListData.Add(updateResult);
                foreach (Dictionary<string, object> dic in saveDataModel.DetailData)
                {
                    Dictionary<string, object> dicTmp = dic;
                    if (dicTmp["key"]?.ToString() == "table1RowData")
                    {
                        string sData = dicTmp["value"]?.ToString();
                        //新增
                        List<Dictionary<string,object>> dicList = base.CalcSameEntiryProperties(typeof(Viat_wk_cont_stretagy_detail), sData);
       
                        foreach(Dictionary<string, object> deatil in dicList)
                        {
                            if(deatil["contstretail_dbid"] != null && string.IsNullOrEmpty(deatil["contstretail_dbid"].ToString())==false)
                            {
                                //更新
                                updateResult.DetailData.Add(deatil);
                            }
                            else
                            {
                                //新增
                                deatil["contstretail_dbid"] = System.Guid.NewGuid();
                                deatil["contstret_dbid"] = contstret_dbid;
                                insertResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(deatil)));

                            }
                        }
                    }                    
                    else if (dicTmp["key"]?.ToString() == "delTable1RowData")
                    {
                        string sDeleteData = dicTmp["value"]?.ToString();
                        //删除
                        SaveModel.DetailListDataResult deleteResult = new SaveModel.DetailListDataResult();
                        deleteResult.optionType = SaveModel.MainOptionType.delete;
                        deleteResult.detailType = typeof(Viat_wk_cont_stretagy_detail);
                        saveDataModel.DetailListData.Add(deleteResult);
                        List<Viat_wk_cont_stretagy_detail> deleteList = JsonConvert.DeserializeObject<List<Viat_wk_cont_stretagy_detail>>(sDeleteData);
                        foreach(Viat_wk_cont_stretagy_detail detail in deleteList)
                        {
                            deleteResult.detailDelKeys.Add(detail.contstretail_dbid);
                        }
                    }
                }
            }
            base.CustomBatchProcessEntity(saveDataModel);
            webResponse.Code = "-1";
            return webResponse.OK();
        }

        /// <summary>
        /// 下载模板(导入时弹出框中的下载模板)(2020.05.07)
        /// </summary>
        /// <returns></returns>
        //public override WebResponseContent DownLoadTemplate()
        //{
        //    //指定导出模板的字段,如果不设置DownLoadTemplateColumns，默认导出查所有页面上能看到的列(2020.05.07)
        //    DownLoadTemplateColumns = x => new { x.cont_stretagy_type, x.cont_stretagy_id, x.cont_stretagy_name, x.amount,x.status };
        //    return base.DownLoadTemplate();
        //}

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public override WebResponseContent Import(List<IFormFile> files)
        {
            return Viat_wk_cont_stretagy_detailService.Instance.Import(files);
        }
    }
}
