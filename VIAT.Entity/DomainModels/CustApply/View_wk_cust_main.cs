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
    [Entity(TableCnName = "Customer Apply",TableName = "View_wk_cust_main")]
    public partial class View_wk_cust_main:BaseEntity
    {
        /// <summary>
       ///Bid No
       /// </summary>
       [Display(Name ="Bid No")]
       [MaxLength(20)]
       [Column(TypeName="char(20)")]
       [Editable(true)]
       public string bid_no { get; set; }

       /// <summary>
       ///Apply Type
       /// </summary>
       [Display(Name ="Apply Type")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       [Editable(true)]
       public string apply_type { get; set; }

       /// <summary>
       ///Cust Name
       /// </summary>
       [Display(Name ="Cust Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string cust_name { get; set; }

       /// <summary>
       ///Cust City Name
       /// </summary>
       [Display(Name ="Cust City Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string cust_city_name { get; set; }

       /// <summary>
       ///Cust Zip Name
       /// </summary>
       [Display(Name ="Cust Zip Name")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string cust_zip_id { get; set; }

       /// <summary>
       ///Cust Address
       /// </summary>
       [Display(Name ="Cust Address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string cust_address { get; set; }

       /// <summary>
       ///Invoice Name
       /// </summary>
       [Display(Name ="Invoice Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string invoice_name { get; set; }

       /// <summary>
       ///Invoice City Name
       /// </summary>
       [Display(Name ="Invoice City Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string invoice_city_name { get; set; }

       /// <summary>
       ///Invoice Zip Id
       /// </summary>
       [Display(Name ="Invoice Zip Id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string invoice_zip_id { get; set; }

       /// <summary>
       ///Invoice Address
       /// </summary>
       [Display(Name ="Invoice Address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string invoice_address { get; set; }

       /// <summary>
       ///Delivery City Name
       /// </summary>
       [Display(Name ="Delivery City Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string delivery_city_name { get; set; }

       /// <summary>
       ///Delivery Zip Id
       /// </summary>
       [Display(Name ="Delivery Zip Id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string delivery_zip_id { get; set; }

       /// <summary>
       ///Delivery Addr
       /// </summary>
       [Display(Name ="Delivery Addr")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string delivery_addr { get; set; }

       /// <summary>
       ///Delivery Contact
       /// </summary>
       [Display(Name ="Delivery Contact")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string delivery_contact { get; set; }

       /// <summary>
       ///Delivery Tel
       /// </summary>
       [Display(Name ="Delivery Tel")]
       [MaxLength(60)]
       [Column(TypeName="varchar(60)")]
       [Editable(true)]
       public string delivery_tel_no { get; set; }

       /// <summary>
       ///Doh Type
       /// </summary>
       [Display(Name ="Doh Type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string doh_type { get; set; }

       /// <summary>
       ///NHI Institute No
       /// </summary>
       [Display(Name ="NHI Institute No")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string doh_institute_no { get; set; }

       /// <summary>
       ///Public/Private
       /// </summary>
       [Display(Name ="Public/Private")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string is_private { get; set; }

       /// <summary>
       ///Owner
       /// </summary>
       [Display(Name ="Owner")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
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
       ///Email
       /// </summary>
       [Display(Name ="Email")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string email { get; set; }

       /// <summary>
       ///Fax NO
       /// </summary>
       [Display(Name ="Fax NO")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string fax_no { get; set; }

       /// <summary>
       ///Own Hospital Cust_id
       /// </summary>
       [Display(Name ="Own Hospital Cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string own_hospital_cust_id { get; set; }

       /// <summary>
       ///Controlled  Mdicine Certificate NO
       /// </summary>
       [Display(Name ="Controlled  Mdicine Certificate NO")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       public string ctrl_drug_no { get; set; }

       /// <summary>
       ///Controlled  Medicine Contact
       /// </summary>
       [Display(Name ="Controlled  Medicine Contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       public string ctrl_drug_contact { get; set; }

       /// <summary>
       ///Remark
       /// </summary>
       [Display(Name ="Remark")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///Creator
       /// </summary>
       [Display(Name ="Creator")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string created_username { get; set; }

       /// <summary>
       ///Created Date
       /// </summary>
       [Display(Name ="Created Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///Modifier
       /// </summary>
       [Display(Name ="Modifier")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string modified_username { get; set; }

       /// <summary>
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///列名wkcust_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名wkcust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid wkcust_dbid { get; set; }

       /// <summary>
       ///列名bidmast_dbid
       /// </summary>
       [Display(Name ="列名bidmast_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? bidmast_dbid { get; set; }

       /// <summary>
       ///列名ctype
       /// </summary>
       [Display(Name ="列名ctype")]
       [MaxLength(1)]
       [Column(TypeName="char(1)")]
       public string ctype { get; set; }

       /// <summary>
       ///Cust ID
       /// </summary>
       [Display(Name ="Cust ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cust_id { get; set; }

       /// <summary>
       ///列名territory_id
       /// </summary>
       [Display(Name ="列名territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///Cust Zip Name
       /// </summary>
       [Display(Name ="Cust Zip Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string cust_zip_name { get; set; }

       /// <summary>
       ///列名invoice_type
       /// </summary>
       [Display(Name ="列名invoice_type")]
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
       ///列名contact
       /// </summary>
       [Display(Name ="列名contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string contact { get; set; }

       /// <summary>
       ///列名tel_no
       /// </summary>
       [Display(Name ="列名tel_no")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string tel_no { get; set; }

       /// <summary>
       ///Delivery Zip Name
       /// </summary>
       [Display(Name ="Delivery Zip Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string delivery_zip_name { get; set; }

       /// <summary>
       ///列名source
       /// </summary>
       [Display(Name ="列名source")]
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
       ///列名dbid
       /// </summary>
       [Display(Name ="列名dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///列名own_hospital
       /// </summary>
       [Display(Name ="列名own_hospital")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? own_hospital { get; set; }

       /// <summary>
       ///列名med_group
       /// </summary>
       [Display(Name ="列名med_group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? med_group { get; set; }

       /// <summary>
       ///列名own_by_hospital
       /// </summary>
       [Display(Name ="列名own_by_hospital")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string own_by_hospital { get; set; }

       /// <summary>
       ///列名delv_group
       /// </summary>
       [Display(Name ="列名delv_group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? delv_group { get; set; }

       /// <summary>
       ///列名is_contract
       /// </summary>
       [Display(Name ="列名is_contract")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string is_contract { get; set; }

       /// <summary>
       ///列名created_user
       /// </summary>
       [Display(Name ="列名created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///列名created_client
       /// </summary>
       [Display(Name ="列名created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///列名created_clientusername
       /// </summary>
       [Display(Name ="列名created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///列名modified_user
       /// </summary>
       [Display(Name ="列名modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///列名modified_client
       /// </summary>
       [Display(Name ="列名modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///列名modified_clientusername
       /// </summary>
       [Display(Name ="列名modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///Atart Date
       /// </summary>
       [Display(Name ="Atart Date")]
       [Column(TypeName="date")]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///列名end_date
       /// </summary>
       [Display(Name ="列名end_date")]
       [Column(TypeName="date")]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(2)]
       [Column(TypeName="char(2)")]
       public string status { get; set; }

       /// <summary>
       ///Own Hospital Cust_name
       /// </summary>
       [Display(Name ="Own Hospital Cust_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string own_hospital_cust_name { get; set; }

       
    }
}