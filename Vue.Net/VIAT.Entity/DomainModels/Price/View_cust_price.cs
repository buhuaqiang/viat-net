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
    [Entity(TableCnName = "群組價格主頁面",TableName = "View_cust_price")]
    public partial class View_cust_price:BaseEntity
    {
        /// <summary>
       ///Group Id
       /// </summary>
       [Display(Name ="Group Id")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string group_id { get; set; }

       /// <summary>
       ///Group Name
       /// </summary>
       [Display(Name ="Group Name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string group_name { get; set; }

       /// <summary>
       ///Product Id
       /// </summary>
       [Display(Name ="Product Id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Required(AllowEmptyStrings=false)]
       public string prod_id { get; set; }

       /// <summary>
       ///Product Name
       /// </summary>
       [Display(Name ="Product Name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="custprice_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid custprice_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///Bid NO
       /// </summary>
       [Display(Name ="Bid NO")]
       [MaxLength(16)]
       [Column(TypeName="varchar(16)")]
       [Editable(true)]
       public string bid_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="requestor")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string requestor { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="pricegroup_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? pricegroup_dbid { get; set; }

       /// <summary>
       ///NHI Price
       /// </summary>
       [Display(Name ="NHI Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///Invoice Price
       /// </summary>
       [Display(Name ="Invoice Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? invoice_price { get; set; }

       /// <summary>
       ///Net Price
       /// </summary>
       [Display(Name ="Net Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? net_price { get; set; }

       /// <summary>
       ///Min Qty
       /// </summary>
       [Display(Name ="Min Qty")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? min_qty { get; set; }

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
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Required(AllowEmptyStrings=false)]
       public string status { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="is_used")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string is_used { get; set; }

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
       [Display(Name ="nhi_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string nhi_id { get; set; }

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
       [Display(Name ="sys_end_date")]
       [Column(TypeName="datetime")]
       public DateTime? sys_end_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="org_start_date")]
       [Column(TypeName="datetime")]
       public DateTime? org_start_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="org_end_date")]
       [Column(TypeName="datetime")]
       public DateTime? org_end_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="updated_user")]
       [Column(TypeName="int")]
       public int? updated_user { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="updated_date")]
       [Column(TypeName="datetime")]
       public DateTime? updated_date { get; set; }

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
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Group
       /// </summary>
       [Display(Name ="Group")]
       [MaxLength(121)]
       [Column(TypeName="varchar(121)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string pricegroup_dbidname { get; set; }

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
       [Display(Name ="prod_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_cname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="pack_size_pri")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? pack_size_pri { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="state")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string state { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="C1")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string C1 { get; set; }

       /// <summary>
       ///Product
       /// </summary>
       [Display(Name ="Product")]
       [MaxLength(66)]
       [Column(TypeName="varchar(66)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string prod_dbidname { get; set; }

       
    }
}