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
                                  AND bid_no LIKE '"+ sCurrentDate  + @"%'
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
                string sSerial = obj.ToString().Substring(9, 2);
                int nSerial = 0;
                int.TryParse(sSerial, out nSerial);
                return sCurrentDate + (nSerial + 1).ToString().PadLeft(2,'0');
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
                foreach (SearchParameters item in searchParametersList)
                {
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
                    if(item.Name== "QueryStatus")
                    {
                        searchParametersList.Remove(item);
                        //Valid(Current)
                        if (item.Value == "1")
                        {

                        } 
                        //InValid History
                        else if (item.Value == "2")
                        {

                        }
                        //Valid future
                        else if (item.Value == "3")
                        {

                        }
                    }
                }
            };
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

            AddOnExecute = (saveModel) => {
                return base.CustomUpdateMains(saveModel);
            };

            return base.Add(saveModel);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //
            return _cust_priceService.Add(saveDataModel);
        }


        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _cust_priceService.Update(saveModel);
        }

        public WebResponseContent invalidData(SaveModel saveModel)
        {
            return null;
        }

        public WebResponseContent detachProducts(SaveModel saveModel)
        {
            return null;
        }

        public override WebResponseContent DownLoadTemplate()
        {
            DownLoadTemplateColumns = x => new { x.group_id, x.prod_id, x.nhi_price,x.net_price,x.min_qty,x.start_date,x.end_date,x.remarks };
            return base.DownLoadTemplate();
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
