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
    [Entity(TableCnName = "客戶基本信息",TableName = "Viat_com_cust",DetailTable =  new Type[] { typeof(Viat_com_cust_delivery)},DetailTableCnName = "客戶送貨資訊")]
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
       ///客戶編號
       /// </summary>
       [Display(Name ="客戶編號")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_id { get; set; }

       /// <summary>
       ///客戶名稱
       /// </summary>
       [Display(Name ="客戶名稱")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string cust_name { get; set; }

       /// <summary>
       ///客戶地址
       /// </summary>
       [Display(Name ="客戶地址")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string cust_address { get; set; }

       /// <summary>
       ///發票抬頭
       /// </summary>
       [Display(Name ="發票抬頭")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string invoice_name { get; set; }

       /// <summary>
       ///發票地址
       /// </summary>
       [Display(Name ="發票地址")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string invoice_address { get; set; }

       /// <summary>
       ///負責人
       /// </summary>
       [Display(Name ="負責人")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
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
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string is_contract { get; set; }

       /// <summary>
       ///是否為私立
       /// </summary>
       [Display(Name ="是否為私立")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string is_private { get; set; }

       /// <summary>
       ///是否為門前藥局/診所
       /// </summary>
       [Display(Name ="是否為門前藥局/診所")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string own_by_hospital { get; set; }

       /// <summary>
       ///隸屬醫院代碼
       /// </summary>
       [Display(Name ="隸屬醫院代碼")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? own_hospital { get; set; }

       /// <summary>
       ///隸書體系主院代碼
       /// </summary>
       [Display(Name ="隸書體系主院代碼")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? med_group { get; set; }

       /// <summary>
       ///統一寄送至醫院代碼
       /// </summary>
       [Display(Name ="統一寄送至醫院代碼")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? delv_group { get; set; }

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
       ///健保類別
       /// </summary>
       [Display(Name ="健保類別")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string doh_type { get; set; }

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
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///建立時間
       /// </summary>
       [Display(Name ="建立時間")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///主鍵
       /// </summary>
       [Key]
       [Display(Name ="主鍵")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid cust_dbid { get; set; }

       /// <summary>
       ///客戶地址郵區代碼
       /// </summary>
       [Display(Name ="客戶地址郵區代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string cust_zip_id { get; set; }

       /// <summary>
       ///發票地址郵區代碼
       /// </summary>
       [Display(Name ="發票地址郵區代碼")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string invoice_zip_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="last_deal_date")]
       [Column(TypeName="date")]
       public DateTime? last_deal_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///健保類別子類
       /// </summary>
       [Display(Name ="健保類別子類")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string doh_sub_type { get; set; }

       /// <summary>
       ///隸屬醫院名稱
       /// </summary>
       [Display(Name ="隸屬醫院名稱")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
        [Editable(true)]
       public string own_hospital_name { get; set; }

       /// <summary>
       ///是否管控客戶)
       /// </summary>
       [Display(Name ="是否管控客戶)")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
        [Editable(true)]
        public string is_controll { get; set; }

       [Display(Name ="客戶送貨資訊")]
       [ForeignKey("cust_dbid")]
       public List<Viat_com_cust_delivery> Viat_com_cust_delivery { get; set; }

    }
}
