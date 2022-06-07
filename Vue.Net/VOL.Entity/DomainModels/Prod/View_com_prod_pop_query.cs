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
    [Entity(TableCnName = "產品pop框查詢",TableName = "View_com_prod_pop_query")]
    public partial class View_com_prod_pop_query:BaseEntity
    {
        /// <summary>
       ///MPG
       /// </summary>
       [Display(Name ="MPG")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string mpg_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="localmpg_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? localmpg_dbid { get; set; }

       /// <summary>
       ///ID
       /// </summary>
       [Display(Name ="ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Required(AllowEmptyStrings=false)]
       public string prod_id { get; set; }

       /// <summary>
       ///EnglishName
       /// </summary>
       [Display(Name ="EnglishName")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_cname { get; set; }

       /// <summary>
       ///ChineseName
       /// </summary>
       [Display(Name ="ChineseName")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_sname { get; set; }

       /// <summary>
       ///NHI Price
       /// </summary>
       [Display(Name ="NHI Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///Pack Size
       /// </summary>
       [Display(Name ="Pack Size")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? pack_size { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="globalmpg_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? globalmpg_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_date1")]
       [Column(TypeName="datetime")]
       public DateTime? created_date1 { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_dbid { get; set; }

       
    }
}