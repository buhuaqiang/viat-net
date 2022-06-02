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
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels
{
    [Entity(TableCnName = "地區信息",TableName = "Viat_com_zip_city")]
    public partial class Viat_com_zip_city:BaseEntity
    {
        /// <summary>
       ///識別碼, PK, Identity
       /// </summary>
       [Display(Name ="識別碼, PK, Identity")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///地區編碼
       /// </summary>
       [Display(Name ="地區編碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string zip_id { get; set; }

       /// <summary>
       ///地區名稱
       /// </summary>
       [Display(Name ="地區名稱")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string zip_name { get; set; }

       /// <summary>
       ///城市代碼
       /// </summary>
       [Display(Name ="城市代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string city_id { get; set; }

       /// <summary>
       ///城市名稱
       /// </summary>
       [Display(Name ="城市名稱")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string city_name { get; set; }

       /// <summary>
       ///是否有效
       /// </summary>
       [Display(Name ="是否有效")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

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
       ///最後修改時間
       /// </summary>
       [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///郵區表DBID
       /// </summary>
       [Key]
       [Display(Name ="郵區表DBID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid zip_dbid { get; set; }

       
    }
}
