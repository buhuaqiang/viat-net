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
    [Entity(TableCnName = "客戶送貨資訊",TableName = "Viat_com_cust_delivery")]
    public partial class Viat_com_cust_delivery:BaseEntity
    {
        /// <summary>
       ///ID
       /// </summary>
       [Key]
       [Display(Name ="ID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid delivery_dbid { get; set; }

       /// <summary>
       ///識別碼, PK, Identity
       /// </summary>
       /*[Display(Name ="識別碼, PK, Identity")]
       [JsonIgnore]
       [Column(TypeName="numeric")]
       [Required(AllowEmptyStrings=false)]
       public decimal dbid { get; set; }*/

       /// <summary>
       ///公司別,舊版SUM_DB
       /// </summary>
       [Display(Name ="公司別,舊版SUM_DB")]
       [MaxLength(3)]
       [JsonIgnore]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///所屬事業單位,01:PH;03:AH;05:CH;06:NU
       /// </summary>
       [Display(Name ="所屬事業單位,01:PH;03:AH;05:CH;06:NU")]
       [MaxLength(15)]
       [JsonIgnore]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///客戶代碼
       /// </summary>
       [Display(Name ="客戶代碼")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///郵區代碼
       /// </summary>
       [Display(Name ="郵區代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string zip_id { get; set; }

       /// <summary>
       ///序號
       /// </summary>
       [Display(Name ="序號")]
       [Column(TypeName="decimal")]
       public decimal? seq_no { get; set; }

       /// <summary>
       ///送貨抬頭
       /// </summary>
       [Display(Name ="送貨抬頭")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string delivery_name { get; set; }

       /// <summary>
       ///聯絡人
       /// </summary>
       [Display(Name ="聯絡人")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string delivery_contact { get; set; }

       /// <summary>
       ///聯絡人電話
       /// </summary>
       [Display(Name ="聯絡人電話")]
       [MaxLength(60)]
       [Column(TypeName="varchar(60)")]
       [Editable(true)]
       public string delivery_tel_no { get; set; }

       /// <summary>
       ///送貨地址
       /// </summary>
       [Display(Name ="送貨地址")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string delivery_addr { get; set; }

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

       
    }
}
