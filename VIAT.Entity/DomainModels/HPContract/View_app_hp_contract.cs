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
    [Entity(TableCnName = "HP合約設置",TableName = "viat_app_hp_contract")]
    public partial class View_app_hp_contract:BaseEntity
    {
        /// <summary>
       ///列名hpcont_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名hpcont_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid hpcont_dbid { get; set; }

       /// <summary>
       ///列名entity
       /// </summary>
       [Display(Name ="列名entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///列名division
       /// </summary>
       [Display(Name ="列名division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///Allowance Type
       /// </summary>
       [Display(Name ="Allowance Type")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int allw_type { get; set; }

       /// <summary>
       ///Contract No
       /// </summary>
       [Display(Name ="Contract No")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string contract_no { get; set; }

       /// <summary>
       ///GroupId
       /// </summary>
       [Display(Name ="GroupId")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string group_id { get; set; }

       /// <summary>
       ///GroupName
       /// </summary>
       [Display(Name ="GroupName")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string group_name { get; set; }

       /// <summary>
       ///CustID
       /// </summary>
      /*  [Display(Name ="CustID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string g_cust_id { get; set; }*/

       /// <summary>
       ///CustName
       /// </summary>
      /* [Display(Name ="CustName")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string g_cust_name { get; set; }*/

       /// <summary>
       ///FG Product Code
       /// </summary>
       [Display(Name ="FG Product Code")]
       [MaxLength(1000)]
       [Column(TypeName="varchar(1000)")]
       public string prod_id { get; set; }

       /// <summary>
       ///FG Product Name
       /// </summary>
       [Display(Name ="FG Product Name")]
       [MaxLength(2000)]
       [Column(TypeName="varchar(2000)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///Effective Date
       /// </summary>
       [Display(Name ="Effective Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime start_date { get; set; }

       /// <summary>
       ///Bu
       /// </summary>
       [Display(Name ="Bu")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       public string bu_id { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime end_date { get; set; }

       /// <summary>
       ///Accrue Amount(Per Month)
       /// </summary>
       [Display(Name ="Accrue Amount(Per Month)")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public decimal accrue_amt { get; set; }

       /// <summary>
       ///Accrue Amount
       /// </summary>
       [Display(Name ="Accrue Amount")]
       [DisplayFormat(DataFormatString="38,5")]
       [Column(TypeName="decimal")]
       public decimal? C1 { get; set; }

       /// <summary>
       ///Reverse Amount
       /// </summary>
       [Display(Name ="Reverse Amount")]
       [DisplayFormat(DataFormatString="38,5")]
       [Column(TypeName="decimal")]
       public decimal? C2 { get; set; }

       /// <summary>
       ///modified_date
       /// </summary>
       [Display(Name ="modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Contract Term
       /// </summary>
       [Display(Name ="Contract Term")]
       [MaxLength(16)]
       [Column(TypeName="text(16)")]
       [Editable(true)]
       public string contract_term { get; set; }

       /// <summary>
       ///列名est_months
       /// </summary>
       [Display(Name ="列名est_months")]
       [Column(TypeName="int")]
       public int? est_months { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string state { get; set; }

       /// <summary>
       ///列名o_contract_no
       /// </summary>
       [Display(Name ="列名o_contract_no")]
       [Column(TypeName="int")]
       public int? o_contract_no { get; set; }

       /// <summary>
       ///列名created_user
       /// </summary>
       [Display(Name ="列名created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///列名created_username
       /// </summary>
       [Display(Name ="列名created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

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
       ///列名created_date
       /// </summary>
       [Display(Name ="列名created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///列名modified_user
       /// </summary>
       [Display(Name ="列名modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///列名modified_username
       /// </summary>
       [Display(Name ="列名modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

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
       ///列名C3
       /// </summary>
       [Display(Name ="列名C3")]
       [DisplayFormat(DataFormatString="38,5")]
       [Column(TypeName="decimal")]
       public decimal? C3 { get; set; }

       /// <summary>
       ///列名cust_dbid2
       /// </summary>
       /*[Display(Name ="列名cust_dbid2")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid2 { get; set; }*/

       /// <summary>
       ///列名cust_dbid
       /// </summary>
       [Display(Name ="列名cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///列名cust_id
       /// </summary>
       [Display(Name ="列名cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cust_id { get; set; }

       /// <summary>
       ///列名cust_name
       /// </summary>
       [Display(Name ="列名cust_name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///列名prod_dbid
       /// </summary>
       [Display(Name ="列名prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///列名cf_prod_dbid
       /// </summary>
       [Display(Name ="列名cf_prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? cf_prod_dbid { get; set; }

       /// <summary>
       ///列名pu_prod_dbid
       /// </summary>
       [Display(Name ="列名pu_prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? pu_prod_dbid { get; set; }

       /// <summary>
       ///列名pricegroup_dbid
       /// </summary>
       [Display(Name ="列名pricegroup_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? pricegroup_dbid { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "costomer_type")]
        [MaxLength(1)]
        [Column(TypeName = "varchar(1)")]
        [Required(AllowEmptyStrings = false)]
        public string costomer_type { get; set; }


    }
}