/*
 *所有关于Viat_com_cust类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_com_custService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System;
using System.Collections.Generic;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_custService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_com_custRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();

        [ActivatorUtilitiesConstructor]
        public Viat_com_custService(
            IViat_com_custRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }


        public override WebResponseContent Add(SaveModel saveDataModel)
        {

            string code = View_com_custService.Instance.getCustID();
            saveDataModel.MainData["cust_id"] = code;
            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            AddOnExecuting = (Viat_com_cust order, object list) =>
            {
                order.cust_id = code;

                return webResponse.OK();
            };

            return base.Add(saveDataModel);
        }

        public string getCustCode()
        {
            string rule = "C" + $"D{DateTime.Now.GetHashCode()}";
            return rule.Substring(0, 10);
        }


        /// <summary>
        /// 根据custID获取单一实体
        /// </summary>
        /// <param name="sCustID"></param>
        /// <returns></returns>
        public Viat_com_cust getCustByCustID(string sCustID)
        {
            return   repository.FindAsIQueryable(x => x.cust_id == sCustID).FirstOrDefault();
        }

        /// <summary>
        /// 根据cust_id获取唯一的实体
        /// </summary>
        /// <param name="cust_id"></param>
        /// <returns></returns>
        public Viat_com_cust getCustByCustDBID(string cust_dbid)
        {
            string sSql = " select  top(1)* from viat_com_cust where cust_dbid='" + cust_dbid + "' order by created_date desc";

            return _repository.DapperContext.QueryFirst<Viat_com_cust>(sSql, null);
        }

        /// <summary>
        /// 根据pricegroupid获取cust全部信息
        /// </summary>
        /// <param name="sPriceGroupDBID"></param>
        /// <returns></returns>

        public List<Viat_com_cust> GetCustListByPriceGroupDBID(string sPriceGroupDBID)
        {
            string sSql = @"select distinct b.* from viat_app_cust_group  a left join viat_com_cust b on a.cust_dbid=b.cust_dbid 
                            where a.pricegroup_dbid=@pricegroup_dbid";

            return repository.DapperContext.QueryList<Viat_com_cust>(sSql, new { pricegroup_dbid = sPriceGroupDBID });
        }
    }
}
