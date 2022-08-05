/*
 *所有关于Viat_wk_cont_stretagy_detail类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_wk_cont_stretagy_detailService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System.Collections.Generic;
using System;
using System.IO;
using System.Data;
using Newtonsoft.Json;

namespace VIAT.WorkFlow.Services
{
    public partial class Viat_wk_cont_stretagy_detailService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_wk_cont_stretagy_detailRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_wk_cont_stretagy_detailService(
            IViat_wk_cont_stretagy_detailRepository dbRepository,
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
        public override WebResponseContent Import(List<IFormFile> files)
        {
            SaveModel saveModel = new SaveModel();
            WebResponseContent detailContent = View_wk_bid_price_apply_mainService.BidDetailData(files);
            if (!detailContent.Status)
            {
                return detailContent;
            }
            DataTable dt = detailContent.Data as DataTable;
            foreach (DataRow dw in dt.Rows)
            {
                Viat_wk_cont_stretagy_detail stretagyDetailModel = new Viat_wk_cont_stretagy_detail();
                SaveModel.DetailListDataResult detailResult = new SaveModel.DetailListDataResult();
                saveModel.DetailListData.Add(detailResult);
                string cont_stretagy_id = dw["stretagy_id"].ToString();
                string prod_id = dw["prod_id"].ToString();
                decimal invoice_price = dw["invoice_price"] == null ? 0 : Convert.ToDecimal(dw["invoice_price"]);
                decimal net_price = dw["net_price"] == null ? 0 : Convert.ToDecimal(dw["net_price"]);
                int min_qty = dw["min_qty"] == null ? 0 : Convert.ToInt32(dw["min_qty"]);
                string isbelong = dw["isbelong"].ToString();

                #region 查询contstret_dbid
                var lstStretagy = repository.DbContext.Set<Viat_wk_contract_stretagy>().Where(x => x.cont_stretagy_id == cont_stretagy_id).ToList();
                if (lstStretagy.Count() == 0)
                {
                    return new WebResponseContent { Code = "-2", Message = $"The {cont_stretagy_id} not exist" };
                }
                #endregion
                #region 查询prod_dbid
                var lstProd = repository.DbContext.Set<Viat_com_prod>().Where(x => x.prod_id == prod_id).ToList();
                if (lstProd.Count()==0)
                {
                    return new WebResponseContent { Code = "-2", Message = $"The {prod_id} not exist" };
                }
                #endregion
                var detailCon = repository.DbContext.Set<Viat_wk_cont_stretagy_detail>().Where(x => x.contstret_dbid == lstStretagy[0].contstret_dbid && x.prod_dbid == lstProd[0].prod_dbid).ToList();
                if (detailCon.Count() > 0)
                {
                    stretagyDetailModel.contstretail_dbid = detailCon[0].contstretail_dbid;
                    detailResult.optionType = SaveModel.MainOptionType.update;
                }
                else
                {
                    detailResult.optionType = SaveModel.MainOptionType.add;
                    stretagyDetailModel.contstretail_dbid = Guid.NewGuid();
                }
                stretagyDetailModel.invoice_price = invoice_price;
                stretagyDetailModel.net_price = net_price;
                stretagyDetailModel.min_qty = min_qty;
                stretagyDetailModel.isbelong = isbelong;
                stretagyDetailModel.contstret_dbid = lstStretagy[0].contstret_dbid;
                stretagyDetailModel.prod_dbid = lstProd[0].prod_dbid;

                detailResult.DetailData.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(stretagyDetailModel)));
                detailResult.detailType = typeof(Viat_wk_cont_stretagy_detail);
                
            }
            base.CustomBatchProcessEntity(saveModel);
            webResponse.Code = "-1";
            return webResponse;
        }
    }
}
