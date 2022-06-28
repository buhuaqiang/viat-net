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
    [Entity(TableCnName = "客戶價格明細主页面",TableName = "View_cust_price_detail")]
    public partial class View_cust_price_detail:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="pricedetail_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid pricedetail_dbid { get; set; }

       /// <summary>
       ///Cust ID
       /// </summary>
       [Display(Name ="Cust ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cust_id { get; set; }

       /// <summary>
       ///Cust Name
       /// </summary>
       [Display(Name ="Cust Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="source_type")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string source_type { get; set; }

       /// <summary>
       ///Group ID
       /// </summary>
       [Display(Name ="Group ID")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string group_id { get; set; }

       /// <summary>
       ///Group Name
       /// </summary>
       [Display(Name ="Group Name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string group_name { get; set; }

       /// <summary>
       ///Cust
       /// </summary>
       [Display(Name ="Cust")]
       [MaxLength(111)]
       [Column(TypeName="nvarchar(111)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_dbidname { get; set; }

       /// <summary>
       ///Product ID
       /// </summary>
       [Display(Name ="Product ID")]
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
       ///Product
       /// </summary>
       [Display(Name ="Product")]
       [MaxLength(66)]
       [Column(TypeName="varchar(66)")]
       [Editable(true)]
       public string prod_dbidname { get; set; }

       /// <summary>
       ///NHI Price
       /// </summary>
       [Display(Name ="NHI Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public decimal nhi_price { get; set; }

       /// <summary>
       ///Invoice Price
       /// </summary>
       [Display(Name ="Invoice Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public decimal invoice_price { get; set; }

       /// <summary>
       ///Net Price
       /// </summary>
       [Display(Name ="Net Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public decimal net_price { get; set; }

       /// <summary>
       ///Gross Price
       /// </summary>
       [Display(Name ="Gross Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? gross_price { get; set; }

       /// <summary>
       ///Min Qty
       /// </summary>
       [Display(Name ="Min Qty")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? min_qty { get; set; }

       /// <summary>
       ///status
       /// </summary>
       [Display(Name ="status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///Start Date
       /// </summary>
       [Display(Name ="Start Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime end_date { get; set; }

       /// <summary>
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Remarks
       /// </summary>
       [Display(Name ="Remarks")]
       [MaxLength(256)]
       [Column(TypeName="nvarchar(256)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="state")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string state { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_group_status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string cust_group_status { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="emp_ename")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string emp_ename { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="custStatus")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string custStatus { get; set; }

       /// <summary>
       ///Products
       /// </summary>
       [Display(Name ="Products")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string prods { get; set; }

       /// <summary>
       ///Bid NO
       /// </summary>
       [Display(Name ="Bid NO")]
       [MaxLength(16)]
       [Column(TypeName="varchar(16)")]
       [Editable(true)]
       public string bid_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? cust_dbid { get; set; }

       
    }
}