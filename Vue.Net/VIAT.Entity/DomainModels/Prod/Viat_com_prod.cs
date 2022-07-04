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
    [Entity(TableCnName = "產品基本資料",TableName = "Viat_com_prod")]
    public partial class Viat_com_prod:BaseEntity
    {
        /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_dbid { get; set; }

       /// <summary>
       ///ID
       /// </summary>
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
       public string entity { get; set; }

       /// <summary>
       ///本地產品組DBID
       /// </summary>
       [Display(Name ="本地產品組DBID")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? localmpg_dbid { get; set; }

       /// <summary>
       ///所屬事業單位
       /// </summary>
       [Display(Name ="所屬事業單位")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///產品id
       /// </summary>
       [Display(Name ="產品id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string prod_id { get; set; }

       /// <summary>
       ///英文名稱
       /// </summary>
       [Display(Name ="英文名稱")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///中文名稱
       /// </summary>
       [Display(Name ="中文名稱")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
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
        [Editable(true)]
        public decimal? std_cost { get; set; }

       /// <summary>
       ///最小庫存單位
       /// </summary>
       [Display(Name ="最小庫存單位")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string unit_stock { get; set; }

       /// <summary>
       ///最小銷售單位
       /// </summary>
       [Display(Name ="最小銷售單位")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
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
       public string nhi_id { get; set; }

       /// <summary>
       ///產品類別
       /// </summary>
       [Display(Name ="產品類別")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
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
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
        [Editable(true)]
        public string is_ctrl_drug { get; set; }

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
       [Editable(true)]
       public string license_no { get; set; }

       /// <summary>
       ///許可證名稱
       /// </summary>
       [Display(Name ="許可證名稱")]
       [MaxLength(60)]
       [Column(TypeName="nvarchar(60)")]
       [Editable(true)]
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
       [Editable(true)]
       public int? safty_stock { get; set; }

       /// <summary>
       ///狀態
       /// </summary>
       [Display(Name ="狀態")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string state { get; set; }

       /// <summary>
       ///是否可申請樣品
       /// </summary>
       [Display(Name ="是否可申請樣品")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status_sample { get; set; }

       /// <summary>
       ///是否可申請議價決標單
       /// </summary>
       [Display(Name ="是否可申請議價決標單")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status_bid { get; set; }

       /// <summary>
       ///輝瑞庫存狀態
       /// </summary>
       [Display(Name ="輝瑞庫存狀態")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status_stock_pfizer { get; set; }

       /// <summary>
       ///經銷商庫存狀態
       /// </summary>
       [Display(Name ="經銷商庫存狀態")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status_stock_dist { get; set; }

       /// <summary>
       ///預設所屬經銷商
       /// </summary>
       [Display(Name ="預設所屬經銷商")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string default_dist_id { get; set; }

       /// <summary>
       ///產品簡稱
       /// </summary>
       [Display(Name ="產品簡稱")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
        [Editable(true)]
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
        [Editable(true)]
        public string prod_form { get; set; }

       /// <summary>
       ///產品屬性-產品劑量
       /// </summary>
       [Display(Name ="產品屬性-產品劑量")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
        [Editable(true)]
        public string prod_strength { get; set; }

       /// <summary>
       ///產品屬性-劑量單位
       /// </summary>
       [Display(Name ="產品屬性-劑量單位")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
        [Editable(true)]
        public string prod_packed { get; set; }

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
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///建立時間
       /// </summary>
       [Display(Name ="建立時間")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

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
       ///最後修改時間
       /// </summary>
       [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///建立用戶賬號
       /// </summary>
       [Display(Name ="建立用戶賬號")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///建立者的委託人賬號
       /// </summary>
       [Display(Name ="建立者的委託人賬號")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///最後修改用戶賬號
       /// </summary>
       [Display(Name ="最後修改用戶賬號")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///最後修改的委託人賬號
       /// </summary>
       [Display(Name ="最後修改的委託人賬號")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       
    }
}