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
    [Entity(TableCnName = "GP合约主页面",TableName = "View_app_power_contract_main",DetailTable =  new Type[] { typeof(Viat_app_power_contract_cust)},DetailTableCnName = "合約客戶列表")]
    public partial class View_app_power_contract_main:BaseEntity
    {
        /// <summary>
       ///列dbid
       /// </summary>
       [Display(Name ="列dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       /// <summary>
       ///列entity
       /// </summary>
       [Display(Name ="列entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///列division
       /// </summary>
       [Display(Name ="列division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///列contract_no
       /// </summary>
       [Display(Name ="列contract_no")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string contract_no { get; set; }

       /// <summary>
       ///列contract_type
       /// </summary>
       [Display(Name ="列contract_type")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string contract_type { get; set; }

       /// <summary>
       ///列start_date
       /// </summary>
       [Display(Name ="列start_date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///列end_date
       /// </summary>
       [Display(Name ="列end_date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///列cust_id
       /// </summary>
       [Display(Name ="列cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string cust_id { get; set; }

       /// <summary>
       ///列territory_id
       /// </summary>
       [Display(Name ="列territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///列allw_type
       /// </summary>
       [Display(Name ="列allw_type")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? allw_type { get; set; }

       /// <summary>
       ///列est_months
       /// </summary>
       [Display(Name ="列est_months")]
       [Column(TypeName="int")]
       public int? est_months { get; set; }

       /// <summary>
       ///列accrue_amt
       /// </summary>
       [Display(Name ="列accrue_amt")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? accrue_amt { get; set; }

       /// <summary>
       ///列sales_amt
       /// </summary>
       [Display(Name ="列sales_amt")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? sales_amt { get; set; }

       /// <summary>
       ///列contract_term
       /// </summary>
       [Display(Name ="列contract_term")]
       [MaxLength(16)]
       [Column(TypeName="text(16)")]
       [Editable(true)]
       public string contract_term { get; set; }

       /// <summary>
       ///列state
       /// </summary>
    /*   [Display(Name ="列state")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string state { get; set; }*/

       /// <summary>
       ///列close_date
       /// </summary>
       [Display(Name ="列close_date")]
       [Column(TypeName="date")]
       [Editable(true)]
       public DateTime? close_date { get; set; }

       /// <summary>
       ///列close_date2
       /// </summary>
       [Display(Name ="列close_date2")]
       [Column(TypeName="date")]
       public DateTime? close_date2 { get; set; }

       /// <summary>
       ///列trans_start_date
       /// </summary>
       [Display(Name ="列trans_start_date")]
       [Column(TypeName="datetime")]
       public DateTime? trans_start_date { get; set; }

       /// <summary>
       ///列trans_end_date
       /// </summary>
       [Display(Name ="列trans_end_date")]
       [Column(TypeName="datetime")]
       public DateTime? trans_end_date { get; set; }

       /// <summary>
       ///列rate
       /// </summary>
       [Display(Name ="列rate")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? rate { get; set; }

       /// <summary>
       ///列total_fg_amount
       /// </summary>
       [Display(Name ="列total_fg_amount")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? total_fg_amount { get; set; }

       /// <summary>
       ///列group_name
       /// </summary>
       [Display(Name ="列group_name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string group_name { get; set; }

       /// <summary>
       ///列cust_name
       /// </summary>
       [Display(Name ="列cust_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///列Contract_State
       /// </summary>
       [Display(Name ="列Contract_State")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string state { get; set; }

       /// <summary>
       ///列C1
       /// </summary>
       [Display(Name ="列C1")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
      // [Required(AllowEmptyStrings=false)]
       public string C1 { get; set; }

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
       ///列名pricegroup_dbid
       /// </summary>
       [Display(Name ="列名pricegroup_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? pricegroup_dbid { get; set; }

       /// <summary>
       ///列名cust_dbid
       /// </summary>
       [Display(Name ="列名cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///列名group_id
       /// </summary>
       [Display(Name ="列名group_id")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string group_id { get; set; }

       /// <summary>
       ///列名powercont_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名powercont_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid powercont_dbid { get; set; }

       /// <summary>
       ///Contract_State
       /// </summary>
       [Display(Name ="Contract_State")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string Contract_State { get; set; }

       /// <summary>
       ///GPDS_Contract_Type
       /// </summary>
       [Display(Name ="GPDS_Contract_Type")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string GPDS_Contract_Type { get; set; }

       [Display(Name ="合約客戶列表")]
       [ForeignKey("powercont_dbid")]
       public List<Viat_app_power_contract_cust> Viat_app_power_contract_cust { get; set; }

    }
}