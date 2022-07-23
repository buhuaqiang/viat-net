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
    [Entity(TableCnName = "Customer Maintain",TableName = "View_com_cust",DetailTable =  new Type[] { typeof(View_com_cust_delivery)},DetailTableCnName = "客戶送貨資訊")]
    public partial class View_com_cust:BaseEntity
    {
        /// <summary>
       ///Customer  Code
       /// </summary>
       [Display(Name ="Customer  Code")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_id { get; set; }

       /// <summary>
       ///Entity
       /// </summary>
       [Display(Name ="Entity")]
       [MaxLength(3)]
       [JsonIgnore]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///Division
       /// </summary>
       [Display(Name ="Division")]
       [MaxLength(15)]
       [JsonIgnore]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///Customer name
       /// </summary>
       [Display(Name ="Customer name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_name { get; set; }

       /// <summary>
       ///Default Zone
       /// </summary>
       [Display(Name ="Default Zone")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string territory_id { get; set; }

       /// <summary>
       ///Invoice name
       /// </summary>
       [Display(Name ="Invoice name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_name { get; set; }

       /// <summary>
       ///Customer Zip Code
       /// </summary>
       [Display(Name ="Customer Zip Code")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_zip_id { get; set; }

       /// <summary>
       ///Invoice address
       /// </summary>
       [Display(Name ="Invoice address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_address { get; set; }

       /// <summary>
       ///Owner
       /// </summary>
       [Display(Name ="Owner")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string owner { get; set; }

       /// <summary>
       ///Tax ID
       /// </summary>
       [Display(Name ="Tax ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string tax_id { get; set; }

       /// <summary>
       ///Contact
       /// </summary>
       [Display(Name ="Contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       public string contact { get; set; }

       /// <summary>
       ///Fax
       /// </summary>
       [Display(Name ="Fax")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string fax_no { get; set; }

       /// <summary>
       ///Email
       /// </summary>
       [Display(Name ="Email")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string email { get; set; }

       /// <summary>
       ///Customer address
       /// </summary>
       [Display(Name ="Customer address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_address { get; set; }

       /// <summary>
       ///Telephone
       /// </summary>
       [Display(Name ="Telephone")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string tel_no { get; set; }

       /// <summary>
       ///NHI Institute no
       /// </summary>
       [Display(Name ="NHI Institute no")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string doh_institute_no { get; set; }

       /// <summary>
       ///Controlled Medicine Certificate NO
       /// </summary>
       [Display(Name ="Controlled Medicine Certificate NO")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       public string ctrl_drug_no { get; set; }

       /// <summary>
       ///Controlled Medicine Contact
       /// </summary>
       [Display(Name ="Controlled Medicine Contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       public string ctrl_drug_contact { get; set; }

       /// <summary>
       ///DOH Type
       /// </summary>
       [Display(Name ="DOH Type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string doh_type { get; set; }

       /// <summary>
       ///Margin Type
       /// </summary>
       [Display(Name ="Margin Type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string margin_type { get; set; }

       /// <summary>
       ///Is Controlled
       /// </summary>
       [Display(Name ="Is Controlled")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string is_controll { get; set; }

       /// <summary>
       ///Public/Private
       /// </summary>
       [Display(Name ="Public/Private")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string is_private { get; set; }

       /// <summary>
       ///Is Hospital Owned Drug Store
       /// </summary>
       [Display(Name ="Is Hospital Owned Drug Store")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string own_by_hospital { get; set; }

       /// <summary>
       ///Owned Hospital
       /// </summary>
       [Display(Name ="Owned Hospital")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? own_hospital { get; set; }

       /// <summary>
       ///Own Hospital Name
       /// </summary>
       [Display(Name ="Own Hospital Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string own_hospital_name { get; set; }

       /// <summary>
       ///Medical Group
       /// </summary>
       [Display(Name ="Medical Group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? med_group { get; set; }

       /// <summary>
       ///Price Group
       /// </summary>
       [Display(Name ="Price Group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? delv_group { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///Remarks
       /// </summary>
       [Display(Name ="Remarks")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///Source
       /// </summary>
       [Display(Name ="Source")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string source { get; set; }

       /// <summary>
       ///列名accnt_code
       /// </summary>
       [Display(Name ="列名accnt_code")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string accnt_code { get; set; }

       /// <summary>
       ///Invoice Type
       /// </summary>
       [Display(Name ="Invoice Type")]
       [MaxLength(2)]
       [Column(TypeName="varchar(2)")]
       public string invoice_type { get; set; }

       /// <summary>
       ///Invoice Zip Name
       /// </summary>
       [Display(Name ="Invoice Zip Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string invoice_zip_name { get; set; }

       /// <summary>
       ///Invoice City Name
       /// </summary>
       [Display(Name ="Invoice City Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_city_name { get; set; }

       /// <summary>
       ///Customer City Name
       /// </summary>
       [Display(Name ="Customer City Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_city_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_zip_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string cust_zip_name { get; set; }

       /// <summary>
       ///Is contracted
       /// </summary>
       [Display(Name ="Is contracted")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string is_contract { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="datetime")]
       public DateTime? inactive_date { get; set; }

       /// <summary>
       ///New Customer
       /// </summary>
       [Display(Name ="New Customer")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string new_cust_id { get; set; }

       /// <summary>
       ///Invoice Zip Id
       /// </summary>
       [Display(Name ="Invoice Zip Id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_zip_id { get; set; }

       /// <summary>
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///列名modified_client
       /// </summary>
       [Display(Name ="列名modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///列名modified_user
       /// </summary>
       [Display(Name ="列名modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///Created Date
       /// </summary>
       [Display(Name ="Created Date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///列名created_client
       /// </summary>
       [Display(Name ="列名created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///列名created_user
       /// </summary>
       [Display(Name ="列名created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///列名cust_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid cust_dbid { get; set; }

       /// <summary>
       ///Created User
       /// </summary>
       [Display(Name ="Created User")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="own_hospitalname")]
       [MaxLength(111)]
       [Column(TypeName="nvarchar(111)")]
       public string own_hospitalname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="med_groupname")]
       [MaxLength(111)]
       [Column(TypeName="nvarchar(111)")]
       public string med_groupname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="delv_groupname")]
       [MaxLength(111)]
       [Column(TypeName="nvarchar(111)")]
       public string delv_groupname { get; set; }

       /// <summary>
       ///列名C1
       /// </summary>
       [Display(Name ="列名C1")]
       [MaxLength(71)]
       [Column(TypeName="nvarchar(71)")]
       public string C1 { get; set; }

       /// <summary>
       ///Created Client
       /// </summary>
       [Display(Name ="Created Client")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///Modified User
       /// </summary>
       [Display(Name ="Modified User")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///Modified Client
       /// </summary>
       [Display(Name ="Modified Client")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="delv_group_cust_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string delv_group_cust_name { get; set; }

       /// <summary>
       ///Owned Hospital
       /// </summary>
       [Display(Name ="Owned Hospital")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string own_hospital_cust_id { get; set; }

       /// <summary>
       ///Owned Hospital Name
       /// </summary>
       [Display(Name ="Owned Hospital Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string own_hospital_cust_name { get; set; }

       /// <summary>
       ///Medical Group
       /// </summary>
       [Display(Name ="Medical Group")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string med_group_cust_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="med_group_cust_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string med_group_cust_name { get; set; }

       /// <summary>
       ///Price Group
       /// </summary>
       [Display(Name ="Price Group")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string delv_group_cust_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="last_deal_date")]
       [Column(TypeName="date")]
       public DateTime? last_deal_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="doh_sub_type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string doh_sub_type { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       [Display(Name ="客戶送貨資訊")]
       [ForeignKey("cust_dbid")]
       public List<View_com_cust_delivery> View_com_cust_delivery { get; set; }

    }
}
