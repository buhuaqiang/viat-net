using Newtonsoft.Json;
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
    [Entity(TableCnName = "產品設置",TableName = "Viat_com_prod")]
    public partial class Viat_com_prod:BaseEntity
    {
        /// <summary>
       ///ID
       /// </summary>
       [Key]
       [Display(Name ="ID")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///公司別
       /// </summary>
       [Display(Name ="公司別")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Editable(true)]
       public string entity { get; set; }

       /// <summary>
       ///所屬事業單位
       /// </summary>
       [Display(Name ="所屬事業單位")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string division { get; set; }

       /// <summary>
       ///台灣產品群組識別碼
       /// </summary>
       [Display(Name ="台灣產品群組識別碼")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int mpg_id { get; set; }

       /// <summary>
       ///產品id
       /// </summary>
       [Display(Name ="產品id")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_id { get; set; }

       /// <summary>
       ///英文名稱
       /// </summary>
       [Display(Name ="英文名稱")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string prod_ename { get; set; }

       /// <summary>
       ///中文名稱
       /// </summary>
       [Display(Name ="中文名稱")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string prod_cname { get; set; }

       /// <summary>
       ///中文名稱
       /// </summary>
       [Display(Name ="中文名稱")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_sname { get; set; }

       /// <summary>
       ///標準成本
       /// </summary>
       [Display(Name ="標準成本")]
       [DisplayFormat(DataFormatString="12,5")]
       [Column(TypeName="decimal")]
       public decimal? std_cost { get; set; }

       /// <summary>
       ///最小庫存單位
       /// </summary>
       [Display(Name ="最小庫存單位")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string unit_stock { get; set; }

       /// <summary>
       ///最小銷售單位
       /// </summary>
       [Display(Name ="最小銷售單位")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string unit_sale { get; set; }

       /// <summary>
       ///全球產品群組
       /// </summary>
       [Display(Name ="全球產品群組")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string global_mpg { get; set; }

       /// <summary>
       ///產品保健代碼
       /// </summary>
       [Display(Name ="產品保健代碼")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string nhi_id { get; set; }

       /// <summary>
       ///產品類別
       /// </summary>
       [Display(Name ="產品類別")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string prod_type { get; set; }

       /// <summary>
       ///庫存類別
       /// </summary>
       [Display(Name ="庫存類別")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string inv_type { get; set; }

       /// <summary>
       ///盒裝數
       /// </summary>
       [Display(Name ="盒裝數")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? pack_size { get; set; }

       /// <summary>
       ///包裝係數
       /// </summary>
       [Display(Name ="包裝係數")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? pack_size_pri { get; set; }

       /// <summary>
       ///新產品代碼
       /// </summary>
       [Display(Name ="新產品代碼")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string new_prod_id { get; set; }

       /// <summary>
       ///是否為管制藥品
       /// </summary>
       [Display(Name ="是否為管制藥品")]
       [Column(TypeName="bit")]
       public bool? is_ctrl_drug { get; set; }

       /// <summary>
       ///健保價
       /// </summary>
       [Display(Name ="健保價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///許可證字號
       /// </summary>
       [Display(Name ="許可證字號")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string license_no { get; set; }

       /// <summary>
       ///許可證名稱
       /// </summary>
       [Display(Name ="許可證名稱")]
       [MaxLength(60)]
       [Column(TypeName="nvarchar(60)")]
       public string license_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="stock_market")]
       [Column(TypeName="int")]
       public int? stock_market { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="stock_pfizer")]
       [Column(TypeName="int")]
       public int? stock_pfizer { get; set; }

       /// <summary>
       ///安全庫存量
       /// </summary>
       [Display(Name ="安全庫存量")]
       [Column(TypeName="int")]
       public int? safty_stock { get; set; }

       /// <summary>
       ///狀態
       /// </summary>
       [Display(Name ="狀態")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string state { get; set; }

       /// <summary>
       ///是否可申請樣品
       /// </summary>
       [Display(Name ="是否可申請樣品")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status_sample { get; set; }

       /// <summary>
       ///是否可申請議價決標單
       /// </summary>
       [Display(Name ="是否可申請議價決標單")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status_bid { get; set; }

       /// <summary>
       ///輝瑞庫存狀態
       /// </summary>
       [Display(Name ="輝瑞庫存狀態")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status_stock_pfizer { get; set; }

       /// <summary>
       ///經銷商庫存狀態
       /// </summary>
       [Display(Name ="經銷商庫存狀態")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status_stock_dist { get; set; }

       /// <summary>
       ///預設所屬經銷商
       /// </summary>
       [Display(Name ="預設所屬經銷商")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string default_dist_id { get; set; }

       /// <summary>
       ///產品簡稱
       /// </summary>
       [Display(Name ="產品簡稱")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_short_name { get; set; }

       /// <summary>
       ///產品屬性-產品大類
       /// </summary>
       [Display(Name ="產品屬性-產品大類")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_category { get; set; }

       /// <summary>
       ///產品屬性-產品劑型(膠囊/針劑/藥丸)
       /// </summary>
       [Display(Name ="產品屬性-產品劑型(膠囊/針劑/藥丸)")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_form { get; set; }

       /// <summary>
       ///產品屬性-產品劑量
       /// </summary>
       [Display(Name ="產品屬性-產品劑量")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_strength { get; set; }

       /// <summary>
       ///產品屬性-劑量單位
       /// </summary>
       [Display(Name ="產品屬性-劑量單位")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_packed { get; set; }

       /// <summary>
       ///最後修改人
       /// </summary>
       [Display(Name ="最後修改人")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string Modifier { get; set; }

       /// <summary>
       ///修改時間
       /// </summary>
       [Display(Name ="修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///最後修改人id
       /// </summary>
       [Display(Name ="最後修改人id")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       /// <summary>
       ///最後修改者的委託人ID
       /// </summary>
       [Display(Name ="最後修改者的委託人ID")]
       [Column(TypeName="int")]
       public int? ModifyClientID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifierClient")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string ModifierClient { get; set; }

       
    }
}
