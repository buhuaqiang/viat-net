/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIAT.Entity.SystemModels;

namespace VIAT.Entity.DomainModels
{
    [Entity(TableCnName = "wkmaster",TableName = "Viat_wk_master")]
    public partial class Viat_wk_master:BaseEntity
    {
        /// <summary>
       ///PKID
       /// </summary>
       [Key]      
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid bidmast_dbid { get; set; }

       /// <summary>
       ///審批案號
       /// </summary>
       [Display(Name ="審批案號")]
       [MaxLength(20)]
       [Column(TypeName= "varchar(20)")]
       public string bid_no { get; set; }

       /// <summary>
       ///申請類型：01 newcust;02:editcust;03NewBid price/order
       /// </summary>
       [Display(Name ="申請類型：01 newcust;02:editcust;03NewBid price/order")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       [Required(AllowEmptyStrings=false)]
       public string apply_type { get; set; }

       /// <summary>
       ///bidprice 
       /// </summary>
       [Display(Name ="bidprice ")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? contstret_dbid { get; set; }

       /// <summary>
       ///主鍵
       /// </summary>
       [Display(Name ="主鍵")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? pricegroup_dbid { get; set; }

       /// <summary>
       ///主鍵
       /// </summary>
       [Display(Name ="主鍵")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///議價日期
       /// </summary>
       [Display(Name ="議價日期")]
       [Column(TypeName="date")]
       public DateTime? bid_date { get; set; }

       /// <summary>
       ///生效開始日期
       /// </summary>
       [Display(Name ="生效開始日期")]
       [Column(TypeName="date")]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///生效結束日期
       /// </summary>
       [Display(Name ="生效結束日期")]
       [Column(TypeName="date")]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///預留
       /// </summary>
       [Display(Name ="預留")]
       [Column(TypeName="date")]
       public DateTime? order_date { get; set; }

       /// <summary>
       ///預留
       /// </summary>
       [Display(Name ="預留")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       public string invoice_type { get; set; }

       /// <summary>
       ///預留
       /// </summary>
       [Display(Name ="預留")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string shipto_address { get; set; }

       /// <summary>
       ///預留
       /// </summary>
       [Display(Name ="預留")]
       [MaxLength(32)]
       [Column(TypeName="varchar(32)")]
       public string po_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="remarks")]
       [Column(TypeName="nvarchar(max)")]
       public string remarks { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="upload")]
       [MaxLength(4000)]
       [Column(TypeName="varchar(4000)")]
       public string upload { get; set; }

       /// <summary>
       ///00：草稿 ；01：提交審批；02拿回；03審批通過；04審批拒絕
       /// </summary>
       [Display(Name ="00：草稿 ；01：提交審批；02拿回；03審批通過；04審批拒絕")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       public string status { get; set; }

       /// <summary>
       ///當前審批人ID
       /// </summary>
       [Display(Name ="當前審批人ID")]
       [Column(TypeName="int")]
       public int? approval_user { get; set; }

       /// <summary>
       ///當前審批人Name
       /// </summary>
       [Display(Name ="當前審批人Name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string approval_username { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///建立時間
       /// </summary>
       [Display(Name ="建立時間")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///最後修改時間
       /// </summary>
       [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       
    }
}