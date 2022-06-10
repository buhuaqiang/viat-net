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
    [Entity(TableCnName = "代理信息",TableName = "View_sys_deputy")]
    public partial class View_sys_deputy:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="deputy_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid deputy_dbid { get; set; }

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
       ///Deputy Id
       /// </summary>
       [Display(Name ="Deputy Id")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int deputy_user_id { get; set; }

       /// <summary>
       ///Deputy Name
       /// </summary>
       [Display(Name ="Deputy Name")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       public string emp_ename { get; set; }

       /// <summary>
       ///User Id
       /// </summary>
       [Display(Name ="User Id")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int user_id2 { get; set; }

       /// <summary>
       ///user_name2
       /// </summary>
       [Display(Name ="user_name2")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string user_name2 { get; set; }

       /// <summary>
       ///列userid
       /// </summary>
       [Display(Name ="列userid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int user_id { get; set; }

       /// <summary>
       ///created_date
       /// </summary>
       [Display(Name ="created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///dept_name
       /// </summary>
       [Display(Name ="dept_name")]
       [MaxLength(80)]
       [Column(TypeName="varchar(80)")]
       public string dept_name { get; set; }

       /// <summary>
       ///emp_cname
       /// </summary>
       [Display(Name ="emp_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string emp_cname { get; set; }

       /// <summary>
       ///UserTrueName
       /// </summary>
       [Display(Name ="UserTrueName")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string UserTrueName { get; set; }

       /// <summary>
       ///status
       /// </summary>
       [Display(Name ="status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string status { get; set; }

       
    }
}