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
    [Entity(TableCnName = "價格群組對應客戶",TableName = "View_cust_custgroup_pricegroup")]
    public partial class View_cust_custgroup_pricegroup:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid cust_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Required(AllowEmptyStrings=false)]
       public string cust_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string cust_address { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string invoice_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string invoice_address { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="owner")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string owner { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="tax_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string tax_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string contact { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="tel_no")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string tel_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="fax_no")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string fax_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="email")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string email { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="doh_institute_no")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string doh_institute_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ctrl_drug_no")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string ctrl_drug_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ctrl_drug_contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string ctrl_drug_contact { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_zip_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string cust_zip_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_zip_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string invoice_zip_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="doh_type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string doh_type { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="margin_type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string margin_type { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="is_contract")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string is_contract { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="is_private")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string is_private { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="own_by_hospital")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string own_by_hospital { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="own_hospital")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? own_hospital { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="med_group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? med_group { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="delv_group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? delv_group { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="new_cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string new_cust_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="inactive_date")]
       [Column(TypeName="datetime")]
       public DateTime? inactive_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="remarks")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       public string remarks { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="source")]
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
       [Column(TypeName="varchar(2)")]
       public string invoice_type { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

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
       ///
       /// </summary>
       [Display(Name ="custGroupStatus")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string custGroupStatus { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="priceGroudId")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string priceGroudId { get; set; }

       
    }
}