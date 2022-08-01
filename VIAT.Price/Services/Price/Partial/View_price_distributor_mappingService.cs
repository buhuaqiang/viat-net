/*
 *所有关于View_price_distributor_mapping类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_price_distributor_mappingService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Basic.Services;
namespace VIAT.Price.Services
{
    public partial class View_price_distributor_mappingService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_price_distributor_mappingRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();

        private readonly IViat_app_dist_mappingService _viat_app_dist_mappingService;
        private readonly IViat_app_dist_mappingRepository _viat_app_dist_mappingRepository;

        [ActivatorUtilitiesConstructor]
        public View_price_distributor_mappingService(
            IView_price_distributor_mappingRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_dist_mappingService viat_app_dist_mappingService,
            IViat_app_dist_mappingRepository viat_app_dist_mappingRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
            _viat_app_dist_mappingService = viat_app_dist_mappingService;
            _viat_app_dist_mappingRepository = viat_app_dist_mappingRepository;
        }
        public override WebResponseContent Add(SaveModel saveDataModel)
        {

            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(saveDataModel.MainData));
            if (saveDataModel.MainData.ContainsKey("distmapping_dbid") == true)
            {
                saveDataModel.MainData.Remove("distmapping_dbid");
            }
            
            Viat_app_dist_mapping dist = JsonConvert.DeserializeObject<Viat_app_dist_mapping>(JsonConvert.SerializeObject(saveDataModel.MainData));
            string sProds = saveDataModel.MainData["prods"].ToString();
            string sGroups = saveDataModel.MainData["pricegroups"].ToString();
            string sCusts = saveDataModel.MainData["custs"].ToString();
            string sPriceChannel = saveDataModel.MainData["price_channel"].ToString();
            string[] sProdArray = sProds.Split(',');
            string[] sGroupArray = null;
            if(string.IsNullOrEmpty(sGroups) ==false)
            {
                sGroupArray = sGroups.Split(',');
            }

            string[] sCustArray = null;
            if (string.IsNullOrEmpty(sCusts) == false)
            {
                sCustArray = sCusts.Split(',');
            }

            saveDataModel.MainDatas = new List<Dictionary<string, object>>();
            saveDataModel.mainOptionType = SaveModel.MainOptionType.add;
            saveDataModel.MainFacType = typeof(Viat_app_dist_mapping);

            if (sPriceChannel != null && sPriceChannel !="" )
            {
                for (int i = 0; i < sProdArray.Length; i++)
                {
                    Viat_com_prod prod = Viat_com_prodService.Instance.getProdByProdID(sProdArray[i]);
                    if (prod == null)
                    {
                        return webResponse.Error("no proddbid");
                    }
                    //产品dbid
                    string sProdDBID = prod.prod_dbid.ToString();
                    Dictionary<string, object> saveDic = new Dictionary<string, object>(saveDataModel.MainData);
                    //处理distmapping_dbid，prod_dbid，cust_dbid,pricegroup_dbid
                    if (saveDic.ContainsKey("distmapping_dbid") == false)
                    {
                        saveDic.Add("distmapping_dbid", "");
                    }
                    if (saveDic.ContainsKey("prod_dbid") == false)
                    {
                        saveDic.Add("prod_dbid", "");
                    }

                    if (saveDic.ContainsKey("cust_dbid") == false)
                    {
                        saveDic.Add("cust_dbid", "");
                    }

                    if (saveDic.ContainsKey("pricegroup_dbid") == false)
                    {
                        saveDic.Add("pricegroup_dbid", "");
                    }
                    saveDic["prod_dbid"] = sProdDBID;
                    saveDic["price_channel"] = sPriceChannel;
                    saveDataModel.MainDatas.Add(saveDic);
                }
            }
            //如果是组
            if (sGroupArray != null && sGroupArray.Length > 0)
            {
                for (int i = 0; i < sProdArray.Length; i++)
                {
                    Viat_com_prod prod = Viat_com_prodService.Instance.getProdByProdID(sProdArray[i]);
                    if (prod == null)
                    {
                        return webResponse.Error("no proddbid");
                    }
                    //产品dbid
                    string sProdDBID = prod.prod_dbid.ToString();
                    for (int j = 0; j < sGroupArray.Length; j++)
                    {
                        Viat_app_cust_price_group group = Viat_app_cust_price_groupService.Instance.getPriceGroupByGroupID(sGroupArray[j]);
                        if (group == null)
                        {
                            return webResponse.Error("no groupdbid");
                        }
                        string scust_dbidDBID = group.pricegroup_dbid.ToString();
                        Dictionary<string, object> saveDic = new Dictionary<string, object>(saveDataModel.MainData);

                        //处理distmapping_dbid，prod_dbid，cust_dbid,pricegroup_dbid
                        if (saveDic.ContainsKey("distmapping_dbid") == false)
                        {
                            saveDic.Add("distmapping_dbid", "");
                        }
                        if (saveDic.ContainsKey("prod_dbid") == false)
                        {
                            saveDic.Add("prod_dbid", "");
                        }

                        if (saveDic.ContainsKey("cust_dbid") == false)
                        {
                            saveDic.Add("cust_dbid", "");
                        }

                        if (saveDic.ContainsKey("pricegroup_dbid") == false)
                        {
                            saveDic.Add("pricegroup_dbid", "");
                        }
                        saveDic["prod_dbid"] = sProdDBID;
                        saveDic["pricegroup_dbid"] = scust_dbidDBID;
                        saveDataModel.MainDatas.Add(saveDic);
                    }
                }
            }
            //如果是客户
            if (sCustArray != null && sCustArray.Length > 0)
            {
                for (int i = 0; i < sProdArray.Length; i++)
                {
                    Viat_com_prod prod = Viat_com_prodService.Instance.getProdByProdID(sProdArray[i]);
                    if (prod == null)
                    {
                        return webResponse.Error("no proddbid");
                    }
                    //产品dbid
                    string sProdDBID = prod.prod_dbid.ToString();
                    for (int j = 0; j < sCustArray.Length; j++)
                    {
                        Viat_com_cust cust = Viat_com_custService.Instance.getCustByCustID(sCustArray[j]);
                        if (cust == null)
                        {
                            return webResponse.Error("no custdbid");
                        }
                        string sCustDBID = cust.cust_dbid.ToString();
                        Dictionary<string, object> saveDic = new Dictionary<string, object>(saveDataModel.MainData);
                        //处理distmapping_dbid，prod_dbid，cust_dbid,pricegroup_dbid
                        if (saveDic.ContainsKey("distmapping_dbid") == false)
                        {
                            saveDic.Add("distmapping_dbid", "");
                        }
                        if (saveDic.ContainsKey("prod_dbid") == false)
                        {
                            saveDic.Add("prod_dbid", "");
                        }

                        if (saveDic.ContainsKey("cust_dbid") == false)
                        {
                            saveDic.Add("cust_dbid", "");
                        }

                        if (saveDic.ContainsKey("pricegroup_dbid") == false)
                        {
                            saveDic.Add("pricegroup_dbid", "");
                        }
                        saveDic["prod_dbid"] = sProdDBID;
                        saveDic["cust_dbid"] = sCustDBID;
                        saveDataModel.MainDatas.Add(saveDic);
                    }
                }
            }
            //else
            //{
            //    for (int i = 0; i < sProdArray.Length; i++)
            //    {
            //        Viat_com_prod prod = Viat_com_prodService.Instance.getProdByProdID(sProdArray[i]);
            //        if (prod == null)
            //        {
            //            return webResponse.Error("no proddbid");
            //        }
            //        //Viat_com_cust cust = Viat_com_custService.Instance.getCustByCustID(sCustArray[j]);
            //        //if (cust == null)
            //        //{
            //        //    return webResponse.Error("no custdbid");
            //        //}
            //        //产品dbid
            //        string sProdDBID = prod.prod_dbid.ToString();
            //        //string sCustDBID = cust.cust_dbid.ToString();
            //        Dictionary<string, object> saveDic = new Dictionary<string, object>(saveDataModel.MainData);
            //        //处理distmapping_dbid，prod_dbid，cust_dbid,pricegroup_dbid
            //        if (saveDic.ContainsKey("distmapping_dbid") == false)
            //        {
            //            saveDic.Add("distmapping_dbid", "");
            //        }
            //        if (saveDic.ContainsKey("prod_dbid") == false)
            //        {
            //            saveDic.Add("prod_dbid", "");
            //        }

            //        if (saveDic.ContainsKey("cust_dbid") == false)
            //        {
            //            saveDic.Add("cust_dbid", "");
            //        }

            //        if (saveDic.ContainsKey("pricegroup_dbid") == false)
            //        {
            //            saveDic.Add("pricegroup_dbid", "");
            //        }
            //        saveDic["prod_dbid"] = sProdDBID;
            //        //saveDic["cust_dbid"] = sCustDBID;
            //        saveDataModel.MainDatas.Add(saveDic);
            //    }
            //}
            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            return base.CustomUpdateMains(saveDataModel);
        }

        #region select

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public override PageGridData<View_price_distributor_mapping> GetPageData(PageDataOptions options)
        {
            setQueryParameters();
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

                }
            };
        }


        #endregion


        #region add


        #endregion
        public override WebResponseContent Update(SaveModel saveModel)
        {

            UpdateOnExecuting = (View_price_distributor_mapping order, object addList, object updateList, List<object> delKeys) =>
            {
                return webResponse.OK();
            };
            return _viat_app_dist_mappingService.Update(saveModel);
        }
        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            return _viat_app_dist_mappingService.Del(keys, delList);
        }

        public List<View_price_distributor_mapping> PriceDistributorMappingData(string prod_id, string price_channel, string group_id, string cust_id)
        {
            string sql = @"select top(1)* from View_price_distributor_mapping where prod_id =@sProd_id";
            if (!string.IsNullOrEmpty(price_channel))
            {
                sql += " and price_channel =@sPrice_channel";
            }
            if (!string.IsNullOrEmpty(group_id))
            {
                sql += " and group_id =@sGroup_id";
            }
            if (!string.IsNullOrEmpty(cust_id))
            {
                sql += " and cust_id = @sCust_id";
            }
            sql += " order by created_date";
           
            return repository.DapperContext.QueryList<View_price_distributor_mapping>(sql,
                    new { sProd_id = prod_id , sPrice_channel  = price_channel , sGroup_id  = group_id , sCust_id = cust_id });
        }
    }
}
