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
    [Entity(TableCnName = "Viat_sftp_import",TableName = "Viat_sftp_import")]
    public partial class Viat_sftp_import:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="sftp_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid sftp_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dist_id")]
       [MaxLength(10)]
       [JsonIgnore]
       [Column(TypeName="varchar(10)")]
       public string dist_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="file_name")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string file_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="file_path")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string file_path { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="upload_date")]
       [Column(TypeName="datetime")]
       public DateTime? upload_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="source")]
       [MaxLength(255)]
       [JsonIgnore]
       [Column(TypeName="varchar(255)")]
       public string source { get; set; }

       
    }
}
