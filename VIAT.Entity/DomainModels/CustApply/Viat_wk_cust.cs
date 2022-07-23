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
    [Entity(TableCnName = "viat_wk_cust_合約客戶",TableName = "Viat_wk_cust")]
    public partial class Viat_wk_cust:BaseEntity
    {
        /// <summary>
       ///主鍵
       /// </summary>
       [Key]
       [Display(Name ="主鍵")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
        public Guid wkcust_dbid { get; set; }

       /// <summary>
       ///電子郵箱
       /// </summary>
       [Display(Name ="電子郵箱")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
        [Editable(true)]
        public string email { get; set; }

       /// <summary>
       ///傳真號碼
       /// </summary>
       [Display(Name ="傳真號碼")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
        [Editable(true)]
        public string fax_no { get; set; }

       /// <summary>
       ///備註
       /// </summary>
       [Display(Name ="備註")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
        [Editable(true)]
        public string remarks { get; set; }

       /// <summary>
       ///資料來源,0:EBMS;1:Distributor;2:Manual
       /// </summary>
       [Display(Name ="資料來源,0:EBMS;1:Distributor;2:Manual")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
        [Editable(true)]
        public string source { get; set; }

       /// <summary>
       ///accnt_code
       /// </summary>
       [Display(Name ="accnt_code")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
        [Editable(true)]
        public string accnt_code { get; set; }

       /// <summary>
       ///門前藥局/診所隸屬醫院代碼
       /// </summary>
       [Display(Name ="門前藥局/診所隸屬醫院代碼")]
       [Column(TypeName="uniqueidentifier")]
        [Editable(true)]
        public Guid? own_hospital { get; set; }

       /// <summary>
       ///隸屬體系主院代碼
       /// </summary>
       [Display(Name ="隸屬體系主院代碼")]
       [Column(TypeName="uniqueidentifier")]
        [Editable(true)]
        public Guid? med_group { get; set; }

       /// <summary>
       ///是否為門前藥局/診所
       /// </summary>
       [Display(Name ="是否為門前藥局/診所")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
        [Editable(true)]
        public string own_by_hospital { get; set; }

       /// <summary>
       ///統一寄送至醫院代碼
       /// </summary>
       [Display(Name ="統一寄送至醫院代碼")]
       [Column(TypeName="uniqueidentifier")]
        [Editable(true)]
        public Guid? delv_group { get; set; }

       /// <summary>
       ///是否為合約客戶
       /// </summary>
       [Display(Name ="是否為合約客戶")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
        [Editable(true)]
        public string is_contract { get; set; }

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
       ///管制藥品聯絡人
       /// </summary>
       [Display(Name ="管制藥品聯絡人")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
        [Editable(true)]
        public string ctrl_drug_contact { get; set; }

       /// <summary>
       ///管制藥品認證代碼
       /// </summary>
       [Display(Name ="管制藥品認證代碼")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
        [Editable(true)]
        public string ctrl_drug_no { get; set; }

       /// <summary>
       ///送貨地址
       /// </summary>
       [Display(Name ="送貨地址")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
        [Editable(true)]
        public string delivery_addr { get; set; }

       /// <summary>
       ///送貨地址郵區
       /// </summary>
       [Display(Name ="送貨地址郵區")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
        [Editable(true)]
        public string delivery_zip_id { get; set; }

       /// <summary>
       ///bidmast_dbid
       /// </summary>
       [Display(Name ="bidmast_dbid")]
       [Column(TypeName="uniqueidentifier")]
        [Editable(true)]
        public Guid? bidmast_dbid { get; set; }

       /// <summary>
       ///ctype
       /// </summary>
       [Display(Name ="ctype")]
       [MaxLength(1)]
       [Column(TypeName="char(1)")]
        [Editable(true)]
        public string ctype { get; set; }

       /// <summary>
       ///客戶代碼
       /// </summary>
       [Display(Name ="客戶代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
        [Editable(true)]
        public string cust_id { get; set; }

       /// <summary>
       ///預設業代區域
       /// </summary>
       [Display(Name ="預設業代區域")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
        [Editable(true)]
        public string territory_id { get; set; }

       /// <summary>
       ///客戶名稱
       /// </summary>
       [Display(Name ="客戶名稱")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
        [Editable(true)]
        public string cust_name { get; set; }

       /// <summary>
       ///客戶地址郵區
       /// </summary>
       [Display(Name ="客戶地址郵區")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
        [Editable(true)]
        public string cust_zip_id { get; set; }

       /// <summary>
       ///客戶地址
       /// </summary>
       [Display(Name ="客戶地址")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
        [Editable(true)]
        public string cust_address { get; set; }

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
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
        [Editable(true)]
        public string modified_clientusername { get; set; }

       /// <summary>
       ///健保類別
       /// </summary>
       [Display(Name ="健保類別")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
        [Editable(true)]
        public string doh_type { get; set; }

       /// <summary>
       ///是否為私立
       /// </summary>
       [Display(Name ="是否為私立")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
        [Editable(true)]
        public string is_private { get; set; }

       /// <summary>
       ///category: InvoiceType  2 聯  3 聯
       /// </summary>
       [Display(Name ="category: InvoiceType  2 聯  3 聯")]
       [MaxLength(2)]
       [Column(TypeName="varchar(2)")]
        [Editable(true)]
        public string invoice_type { get; set; }

       /// <summary>
       ///(發票地址郵區)
       /// </summary>
       [Display(Name ="(發票地址郵區)")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
        [Editable(true)]
        public string invoice_zip_id { get; set; }

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
       ///健保機構代碼
       /// </summary>
       [Display(Name ="健保機構代碼")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
        [Editable(true)]
        public string doh_institute_no { get; set; }

       /// <summary>
       ///最後修改時間
       /// </summary>
       [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
        public DateTime? modified_date { get; set; }

       
    }
}