/*
 *所有关于View_com_prod类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_com_prodService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
namespace VIAT.Basic.Services
{
    public partial class View_com_prodService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_com_prodRepository _repository;//访问数据库
        private readonly IViat_com_prodService _viat_com_prodService;
        private readonly IViat_com_prodRepository _viat_com_prodRepository;

        [ActivatorUtilitiesConstructor]
        public View_com_prodService(
            IView_com_prodRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_com_prodService viat_com_prodService,
            IViat_com_prodRepository viat_com_prodRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_com_prodService = viat_com_prodService;
            _viat_com_prodRepository = viat_com_prodRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        //重写更新方法，更新Viat_com_prod表
        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _viat_com_prodService.Update(saveModel);
        }

         //重写新增方法，
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            return _viat_com_prodService.Add(saveDataModel);
        }

        public override WebResponseContent Export(PageDataOptions pageData)
        {
            ExportColumns = x => new {x.entity,x.prod_id,x.prod_ename,x.prod_sname,x.unit_stock,x.unit_sale,x.global_mpg,x.lmpg_mpg_id,
            x.nhi_id,x.default_dist_id,x.pack_size,x.pack_size_pri,x.nhi_price,x.division,x.prod_short_name,x.license_name,x.license_no,x.prod_form,x.prod_strength,
            x.is_ctrl_drug,x.safty_stock,x.state,x.status_sample,x.status_bid,x.status_stock_pfizer,x.status_stock_dist };
            return base.Export(pageData);
        }



    }
}
