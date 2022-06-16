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
    [Entity(TableCnName = "員工設置",TableName = "Viat_com_employee")]
    public partial class Viat_com_employee:BaseEntity
    {
        /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid emp_dbid { get; set; }

       /// <summary>
       ///員工編號
       /// </summary>
       [Display(Name ="員工編號")]
       [MaxLength(36)]
       [Column(TypeName="varchar(36)")]
       [Required(AllowEmptyStrings=false)]
       public string emp_id { get; set; }

       /// <summary>
       ///識別碼, PK, Identity
       /// </summary>
       [Display(Name ="識別碼, PK, Identity")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

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
       ///郵區代碼
       /// </summary>
       [Display(Name ="郵區代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string zip_id { get; set; }

       /// <summary>
       ///AD登入 name
       /// </summary>
       [Display(Name ="AD登入 name")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string user_name { get; set; }

       /// <summary>
       ///AD登入 domain
       /// </summary>
       [Display(Name ="AD登入 domain")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string user_domain { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="emp_global_id")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string emp_global_id { get; set; }

       /// <summary>
       ///員工英文姓名
       /// </summary>
       [Display(Name ="員工英文姓名")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string emp_ename { get; set; }

       /// <summary>
       ///員工中文姓名
       /// </summary>
       [Display(Name ="員工中文姓名")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string emp_cname { get; set; }

       /// <summary>
       ///電子郵箱
       /// </summary>
       [Display(Name ="電子郵箱")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string email { get; set; }

       /// <summary>
       ///部門代碼
       /// </summary>
       [Display(Name ="部門代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string dept_id { get; set; }

       /// <summary>
       ///部門名稱
       /// </summary>
       [Display(Name ="部門名稱")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string dept_name { get; set; }

       /// <summary>
       ///手機
       /// </summary>
       [Display(Name ="手機")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string mobile { get; set; }

       /// <summary>
       ///地址
       /// </summary>
       [Display(Name ="地址")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string address { get; set; }

       /// <summary>
       ///moving type for sun systems
       /// </summary>
       [Display(Name ="moving type for sun systems")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string mvmnt_type { get; set; }

       /// <summary>
       ///部門類別
       /// </summary>
       [Display(Name ="部門類別")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string dept_type { get; set; }

       /// <summary>
       ///英文部門
       /// </summary>
       [Display(Name ="英文部門")]
       [MaxLength(80)]
       [Column(TypeName="varchar(80)")]
       public string dept_ename { get; set; }

       /// <summary>
       ///中文職稱
       /// </summary>
       [Display(Name ="中文職稱")]
       [MaxLength(80)]
       [Column(TypeName="nvarchar(80)")]
       public string jposition { get; set; }

       /// <summary>
       ///英文職稱
       /// </summary>
       [Display(Name ="英文職稱")]
       [MaxLength(80)]
       [Column(TypeName="varchar(80)")]
       public string ejposition { get; set; }

       /// <summary>
       ///離職日
       /// </summary>
       [Display(Name ="離職日")]
       [Column(TypeName="date")]
       public DateTime? quite_time { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
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
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
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
       ///建立時間
       /// </summary>
       [Display(Name ="建立時間")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
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
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
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
       ///最後修改時間
       /// </summary>
       [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       
    }
}