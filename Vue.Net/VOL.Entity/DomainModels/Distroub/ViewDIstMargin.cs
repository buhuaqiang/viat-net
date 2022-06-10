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
    [Entity(TableCnName = "經銷商margin查詢視圖",TableName = "ViewDistMargin")]
[Table("ViewDistMargin")]
    public partial class ViewDIstMargin:BaseEntity
    {
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
       [Display(Name ="dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

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
       [Display(Name ="division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///Distributor
       /// </summary>
       [Display(Name ="Distributor")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Required(AllowEmptyStrings=false)]
       public string dist_id { get; set; }

       /// <summary>
       ///Margin Type
       /// </summary>
       [Display(Name ="Margin Type")]
       [Column(TypeName="int")]
       public int? margin_value_type { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="margin_value")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? margin_value { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_id_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_id_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="mpg_id_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? mpg_id_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="channel")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string channel { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="start_date")]
       [Column(TypeName="datetime")]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="end_date")]
       [Column(TypeName="datetime")]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_id_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_id_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cust_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

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
       [Display(Name ="prod_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_ename")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="sys_value")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string sys_value { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="doh_type_ename")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string doh_type_ename { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="emp_ename")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string emp_ename { get; set; }

       
    }
}