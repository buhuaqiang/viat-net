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
    [Entity(TableCnName = "view_invoice_finder",TableName = "View_invoice_finder")]
    public partial class View_invoice_finder:BaseEntity
    {
        /// <summary>
       ///列名invoice_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名invoice_dbid")]
       [Column(TypeName="varchar")]
       [Required(AllowEmptyStrings=false)]
       public Guid invoice_dbid { get; set; }

       /// <summary>
       ///列名entity
       /// </summary>
       [Display(Name ="列名entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///列名dividion
       /// </summary>
       [Display(Name ="列名dividion")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string dividion { get; set; }

       /// <summary>
       ///列名distributor
       /// </summary>
       [Display(Name ="列名distributor")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string distributor { get; set; }

       /// <summary>
       ///列名invoice_start_date
       /// </summary>
       [Display(Name ="列名invoice_start_date")]
       [Column(TypeName="varchar")]
       public DateTime? invoice_start_date { get; set; }

       /// <summary>
       ///列名invoice_end_date
       /// </summary>
       [Display(Name ="列名invoice_end_date")]
       [Column(TypeName="varchar")]
       public DateTime? invoice_end_date { get; set; }

       /// <summary>
       ///列名pay_ment_date
       /// </summary>
       [Display(Name ="列名pay_ment_date")]
       [Column(TypeName="varchar")]
       public DateTime? pay_ment_date { get; set; }

       /// <summary>
       ///列名allw_account_code
       /// </summary>
       [Display(Name ="列名allw_account_code")]
       [MaxLength(12)]
       [Column(TypeName="varchar(12)")]
       public string allw_account_code { get; set; }

       /// <summary>
       ///Prod Id
       /// </summary>
       [Display(Name ="Prod Id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string prod_id { get; set; }

       /// <summary>
       ///Prod Name
       /// </summary>
       [Display(Name ="Prod Name")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///Amount
       /// </summary>
       [Display(Name ="Amount")]
       [Column(TypeName="int")]
       public int? amount { get; set; }

       /// <summary>
       ///Allw.SOType
       /// </summary>
       [Display(Name ="Allw.SOType")]
       [MaxLength(2)]
       [Column(TypeName="varchar(4)")]
       public string allw_so_type { get; set; }

       /// <summary>
       ///Allw.Type
       /// </summary>
       [Display(Name ="Allw.Type")]
       [MaxLength(2)]
       [Column(TypeName="varchar(4)")]
       public string allw_type { get; set; }

       /// <summary>
       ///Est.Invoice
       /// </summary>
       [Display(Name ="Est.Invoice")]
       [MaxLength(4)]
       [Column(TypeName="varchar(4)")]
       public string est_invoice { get; set; }

       /// <summary>
       ///Est.Invoice.Date
       /// </summary>
       [Display(Name ="Est.Invoice.Date")]
       [Column(TypeName="varchar")]
       public DateTime? est_invoice_date { get; set; }

       /// <summary>
       ///Final.Invoice
       /// </summary>
       [Display(Name ="Final.Invoice")]
       [MaxLength(4)]
       [Column(TypeName="varchar(4)")]
       public string final_invoice { get; set; }

       /// <summary>
       ///Final.Invoice.Date
       /// </summary>
       [Display(Name ="Final.Invoice.Date")]
       [Column(TypeName="varchar")]
       public DateTime? final_invoice_date { get; set; }

       /// <summary>
       ///列名created_date
       /// </summary>
       [Display(Name ="列名created_date")]
       [Column(TypeName="varchar")]
       public DateTime? created_date { get; set; }

        /// <summary>
        ///CSVFile
        /// </summary>
        [Display(Name = "CSVFile")]
        [MaxLength(4000)]
        [Column(TypeName = "varchar(4000)")]
        public string select_file { get; set; }

    }
}