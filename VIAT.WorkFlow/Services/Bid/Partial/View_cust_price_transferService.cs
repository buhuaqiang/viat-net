/*
 *所有关于View_cust_price_transfer类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_cust_price_transferService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System;

namespace VIAT.WorkFlow.Services
{
    public partial class View_cust_price_transferService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_cust_price_transferRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_cust_price_transferService(
            IView_cust_price_transferRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override PageGridData<View_cust_price_transfer> GetPageData(PageDataOptions options)
        {
            PageGridData<View_cust_price_transfer> pageGridData = base.GetPageData(options);
            foreach(View_cust_price_transfer trans in pageGridData.rows)
            {
                string result = "";
                if (trans.start_date!=null && trans.transfer_date!=null && getFormatYYYYMMDD(trans.start_date) != getFormatYYYYMMDD(trans.transfer_date))
                    result += " Start Date ≠ Approved Date; ";
                if (trans.end_date != null && trans.end_date.Value.Year != 2099)
                    result += " End Date ≠ 2099; ";
                if (trans.end_date != null && trans.end_date.Value.Date < DateTime.Now.Date)
                    result += " End Date < Today; ";
                if (trans.net_price == trans.invoice_price && trans.net_price != trans.nhi_price)
                    result += " Net Price=Invoce Price But ≠ NHI Price; ";
                if (trans.net_price > trans.invoice_price)
                    result += " Net Price > Invoice Price; ";
                trans.pendingReason = result;
            }
            return pageGridData;
        }
        public override WebResponseContent Export(PageDataOptions pageData)
        {
            ExportColumns = x => new {
                x.bid_no,
                x.state,
                x.modified_date,
                x.created_date,
                x.requestorName,
                x.group_id,
                x.group_name,
                x.cust_id,
                x.cust_name,
                x.prod_id,
                x.prod_ename,
                x.note
            };
            return base.Export(pageData);
        }
    }
}
