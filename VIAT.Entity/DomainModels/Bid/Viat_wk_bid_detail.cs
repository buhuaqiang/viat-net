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
    [Entity(TableCnName = "viat_wk_bid_detail主表",TableName = "Viat_wk_bid_detail")]
    public partial class Viat_wk_bid_detail:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="bidetail_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid bidetail_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="bidmast_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? bidmast_dbid { get; set; }

       /// <summary>
       ///PKID
       /// </summary>
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="nhi_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal nhi_price { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? invoice_price { get; set; }

       /// <summary>
       ///最近的售價
       /// </summary>
       [Display(Name ="最近的售價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal net_price { get; set; }

       /// <summary>
       ///擬售價
       /// </summary>
       [Display(Name ="擬售價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal bid_price { get; set; }

       /// <summary>
       ///審批決標價
       /// </summary>
       [Display(Name ="審批決標價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal price_close { get; set; }

       /// <summary>
       ///凈售價
       /// </summary>
       [Display(Name ="凈售價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? reserv_price { get; set; }

       /// <summary>
       ///最小售量
       /// </summary>
       [Display(Name ="最小售量")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int min_qty { get; set; }

       /// <summary>
       ///FG%
       /// </summary>
       [Display(Name ="FG%")]
       [DisplayFormat(DataFormatString="18,2")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal allowance { get; set; }

       /// <summary>
       ///DIS%
       /// </summary>
       [Display(Name ="DIS%")]
       [DisplayFormat(DataFormatString="18,2")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal discount { get; set; }

       /// <summary>
       ///終審后 FG
       /// </summary>
       [Display(Name ="終審后 FG")]
       [DisplayFormat(DataFormatString="18,2")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal final_allowance { get; set; }

       /// <summary>
       ///終審后的DIS
       /// </summary>
       [Display(Name ="終審后的DIS")]
       [DisplayFormat(DataFormatString="18,2")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal final_discount { get; set; }

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