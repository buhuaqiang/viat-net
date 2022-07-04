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
    [Entity(TableCnName = "消息模板",TableName = "Viat_com_notify_template")]
    public partial class Viat_com_notify_template:BaseEntity
    {
        /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid notifytemp_dbid { get; set; }

       /// <summary>
       ///公司別,舊版SUN_DB
       /// </summary>
       [Display(Name ="公司別,舊版SUN_DB")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Editable(true)]
       public string entity { get; set; }

       /// <summary>
       ///範本自訂代碼
       /// </summary>
       [Display(Name ="範本自訂代碼")]
       [MaxLength(4)]
       [Column(TypeName="varchar(4)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string notify_id { get; set; }

       /// <summary>
       ///模組自訂代碼
       /// </summary>
       [Display(Name ="模組自訂代碼")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       //[Required(AllowEmptyStrings=false)]
       public string function_id { get; set; }

       /// <summary>
       ///寄件者
       /// </summary>
       [Display(Name ="寄件者")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string sender { get; set; }

       /// <summary>
       ///收件者
       /// </summary>
       [Display(Name ="收件者")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string recipient { get; set; }

       /// <summary>
       ///密件收件者
       /// </summary>
       [Display(Name ="密件收件者")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string bcc { get; set; }

       /// <summary>
       ///副本收件者
       /// </summary>
       [Display(Name ="副本收件者")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string cc { get; set; }

       /// <summary>
       ///主旨
       /// </summary>
       [Display(Name ="主旨")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string subject { get; set; }

       /// <summary>
       ///內容
       /// </summary>
       [Display(Name ="內容")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       [Editable(true)]
       public string content { get; set; }

       /// <summary>
       ///備註
       /// </summary>
       [Display(Name ="備註")]
       [MaxLength(450)]
       [Column(TypeName="nvarchar(450)")]
       [Editable(true)]
       public string remarks { get; set; }

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
       [Editable(true)]
       public int? modified_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
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
       [Editable(true)]
       public DateTime? modified_date { get; set; }

       
    }
}