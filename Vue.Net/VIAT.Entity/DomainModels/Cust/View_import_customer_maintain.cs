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
    [Entity(TableCnName = "Import Customer Maintain",TableName = "View_import_customer_maintain",DetailTable =  new Type[] { typeof(View_app_cust_delivery_transfer)},DetailTableCnName = "客戶運送轉移")]
    public partial class View_import_customer_maintain:BaseEntity
    {
        /// <summary>
       ///Territory ID
       /// </summary>
       [Display(Name ="Territory ID")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string territory_id { get; set; }

       /// <summary>
       ///Name
       /// </summary>
       [Display(Name ="Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string emp_cname { get; set; }

       /// <summary>
       ///Customer
       /// </summary>
       [Display(Name ="Customer")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_name { get; set; }

       /// <summary>
       ///Transfer Date
       /// </summary>
       [Display(Name ="Transfer Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///Process Status
       /// </summary>
       [Display(Name ="Process Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string state { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="custtransfer_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid custtransfer_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="bid_no")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string bid_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="emp_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string emp_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///Division
       /// </summary>
       [Display(Name ="Division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string division { get; set; }

       /// <summary>
       ///Customer Code
       /// </summary>
       [Display(Name ="Customer Code")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string cust_id { get; set; }

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
       ///Customer address
       /// </summary>
       [Display(Name ="Customer address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_address { get; set; }

       /// <summary>
       ///Invoice Zip Id
       /// </summary>
       [Display(Name ="Invoice Zip Id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_zip_id { get; set; }

       /// <summary>
       ///Invoice Name
       /// </summary>
       [Display(Name ="Invoice Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_name { get; set; }

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
       ///Telephone
       /// </summary>
       [Display(Name ="Telephone")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string tel_no { get; set; }

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
       ///NHI Institute NO
       /// </summary>
       [Display(Name ="NHI Institute NO")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string doh_institute_no { get; set; }

       /// <summary>
       ///Controlled Medicine Certificate No
       /// </summary>
       [Display(Name ="Controlled Medicine Certificate No")]
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
       [Display(Name ="DOH Type ")]
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
       ///Medical Group
       /// </summary>
       [Display(Name ="Medical Group")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string med_group_cust_id { get; set; }

       /// <summary>
       ///Price Group
       /// </summary>
       [Display(Name ="Price Group")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string delv_group_cust_id { get; set; }

       /// <summary>
       ///Own Hospital
       /// </summary>
       [Display(Name ="Own Hospital")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string own_hospital_cust_id { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///Note
       /// </summary>
       [Display(Name ="Note")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///Import Source
       /// </summary>
       [Display(Name ="Import Source")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string source { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="note")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       public string note { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///Created User
       /// </summary>
       [Display(Name ="Created User")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string created_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_client")]
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
       ///
       /// </summary>
       [Display(Name ="modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///Update User
       /// </summary>
       [Display(Name ="Update User")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string modified_username { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_client")]
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
       ///Update Date
       /// </summary>
       [Display(Name ="Update Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_zip_id_dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int cust_zip_id_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_zip_id_zip_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Required(AllowEmptyStrings=false)]
       public string cust_zip_id_zip_name { get; set; }

       /// <summary>
       ///Customer City Name
       /// </summary>
       [Display(Name ="Customer City Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_zip_id_city_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_zip_id_dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int invoice_zip_id_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_zip_id_zip_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Required(AllowEmptyStrings=false)]
       public string invoice_zip_id_zip_name { get; set; }

       /// <summary>
       ///Invoice City Name
       /// </summary>
       [Display(Name ="Invoice City Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_zip_id_city_name { get; set; }

       /// <summary>
       ///Own Hospital Name
       /// </summary>
       [Display(Name ="Own Hospital Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string own_hospital_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_cust_zip_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string com_cust_zip_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_cust_city_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string com_cust_city_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_invoice_zip_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string com_invoice_zip_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_invoice_city_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string com_invoice_city_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_dbid")]
       [Column(TypeName="int")]
       public int? com_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_created_user")]
       [Column(TypeName="int")]
       public int? com_created_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_created_client")]
       [Column(TypeName="int")]
       public int? com_created_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_created_date")]
       [Column(TypeName="datetime")]
       public DateTime? com_created_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_modified_user")]
       [Column(TypeName="int")]
       public int? com_modified_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_modified_client")]
       [Column(TypeName="int")]
       public int? com_modified_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? com_modified_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string com_entity { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string com_division { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string com_cust_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_cust_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string com_cust_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_cust_zip_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string com_cust_zip_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_cust_address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string com_cust_address { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_invoice_zip_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string com_invoice_zip_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_invoice_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string com_invoice_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_invoice_address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string com_invoice_address { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_owner")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string com_owner { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_tax_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string com_tax_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string com_contact { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_tel_no")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string com_tel_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_fax_no")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string com_fax_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_email")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string com_email { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string com_territory_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_doh_institute_no")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string com_doh_institute_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_ctrl_drug_no")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string com_ctrl_drug_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_ctrl_drug_contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string com_ctrl_drug_contact { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_doh_type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string com_doh_type { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_margin_type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string com_margin_type { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_is_contract")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string com_is_contract { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_is_private")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string com_is_private { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_own_by_hospital")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string com_own_by_hospital { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_own_hospital")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? com_own_hospital { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_med_group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? com_med_group { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_delv_group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? com_delv_group { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_new_cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string com_new_cust_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_inactive_date")]
       [Column(TypeName="datetime")]
       public DateTime? com_inactive_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string com_status { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_remarks")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       public string com_remarks { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="com_source")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string com_source { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="createdusername")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string createdusername { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modifiedusername")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string modifiedusername { get; set; }

       /// <summary>
       ///Own Hospital Custname
       /// </summary>
       [Display(Name ="Own Hospital Custname")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string own_hospital_custname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="med_group_custname")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string med_group_custname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="delv_group_custname")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string delv_group_custname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="C1")]
       [MaxLength(56)]
       [Column(TypeName="nvarchar(56)")]
       public string C1 { get; set; }

       /// <summary>
       ///Is Contracted
       /// </summary>
       [Display(Name ="Is Contracted")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string is_contract { get; set; }

       /// <summary>
       ///Inactivated Date
       /// </summary>
       [Display(Name ="Inactivated Date")]
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
       ///Price Group
       /// </summary>
       [Display(Name ="Price Group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? delv_group { get; set; }

       /// <summary>
       ///Medical Group
       /// </summary>
       [Display(Name ="Medical Group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? med_group { get; set; }

       /// <summary>
       ///Own Hospital Cust ID
       /// </summary>
       [Display(Name ="Own Hospital Cust ID")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? own_hospital { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       [Display(Name ="客戶運送轉移")]
       [ForeignKey("custtransfer_dbid")]
       public List<View_app_cust_delivery_transfer> View_app_cust_delivery_transfer { get; set; }

    }
}