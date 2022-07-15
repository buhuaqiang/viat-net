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
    [Entity(TableCnName = "客戶價格明細表",TableName = "Viat_app_cust_price_detail")]
    public partial class Viat_app_cust_price_detail:BaseEntity
    {
        /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid pricedetail_dbid { get; set; }

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
       [MaxLength(16)]
       [Column(TypeName="varchar(16)")]
       [Editable(true)]
       public string bid_no { get; set; }

       /// <summary>
       ///產品表PK
       /// </summary>
       [Display(Name ="產品表PK")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///客戶表PK
       /// </summary>
       [Display(Name ="客戶表PK")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///健保價格
       /// </summary>
       [Display(Name ="健保價格")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? nhi_price { get; set; }

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
       ///Gross Price
       /// </summary>
       [Display(Name ="Gross Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? gross_price { get; set; }

       /// <summary>
       ///最低訂購量
       /// </summary>
       [Display(Name ="最低訂購量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? min_qty { get; set; }

       /// <summary>
       ///生效日
       /// </summary>
       [Display(Name ="生效日")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime start_date { get; set; }

       /// <summary>
       ///結束日
       /// </summary>
       [Display(Name ="結束日")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime end_date { get; set; }

       /// <summary>
       ///status
       /// </summary>
       [Display(Name ="status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string status { get; set; }

       /// <summary>
       ///資料來源,0:EBMS;1:Manual;2:Copy;3:Detach
       /// </summary>
       [Display(Name ="資料來源,0:EBMS;1:Manual;2:Copy;3:Detach")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string source { get; set; }

       /// <summary>
       ///備註
       /// </summary>
       [Display(Name ="備註")]
       [MaxLength(256)]
       [Column(TypeName="nvarchar(256)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///系統結束日
       /// </summary>
       [Display(Name ="系統結束日")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? sys_end_date { get; set; }

       /// <summary>
       ///原生效日
       /// </summary>
       [Display(Name ="原生效日")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? org_start_date { get; set; }

       /// <summary>
       ///原結束日
       /// </summary>
       [Display(Name ="原結束日")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? org_end_date { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [Column(TypeName="int")]
       public int? updated_user { get; set; }

       /// <summary>
       ///修改時間
       /// </summary>
       [Display(Name ="修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? updated_date { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
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

       /// <summary>
       ///淨售價
       /// </summary>
       [Display(Name ="淨售價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? reserv_price { get; set; }

       
    }
}