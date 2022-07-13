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
    [Entity(TableCnName = "Full Allowance Reverse",TableName = "View_full_allowance_main")]
    public partial class View_full_allowance_main:BaseEntity
    {
        /// <summary>
       ///Contract No
       /// </summary>
       [Display(Name ="Contract No")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string contract_no { get; set; }

       /// <summary>
       ///GroupID
       /// </summary>
       [Display(Name ="GroupID")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string group_id { get; set; }

       /// <summary>
       ///GroupName
       /// </summary>
       [Display(Name ="GroupName")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Required(AllowEmptyStrings=false)]
       public string group_name { get; set; }

       /// <summary>
       ///CustID
       /// </summary>
       [Display(Name ="CustID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Required(AllowEmptyStrings=false)]
       public string cust_id { get; set; }

       /// <summary>
       ///CustName
       /// </summary>
       [Display(Name ="CustName")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Required(AllowEmptyStrings=false)]
       public string cust_name { get; set; }

       /// <summary>
       ///Effective Date
       /// </summary>
       [Display(Name ="Effective Date")]
       [Column(TypeName= "varchar")]
       [Required(AllowEmptyStrings=false)]
       public DateTime start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName= "varchar")]
       [Required(AllowEmptyStrings=false)]
       public DateTime end_date { get; set; }

       /// <summary>
       ///Accrue Amount
       /// </summary>
       [Display(Name ="Accrue Amount")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int accrue_amt { get; set; }

       /// <summary>
       ///Reverse Amount
       /// </summary>
       [Display(Name ="Reverse Amount")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int c2 { get; set; }

       /// <summary>
       ///Adjustment Amount
       /// </summary>
       [Display(Name ="Adjustment Amount")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int c3 { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Required(AllowEmptyStrings=false)]
       public string status { get; set; }

       /// <summary>
       ///pricegroup_dbid
       /// </summary>
       [Display(Name ="pricegroup_dbid")]
       [Column(TypeName= "varchar")]
       [Required(AllowEmptyStrings=false)]
       public Guid pricegroup_dbid { get; set; }

       /// <summary>
       ///cust_dbid
       /// </summary>
       [Display(Name ="cust_dbid")]
       [Column(TypeName= "varchar")]
       [Required(AllowEmptyStrings=false)]
       public Guid cust_dbid { get; set; }

       /// <summary>
       ///cf_prod_dbid
       /// </summary>
       [Display(Name ="cf_prod_dbid")]
       [Column(TypeName= "varchar")]
       [Required(AllowEmptyStrings=false)]
       public Guid cf_prod_dbid { get; set; }

       /// <summary>
       ///cf_prod_id
       /// </summary>
       [Display(Name ="cf_prod_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Required(AllowEmptyStrings=false)]
       public string cf_prod_id { get; set; }

       /// <summary>
       ///cf_prod_name
       /// </summary>
       [Display(Name ="cf_prod_name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Required(AllowEmptyStrings=false)]
       public string cf_prod_name { get; set; }

       /// <summary>
       ///cp_prod_dbid
       /// </summary>
       [Display(Name ="cp_prod_dbid")]
       [Column(TypeName= "varchar")]
       [Required(AllowEmptyStrings=false)]
       public Guid cp_prod_dbid { get; set; }

       /// <summary>
       ///cp_prod_id
       /// </summary>
       [Display(Name ="cp_prod_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Required(AllowEmptyStrings=false)]
       public string cp_prod_id { get; set; }

       /// <summary>
       ///cp_prod_name
       /// </summary>
       [Display(Name ="cp_prod_name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Required(AllowEmptyStrings=false)]
       public string cp_prod_name { get; set; }

       /// <summary>
       ///列allw_accrue_dbid
       /// </summary>
       [Key]
       [Display(Name ="列allw_accrue_dbid")]
       [Column(TypeName= "varchar")]
       [Required(AllowEmptyStrings=false)]
       public Guid allw_accrue_dbid { get; set; }

       /// <summary>
       ///列created_date
       /// </summary>
       [Display(Name ="列created_date")]
       [Column(TypeName= "varchar")]
       [Required(AllowEmptyStrings=false)]
       public DateTime created_date { get; set; }

         /// <summary>
       ///列名hpcont_dbid
       /// </summary>
       [Display(Name ="列名hpcont_dbid")]
       [Column(TypeName="varchar")]
       [Required(AllowEmptyStrings=false)]
       public Guid hpcont_dbid { get; set; }
       

       
    }
}