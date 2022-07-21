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
    [Entity(TableCnName = "價格暫存",TableName = "Viat_app_cust_price_transfer")]
    public partial class Viat_app_cust_price_transfer:BaseEntity
    {
        /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid price_transfer_dbid { get; set; }

       /// <summary>
       ///所屬事業單位,01:PH;03:AH;05:CH;06:NU
       /// </summary>
       [Display(Name ="所屬事業單位,01:PH;03:AH;05:CH;06:NU")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string division { get; set; }

       /// <summary>
       ///議價決標單號
       /// </summary>
       [Display(Name ="議價決標單號")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string bid_no { get; set; }

       /// <summary>
       ///申請人(系统表pkid)
       /// </summary>
       [Display(Name ="申請人(系统表pkid)")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? requestor { get; set; }

       /// <summary>
       ///申请人姓名
       /// </summary>
       [Display(Name ="申请人姓名")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string requestor_name { get; set; }

       /// <summary>
       ///群組代碼
       /// </summary>
       [Display(Name ="群組代碼")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? pricegroup_dbid { get; set; }

       /// <summary>
       ///cust_dbid
       /// </summary>
       [Display(Name ="cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///PKID
       /// </summary>
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///健保價格
       /// </summary>
       [Display(Name ="健保價格")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///客戶代碼
       /// </summary>
       [Display(Name ="客戶代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string bmp_cust_id { get; set; }

       /// <summary>
       ///銷售淨價(盒價)
       /// </summary>
       [Display(Name ="銷售淨價(盒價)")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? net_price_ebms { get; set; }

       /// <summary>
       ///發票價(盒價)
       /// </summary>
       [Display(Name ="發票價(盒價)")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? invoice_price { get; set; }

       /// <summary>
       ///銷售淨價(盒價)
       /// </summary>
       [Display(Name ="銷售淨價(盒價)")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? net_price { get; set; }

       /// <summary>
       ///cust_id_ebms
       /// </summary>
       [Display(Name ="cust_id_ebms")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string cust_id_ebms { get; set; }

       /// <summary>
       ///產品代碼
       /// </summary>
       [Display(Name ="產品代碼")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string prod_id_ebms { get; set; }

       /// <summary>
       ///最低訂購量
       /// </summary>
       [Display(Name ="最低訂購量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? min_qty_ebms { get; set; }

       /// <summary>
       ///最低訂購量
       /// </summary>
       [Display(Name ="最低訂購量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? min_qty { get; set; }

       /// <summary>
       ///原供應價
       /// </summary>
       [Display(Name ="原供應價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? price_list { get; set; }

       /// <summary>
       ///擬供應價
       /// </summary>
       [Display(Name ="擬供應價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? price_bid { get; set; }

       /// <summary>
       ///決標價
       /// </summary>
       [Display(Name ="決標價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? price_close { get; set; }

       /// <summary>
       ///discount
       /// </summary>
       [Display(Name ="discount")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? discount { get; set; }

       /// <summary>
       ///final_discount
       /// </summary>
       [Display(Name ="final_discount")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? final_discount { get; set; }

       /// <summary>
       ///final_fg
       /// </summary>
       [Display(Name ="final_fg")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? final_fg { get; set; }

       /// <summary>
       ///業務分區
       /// </summary>
       [Display(Name ="業務分區")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string territory_id { get; set; }

       /// <summary>
       ///生效日
       /// </summary>
       [Display(Name ="生效日")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///結束日
       /// </summary>
       [Display(Name ="結束日")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///群組狀態,Y:加入,N:不加入
       /// </summary>
       [Display(Name ="群組狀態,Y:加入,N:不加入")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string add_group { get; set; }

       /// <summary>
       ///處理狀態,0:待處理,1:匯入,2:不匯入;3:匯出
       /// </summary>
       [Display(Name ="處理狀態,0:待處理,1:匯入,2:不匯入;3:匯出")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string state { get; set; }

       /// <summary>
       ///處理說明
       /// </summary>
       [Display(Name ="處理說明")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       [Editable(true)]
       public string note { get; set; }

       /// <summary>
       ///轉入日期
       /// </summary>
       [Display(Name ="轉入日期")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? transfer_date { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? created_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_username")]
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
       ///
       /// </summary>
       [Display(Name ="created_clientusername")]
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
       ///
       /// </summary>
       [Display(Name ="modified_username")]
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
       ///
       /// </summary>
       [Display(Name ="modified_clientusername")]
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