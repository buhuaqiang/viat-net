/*
 *所有关于Viat_wk_bid_detail类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_wk_bid_detailService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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




namespace VIAT.WorkFlow.Services
{
    public partial class Viat_wk_bid_detailService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_wk_bid_detailRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_wk_bid_detailService(
            IViat_wk_bid_detailRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }


        public override PageGridData<Viat_wk_bid_detail_select> GetPageData(PageDataOptions options)
        {

            /*解析查询条件*/
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    string bidmast_dbid = "";
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        if (sp.Name.ToLower() == "bidmast_dbid".ToLower())
                        {
                            bidmast_dbid = sp.Value ?? System.Guid.NewGuid().ToString() ?? sp.Value;
                            continue;
                        }
                    }

                    QuerySql = @"select a.*,b.prod_id,b.prod_ename from viat_wk_bid_detail a, viat_com_prod b where a.prod_dbid = b.prod_dbid" +
                " and  a.bidmast_dbid='" + bidmast_dbid + "'";
                }
            }




            return base.GetPageData(options);
        }
    }
}
