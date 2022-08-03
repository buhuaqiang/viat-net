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
    [Entity(TableCnName = "All Bid Order Apply",TableName = "View_order_apply")]
    public partial class View_order_apply:BaseEntity
    {
        /// <summary>
       ///列名bidmast_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名bidmast_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid bidmast_dbid { get; set; }

       /// <summary>
       ///Bid No
       /// </summary>
       [Display(Name ="Bid No")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string bid_no { get; set; }

       /// <summary>
       ///Apply Type
       /// </summary>
       [Display(Name ="Apply Type")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string apply_type { get; set; }

       /// <summary>
       ///Bid Date
       /// </summary>
       [Display(Name ="Bid Date")]
       [Column(TypeName="date")]
       [Editable(true)]
       public DateTime? bid_date { get; set; }

       /// <summary>
       ///Start Date
       /// </summary>
       [Display(Name ="Start Date")]
       [Column(TypeName="date")]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="date")]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///Remarks
       /// </summary>
       [Display(Name ="Remarks")]
       [Column(TypeName="nvarchar(max)")]
       public string remarks { get; set; }

       /// <summary>
       ///Upload
       /// </summary>
       [Display(Name ="Upload")]
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
       ///Cust Id
       /// </summary>
       [Display(Name ="Cust Id")]
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
       ///Is group
       /// </summary>
       [Display(Name ="Is group")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string isgroup { get; set; }

       /// <summary>
       ///Qty
       /// </summary>
       [Display(Name ="Qty")]
       [Column(TypeName="int")]
       public int? qty { get; set; }

       /// <summary>
       ///Prod Id
       /// </summary>
       [Display(Name ="Prod Id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_id { get; set; }

       /// <summary>
       ///Prod Name
       /// </summary>
       [Display(Name ="Prod Name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///列名ordetail_dbid
       /// </summary>
       [Display(Name ="列名ordetail_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? ordetail_dbid { get; set; }

       /// <summary>
       ///列名cont_stretagy_name
       /// </summary>
       [Display(Name ="列名cont_stretagy_name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string cont_stretagy_name { get; set; }

       /// <summary>
       ///列名cont_stretagy_id
       /// </summary>
       [Display(Name ="列名cont_stretagy_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cont_stretagy_id { get; set; }

       /// <summary>
       ///列名group_name
       /// </summary>
       [Display(Name ="列名group_name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string group_name { get; set; }

       /// <summary>
       ///列名group_id
       /// </summary>
       [Display(Name ="列名group_id")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string group_id { get; set; }

       /// <summary>
       ///列名approved_date
       /// </summary>
       [Display(Name ="列名approved_date")]
       [Column(TypeName="datetime")]
       public DateTime? approved_date { get; set; }

       /// <summary>
       ///列名modified_date
       /// </summary>
       [Display(Name ="列名modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///列名modified_clientusername
       /// </summary>
       [Display(Name ="列名modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///列名modified_client
       /// </summary>
       [Display(Name ="列名modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///列名modified_username
       /// </summary>
       [Display(Name ="列名modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///列名modified_user
       /// </summary>
       [Display(Name ="列名modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///列名created_date
       /// </summary>
       [Display(Name ="列名created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///列名created_clientusername
       /// </summary>
       [Display(Name ="列名created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///列名created_client
       /// </summary>
       [Display(Name ="列名created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///列名created_username
       /// </summary>
       [Display(Name ="列名created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///列名created_user
       /// </summary>
       [Display(Name ="列名created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///列名approval_username
       /// </summary>
       [Display(Name ="列名approval_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string approval_username { get; set; }

       /// <summary>
       ///列名approval_user
       /// </summary>
       [Display(Name ="列名approval_user")]
       [Column(TypeName="int")]
       public int? approval_user { get; set; }

       /// <summary>
       ///列名po_no
       /// </summary>
       [Display(Name ="列名po_no")]
       [MaxLength(32)]
       [Column(TypeName="varchar(32)")]
       public string po_no { get; set; }

       /// <summary>
       ///列名shipto_address
       /// </summary>
       [Display(Name ="列名shipto_address")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string shipto_address { get; set; }

       /// <summary>
       ///列名invoice_type
       /// </summary>
       [Display(Name ="列名invoice_type")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       public string invoice_type { get; set; }

       /// <summary>
       ///列名order_date
       /// </summary>
       [Display(Name ="列名order_date")]
       [Column(TypeName="date")]
       public DateTime? order_date { get; set; }

       /// <summary>
       ///列名territory_id
       /// </summary>
       [Display(Name ="列名territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///列名cust_dbid
       /// </summary>
       [Display(Name ="列名cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///列名pricegroup_dbid
       /// </summary>
       [Display(Name ="列名pricegroup_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? pricegroup_dbid { get; set; }

       /// <summary>
       ///列名contstret_dbid
       /// </summary>
       [Display(Name ="列名contstret_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? contstret_dbid { get; set; }

       
    }
}