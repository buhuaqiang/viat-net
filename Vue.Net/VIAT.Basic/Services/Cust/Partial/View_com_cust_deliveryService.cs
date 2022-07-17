/*
 *所有关于View_com_cust_delivery类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_com_cust_deliveryService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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

namespace VIAT.Basic.Services
{
    public partial class View_com_cust_deliveryService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_com_cust_deliveryRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_com_cust_deliveryService(
            IView_com_cust_deliveryRepository dbRepository,
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
        /// 检查表体数据是否已存在
        /// </summary>
        /// <param name="delivery_name">送貨抬頭</param>
        /// <param name="delivery_contact">聯絡人</param>
        /// <param name="delivery_tel_no">聯絡人電話</param>
        /// <param name="delivery_zip_id">送貨地址郵區</param>
        /// <param name="delivery_addr">送貨地址</param>
        /// <returns></returns>
        public View_com_cust_delivery getCustDelivery(string delivery_name,string delivery_contact, string delivery_tel_no,
            string delivery_zip_id, string delivery_addr, string cust_id)
        {
            string sSql = "select * from viat_com_cust_delivery l inner join viat_com_cust h on h.cust_dbid=l.cust_dbid  where 1=1 and h.cust_id='" + cust_id + "'";

            sSql += " and l.delivery_name='" + delivery_name + "'";
            sSql += " and l.delivery_contact='" + delivery_contact + "'";
            sSql += " and l.delivery_tel_no='" + delivery_tel_no + "'";
            sSql += " and l.zip_id='" + delivery_zip_id + "'";
            sSql += " and l.delivery_addr='" + delivery_addr + "'";

            return _repository.DapperContext.QueryFirst<View_com_cust_delivery>(sSql, null);
        }

        /// <summary>
        /// 取得最大seqno,用于新增时，增加序号
        /// </summary>
        /// <param name="cust_id"></param>
        /// <returns></returns>
        public decimal getMaxSeq(string cust_id)
        {
            decimal dSeqNo = 0;

            string sSql = "select max(seq_no) from viat_com_cust_delivery l inner join viat_com_cust h on h.cust_dbid=l.cust_dbid" +
                " where h.cust_id='" + cust_id + "'";
            object ojb = _repository.DapperContext.ExecuteScalar(sSql, null);
            if(ojb == null)
            {
                dSeqNo = 1;
            }
            else
            {
                dSeqNo = (decimal)ojb + 1;
            }

            return dSeqNo;
        }
  }
}
