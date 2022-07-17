/*
 *所有关于View_import_customer_maintain类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_import_customer_maintainService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using Newtonsoft.Json;

namespace VIAT.Basic.Services
{
    public partial class View_import_customer_maintainService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_import_customer_maintainRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_import_customer_maintainService(
            IView_import_customer_maintainRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webResponse = new WebResponseContent();

        /// <summary>
        /// 保存处理
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            //保存处理
            /*
             *  处理表头表体
             *  处理cust表头，表体
             *  当cust_id为空时，新增cust表头和表体
             *  当cust_id不为空时，更新cust表头，表体判断是否新增
             */
            AddOnExecute = (saveModel) => {
                //处理表头[viat_app_cust_transfer]
                SaveModel.DetailListDataResult transfer = new SaveModel.DetailListDataResult();
                transfer.detailType = typeof(Viat_app_cust_transfer);
                transfer.DetailData = saveModel.MainDatas;
                transfer.optionType = SaveModel.MainOptionType.update;
                saveModel.DetailListData.Add(transfer);

                //处理表体
                SaveModel.DetailListDataResult deliveryResult = new SaveModel.DetailListDataResult();
                deliveryResult.detailType = typeof(Viat_app_cust_delivery_transfer);
                deliveryResult.DetailData = saveModel.DetailData;

                //处理cust
                Viat_app_cust_transfer transferEntity = JsonConvert.DeserializeObject<Viat_app_cust_transfer>(JsonConvert.SerializeObject(saveModel.MainData));
                if(string.IsNullOrEmpty(transferEntity.cust_id)==true)
                {
                    //当cust_id为空时，需要同步cust
                    //string sCustID = 

                }


                return webResponse.OK();

            };

           
            return base.Update(saveModel);
        }


        /// <summary>
        /// 关联处理cust
        /// </summary>
        /// <returns></returns>
        private WebResponseContent processCust(Viat_app_cust_transfer transfer, List<Viat_app_cust_delivery_transfer> deliveryLst)
        {
            

            return webResponse.OK();
        }



    }
}
