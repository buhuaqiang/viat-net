/*
 *所有关于Viat_com_zip_city类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_com_zip_cityService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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

namespace VIAT.Basic.Services
{
    public partial class Viat_com_zip_cityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_com_zip_cityRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_com_zip_cityService(
            IViat_com_zip_cityRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override WebResponseContent DownLoadTemplate()
        {
            DownLoadTemplateColumns = x => new{ x.city_id,x.city_name,x.status };
            return base.DownLoadTemplate();
        }

        public override WebResponseContent Import(List<IFormFile> files)
        {
            //如果下載模板指定了DownLoadTemplate,則在Import方法必須也要指定,並且字段要和下載模板裡指定的一致
            DownLoadTemplateColumns = x => new { x.city_id, x.city_name, x.status };
            return base.Import(files);
        }

        public override WebResponseContent Export(PageDataOptions pageData)
        {
            ExportColumns = x => new { x.city_id, x.city_name, x.zip_id,x.zip_name, x.status };
            return base.Export(pageData);
        }
    }
}
