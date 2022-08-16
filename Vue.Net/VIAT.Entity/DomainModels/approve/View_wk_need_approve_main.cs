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
    [Entity(TableCnName = "Work Flow Need Approve",TableName = "View_wk_need_approve_main")]
    public partial class View_wk_need_approve_main:BaseEntity
    {
        /// <summary>
       ///BId No
       /// </summary>
       [Display(Name ="BId No")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string bid_no { get; set; }

       /// <summary>
       ///Apply Type
       /// </summary>
       [Display(Name ="Apply Type")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       [Required(AllowEmptyStrings=false)]
       public string apply_type { get; set; }

       /// <summary>
       ///Territoy ID
       /// </summary>
       [Display(Name ="Territoy ID")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///Customer ID
       /// </summary>
       [Display(Name ="Customer ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cust_id { get; set; }

       /// <summary>
       ///Customer Name
       /// </summary>
       [Display(Name ="Customer Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///Group Id
       /// </summary>
       [Display(Name ="Group Id")]
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
       ///
       /// </summary>
       [Key]
       [Display(Name ="bidmast_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid bidmast_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="contstret_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? contstret_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="pricegroup_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? pricegroup_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="bid_date")]
       [Column(TypeName="datetime")]
       public DateTime? bid_date { get; set; }

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
       [Display(Name ="order_date")]
       [Column(TypeName="datetime")]
       public DateTime? order_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_type")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       public string invoice_type { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="shipto_address")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string shipto_address { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="po_no")]
       [MaxLength(32)]
       [Column(TypeName="varchar(32)")]
       public string po_no { get; set; }

       /// <summary>
       ///Remarks
       /// </summary>
       [Display(Name ="Remarks")]
       [Column(TypeName="nvarchar(max)")]
       public string remarks { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="upload")]
       [MaxLength(4000)]
       [Column(TypeName="varchar(4000)")]
       public string upload { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       public string status { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="approval_user")]
       [Column(TypeName="int")]
       public int? approval_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="approval_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string approval_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="approved_date")]
       [Column(TypeName="datetime")]
       public DateTime? approved_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///Requestor
       /// </summary>
       [Display(Name ="Requestor")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///Approve Date
       /// </summary>
       [Display(Name ="Approve Date")]
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
       [Display(Name ="modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       
    }
}