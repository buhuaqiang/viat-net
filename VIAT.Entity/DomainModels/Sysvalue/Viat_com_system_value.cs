using Newtonsoft.Json;
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
    [Entity(TableCnName = "系統參數設置",TableName = "Viat_com_system_value")]
    public partial class Viat_com_system_value:BaseEntity
    {
        /// <summary>
       ///ID
       /// </summary>
       [Key]
       [Display(Name ="ID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid sysval_dbid { get; set; }

       /// <summary>
       ///ID
       /// </summary>
       /*[Display(Name ="ID")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }*/

       /// <summary>
       ///類別代碼
       /// </summary>
       [Display(Name ="類別代碼")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string category_id { get; set; }

       /// <summary>
       ///參數名稱
       /// </summary>
       [Display(Name ="參數名稱")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string sys_key { get; set; }

       /// <summary>
       ///參數值
       /// </summary>
       [Display(Name ="參數值")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       [Editable(true)]
       public string sys_value { get; set; }

       /// <summary>
       ///順序
       /// </summary>
       [Display(Name ="順序")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? seqno { get; set; }

       /// <summary>
       ///是否有效
       /// </summary>
       [Display(Name ="是否有效")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

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
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

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
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///最後修改時間
       /// </summary>
       [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

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
       [Display(Name ="created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

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
       [Display(Name ="modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       
    }
}
