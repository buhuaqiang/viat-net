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
    [Entity(TableCnName = "BidPrice Apply",TableName = "View_wk_bid_price_apply_main")]
    public partial class View_wk_bid_price_apply_main:BaseEntity
    {
        /// <summary>
       ///Bid NO
       /// </summary>
       [Display(Name ="Bid NO")]
       [MaxLength(20)]
       [Column(TypeName="char(20)")]
       [Editable(true)]
       public string bid_no { get; set; }

       /// <summary>
       ///Customer ID
       /// </summary>
       [Display(Name ="Customer ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string cust_id { get; set; }

       /// <summary>
       ///Customer Name
       /// </summary>
       [Display(Name ="Customer Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///Group ID
       /// </summary>
       [Display(Name ="Group ID")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string group_id { get; set; }

       /// <summary>
       ///Group Name
       /// </summary>
       [Display(Name ="Group Name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string group_name { get; set; }

       /// <summary>
       ///主鍵
       /// </summary>
       [Display(Name ="主鍵")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///主鍵
       /// </summary>
       [Display(Name ="主鍵")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? pricegroup_dbid { get; set; }

       /// <summary>
       ///Apply Date
       /// </summary>
       [Display(Name ="Apply Date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///Current Approval User
       /// </summary>
       [Display(Name ="Current Approval User")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string approval_username { get; set; }

       /// <summary>
       ///Approval Status
       /// </summary>
       [Display(Name ="Approval Status")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       public string status { get; set; }

       /// <summary>
       ///Requestor
       /// </summary>
       [Display(Name ="Requestor")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///Bid Date
       /// </summary>
       [Display(Name ="Bid Date")]
       [Column(TypeName="date")]
       [Editable(true)]
       public DateTime? bid_date { get; set; }

       /// <summary>
       ///Start Date
       /// </summary>
       [Display(Name ="Start Date")]
       [Column(TypeName="date")]
       [Editable(true)]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="date")]
       [Editable(true)]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid bidmast_dbid { get; set; }

       /// <summary>
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///當前審批人ID
       /// </summary>
       [Display(Name ="當前審批人ID")]
       [Column(TypeName="int")]
       public int? approval_user { get; set; }

       /// <summary>
       ///Attachments
       /// </summary>
       [Display(Name ="Attachments")]
       [MaxLength(4000)]
       [Column(TypeName="varchar(4000)")]
       [Editable(true)]
       public string upload { get; set; }

       /// <summary>
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///Remark
       /// </summary>
       [Display(Name ="Remark")]
       [Column(TypeName="nvarchar(max)")]
       [Editable(true)]
       public string remarks { get; set; }

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
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       public string invoice_type { get; set; }

       /// <summary>
       ///預留
       /// </summary>
       [Display(Name ="預留")]
       [Column(TypeName="date")]
       public DateTime? order_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///bidprice 
       /// </summary>
       [Display(Name ="bidprice ")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? contstret_dbid { get; set; }

       /// <summary>
       ///Apply Type
       /// </summary>
       [Display(Name ="Apply Type")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string apply_type { get; set; }

       /// <summary>
       ///預留
       /// </summary>
       [Display(Name ="預留")]
       [MaxLength(32)]
       [Column(TypeName="varchar(32)")]
       public string po_no { get; set; }

       /// <summary>
       ///最後修改時間
       /// </summary>
       [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Is Group
       /// </summary>
       [Display(Name ="Is Group")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string isgroup { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cont_stretagy_name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string cont_stretagy_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cont_stretagy_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cont_stretagy_id { get; set; }

       
    }
}