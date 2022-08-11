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
    [Entity(TableCnName = "viat_app_stock_dist",TableName = "Viat_app_stock_dist")]
    public partial class Viat_app_stock_dist:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Display(Name ="stock_dist_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid stock_dist_dbid { get; set; }

       /// <summary>
       ///識別碼, PK, Identity
       /// </summary>
       [Key]
       [Display(Name ="識別碼, PK, Identity")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///PKID
       /// </summary>
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///庫存上傳日期
       /// </summary>
       [Display(Name ="庫存上傳日期")]
       [Column(TypeName="date")]
       [Required(AllowEmptyStrings=false)]
       public DateTime dist_upload_date { get; set; }

       /// <summary>
       ///經銷商代碼
       /// </summary>
       [Display(Name ="經銷商代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Required(AllowEmptyStrings=false)]
       public string dist_id { get; set; }

       /// <summary>
       ///經銷商產品代碼
       /// </summary>
       [Display(Name ="經銷商產品代碼")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string dist_prod_id { get; set; }

       /// <summary>
       ///產品名稱
       /// </summary>
       [Display(Name ="產品名稱")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_name { get; set; }

       /// <summary>
       ///批次號碼
       /// </summary>
       [Display(Name ="批次號碼")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string lot_no { get; set; }

       /// <summary>
       ///期初數量
       /// </summary>
       [Display(Name ="期初數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? start_qty { get; set; }

       /// <summary>
       ///進貨淨數量
       /// </summary>
       [Display(Name ="進貨淨數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? receive_qty { get; set; }

       /// <summary>
       ///銷貨退回: 良品數量
       /// </summary>
       [Display(Name ="銷貨退回: 良品數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? return_qty { get; set; }

       /// <summary>
       ///銷貨退回: 壞品數量 Onhand 庫存
       /// </summary>
       [Display(Name ="銷貨退回: 壞品數量 Onhand 庫存")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? bad_qty { get; set; }

       /// <summary>
       ///銷貨數量
       /// </summary>
       [Display(Name ="銷貨數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? issues_qty { get; set; }

       /// <summary>
       ///樣品數量
       /// </summary>
       [Display(Name ="樣品數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? sample_qty { get; set; }

       /// <summary>
       ///調整數量
       /// </summary>
       [Display(Name ="調整數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? adjust_qty { get; set; }

       /// <summary>
       ///期末數量
       /// </summary>
       [Display(Name ="期末數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? end_qty { get; set; }

       /// <summary>
       ///暫借數量
       /// </summary>
       [Display(Name ="暫借數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? borrow_qty { get; set; }

       /// <summary>
       ///暫借銷售數量
       /// </summary>
       [Display(Name ="暫借銷售數量")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? borrow_sales { get; set; }

       /// <summary>
       ///期初日期
       /// </summary>
       [Display(Name ="期初日期")]
       [Column(TypeName="date")]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///期末日期
       /// </summary>
       [Display(Name ="期末日期")]
       [Column(TypeName="date")]
       public DateTime? end_date { get; set; }

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