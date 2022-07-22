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
    [Entity(TableCnName = "Import Bid Order",TableName = "View_cust_order_transfer")]
    public partial class View_cust_order_transfer:BaseEntity
    {
        /// <summary>
       ///Bid NO
       /// </summary>
       [Display(Name ="Bid NO")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string bid_no { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string state { get; set; }

       /// <summary>
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Apply Date
       /// </summary>
       [Display(Name ="Apply Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? created_date { get; set; }

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
       ///Prod ID
       /// </summary>
       [Display(Name ="Prod ID")]
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
       ///Qty
       /// </summary>
       [Display(Name ="Qty")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? qty { get; set; }

       /// <summary>
       ///Requstor
       /// </summary>
       [Display(Name ="Requstor")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string requestor_name { get; set; }

       /// <summary>
       ///Note
       /// </summary>
       [Display(Name ="Note")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       public string note { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="order_transfer_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid order_transfer_dbid { get; set; }

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
       [Display(Name ="requestor")]
       [Column(TypeName="int")]
       public int? requestor { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="order_no")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string order_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///Transfer Date
       /// </summary>
       [Display(Name ="Transfer Date")]
       [Column(TypeName="datetime")]
       public DateTime? transfer_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

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
       ///Mpg
       /// </summary>
       [Display(Name ="Mpg")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string mpg_name { get; set; }

       /// <summary>
       ///Requstor
       /// </summary>
       [Display(Name ="Requstor")]
       [MaxLength(56)]
       [Column(TypeName="nvarchar(56)")]
       public string requestorName { get; set; }

       
    }
}