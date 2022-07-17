/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using VIAT.Core.BaseProvider;
using VIAT.Entity.DomainModels;

namespace VIAT.Basic.IServices
{
    public partial interface IView_com_cust_deliveryService : IService<View_com_cust_delivery>
    {
        // <summary>
        /// 取得最大seqno,用于新增时，增加序号
        /// </summary>
        /// <param name="cust_id"></param>
        /// <returns></returns>
        decimal getMaxSeq(string cust_id);

        /// <summary>
        /// 检查表体数据是否已存在
        /// </summary>
        /// <param name="delivery_name">送貨抬頭</param>
        /// <param name="delivery_contact">聯絡人</param>
        /// <param name="delivery_tel_no">聯絡人電話</param>
        /// <param name="delivery_zip_id">送貨地址郵區</param>
        /// <param name="delivery_addr">送貨地址</param>
        /// <returns></returns>
        View_com_cust_delivery getCustDelivery(string delivery_name, string delivery_contact, string delivery_tel_no,
            string delivery_zip_id, string delivery_addr, string cust_id);
    }
}
