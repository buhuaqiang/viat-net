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
    [Entity(TableCnName = "Import Bid Price ",TableName = "View_cust_price_transfer")]
    public partial class View_cust_price_transfer:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="price_transfer_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid price_transfer_dbid { get; set; }

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
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string bid_no { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string state { get; set; }

       /// <summary>
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Applied Date
       /// </summary>
       [Display(Name ="Applied Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///Requestor
       /// </summary>
       [Display(Name ="Requestor")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string requestor_name { get; set; }

       /// <summary>
       ///Requestor
       /// </summary>
       [Display(Name ="Requestor")]
       [MaxLength(56)]
       [Column(TypeName="nvarchar(56)")]
       public string requestorName { get; set; }

       /// <summary>
       ///Requestor
       /// </summary>
       [Display(Name ="Requestor")]
       [Column(TypeName="int")]
       public int? requestor { get; set; }

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
       public string group_name { get; set; }

       /// <summary>
       ///Cust ID
       /// </summary>
       [Display(Name ="Cust ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string cust_id { get; set; }

       /// <summary>
       ///Cust Name
       /// </summary>
       [Display(Name ="Cust Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }

       /// <summary>
       ///Prod ID
       /// </summary>
       [Display(Name ="Prod ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="pricegroup_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? pricegroup_dbid { get; set; }

       /// <summary>
       ///Prod Name
       /// </summary>
       [Display(Name ="Prod Name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="nhi_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="bmp_cust_id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string bmp_cust_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="net_price_ebms")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? net_price_ebms { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="invoice_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? invoice_price { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="net_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? net_price { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="cust_id_ebms")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string cust_id_ebms { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_id_ebms")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_id_ebms { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="min_qty_ebms")]
       [Column(TypeName="int")]
       public int? min_qty_ebms { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="min_qty")]
       [Column(TypeName="int")]
       public int? min_qty { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="price_list")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? price_list { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="price_bid")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? price_bid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="price_close")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? price_close { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="discount")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? discount { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="final_discount")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? final_discount { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="final_fg")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? final_fg { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="territory_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string territory_id { get; set; }

       /// <summary>
       ///Start Date
       /// </summary>
       [Display(Name ="Start Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///Group Import
       /// </summary>
       [Display(Name ="Group Import")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string add_group { get; set; }

       /// <summary>
       ///Bid Note
       /// </summary>
       [Display(Name ="Bid Note")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       public string note { get; set; }

       /// <summary>
       ///Transfer Date
       /// </summary>
       [Display(Name ="Transfer Date")]
       [Column(TypeName="datetime")]
       public DateTime? transfer_date { get; set; }

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
       ///Pending Reason
       /// </summary>
       [Display(Name ="Pending Reason")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string pendingReason { get; set; }

       /// <summary>
       ///MPG
       /// </summary>
       [Display(Name ="MPG")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string mpg_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="reserv_price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
        [Editable(true)]
        public decimal? reserv_price { get; set; }
    }
}