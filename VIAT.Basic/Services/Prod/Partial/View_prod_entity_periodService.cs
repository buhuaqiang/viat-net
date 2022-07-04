/*
 *所有关于View_prod_entity_period类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_prod_entity_periodService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System.Collections.Generic;

namespace VIAT.Basic.Services
{
    public partial class View_prod_entity_periodService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_prod_entity_periodRepository _repository;//访问数据库
        WebResponseContent webResponse = new WebResponseContent();

        private readonly IViat_com_prod_entity_periodService _viat_com_prod_entity_periodService;
        private readonly IViat_com_prod_entity_periodRepository _viat_com_prod_entity_periodRepository;

        [ActivatorUtilitiesConstructor]
        public View_prod_entity_periodService(
            IView_prod_entity_periodRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_com_prod_entity_periodService viat_com_prod_entity_periodService,
            IViat_com_prod_entity_periodRepository viat_com_prod_entity_periodRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_com_prod_entity_periodService = viat_com_prod_entity_periodService;
            _viat_com_prod_entity_periodRepository = viat_com_prod_entity_periodRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            return _viat_com_prod_entity_periodService.Add(saveDataModel);
        }
        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecuting = (View_prod_entity_period order, object addList, object updateList, List<object> delKeys) =>
            {
                return webResponse.OK();
            };
            return _viat_com_prod_entity_periodService.Update(saveModel);
        }
    }
}
