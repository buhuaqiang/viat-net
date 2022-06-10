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
    [Entity(TableCnName = "代理人pop框",TableName = "View_sys_deputy_pop")]
    public partial class View_sys_deputy_pop:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="user_id")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int user_id { get; set; }

       /// <summary>
       ///UserName
       /// </summary>
       [Display(Name ="UserName")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string user_name { get; set; }

       /// <summary>
       ///Department Name
       /// </summary>
       [Display(Name ="Department Name")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string dept_name { get; set; }

       /// <summary>
       ///E-Name
       /// </summary>
       [Display(Name ="E-Name")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string emp_ename { get; set; }

       /// <summary>
       ///C-Name
       /// </summary>
       [Display(Name ="C-Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string emp_cname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateDate")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       
    }
}