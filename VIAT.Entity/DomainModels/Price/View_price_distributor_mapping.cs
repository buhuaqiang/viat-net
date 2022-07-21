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
    [Entity(TableCnName = "經銷商映射",TableName = "View_price_distributor_mapping")]
    public partial class View_price_distributor_mapping:BaseEntity
    {
        /// <summary>
       ///Product
       /// </summary>
       [Display(Name ="Product")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string prods { get; set; }

       /// <summary>
       ///Customer
       /// </summary>
       [Display(Name ="Customer")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string custs { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="pricegroups")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string pricegroups { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="distmapping_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid distmapping_dbid { get; set; }

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
       [Display(Name ="prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

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
       [Display(Name ="created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

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
       [Display(Name ="modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///Product ID
       /// </summary>
       [Display(Name ="Product ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string prod_id { get; set; }

       /// <summary>
       ///Product Name
       /// </summary>
       [Display(Name ="Product Name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string prod_ename { get; set; }

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
       ///Group ID
       /// </summary>
       [Display(Name ="Group ID")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? pricegroup_dbid { get; set; }

       /// <summary>
       ///Group ID
       /// </summary>
       [Display(Name ="Group ID")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string group_id { get; set; }

       /// <summary>
       ///Group Name
       /// </summary>
       [Display(Name ="Group Name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       public string group_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_cname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="state")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string state { get; set; }

       /// <summary>
       ///Customer ID
       /// </summary>
       [Display(Name ="Customer ID")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///Customer ID
       /// </summary>
       [Display(Name ="Customer ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string cust_id { get; set; }

       /// <summary>
       ///Customer Name
       /// </summary>
       [Display(Name ="Customer Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string cust_name { get; set; }

       /// <summary>
       ///Original Distributor
       /// </summary>
       [Display(Name ="Original Distributor")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string i_dist_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="statusCust")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string statusCust { get; set; }

       /// <summary>
       ///Assign Distributor
       /// </summary>
       [Display(Name ="Assign Distributor")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string e_dist_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="sys_value")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string sys_value { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="sys_value2")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string sys_value2 { get; set; }

       /// <summary>
       ///Start Date
       /// </summary>
       [Display(Name ="Start Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime end_date { get; set; }

       /// <summary>
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string status { get; set; }

       /// <summary>
       ///Remarks
       /// </summary>
       [Display(Name ="Remarks")]
       [MaxLength(256)]
       [Column(TypeName="nvarchar(256)")]
       [Editable(true)]
       public string remarks { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }

       
    }
}