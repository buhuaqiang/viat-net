/*
 *所有关于View_com_cust类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_com_custService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Basic.IServices;
using System;
using System.Collections.Generic;

namespace VIAT.Basic.Services
{
    public partial class View_com_custService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_com_custRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();

        private readonly IViat_com_custService _viat_com_custService;
        private readonly IViat_com_custRepository _viat_com_custRepository;

        [ActivatorUtilitiesConstructor]
        public View_com_custService(
            IView_com_custRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_com_custService viat_com_custService,
            IViat_com_custRepository viat_com_custRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_com_custService = viat_com_custService;
            _viat_com_custRepository = viat_com_custRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public void setQueryParameters()
        {
            QueryRelativeList = (searchParametersList) =>
            {
                for (int i = searchParametersList.Count - 1; i >= 0; i--)
                {
                    SearchParameters item = searchParametersList[i];

                    if (item.Name == "channelValue")
                    {
                        searchParametersList.Remove(item);

                        SearchParameters paraTmp = new SearchParameters();
                        paraTmp.Name = "doh_type";
                        paraTmp.Value = item.Value;
                        paraTmp.DisplayType = item.DisplayType;
                        searchParametersList.Add(paraTmp);
                        break;
                    }
                   
                }
                
            };
        }


        public string getCustCode()
        {
            string rule = "C" + $"D{DateTime.Now.GetHashCode()}";
            return rule.Substring(0, 10);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            string code = getCustCode();
            Guid cust_dbid = Guid.NewGuid();

            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            /* AddOnExecuting = (View_com_cust order, object list) => 
             {

                 Viat_com_cust cust = new Viat_com_cust()
                 {
                     cust_dbid = cust_dbid,
                     cust_id=code,
                     cust_address=order.cust_address,
                     invoice_address = order.invoice_address,
                     own_hospital=order.own_hospital,
                     delv_group= order.delv_group,
                     bmp_zip_id=order.bmp_zip_id,
                     zip_id=order.zip_id,


                 };

                 List<Viat_com_cust_delivery> Viat_com_cust_delivery = list as List<Viat_com_cust_delivery>;
                 //  
                 foreach (var item in Viat_com_cust_delivery)
                 {
                     item.cust_dbid = cust_dbid;
                 }
                 cust.Viat_com_cust_delivery = Viat_com_cust_delivery;

                 webResponse.Code = "-1";

                 return webResponse.OK();
             };*/

            saveDataModel.MainData["cust_id"] = code;
            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            AddOnExecuting = (View_com_cust order, object list) =>
            {
                order.cust_id = code;

                return webResponse.OK();
            };

            return _viat_com_custService.Add(saveDataModel);
        }


        public override WebResponseContent Update(SaveModel saveModel)
        {
             UpdateOnExecuting = (View_com_cust order, object addList, object updateList, List<object> delKeys) =>
             {

                return webResponse.OK();
            };
            return _viat_com_custService.Update(saveModel);
        }


        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            return _viat_com_custService.Del(keys, delList);
        }

        public override WebResponseContent Export(PageDataOptions pageData)
        {
            ExportColumns = x => new {x.territory_id,x.cust_id,x.cust_name,x.cust_zip_id,x.cust_address,x.invoice_zip_id,x.invoice_name,x.invoice_address,
            x.owner,x.tax_id,x.contact,x.tel_no,x.fax_no,x.email,x.doh_institute_no,x.ctrl_drug_no,x.ctrl_drug_contact,x.doh_type,x.margin_type,
            x.is_contract,x.is_private,x.own_by_hospital,x.own_hospital_cust_id,x.own_hospital_cust_name,x.med_group_cust_id,x,x.delv_group_cust_id,
           x.new_cust_id,x.inactive_date,x.status,x.remarks,x.source,x.created_username,x.created_clientusername,x.created_date,x.modified_username,
                x.modified_clientusername,x.modified_date,x.entity,x.division };
            return base.Export(pageData);
        }
    }
}
