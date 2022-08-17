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
    [Entity(TableCnName = "NHI Adjust Detail",TableName = "View_nhi_adjust_detail")]
    public partial class View_nhi_adjust_detail:BaseEntity
    {
        /// <summary>
       ///Product ID
       /// </summary>
       [Display(Name ="Product ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string prod_id { get; set; }

       /// <summary>
       ///Product Name
       /// </summary>
       [Display(Name ="Product Name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string prod_ename { get; set; }

       /// <summary>
       ///NHI Code
       /// </summary>
       [Display(Name ="NHI Code")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string nhi_id { get; set; }

       /// <summary>
       ///Old NHI Price
       /// </summary>
       [Display(Name ="Old NHI Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? old_nhi_price { get; set; }

       /// <summary>
       ///New NHI Price
       /// </summary>
       [Display(Name ="New NHI Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? new_nhi_price { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="nhiadjust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid nhiadjust_dbid { get; set; }

       /// <summary>
       ///Product
       /// </summary>
       [Display(Name ="Product")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///m主鍵
       /// </summary>
       [Display(Name ="m主鍵")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? nhiadjustm_dbid { get; set; }

       /// <summary>
       ///Apply Allowance
       /// </summary>
       [Display(Name ="Apply Allowance")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string apply_allow { get; set; }

       
    }
}