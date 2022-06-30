/*
 *所有关于View_app_hp_share_table类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_app_hp_share_tableService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;
using System.Linq;
using VOL.Core.Utilities;
using System.Linq.Expressions;
using VOL.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Contract.IRepositories;
using VIAT.Contract.IServices;
using System;
using System.Collections.Generic;

namespace VIAT.Contract.Services
{
    public partial class View_app_hp_share_tableService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_app_hp_share_tableRepository _repository;//访问数据库
        private readonly IViat_app_hp_contract_shareService _viat_app_hp_contract_shareService;
        private readonly IViat_app_hp_contract_shareRepository _viat_app_hp_contract_shareRepository;
        WebResponseContent webResponse = new WebResponseContent();

        [ActivatorUtilitiesConstructor]
        public View_app_hp_share_tableService(
            IView_app_hp_share_tableRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_hp_contract_shareService viat_app_hp_contract_shareService,
            IViat_app_hp_contract_shareRepository viat_app_hp_contract_shareRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_app_hp_contract_shareService = viat_app_hp_contract_shareService;
            _viat_app_hp_contract_shareRepository = viat_app_hp_contract_shareRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        //新增
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            return _viat_app_hp_contract_shareService.Add(saveDataModel);
        }
        //更新
        public override WebResponseContent Update(SaveModel saveModel)
        {
            return _viat_app_hp_contract_shareService.Update(saveModel);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        public override WebResponseContent Export(PageDataOptions pageData)
        {
            //设置最大导出的数量
            Limit = 1000;
            //指定导出的字段(2020.05.07)
            ExportColumns = x => new { x.hpcont_dbid, x.prod_dbid, x.cust_dbid, x.percent, x.status };

            //查询要导出的数据后，在生成excel文件前处理
            //list导出的实体，ignore过滤不导出的字段
            ExportOnExecuting = (List<View_app_hp_share_table> list, List<string> ignore) =>
            {
                return webResponse.OK();
            };

            return base.Export(pageData);
        }


        /// <summary>
        /// 下载模板(导入时弹出框中的下载模板)(2020.05.07)
        /// </summary>
        /// <returns></returns>
        public override WebResponseContent DownLoadTemplate()
        {
            //指定导出模板的字段,如果不设置DownLoadTemplateColumns，默认导出查所有页面上能看到的列(2020.05.07)
            DownLoadTemplateColumns = x => new { x.hpcont_dbid, x.prod_dbid, x.cust_dbid, x.percent, x.status };
            return base.DownLoadTemplate();
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public override WebResponseContent Import(List<IFormFile> files)
        {
            //(2020.05.07)
            //设置导入的字段(如果指定了上面导出模板的字段，这里配置应该与上面DownLoadTemplate方法里配置一样)
            //如果不设置导入的字段DownLoadTemplateColumns,默认显示所有界面上所有可以看到的字段
            DownLoadTemplateColumns = x => new { x.hpcont_dbid, x.prod_dbid, x.cust_dbid, x.percent, x.status };

            //导入保存前处理(可以对list设置新的值)
            ImportOnExecuting = (List<View_app_hp_share_table> list) =>
            {
                /* list.ForEach(item =>
                 {
                     Guid hpcontshare_dbid = Guid.NewGuid();
                     Viat_app_hp_share_table share_table = new Viat_app_hp_share_table()
                     {
                         hpcontshare_dbid = hpcontshare_dbid,
                         hpcont_dbid = item.hpcont_dbid,
                         prod_dbid = item.prod_dbid,
                         cust_dbid = item.cust_dbid,
                         percent = item.percent,
                         status = item.status,
                     };

                     _viat_app_hp_contract_shareService.Add(share_table);
                 });
                */

                return webResponse.OK();
            };

            //导入后处理(已经写入到数据库了)
            ImportOnExecuted = (List<View_app_hp_share_table> list) =>
            {
                return webResponse.OK();
            };
            return base.Import(files);
        }



    }
}
