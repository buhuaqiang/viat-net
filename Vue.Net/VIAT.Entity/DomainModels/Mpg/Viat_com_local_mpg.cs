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
    [Entity(TableCnName = "本地產品群組實體表",TableName = "Viat_com_local_mpg")]
    public partial class Viat_com_local_mpg:BaseEntity
    {
        /// <summary>
       ///ID
       /// </summary>
       [Key]
       [Display(Name ="ID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid localmpg_dbid { get; set; }

       /// <summary>
       ///PKID
       /// </summary>
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? globalmpg_dbid { get; set; }

       /// <summary>
       ///公司別
       /// </summary>
       [Display(Name ="公司別")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///Mpg代碼
       /// </summary>
       [Display(Name ="Mpg代碼")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string mpg_id { get; set; }

       /// <summary>
       ///Mpg名稱
       /// </summary>
       [Display(Name ="Mpg名稱")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string mpg_name { get; set; }

       /// <summary>
       ///category
       /// </summary>
       [Display(Name ="category")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string category { get; set; }

       /// <summary>
       ///Bu
       /// </summary>
       [Display(Name ="Bu")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string bu_id { get; set; }

       /// <summary>
       ///ta
       /// </summary>
       [Display(Name ="ta")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string ta { get; set; }

       /// <summary>
       ///排序  for finance report
       /// </summary>
       [Display(Name ="排序  for finance report")]
       [Column(TypeName="int")]
       public int? sort { get; set; }

       /// <summary>
       ///是否有效,True:生效;False:失效
       /// </summary>
       [Display(Name ="是否有效,True:生效;False:失效")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///是否主要產品,True:主要;False:非主要
       /// </summary>
       [Display(Name ="是否主要產品,True:主要;False:非主要")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string main_prod { get; set; }

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

       /// <summary>
       ///助理代碼(預留欄位)
       /// </summary>
       [Display(Name ="助理代碼(預留欄位)")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string ma_id { get; set; }

       /// <summary>
       ///主管代碼(預留)
       /// </summary>
       [Display(Name ="主管代碼(預留)")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string pm_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ma_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string ma_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="pm_name")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       [Editable(true)]
       public string pm_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="medical_reviewe_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string medical_reviewe_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="medical_reviewe_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string medical_reviewe_name { get; set; }

       
    }
}