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
    [Entity(TableCnName = "消息模板設置",TableName = "View_com_notify_template")]
    public partial class View_com_notify_template:BaseEntity
    {
        /// <summary>
       ///列名notifytemp_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名notifytemp_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid notifytemp_dbid { get; set; }

       /// <summary>
       ///列名created_date
       /// </summary>
       [Display(Name ="列名created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///列名modified_user
       /// </summary>
       [Display(Name ="列名modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///Notify Id
       /// </summary>
       [Display(Name ="Notify Id")]
       [MaxLength(4)]
       [Column(TypeName="varchar(4)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string notify_id { get; set; }

       /// <summary>
       ///Sender
       /// </summary>
       [Display(Name ="Sender")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string sender { get; set; }

       /// <summary>
       ///Subject
       /// </summary>
       [Display(Name ="Subject")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string subject { get; set; }

       /// <summary>
       ///列名entity
       /// </summary>
       [Display(Name ="列名entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///Recipient
       /// </summary>
       [Display(Name ="Recipient")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string recipient { get; set; }

       /// <summary>
       ///Cc
       /// </summary>
       [Display(Name ="Cc")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string cc { get; set; }

       /// <summary>
       ///Bcc
       /// </summary>
       [Display(Name ="Bcc")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string bcc { get; set; }

       /// <summary>
       ///Remarks
       /// </summary>
       [Display(Name ="Remarks")]
       [MaxLength(450)]
       [Column(TypeName="nvarchar(450)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///列名modified_username
       /// </summary>
       [Display(Name ="列名modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

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
       ///列名function_id
       /// </summary>
       [Display(Name ="列名function_id")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       //[Required(AllowEmptyStrings=false)]
       public string function_id { get; set; }

       /// <summary>
       ///列名content
       /// </summary>
       [Display(Name ="列名content")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       [Editable(true)]
       public string content { get; set; }

       /// <summary>
       ///列名emp_cname
       /// </summary>
       [Display(Name ="列名emp_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string emp_cname { get; set; }

       /// <summary>
       ///列名row_number
       /// </summary>
       [Display(Name ="列名row_number")]
       [Column(TypeName="bigint")]
       public long? row_number { get; set; }

       
    }
}