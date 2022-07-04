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
    [Entity(TableCnName = "客戶送貨地址信息視圖",TableName = "View_com_cust_delivery")]
    public partial class View_com_cust_delivery:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="delivery_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid delivery_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dbid")]
       [Column(TypeName="numeric")]
       [Required(AllowEmptyStrings=false)]
       public decimal dbid { get; set; }

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
       ///
       /// </summary>
       [Display(Name ="cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="zip_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string zip_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="seq_no")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? seq_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="delivery_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string delivery_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="delivery_contact")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string delivery_contact { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="delivery_tel_no")]
       [MaxLength(60)]
       [Column(TypeName="varchar(60)")]
       [Editable(true)]
       public string delivery_tel_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="delivery_addr")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string delivery_addr { get; set; }

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
       [Display(Name ="city_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string city_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="zip_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string zip_name { get; set; }

       
    }
}