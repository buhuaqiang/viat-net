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
    [Entity(TableCnName = "經銷商margin設定",TableName = "Viat_app_dist_margin")]
    public partial class Viat_app_dist_margin:BaseEntity
    {
        /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid distmargin_dbid { get; set; }

       /// <summary>
       ///識別碼,  Identity
       /// </summary>
       [Display(Name ="識別碼,  Identity")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///公司別
       /// </summary>
       [Display(Name ="公司別")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///所屬事業單位,01:PH;03:AH;05:CH;06:NU
       /// </summary>
       [Display(Name ="所屬事業單位,01:PH;03:AH;05:CH;06:NU")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///經銷商代碼
       /// </summary>
       [Display(Name ="經銷商代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Required(AllowEmptyStrings=false)]
       public string dist_id { get; set; }

       /// <summary>
       ///毛利類別,0: Fix Rate ;1:Fix Price
       /// </summary>
       [Display(Name ="毛利類別,0: Fix Rate ;1:Fix Price")]
       [Column(TypeName="int")]
       public int? margin_value_type { get; set; }

       /// <summary>
       ///毛利值,Rate or 固定金額
       /// </summary>
       [Display(Name ="毛利值,Rate or 固定金額")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? margin_value { get; set; }

       /// <summary>
       ///產品代碼,舊版ITEM_CODE
       /// </summary>
       [Display(Name ="產品代碼,舊版ITEM_CODE")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///客戶代碼
       /// </summary>
       [Display(Name ="客戶代碼")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///Local MPG ID
       /// </summary>
       [Display(Name ="Local MPG ID")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? local_mpg_dbid { get; set; }

       /// <summary>
       ///通路
       /// </summary>
       [Display(Name ="通路")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string channel { get; set; }

       /// <summary>
       ///起始日期
       /// </summary>
       [Display(Name ="起始日期")]
       [Column(TypeName="datetime")]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///結束日期
       /// </summary>
       [Display(Name ="結束日期")]
       [Column(TypeName="datetime")]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///備註
       /// </summary>
       [Display(Name ="備註")]
       [MaxLength(256)]
       [Column(TypeName="nvarchar(256)")]
       public string remarks { get; set; }

       /// <summary>
       ///Y:是,N：否
       /// </summary>
       [Display(Name ="Y:是,N：否")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
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