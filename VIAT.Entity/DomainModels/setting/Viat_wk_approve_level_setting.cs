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
    [Entity(TableCnName = "流程審批等級配置",TableName = "Viat_wk_approve_level_setting")]
    public partial class Viat_wk_approve_level_setting:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="levelsetting_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid levelsetting_dbid { get; set; }

       /// <summary>
       ///Flow Type
       /// </summary>
       [Display(Name ="Flow Type")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string biz_type { get; set; }

       /// <summary>
       ///Grade
       /// </summary>
       [Display(Name ="Grade")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int grade { get; set; }

       /// <summary>
       ///Condition
       /// </summary>
       [Display(Name ="Condition")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int condition { get; set; }

       /// <summary>
       ///Approve pos
       /// </summary>
       [Display(Name ="Approve pos")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string approve_pos { get; set; }

       /// <summary>
       ///Remark
       /// </summary>
       [Display(Name ="Remark")]
       [MaxLength(400)]
       [Column(TypeName="varchar(400)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string remark { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="char(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string status { get; set; }

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