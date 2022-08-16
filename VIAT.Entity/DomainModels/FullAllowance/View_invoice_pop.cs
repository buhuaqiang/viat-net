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
    [Entity(TableCnName = "invoicePop框",TableName = "View_invoice_pop")]
    public partial class View_invoice_pop:BaseEntity
    {
        /// <summary>
       ///列名salestransfer_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名salestransfer_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid salestransfer_dbid { get; set; }

       /// <summary>
       ///列名entity
       /// </summary>
       [Display(Name ="列名entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///列名division
       /// </summary>
       [Display(Name ="列名division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///列名trans_type
       /// </summary>
       [Display(Name ="列名trans_type")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Required(AllowEmptyStrings=false)]
       public string trans_type { get; set; }

       /// <summary>
       ///列名trans_class
       /// </summary>
       [Display(Name ="列名trans_class")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string trans_class { get; set; }

       /// <summary>
       ///Invoice Date
       /// </summary>
       [Display(Name ="Invoice Date")]
       [Column(TypeName="datetime")]
       [Required(AllowEmptyStrings=false)]
       public DateTime trans_date { get; set; }

       /// <summary>
       ///Invoice No
       /// </summary>
       [Display(Name ="Invoice No")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string invoice_no { get; set; }

       /// <summary>
       ///列名cust_order_no
       /// </summary>
       [Display(Name ="列名cust_order_no")]
       [MaxLength(80)]
       [Column(TypeName="varchar(80)")]
       public string cust_order_no { get; set; }

       /// <summary>
       ///列名order_no
       /// </summary>
       [Display(Name ="列名order_no")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string order_no { get; set; }

       /// <summary>
       ///列名dist_cust_id
       /// </summary>
       [Display(Name ="列名dist_cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string dist_cust_id { get; set; }

       /// <summary>
       ///列名cust_name
       /// </summary>
       [Display(Name ="列名cust_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string cust_name { get; set; }

       /// <summary>
       ///列名dist_prod_id
       /// </summary>
       [Display(Name ="列名dist_prod_id")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string dist_prod_id { get; set; }

       /// <summary>
       ///列名prod_dbid
       /// </summary>
       [Display(Name ="列名prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///列名cust_dbid
       /// </summary>
       [Display(Name ="列名cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///列名lot_no
       /// </summary>
       [Display(Name ="列名lot_no")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string lot_no { get; set; }

       /// <summary>
       ///列名price
       /// </summary>
       [Display(Name ="列名price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? price { get; set; }

       /// <summary>
       ///列名qty
       /// </summary>
       [Display(Name ="列名qty")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? qty { get; set; }

       /// <summary>
       ///列名free_qty
       /// </summary>
       [Display(Name ="列名free_qty")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? free_qty { get; set; }

       /// <summary>
       ///列名amt
       /// </summary>
       [Display(Name ="列名amt")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? amt { get; set; }

       /// <summary>
       ///列名tax
       /// </summary>
       [Display(Name ="列名tax")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? tax { get; set; }

       /// <summary>
       ///列名ai_basedate
       /// </summary>
       [Display(Name ="列名ai_basedate")]
       [Column(TypeName="datetime")]
       public DateTime? ai_basedate { get; set; }

       /// <summary>
       ///列名dist_id
       /// </summary>
       [Display(Name ="列名dist_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string dist_id { get; set; }

       /// <summary>
       ///列名margin_rate
       /// </summary>
       [Display(Name ="列名margin_rate")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? margin_rate { get; set; }

       /// <summary>
       ///列名margin_amt
       /// </summary>
       [Display(Name ="列名margin_amt")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? margin_amt { get; set; }

       /// <summary>
       ///列名share_yn
       /// </summary>
       [Display(Name ="列名share_yn")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string share_yn { get; set; }

       /// <summary>
       ///列名nhi_price
       /// </summary>
       [Display(Name ="列名nhi_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///列名net_price
       /// </summary>
       [Display(Name ="列名net_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? net_price { get; set; }

       /// <summary>
       ///列名prod_source
       /// </summary>
       [Display(Name ="列名prod_source")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string prod_source { get; set; }

       /// <summary>
       ///列名trans_class1
       /// </summary>
       [Display(Name ="列名trans_class1")]
       [MaxLength(60)]
       [Column(TypeName="varchar(60)")]
       public string trans_class1 { get; set; }

       /// <summary>
       ///列名year
       /// </summary>
       [Display(Name ="列名year")]
       [Column(TypeName="int")]
       public int? year { get; set; }

       /// <summary>
       ///列名period
       /// </summary>
       [Display(Name ="列名period")]
       [Column(TypeName="int")]
       public int? period { get; set; }

       /// <summary>
       ///列名price_dist
       /// </summary>
       [Display(Name ="列名price_dist")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? price_dist { get; set; }

       /// <summary>
       ///列名created_user
       /// </summary>
       [Display(Name ="列名created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///列名created_username
       /// </summary>
       [Display(Name ="列名created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///列名created_client
       /// </summary>
       [Display(Name ="列名created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///列名created_clientusername
       /// </summary>
       [Display(Name ="列名created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///列名created_date
       /// </summary>
       [Display(Name ="列名created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///列名modified_user
       /// </summary>
       [Display(Name ="列名modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///列名modified_username
       /// </summary>
       [Display(Name ="列名modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///列名modified_client
       /// </summary>
       [Display(Name ="列名modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///列名modified_clientusername
       /// </summary>
       [Display(Name ="列名modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///列名modified_date
       /// </summary>
       [Display(Name ="列名modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Product Id
       /// </summary>
       [Display(Name ="Product Id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_id { get; set; }

       /// <summary>
       ///Product Name
       /// </summary>
       [Display(Name ="Product Name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///Customer Id
       /// </summary>
       [Display(Name ="Customer Id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cust_id { get; set; }

       /// <summary>
       ///Customer Name
       /// </summary>
       [Display(Name ="Customer Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name1 { get; set; }

       /// <summary>
       ///unit_price
       /// </summary>
       [Display(Name ="unit_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? unit_price { get; set; }

       
    }
}