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
    [Entity(TableCnName = "經銷商客戶對應",TableName = "View_com_dist")]
    public partial class View_com_dist:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="dist_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid dist_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateID")]
       [Column(TypeName="int")]
       public int? CreateID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateClient")]
       [Column(TypeName="int")]
       public int? CreateClient { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateDate")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyID")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyClient")]
       [Column(TypeName="int")]
       public int? ModifyClient { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyDate")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///Entity
       /// </summary>
       [Display(Name ="Entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string entity { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///Dist ID
       /// </summary>
       [Display(Name ="Dist ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string dist_id { get; set; }

       /// <summary>
       ///Distributor
       /// </summary>
       [Display(Name ="Distributor")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string sys_value { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string status { get; set; }

       /// <summary>
       ///Viatris CustID
       /// </summary>
       [Display(Name ="Viatris CustID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_dbid { get; set; }

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
       [Display(Name ="status1")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status1 { get; set; }

       
    }
}