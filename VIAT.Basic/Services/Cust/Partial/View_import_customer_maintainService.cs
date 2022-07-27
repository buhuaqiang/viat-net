/*
 *所有关于View_import_customer_maintain类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_import_customer_maintainService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Basic.IRepositories;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Reflection;

namespace VIAT.Basic.Services
{
    public partial class View_import_customer_maintainService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_import_customer_maintainRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_import_customer_maintainService(
            IView_import_customer_maintainRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webResponse = new WebResponseContent();

        /// <summary>
        /// 保存处理
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            //保存处理
            /*
             *  处理表头表体
             *  处理cust表头，表体
             *  当cust_id为空时，新增cust表头和表体
             *  当cust_id不为空时，更新cust表头，表体判断是否新增
             */
            UpdateOnExecute = (saveModel) => {
                Viat_app_cust_transfer transferEntity = JsonConvert.DeserializeObject<Viat_app_cust_transfer>(JsonConvert.SerializeObject(saveModel.MainData));
                string sCustID = "";              
                if (string.IsNullOrEmpty(transferEntity.cust_id) == true)
                {
                    string dohInstituteNo = saveModel.MainData["doh_institute_no"].ToString();
                    if (!string.IsNullOrEmpty(dohInstituteNo))
                    {
                        PageGridData<View_com_cust> detailGrid = new PageGridData<View_com_cust>();
                        string sql = "select count(1) from View_com_cust where doh_institute_no=@dohInstituteNo";
                        detailGrid.total = repository.DapperContext.ExecuteScalar(sql, new { dohInstituteNo = dohInstituteNo }).GetInt();
                        if (detailGrid.total > 0)
                        {
                            return webResponse.Error("NHI Institute no Already Exists");
                        }
                    }
                    //当cust_id为空时，需要同步cust
                    sCustID = View_com_custService.Instance.getCustID();                   
                    saveModel.MainData["cust_id"] = sCustID;
                    
                }
                saveModel.MainData["state"] = "1";
                //处理表头[viat_app_cust_transfer]
                SaveModel.DetailListDataResult transfer = new SaveModel.DetailListDataResult();
                transfer.detailType = typeof(Viat_app_cust_transfer);               
                transfer.DetailData = new List<Dictionary<string, object>> { saveModel.MainData };
                transfer.optionType = SaveModel.MainOptionType.update;
                saveModel.DetailListData.Add(transfer);

                //处理表体
                PropertyInfo mainKeyProperty = typeof(Viat_app_cust_delivery_transfer).GetKeyProperty();
                object keyDefaultVal = mainKeyProperty.PropertyType.Assembly.CreateInstance(mainKeyProperty.PropertyType.FullName);
                foreach (Dictionary<string,object> detail in saveModel.DetailData)
                {
                    Viat_app_cust_delivery_transfer custDeliveryEntity = JsonConvert.DeserializeObject<Viat_app_cust_delivery_transfer>(JsonConvert.SerializeObject(detail));
                    SaveModel.DetailListDataResult custDeliveryResult = new SaveModel.DetailListDataResult();
                    custDeliveryResult.detailType = typeof(Viat_app_cust_delivery_transfer);                    
                    custDeliveryEntity.custtransfer_dbid= transferEntity.custtransfer_dbid;
                    if (custDeliveryEntity.custdeltransfer_dbid.ToString() == keyDefaultVal.ToString())
                    {
                        custDeliveryResult.optionType = SaveModel.MainOptionType.add;
                        custDeliveryEntity.custdeltransfer_dbid = System.Guid.NewGuid();
                    }
                    else
                    {
                        custDeliveryResult.optionType = SaveModel.MainOptionType.update;
                    }

                    custDeliveryResult.DetailData = new List<Dictionary<string, object>> { JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custDeliveryEntity)) };
                    saveModel.DetailListData.Add(custDeliveryResult);

                }
               

                //处理cust表头               
                if(string.IsNullOrEmpty(transferEntity.cust_id)==true)
                {

                    Guid custGuid = System.Guid.NewGuid();
                    //当cust_id为空时，需要同步cust                    
                    transferEntity.cust_id = sCustID;                     
                    Viat_com_cust cust = new Viat_com_cust();
                    transferEntity.MapValueToEntity(cust);
                    cust.cust_dbid = custGuid;
                    cust.cust_id = sCustID;
                    /*cust.own_hospital = saveModel.MainData["own_hospital"] == null? new Guid(): (Guid?)saveModel.MainData["own_hospital"];
                    cust.med_group = saveModel.MainData["med_group"] == null ? new Guid() : (Guid?)saveModel.MainData["med_group"];
                    cust.delv_group = saveModel.MainData["delv_group"] == null ? new Guid() : (Guid?)saveModel.MainData["delv_group"];*/
                    SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
                    custResult.detailType = typeof(Viat_com_cust);
                    custResult.optionType = SaveModel.MainOptionType.add;
                    custResult.DetailData = new List<Dictionary<string, object>> { JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(cust)) };
                    saveModel.DetailListData.Add(custResult);

                    //表体新增
                    foreach(Dictionary<string,object> custDelivery in saveModel.DetailData)
                    {
                        Viat_app_cust_delivery_transfer appDeliveryEntity = JsonConvert.DeserializeObject<Viat_app_cust_delivery_transfer>(JsonConvert.SerializeObject(custDelivery));

                        Viat_com_cust_delivery custDeliveryEntity = new Viat_com_cust_delivery();
                        appDeliveryEntity.MapValueToEntity(custDeliveryEntity);
                        custDeliveryEntity.cust_dbid = custGuid;
                        custDeliveryEntity.delivery_dbid = System.Guid.NewGuid();                       
                        SaveModel.DetailListDataResult custDeliveryResult = new SaveModel.DetailListDataResult();
                        custDeliveryResult.detailType = typeof(Viat_com_cust_delivery);
                        custDeliveryResult.optionType = SaveModel.MainOptionType.add;
                        custDeliveryResult.DetailData = custDeliveryResult.DetailData = new List<Dictionary<string, object>> { JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custDeliveryEntity)) };

                        saveModel.DetailListData.Add(custDeliveryResult);
                    }

                }
                else
                {
                    //更新
                    Viat_com_cust_save cust = new Viat_com_cust_save();
                    transferEntity.MapValueToEntity(cust);
                    //Viat_com_cust cust = JsonConvert.DeserializeObject<Viat_com_cust>(JsonConvert.SerializeObject(custDic));
                    //根据cust_id取得实体，目的是拿到cust_dbid,表头表体都可以用
                    View_com_cust custFac = View_com_custService.Instance.getCustByCustID(cust.cust_id);
                    if(custFac != null)
                    {
                        cust.cust_dbid = custFac.cust_dbid;
                    }
                   

                    SaveModel.DetailListDataResult custResult = new SaveModel.DetailListDataResult();
                    custResult.detailType = typeof(Viat_com_cust);
                    custResult.optionType = SaveModel.MainOptionType.update;
                    Dictionary<string,object> dicCustResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(cust));
                    custResult.DetailData = new List<Dictionary<string, object>> { dicCustResult };
                    saveModel.DetailListData.Add(custResult);


                    //表体处理
                    decimal dSeq = View_com_cust_deliveryService.Instance.getMaxSeq(cust.cust_dbid.ToString());
                    foreach (Dictionary<string, object> custDelivery in saveModel.DetailData)
                    {
                        Viat_app_cust_delivery_transfer appDeliveryEntity = JsonConvert.DeserializeObject<Viat_app_cust_delivery_transfer>(JsonConvert.SerializeObject(custDelivery));
                        Viat_com_cust_delivery custDeliveryEntity = new Viat_com_cust_delivery();
                        appDeliveryEntity.MapValueToEntity(custDeliveryEntity);
                        //zip 不一样，需要单独 处理
                        custDeliveryEntity.zip_id = custDelivery["delivery_zip_id"]?.ToString();
                        custDeliveryEntity.cust_dbid = cust.cust_dbid;

                        //判断是否为新增还是修改
                        View_com_cust_delivery custDeliveryFac = View_com_cust_deliveryService.Instance.getCustDelivery(custDeliveryEntity.delivery_name,
                                                              custDeliveryEntity.delivery_contact, custDeliveryEntity.delivery_tel_no, custDeliveryEntity.zip_id, custDeliveryEntity.delivery_addr, cust.cust_id);
                        SaveModel.DetailListDataResult custDeliveryResult = new SaveModel.DetailListDataResult();
                        if (custDeliveryFac == null)
                        {
                            //新增
                            custDeliveryEntity.seq_no = dSeq;
                            dSeq++;
                            custDeliveryEntity.delivery_dbid = System.Guid.NewGuid();
                            custDeliveryResult.optionType = SaveModel.MainOptionType.add;
                        }
                        else
                        {
                            custDeliveryEntity.delivery_dbid = custDeliveryFac.delivery_dbid;
                            //编辑                         
                            custDeliveryResult.optionType = SaveModel.MainOptionType.update; ;
                        }
                        
                        custDeliveryResult.detailType = typeof(Viat_com_cust_delivery);                       
                        Dictionary<string, object> dicDeliveryResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(custDeliveryEntity));
                        custDeliveryResult.DetailData = new List<Dictionary<string, object>> { dicDeliveryResult };
                        saveModel.DetailListData.Add(custDeliveryResult);
                                
                    }
                }
                base.CustomBatchProcessEntity(saveModel);
                webResponse.Code = "-1";
                return webResponse.OK("Update successful");
            };
           
            return base.Update(saveModel);
        }

        private int List<T>()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="custtransfer_dbid"></param>
        public WebResponseContent processIngore(string[] custtransfer_dbid)
        {
            string sCondition = "";
            for(int i=0;i<custtransfer_dbid.Length; i++)
            {
                sCondition += "'" + custtransfer_dbid[i].ToString() + "',";
            }
            if(string.IsNullOrEmpty(sCondition)==false)
            {
                sCondition = sCondition.Substring(0, sCondition.Length - 1);
            }

            string sSql = "update viat_app_cust_transfer set state='2' where custtransfer_dbid in (" + sCondition + ")";
            return  base.CustomExcuteBySql(new List<string> { sSql }, "");
        }



    }
}
