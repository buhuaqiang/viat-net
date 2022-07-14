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
    [Entity(TableCnName = "Dustibutor Margin Rate Maintain",TableName = "view_dist_margin")]
    public partial class view_dist_margin:BaseEntity
    {
        /// <summary>
       ///Distributor
       /// </summary>
       [Display(Name ="Distributor")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string dist_id { get; set; }

       /// <summary>
       ///Dist Name
       /// </summary>
       [Display(Name ="Dist Name")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string sys_value { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///Prod ID
       /// </summary>
       [Display(Name ="Prod ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string prod_id { get; set; }

       /// <summary>
       ///Prod Name
       /// </summary>
       [Display(Name ="Prod Name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///Product
       /// </summary>
       [Display(Name ="Product")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbidname { get; set; }

       /// <summary>
       ///Customer
       /// </summary>
       [Display(Name ="Customer")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbidname { get; set; }

       /// <summary>
       ///Channel
       /// </summary>
       [Display(Name ="Channel")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string channel { get; set; }

       /// <summary>
       ///Channel Description
       /// </summary>
       [Display(Name ="Channel Description")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string doh_type_ename { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///Cust ID
       /// </summary>
       [Display(Name ="Cust ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string cust_id { get; set; }

       /// <summary>
       ///Cust Name
       /// </summary>
       [Display(Name ="Cust Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///Margin Type
       /// </summary>
       [Display(Name ="Margin Type")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? margin_value_type { get; set; }

       /// <summary>
       ///Margin Rate/Price
       /// </summary>
       [Display(Name ="Margin Rate/Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? margin_value { get; set; }

       /// <summary>
       ///Start Date
       /// </summary>
       [Display(Name ="Start Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="mpg_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string mpg_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="mpg_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string mpg_name { get; set; }

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
       [Display(Name ="division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="distmargin_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid distmargin_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="remarks")]
       [MaxLength(256)]
       [Column(TypeName="nvarchar(256)")]
       public string remarks { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///Customers
       /// </summary>
       [Display(Name ="Customers")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string custs { get; set; }

       /// <summary>
       ///Products
       /// </summary>
       [Display(Name ="Products")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string prods { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="localmpg_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? localmpg_dbid { get; set; }

       
    }
}