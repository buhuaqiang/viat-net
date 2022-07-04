/*
 *所有关于View_com_bulletin类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_com_bulletinService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System;
using System.Collections.Generic;

namespace VIAT.Basic.Services
{
    public partial class View_com_bulletinService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_com_bulletinRepository _repository;//访问数据库
        private readonly IViat_app_bulletinService _viat_app_bulletinService;
        private readonly IViat_app_bulletin_receiverService _viat_app_bulletin_receiverService;
        private readonly IViat_app_bulletinRepository _viat_app_bulletinRepository;
        private readonly IViat_app_bulletin_receiverRepository _viat_app_bulletin_receiverRepository;
        WebResponseContent webResponse = new WebResponseContent();

        [ActivatorUtilitiesConstructor]
        public View_com_bulletinService(
            IView_com_bulletinRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_app_bulletinService viat_app_bulletinService,
            IViat_app_bulletin_receiverService viat_app_bulletin_receiverService,
            IViat_app_bulletinRepository viat_app_bulletinRepository,
            IViat_app_bulletin_receiverRepository viat_app_bulletin_receiverRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_app_bulletinService = viat_app_bulletinService;
            _viat_app_bulletin_receiverService = viat_app_bulletin_receiverService;
            _viat_app_bulletinRepository = viat_app_bulletinRepository;
            _viat_app_bulletin_receiverRepository = viat_app_bulletin_receiverRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            /* Guid bulletin_dbid = Guid.NewGuid();


             AddOnExecuting = (View_com_bulletin bulletin, object list) =>
             {
                 Viat_app_bulletin viat_app_bulletin = new Viat_app_bulletin()
                 {
                     bulletin_dbid = bulletin_dbid,
                     start_date = bulletin.start_date,
                     end_date = bulletin.end_date,
                     subject = bulletin.subject,
                     content = bulletin.content,
                 };
                 _viat_app_bulletinRepository.Add(viat_app_bulletin);




                 *//* List<Viat_com_cust_delivery> Viat_com_cust_delivery = list as List<Viat_com_cust_delivery>;
                  //  
                  foreach (var item in Viat_com_cust_delivery)
                  {
                      item.cust_dbid = cust_dbid;
                  }
                  cust.Viat_com_cust_delivery = Viat_com_cust_delivery;

                  webResponse.Code = "-1";
                  return webResponse.OK();*//*
                 return webResponse.OK();


             };
            */


            /* Viat_app_bulletin viat_app_bulletin = new Viat_app_bulletin(){
                 bulletin_dbid = bulletin_dbid,
                 start_date = saveDataModel.start_date,
                 end_date = saveDataModel.end_date,
                 subject = saveDataModel.subject,
                 content = saveDataModel.content,
             };
             _viat_app_bulletinService.Add(viat_app_bulletin);

             if (saveDataModel.SelectUsers.length > 0)
             {
                 foreach (var item in saveDataModel.SelectUsers)
                 {
                     Viat_app_bulletin_receiver viat_app_bulletin_receiver = new Viat_app_bulletin_receiver()
                     {
                         bulletinreceiver_dbid = Guid.NewGuid,
                         bulletin_dbid = bulletin_dbid,
                         user_id = item.key

                     };
                     _viat_app_bulletin_receiverService.Add(viat_app_bulletin_receiver);
                 }
             }*/



            return _viat_app_bulletinService.Add(saveDataModel);


        }

        //重写更新方法，更新Viat_com_prod表
        public override WebResponseContent Update(SaveModel saveModel)
        {

            return _viat_app_bulletinService.Update(saveModel);

        }
    }
}
