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
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels
{
    [Entity(TableCnName = "HP合約主表",TableName = "Viat_app_hp_contract")]
    public partial class Viat_app_hp_contract:BaseEntity
    {
        /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid hpcont_dbid { get; set; }

       /// <summary>
       ///公司別,舊版SUN_DB
       /// </summary>
       [Display(Name ="公司別,舊版SUN_DB")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Editable(true)]
       public string entity { get; set; }

       /// <summary>
       ///所屬事業單位,01:PH;03:AH;05:CH;06:NU
       /// </summary>
       [Display(Name ="所屬事業單位,01:PH;03:AH;05:CH;06:NU")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string division { get; set; }

       /// <summary>
       ///合約號碼(案號)
       /// </summary>
       [Display(Name ="合約號碼(案號)")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string contract_no { get; set; }

       /// <summary>
       ///主鍵
       /// </summary>
       [Display(Name ="主鍵")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? pricegroup_id { get; set; }

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
       ///折讓類別(1:By Amount;2:By Qty)
       /// </summary>
       [Display(Name ="折讓類別(1:By Amount;2:By Qty)")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? allw_type { get; set; }

       /// <summary>
       ///預估參考月數
       /// </summary>
       [Display(Name ="預估參考月數")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? est_months { get; set; }

       /// <summary>
       ///預估金額
       /// </summary>
       [Display(Name ="預估金額")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? accrue_amt { get; set; }

       /// <summary>
       ///合約條款
       /// </summary>
       [Display(Name ="合約條款")]
       [MaxLength(16)]
       [Column(TypeName="text(16)")]
       [Editable(true)]
       public string contract_term { get; set; }

       /// <summary>
       ///合約狀態,Y:Valid;N:Invalid;C:Over period still active;A:Not Achieve
       /// </summary>
       [Display(Name ="合約狀態,Y:Valid;N:Invalid;C:Over period still active;A:Not Achieve")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string state { get; set; }

       /// <summary>
       ///LocalAddon Contractno
       /// </summary>
       [Display(Name ="LocalAddon Contractno")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? o_contract_no { get; set; }

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

       
    }
}