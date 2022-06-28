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
    [Entity(TableCnName = "產品幣別視圖",TableName = "View_prod_entity_period")]
    public partial class View_prod_entity_period:BaseEntity
    {
        /// <summary>
       ///Product ID
       /// </summary>
       [Display(Name ="Product ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string prod_id { get; set; }

       /// <summary>
       ///Entity
       /// </summary>
       [Display(Name ="Entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Editable(true)]
       public string entity { get; set; }

       /// <summary>
       ///Start Date
       /// </summary>
       [Display(Name ="Start Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime end_date { get; set; }

       /// <summary>
       ///Last Modified
       /// </summary>
       [Display(Name ="Last Modified")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       public string emp_ename { get; set; }

       /// <summary>
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="period_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid period_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

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
       [Display(Name ="prod_ename")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string prod_ename { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_cname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_sname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_sname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="emp_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string emp_cname { get; set; }

       /// <summary>
       ///Product ID
       /// </summary>
       [Display(Name ="Product ID")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_dbidname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       
    }
}