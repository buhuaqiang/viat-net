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
    public partial class Viat_wk_cont_stretagy_detail_selectService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_wk_cont_stretagy_detail_selectRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_wk_cont_stretagy_detail_selectService(
            IViat_wk_cont_stretagy_detail_selectRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        /// <summary>
        /// 下载模板(导入时弹出框中的下载模板)(2020.05.07)
        /// </summary>
        /// <returns></returns>
        public override WebResponseContent DownLoadTemplate()
        {
            //指定导出模板的字段,如果不设置DownLoadTemplateColumns，默认导出查所有页面上能看到的列(2020.05.07)
            DownLoadTemplateColumns = x => new { x.cont_stretagy_id,x.cont_stretagy_name,x.amount, x.prod_id,x.prod_ename,x.nhi_price,x.invoice_price,x.net_price,x.min_qty };
            return base.DownLoadTemplate();
        }
    }
}
