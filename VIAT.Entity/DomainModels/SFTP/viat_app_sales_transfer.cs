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
using VIAT.Entity.SystemModels;

namespace VIAT.Entity.DomainModels
{
    [Entity(TableCnName = "viat_app_sales_transfer",TableName = "viat_app_sales_transfer")]
    public partial class viat_app_sales_transfer:BaseEntity
    {
        /// <summary>
       ///salestransfer_dbid
       /// </summary>
       [Display(Name ="salestransfer_dbid")]
       [JsonIgnore]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public Guid salestransfer_dbid { get; set; }

       /// <summary>
       ///dbid
       /// </summary>
       [Key]
       [Display(Name ="dbid")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///entity
       /// </summary>
       [Display(Name ="entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Editable(true)]
       public string entity { get; set; }

       /// <summary>
       ///division
       /// </summary>
       [Display(Name ="division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string division { get; set; }

       /// <summary>
       ///trans_type
       /// </summary>
       [Display(Name ="trans_type")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string trans_type { get; set; }

       /// <summary>
       ///trans_class
       /// </summary>
       [Display(Name ="trans_class")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Editable(true)]
       public string trans_class { get; set; }

       /// <summary>
       ///trans_date
       /// </summary>
       [Display(Name ="trans_date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime trans_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_no")]
       [MaxLength(10)]
       [JsonIgnore]
       [Column(TypeName="varchar(10)")]
       public string invoice_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_order_no")]
       [MaxLength(80)]
       [JsonIgnore]
       [Column(TypeName="varchar(80)")]
       public string cust_order_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="order_no")]
       [MaxLength(20)]
       [JsonIgnore]
       [Column(TypeName="varchar(20)")]
       public string order_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dist_cust_id")]
       [MaxLength(10)]
       [JsonIgnore]
       [Column(TypeName="varchar(10)")]
       public string dist_cust_id { get; set; }

       /// <summary>
       ///客戶名稱
       /// </summary>
       [Display(Name ="客戶名稱")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string cust_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dist_prod_id")]
       [MaxLength(20)]
       [JsonIgnore]
       [Column(TypeName="varchar(20)")]
       public string dist_prod_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_dbid")]
       [JsonIgnore]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_dbid")]
       [JsonIgnore]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="lot_no")]
       [MaxLength(20)]
       [JsonIgnore]
       [Column(TypeName="varchar(20)")]
       public string lot_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="price")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? price { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="qty")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? qty { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="free_qty")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? free_qty { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="amt")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? amt { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="tax")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? tax { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ai_basedate")]
       [JsonIgnore]
       [Column(TypeName="datetime")]
       public DateTime? ai_basedate { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dist_id")]
       [MaxLength(10)]
       [JsonIgnore]
       [Column(TypeName="varchar(10)")]
       public string dist_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="margin_rate")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? margin_rate { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="margin_amt")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? margin_amt { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="share_yn")]
       [MaxLength(1)]
       [JsonIgnore]
       [Column(TypeName="varchar(1)")]
       public string share_yn { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="nhi_price")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="net_price")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? net_price { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_source")]
       [MaxLength(20)]
       [JsonIgnore]
       [Column(TypeName="varchar(20)")]
       public string prod_source { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="trans_class1")]
       [MaxLength(60)]
       [JsonIgnore]
       [Column(TypeName="varchar(60)")]
       public string trans_class1 { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="year")]
       [JsonIgnore]
       [Column(TypeName="int")]
       public int? year { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="period")]
       [JsonIgnore]
       [Column(TypeName="int")]
       public int? period { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="price_dist")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? price_dist { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="unit_price")]
       [JsonIgnore]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? unit_price { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_user")]
       [JsonIgnore]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_username")]
       [MaxLength(50)]
       [JsonIgnore]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_client")]
       [JsonIgnore]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_clientusername")]
       [MaxLength(50)]
       [JsonIgnore]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_date")]
       [JsonIgnore]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_user")]
       [JsonIgnore]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_username")]
       [MaxLength(50)]
       [JsonIgnore]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_client")]
       [JsonIgnore]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_clientusername")]
       [MaxLength(50)]
       [JsonIgnore]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_date")]
       [JsonIgnore]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? invoice_price { get; set; }

       
    }
}
