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
    [Entity(TableCnName = "Margin Period Close",TableName = "View_com_close_period_margin")]
    public partial class View_com_close_period_margin:BaseEntity
    {
        /// <summary>
       ///年度
       /// </summary>
       [Display(Name ="年度")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int year { get; set; }

       /// <summary>
       ///期間
       /// </summary>
       [Display(Name ="期間")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int period { get; set; }

       /// <summary>
       ///Margin起始日期
       /// </summary>
       [Display(Name ="Margin起始日期")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? m_start_date { get; set; }

       /// <summary>
       ///Margin結束日期
       /// </summary>
       [Display(Name ="Margin結束日期")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? m_end_date { get; set; }

       /// <summary>
       ///會計帳起始日期
       /// </summary>
       [Display(Name ="會計帳起始日期")]
       [Column(TypeName="datetime")]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///會計帳結束日期
       /// </summary>
       [Display(Name ="會計帳結束日期")]
       [Column(TypeName="datetime")]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid period_dbid { get; set; }

       /// <summary>
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///建立時間
       /// </summary>
       [Display(Name ="建立時間")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///Sales 會計帳結束日期
       /// </summary>
       [Display(Name ="Sales 會計帳結束日期")]
       [Column(TypeName="datetime")]
       public DateTime? sales_end_date { get; set; }

       /// <summary>
       ///Sales 會計帳起始日期
       /// </summary>
       [Display(Name ="Sales 會計帳起始日期")]
       [Column(TypeName="datetime")]
       public DateTime? sales_start_date { get; set; }

       /// <summary>
       ///公司別,舊版SUN_DB
       /// </summary>
       [Display(Name ="公司別,舊版SUN_DB")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///識別碼, PK, Identity
       /// </summary>
       [Display(Name ="識別碼, PK, Identity")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///最後修改時間
       /// </summary>
       [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       
    }
}