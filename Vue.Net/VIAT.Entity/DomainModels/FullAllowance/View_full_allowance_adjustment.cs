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
    [Entity(TableCnName = "Full Allowance Adjustment",TableName = "View_full_allowance_adjustment")]
    public partial class View_full_allowance_adjustment:BaseEntity
    {
        /// <summary>
       ///Customer ID
       /// </summary>
       [Display(Name ="Customer ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string cust_id { get; set; }

       /// <summary>
       ///Customer
       /// </summary>
       [Display(Name ="Customer")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///Product ID
       /// </summary>
       [Display(Name ="Product ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string prod_id { get; set; }

       /// <summary>
       ///Product
       /// </summary>
       [Display(Name ="Product")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///Amount(W/T)
       /// </summary>
       [Display(Name ="Amount(W/T)")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? amount { get; set; }

       /// <summary>
       ///Remarks
       /// </summary>
       [Display(Name ="Remarks")]
       [MaxLength(256)]
       [Column(TypeName="nvarchar(256)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///Modify User
       /// </summary>
       [Display(Name ="Modify User")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///Modify Date
       /// </summary>
       [Display(Name ="Modify Date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///列名allw_sum_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名allw_sum_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid allw_sum_dbid { get; set; }

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
       ///列名action_type
       /// </summary>
       [Display(Name ="列名action_type")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Required(AllowEmptyStrings=false)]
       public string action_type { get; set; }

       /// <summary>
       ///列名allw_type
       /// </summary>
       [Display(Name ="列名allw_type")]
       [Column(TypeName="int")]
       public int? allw_type { get; set; }

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
       ///列名hpcont_dbid
       /// </summary>
       [Display(Name ="列名hpcont_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? hpcont_dbid { get; set; }

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
       ///列名dist_id
       /// </summary>
       [Display(Name ="列名dist_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string dist_id { get; set; }

       /// <summary>
       ///列名invoice_date
       /// </summary>
       [Display(Name ="列名invoice_date")]
       [Column(TypeName="datetime")]
       public DateTime? invoice_date { get; set; }

       /// <summary>
       ///列名invoice_no
       /// </summary>
       [Display(Name ="列名invoice_no")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string invoice_no { get; set; }

       /// <summary>
       ///TransDate
       /// </summary>
       [Display(Name ="TransDate")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime trans_date { get; set; }

       /// <summary>
       ///列名qty
       /// </summary>
       [Display(Name ="列名qty")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? qty { get; set; }

       /// <summary>
       ///列名status
       /// </summary>
       [Display(Name ="列名status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status { get; set; }

       /// <summary>
       ///列名o_contract_no
       /// </summary>
       [Display(Name ="列名o_contract_no")]
       [Column(TypeName="int")]
       public int? o_contract_no { get; set; }

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
       ///列名percent
       /// </summary>
       [Display(Name ="列名percent")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? percent { get; set; }

       
    }
}