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
    [Entity(TableCnName = "viat_app_cust_transfer",TableName = "Viat_app_cust_transfer")]
    public partial class Viat_app_cust_transfer:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="custtransfer_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid custtransfer_dbid { get; set; }

       /// <summary>
       ///識別碼, PK, Identity
       /// </summary>
       [Display(Name ="識別碼, PK, Identity")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///議價決標單號
       /// </summary>
       [Display(Name ="議價決標單號")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string bid_no { get; set; }

       /// <summary>
       ///申請者員編
       /// </summary>
       [Display(Name ="申請者員編")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string emp_id { get; set; }

       /// <summary>
       ///公司別,舊版SUM_DB
       /// </summary>
       [Display(Name ="公司別,舊版SUM_DB")]
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
       ///客戶代碼
       /// </summary>
       [Display(Name ="客戶代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cust_id { get; set; }

       /// <summary>
       ///客戶名稱
       /// </summary>
       [Display(Name ="客戶名稱")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///客戶地址郵區
       /// </summary>
       [Display(Name ="客戶地址郵區")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string cust_zip_id { get; set; }

       /// <summary>
       ///客戶地址
       /// </summary>
       [Display(Name ="客戶地址")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string cust_address { get; set; }

       /// <summary>
       ///發票地址郵區
       /// </summary>
       [Display(Name ="發票地址郵區")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string invoice_zip_id { get; set; }

       /// <summary>
       ///發票抬頭
       /// </summary>
       [Display(Name ="發票抬頭")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string invoice_name { get; set; }

       /// <summary>
       ///發票地址
       /// </summary>
       [Display(Name ="發票地址")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string invoice_address { get; set; }

       /// <summary>
       ///負責人
       /// </summary>
       [Display(Name ="負責人")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string owner { get; set; }

       /// <summary>
       ///統一編號
       /// </summary>
       [Display(Name ="統一編號")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string tax_id { get; set; }

       /// <summary>
       ///聯絡人
       /// </summary>
       [Display(Name ="聯絡人")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string contact { get; set; }

       /// <summary>
       ///電話號碼
       /// </summary>
       [Display(Name ="電話號碼")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string tel_no { get; set; }

       /// <summary>
       ///傳真號碼
       /// </summary>
       [Display(Name ="傳真號碼")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string fax_no { get; set; }

       /// <summary>
       ///電子郵箱
       /// </summary>
       [Display(Name ="電子郵箱")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string email { get; set; }

       /// <summary>
       ///預設業代區域
       /// </summary>
       [Display(Name ="預設業代區域")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///健保機構代碼
       /// </summary>
       [Display(Name ="健保機構代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string doh_institute_no { get; set; }

       /// <summary>
       ///管制藥品認證代碼
       /// </summary>
       [Display(Name ="管制藥品認證代碼")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string ctrl_drug_no { get; set; }

       /// <summary>
       ///管制藥品聯絡人
       /// </summary>
       [Display(Name ="管制藥品聯絡人")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string ctrl_drug_contact { get; set; }

       /// <summary>
       ///健保類別
       /// </summary>
       [Display(Name ="健保類別")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string doh_type { get; set; }

       /// <summary>
       ///毛利類別
       /// </summary>
       [Display(Name ="毛利類別")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string margin_type { get; set; }

       /// <summary>
       ///是否為合約客戶
       /// </summary>
       [Display(Name ="是否為合約客戶")]
       [Column(TypeName="bit")]
       public bool? is_contract { get; set; }

       /// <summary>
       ///是否為私利
       /// </summary>
       [Display(Name ="是否為私利")]
       [Column(TypeName="bit")]
       public bool? is_private { get; set; }

       /// <summary>
       ///是否為門前藥局/診所
       /// </summary>
       [Display(Name ="是否為門前藥局/診所")]
       [Column(TypeName="bit")]
       public bool? own_by_hospital { get; set; }

       /// <summary>
       ///門前藥局/診所隸屬醫院代碼
       /// </summary>
       [Display(Name ="門前藥局/診所隸屬醫院代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string own_hospital { get; set; }

       /// <summary>
       ///隸屬體系主院代碼
       /// </summary>
       [Display(Name ="隸屬體系主院代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string med_group { get; set; }

       /// <summary>
       ///統一寄送至醫院代碼
       /// </summary>
       [Display(Name ="統一寄送至醫院代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string delv_group { get; set; }

       /// <summary>
       ///新客戶代碼
       /// </summary>
       [Display(Name ="新客戶代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string new_cust_id { get; set; }

       /// <summary>
       ///失效日期
       /// </summary>
       [Display(Name ="失效日期")]
       [Column(TypeName="datetime")]
       public DateTime? inactive_date { get; set; }

       /// <summary>
       ///是否有效,True:生效;False:失效
       /// </summary>
       [Display(Name ="是否有效,True:生效;False:失效")]
       [Column(TypeName="bit")]
       public bool? status { get; set; }

       /// <summary>
       ///備註
       /// </summary>
       [Display(Name ="備註")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       public string remarks { get; set; }

       /// <summary>
       ///處理狀態,0:待處理;1:匯入
       /// </summary>
       [Display(Name ="處理狀態,0:待處理;1:匯入")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string state { get; set; }

       /// <summary>
       ///資料來源,0:EBMS;1:Manual;2:Distributor
       /// </summary>
       [Display(Name ="資料來源,0:EBMS;1:Manual;2:Distributor")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string source { get; set; }

       /// <summary>
       ///處理說明
       /// </summary>
       [Display(Name ="處理說明")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       public string note { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
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
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
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
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
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
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
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