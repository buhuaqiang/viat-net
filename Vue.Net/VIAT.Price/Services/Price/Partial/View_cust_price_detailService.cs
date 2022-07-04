/*
 *所有关于View_cust_price_detail类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_cust_price_detailService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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

namespace VIAT.Price.Services
{
    public partial class View_cust_price_detailService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_cust_price_detailRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();
        private readonly IViat_app_cust_price_detailService _viat_app_cust_price_detailService;


        [ActivatorUtilitiesConstructor]
        public View_cust_price_detailService(
            IView_cust_price_detailRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_cust_price_detailService viat_app_cust_price_detailService
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
            _viat_app_cust_price_detailService = viat_app_cust_price_detailService;
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            return _viat_app_cust_price_detailService.Add(saveDataModel);
        }

        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _viat_app_cust_price_detailService.Update(saveModel);
        }

        public override WebResponseContent DownLoadTemplate()
        {
            DownLoadTemplateColumns = x => new {x.cust_id, x.group_id, x.prod_id, x.nhi_price, x.net_price,x.gross_price, x.min_qty, x.start_date, x.end_date, x.remarks };
            return base.DownLoadTemplate();
        }

        public override WebResponseContent Import(List<IFormFile> files)
        {
            //如果下載模板指定了DownLoadTemplate,則在Import方法必須也要指定,並且字段要和下載模板裡指定的一致
            DownLoadTemplateColumns = x => new { x.cust_id, x.group_id, x.prod_id, x.nhi_price, x.net_price, x.gross_price, x.min_qty, x.start_date, x.end_date, x.remarks };
            return base.Import(files);
        }
    }
}
