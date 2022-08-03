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
    [Entity(TableCnName = "Viat_sftp_export",TableName = "Viat_sftp_export")]
    public partial class Viat_sftp_export:BaseEntity
    {
        /// <summary>
       ///Type
       /// </summary>
       [Display(Name ="Type")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string type { get; set; }

       /// <summary>
       ///Distributor
       /// </summary>
       [Display(Name ="Distributor")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string dist_id { get; set; }

       /// <summary>
       ///Date
       /// </summary>
       [Display(Name ="Date")]
       [Column(TypeName="datetime")]
       public DateTime? transfer_date { get; set; }

       /// <summary>
       ///File Name
       /// </summary>
       [Display(Name ="File Name")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string file_name { get; set; }

       /// <summary>
       ///Update Date
       /// </summary>
       [Display(Name ="Update Date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Size
       /// </summary>
       [Display(Name ="Size")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? file_size { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="sftp_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid sftp_dbid { get; set; }

       
    }
}