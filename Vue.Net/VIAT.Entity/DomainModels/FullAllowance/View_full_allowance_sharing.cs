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
    [Entity(TableCnName = "Full Allowance Sharing",TableName = "View_full_allowance_sharing")]
    public partial class View_full_allowance_sharing:BaseEntity
    {
        /// <summary>
       ///K1
       /// </summary>
       [Display(Name ="K1")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? K1 { get; set; }

       /// <summary>
       ///K2
       /// </summary>
       [Display(Name ="K2")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? K2 { get; set; }

       /// <summary>
       ///A1
       /// </summary>
       [Display(Name ="A1")]
       [DisplayFormat(DataFormatString="38,5")]
       [Column(TypeName="decimal")]
       public decimal? A1 { get; set; }

       /// <summary>
       ///sum_hpcont_dbid
       /// </summary>
       [Key]
       [Display(Name ="sum_hpcont_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid sum_hpcont_dbid { get; set; }

       /// <summary>
       ///Customer ID
       /// </summary>
       [Display(Name ="Customer ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cust_id { get; set; }

       /// <summary>
       ///Customer
       /// </summary>
       [Display(Name ="Customer")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///status
       /// </summary>
       [Display(Name ="status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status { get; set; }

       /// <summary>
       ///Product ID
       /// </summary>
       [Display(Name ="Product ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_id { get; set; }

       /// <summary>
       ///Product
       /// </summary>
       [Display(Name ="Product")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///state
       /// </summary>
       [Display(Name ="state")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string state { get; set; }

       /// <summary>
       ///Sharing amount
       /// </summary>
       [Display(Name ="Sharing amount")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? amount { get; set; }

       /// <summary>
       ///Sharing %
       /// </summary>
       [Display(Name ="Sharing %")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? percent { get; set; }

       /// <summary>
       ///hpcont_dbid
       /// </summary>
       [Display(Name ="hpcont_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? hpcont_dbid { get; set; }

       
    }
}