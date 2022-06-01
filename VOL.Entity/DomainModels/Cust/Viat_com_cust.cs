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
    [Entity(TableCnName = "客戶基本信息",TableName = "Viat_com_cust")]
    public partial class Viat_com_cust:BaseEntity
    {
       
       /// <summary>
       ///公司別
       /// </summary>
       [Display(Name ="公司別")]
       [MaxLength(3)]
       [JsonIgnore]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///所屬事業單位
       /// </summary>
       [Display(Name ="所屬事業單位")]
       [MaxLength(15)]
       [JsonIgnore]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///客戶id
       /// </summary>
       [Key]
       [Display(Name ="客戶id")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid cust_id { get; set; }

       /// <summary>
       ///客戶編碼
       /// </summary>
       [Display(Name ="客戶編碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_code { get; set; }

       /// <summary>
       ///客戶名稱
       /// </summary>
       [Display(Name ="客戶名稱")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_name { get; set; }

       /// <summary>
       ///客戶地址
       /// </summary>
       [Display(Name ="客戶地址")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_address { get; set; }

       /// <summary>
       ///發票抬頭
       /// </summary>
       [Display(Name ="發票抬頭")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_name { get; set; }

       /// <summary>
       ///發票地址
       /// </summary>
       [Display(Name ="發票地址")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_address { get; set; }

       /// <summary>
       ///負責人
       /// </summary>
       [Display(Name ="負責人")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string owner { get; set; }

       /// <summary>
       ///統一編號
       /// </summary>
       [Display(Name ="統一編號")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string tax_id { get; set; }

       /// <summary>
       ///聯絡人
       /// </summary>
       [Display(Name ="聯絡人")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       public string contact { get; set; }

       /// <summary>
       ///電話號碼
       /// </summary>
       [Display(Name ="電話號碼")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string tel_no { get; set; }

       /// <summary>
       ///傳真號碼
       /// </summary>
       [Display(Name ="傳真號碼")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string fax_no { get; set; }

       /// <summary>
       ///電子郵箱
       /// </summary>
       [Display(Name ="電子郵箱")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string email { get; set; }

       /// <summary>
       ///預設業代分區
       /// </summary>
       [Display(Name ="預設業代分區")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string territory_id { get; set; }

       /// <summary>
       ///健保機構代碼
       /// </summary>
       [Display(Name ="健保機構代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string doh_institute_no { get; set; }

       /// <summary>
       ///管制藥品認證代碼
       /// </summary>
       [Display(Name ="管制藥品認證代碼")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       public string ctrl_drug_no { get; set; }

       /// <summary>
       ///管制藥品聯絡人
       /// </summary>
       [Display(Name ="管制藥品聯絡人")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       public string ctrl_drug_contact { get; set; }

       /// <summary>
       ///健保類別
       /// </summary>
       [Display(Name ="健保類別")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string doh_type { get; set; }

       /// <summary>
       ///郵區代碼
       /// </summary>
       [Display(Name ="郵區代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string zip_id { get; set; }

       /// <summary>
       ///郵區代碼
       /// </summary>
       [Display(Name ="郵區代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string bmp_zip_id { get; set; }

       /// <summary>
       ///毛利類別
       /// </summary>
       [Display(Name ="毛利類別")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string margin_type { get; set; }

       /// <summary>
       ///是否為合約客戶
       /// </summary>
       [Display(Name ="是否為合約客戶")]
       [Column(TypeName="bit")]
       [Editable(true)]
       public bool? is_contract { get; set; }

       /// <summary>
       ///是否為私立
       /// </summary>
       [Display(Name ="是否為私立")]
       [Column(TypeName="bit")]
       [Editable(true)]
       public bool? is_private { get; set; }

       /// <summary>
       ///是否為門前藥局/診所
       /// </summary>
       [Display(Name ="是否為門前藥局/診所")]
       [Column(TypeName="bit")]
       [Editable(true)]
       public bool? own_by_hospital { get; set; }

       /// <summary>
       ///隸屬醫院代碼
       /// </summary>
       [Display(Name ="隸屬醫院代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string own_hospital { get; set; }

       /// <summary>
       ///隸書體系主院代碼
       /// </summary>
       [Display(Name ="隸書體系主院代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string med_group { get; set; }

       /// <summary>
       ///統一寄送至醫院代碼
       /// </summary>
       [Display(Name ="統一寄送至醫院代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string delv_group { get; set; }

       /// <summary>
       ///新客戶代碼
       /// </summary>
       [Display(Name ="新客戶代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string new_cust_id { get; set; }

       /// <summary>
       ///失效日期
       /// </summary>
       [Display(Name ="失效日期")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? inactive_date { get; set; }

       /// <summary>
       ///是否有效
       /// </summary>
       [Display(Name ="是否有效")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///備註
       /// </summary>
       [Display(Name ="備註")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///資料來源
       /// </summary>
       [Display(Name ="資料來源")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string source { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="accnt_code")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string accnt_code { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_type")]
       [MaxLength(2)]
       [JsonIgnore]
       [Column(TypeName="varchar(2)")]
       public string invoice_type { get; set; }

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
       [Display(Name ="CreateClient")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string CreateClient { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateClientID")]
       [Column(TypeName="int")]
       public int? CreateClientID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyID")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       /// <summary>
       ///Updated date
       /// </summary>
       [Display(Name ="Updated date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///Updated user
       /// </summary>
       [Display(Name ="Updated user")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string Modifier { get; set; }

       /// <summary>
       ///Created user
       /// </summary>
       [Display(Name ="Created user")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string Creator { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateID")]
       [Column(TypeName="int")]
       public int? CreateID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifierClientID")]
       [Column(TypeName="int")]
       public int? ModifierClientID { get; set; }

       /// <summary>
       ///Created date
       /// </summary>
       [Display(Name ="Created date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? CreateDate { get; set; }

       
    }
}
