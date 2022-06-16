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
    [Entity(TableCnName = "客戶基本信息視圖",TableName = "View_com_cust",DetailTable =  new Type[] { typeof(View_com_cust_delivery)},DetailTableCnName = "客戶送貨資訊")]
    public partial class View_com_cust:BaseEntity
    {
        /// <summary>
       ///列名cust_id
       /// </summary>
       [Display(Name ="列名cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_id { get; set; }

       /// <summary>
       ///列名entity
       /// </summary>
       [Display(Name ="列名entity")]
       [MaxLength(3)]
       [JsonIgnore]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///列名division
       /// </summary>
       [Display(Name ="列名division")]
       [MaxLength(15)]
       [JsonIgnore]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///列名cust_name
       /// </summary>
       [Display(Name ="列名cust_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_name { get; set; }

       /// <summary>
       ///列名territory_id
       /// </summary>
       [Display(Name ="列名territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string territory_id { get; set; }

       /// <summary>
       ///列名invoice_name
       /// </summary>
       [Display(Name ="列名invoice_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_name { get; set; }

       /// <summary>
       ///列名invoice_address
       /// </summary>
       [Display(Name ="列名invoice_address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_address { get; set; }

       /// <summary>
       ///列名owner
       /// </summary>
       [Display(Name ="列名owner")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string owner { get; set; }

       /// <summary>
       ///列名tax_id
       /// </summary>
       [Display(Name ="列名tax_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string tax_id { get; set; }

       /// <summary>
       ///列名contact
       /// </summary>
       [Display(Name ="列名contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       public string contact { get; set; }

       /// <summary>
       ///列名fax_no
       /// </summary>
       [Display(Name ="列名fax_no")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string fax_no { get; set; }

       /// <summary>
       ///列名email
       /// </summary>
       [Display(Name ="列名email")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string email { get; set; }

       /// <summary>
       ///列名cust_address
       /// </summary>
       [Display(Name ="列名cust_address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_address { get; set; }

       /// <summary>
       ///列名tel_no
       /// </summary>
       [Display(Name ="列名tel_no")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string tel_no { get; set; }

       /// <summary>
       ///列名doh_institute_no
       /// </summary>
       [Display(Name ="列名doh_institute_no")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string doh_institute_no { get; set; }

       /// <summary>
       ///列名ctrl_drug_no
       /// </summary>
       [Display(Name ="列名ctrl_drug_no")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       public string ctrl_drug_no { get; set; }

       /// <summary>
       ///列名ctrl_drug_contact
       /// </summary>
       [Display(Name ="列名ctrl_drug_contact")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       public string ctrl_drug_contact { get; set; }

       /// <summary>
       ///列名doh_type
       /// </summary>
       [Display(Name ="列名doh_type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string doh_type { get; set; }

       /// <summary>
       ///列名margin_type
       /// </summary>
       [Display(Name ="列名margin_type")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string margin_type { get; set; }

       /// <summary>
       ///列名is_contract
       /// </summary>
       [Display(Name ="列名is_contract")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string is_contract { get; set; }

       /// <summary>
       ///列名is_private
       /// </summary>
       [Display(Name ="列名is_private")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string is_private { get; set; }

       /// <summary>
       ///列名own_by_hospital
       /// </summary>
       [Display(Name ="列名own_by_hospital")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string own_by_hospital { get; set; }

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
       ///列名delv_group
       /// </summary>
       [Display(Name ="列名delv_group")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? delv_group { get; set; }

       /// <summary>
       ///列名new_cust_id
       /// </summary>
       [Display(Name ="列名new_cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string new_cust_id { get; set; }

       /// <summary>
       ///列名inactive_date
       /// </summary>
       [Display(Name ="列名inactive_date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? inactive_date { get; set; }

       /// <summary>
       ///列名status
       /// </summary>
       [Display(Name ="列名status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///列名remarks
       /// </summary>
       [Display(Name ="列名remarks")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       [Editable(true)]
       public string remarks { get; set; }

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
       ///列名invoice_type
       /// </summary>
       [Display(Name ="列名invoice_type")]
       [MaxLength(2)]
       [Column(TypeName="varchar(2)")]
       public string invoice_type { get; set; }

       /// <summary>
       ///列名invoice_zip_name
       /// </summary>
       [Display(Name ="列名invoice_zip_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string invoice_zip_name { get; set; }

       /// <summary>
       ///列名invoice_city_name
       /// </summary>
       [Display(Name ="列名invoice_city_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_city_name { get; set; }

       /// <summary>
       ///客戶城市
       /// </summary>
       [Display(Name ="客戶城市")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_city_name { get; set; }

       /// <summary>
       ///客戶地區
       /// </summary>
       [Display(Name ="客戶地區")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string cust_zip_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_zip_name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string cust_zip_name { get; set; }

       /// <summary>
       ///列名invoice_zip_id
       /// </summary>
       [Display(Name ="列名invoice_zip_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string invoice_zip_id { get; set; }

       /// <summary>
       ///列名modified_date
       /// </summary>
       [Display(Name ="列名modified_date")]
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
       ///列名created_date
       /// </summary>
       [Display(Name ="列名created_date")]
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
       ///列名created_username
       /// </summary>
       [Display(Name ="列名created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///列名own_hospitalname
       /// </summary>
       [Display(Name ="列名own_hospitalname")]
       [MaxLength(111)]
       [Column(TypeName="nvarchar(111)")]
       [Editable(true)]
       public string own_hospitalname { get; set; }

       /// <summary>
       ///列名med_groupname
       /// </summary>
       [Display(Name ="列名med_groupname")]
       [MaxLength(111)]
       [Column(TypeName="nvarchar(111)")]
       [Editable(true)]
       public string med_groupname { get; set; }

       /// <summary>
       ///列名delv_groupname
       /// </summary>
       [Display(Name ="列名delv_groupname")]
       [MaxLength(111)]
       [Column(TypeName="nvarchar(111)")]
       [Editable(true)]
       public string delv_groupname { get; set; }

       /// <summary>
       ///列名C1
       /// </summary>
       [Display(Name ="列名C1")]
       [MaxLength(71)]
       [Column(TypeName="nvarchar(71)")]
       [Required(AllowEmptyStrings=false)]
       public string C1 { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="last_deal_date")]
       [Column(TypeName="date")]
       public DateTime? last_deal_date { get; set; }

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

       [Display(Name ="客戶送貨資訊")]
       [ForeignKey("cust_dbid")]
       public List<View_com_cust_delivery> View_com_cust_delivery { get; set; }

    }
}
