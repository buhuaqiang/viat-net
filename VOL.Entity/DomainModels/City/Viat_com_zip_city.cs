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
       [Key]
       [Display(Name ="識別碼, PK, Identity")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///郵區代碼
       /// </summary>
       [Display(Name ="郵區代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Required(AllowEmptyStrings=false)]
       public string zip_id { get; set; }

       /// <summary>
       ///地區名稱
       /// </summary>
       [Display(Name ="地區名稱")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string zip_name { get; set; }

       /// <summary>
       ///城市代碼
       /// </summary>
       [Display(Name ="城市代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string city_id { get; set; }

       /// <summary>
       ///城市名稱
       /// </summary>
       [Display(Name ="城市名稱")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string city_name { get; set; }

       /// <summary>
       ///是否有效,Y:生效;N:失效
       /// </summary>
       [Display(Name ="是否有效,Y:生效;N:失效")]
       [Column(TypeName="bit")]
       public bool? status { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateDate")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       public int? CreateID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Creator")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Creator { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Modifier")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Modifier { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyDate")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyID")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateClientID")]
       [Column(TypeName="int")]
       public int? CreateClientID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateClient")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string CreateClient { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifierClient")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string ModifierClient { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifierClientID")]
       [Column(TypeName="int")]
       public int? ModifierClientID { get; set; }

       
    }
}