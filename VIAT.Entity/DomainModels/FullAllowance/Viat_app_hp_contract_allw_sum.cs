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
    [Entity(TableCnName = "全額折讓分配交易",TableName = "Viat_app_hp_contract_allw_sum")]
    public partial class Viat_app_hp_contract_allw_sum:BaseEntity
    {

        /// <summary>
        ///PKID
        /// </summary>
        [Key]
        [Display(Name = "PKID")]
        [Column(TypeName = "uniqueidentifier")]
        [Required(AllowEmptyStrings = false)]
        public Guid hpallw_dbid { get; set; }



        /// <summary>
        ///公司別
        /// </summary>
        [Display(Name ="公司別")]
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
       ///動作類別 (1: Sharing 2:Reverse 3:Adjust)
       /// </summary>
       [Display(Name ="動作類別 (1: Sharing 2:Reverse 3:Adjust)")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string action_type { get; set; }

       /// <summary>
       ///折讓類別(1:By Amount;2:By Qty)
       /// </summary>
       [Display(Name ="折讓類別(1:By Amount;2:By Qty)")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? allw_type { get; set; }

       /// <summary>
       ///年度
       /// </summary>
       [Display(Name ="年度")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? year { get; set; }

       /// <summary>
       ///Period
       /// </summary>
       [Display(Name ="Period")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? period { get; set; }

       /// <summary>
       ///PKID
       /// </summary>
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? hpcont_dbid { get; set; }

       /// <summary>
       ///產品代碼,舊版ITEM_CODE
       /// </summary>
       [Display(Name ="產品代碼,舊版ITEM_CODE")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///客戶PKID
       /// </summary>
       [Display(Name ="客戶PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///經銷商代碼
       /// </summary>
       [Display(Name ="經銷商代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string dist_id { get; set; }

       /// <summary>
       ///發票日期
       /// </summary>
       [Display(Name ="發票日期")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? invoice_date { get; set; }

       /// <summary>
       ///發票號碼
       /// </summary>
       [Display(Name ="發票號碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string invoice_no { get; set; }

       /// <summary>
       ///交易日期
       /// </summary>
       [Display(Name ="交易日期")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime trans_date { get; set; }

       /// <summary>
       ///銷售數量
       /// </summary>
       [Display(Name ="銷售數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? qty { get; set; }

       /// <summary>
       ///金額
       /// </summary>
       [Display(Name ="金額")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? amount { get; set; }

       /// <summary>
       ///備註
       /// </summary>
       [Display(Name ="備註")]
       [MaxLength(256)]
       [Column(TypeName="nvarchar(256)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///是否結案,True:結案/False:未結案
       /// </summary>
       [Display(Name ="是否結案,True:結案/False:未結案")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

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

       
    }
}