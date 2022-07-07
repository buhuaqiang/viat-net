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
    [Entity(TableCnName = "產品信息",TableName = "View_com_prod")]
    public partial class View_com_prod:BaseEntity
    {
       
       /// <summary>
       ///Entity
       /// </summary>
       [Display(Name ="Entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       [Editable(true)]
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
       ///Sales MPG
       /// </summary>
       [Display(Name ="Sales MPG")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string lmpg_mpg_id { get; set; }

       /// <summary>
       ///Finance MPG
       /// </summary>
       [Display(Name ="Finance MPG")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string global_mpg { get; set; }

       /// <summary>
       ///Item Code
       /// </summary>
       [Display(Name ="Item Code")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string prod_id { get; set; }

       /// <summary>
       ///Item Description(Chinese)
       /// </summary>
       [Display(Name ="Item Description(Chinese)")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string prod_sname { get; set; }

       /// <summary>
       ///Item Description(English)
       /// </summary>
       [Display(Name ="Item Description(English)")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       [Editable(true)]
       public string prod_ename { get; set; }

       /// <summary>
       ///列名prod_cname
       /// </summary>
       [Display(Name ="列名prod_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_cname { get; set; }

       /// <summary>
       ///列名std_cost
       /// </summary>
       [Display(Name ="列名std_cost")]
       [DisplayFormat(DataFormatString="12,5")]
       [Column(TypeName="decimal")]
       public decimal? std_cost { get; set; }

       /// <summary>
       ///Unit Of Stock
       /// </summary>
       [Display(Name ="Unit Of Stock")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string unit_stock { get; set; }

       /// <summary>
       ///Unit Of Sale
       /// </summary>
       [Display(Name ="Unit Of Sale")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string unit_sale { get; set; }

       /// <summary>
       ///NHI Product Code
       /// </summary>
       [Display(Name ="NHI Product Code")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string nhi_id { get; set; }

       /// <summary>
       ///列名prod_type
       /// </summary>
       [Display(Name ="列名prod_type")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_type { get; set; }

       /// <summary>
       ///Inv Type
       /// </summary>
       [Display(Name ="Inv Type")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string inv_type { get; set; }

       /// <summary>
       ///NHI Fact/Dis Percent
       /// </summary>
       [Display(Name ="NHI Fact/Dis Percent")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? pack_size { get; set; }

       /// <summary>
       ///Pack Size(Pricing)
       /// </summary>
       [Display(Name ="Pack Size(Pricing)")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? pack_size_pri { get; set; }

       /// <summary>
       ///列名new_prod_id
       /// </summary>
       [Display(Name ="列名new_prod_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string new_prod_id { get; set; }

       /// <summary>
       ///Is Control Drug
       /// </summary>
       [Display(Name ="Is Control Drug")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string is_ctrl_drug { get; set; }

       /// <summary>
       ///NHI Price
       /// </summary>
       [Display(Name ="NHI Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///License Product No
       /// </summary>
       [Display(Name ="License Product No")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       [Editable(true)]
       public string license_no { get; set; }

       /// <summary>
       ///License Product Name
       /// </summary>
       [Display(Name ="License Product Name")]
       [MaxLength(60)]
       [Column(TypeName="nvarchar(60)")]
       [Editable(true)]
       public string license_name { get; set; }

       /// <summary>
       ///列名stock_market
       /// </summary>
       [Display(Name ="列名stock_market")]
       [Column(TypeName="int")]
       public int? stock_market { get; set; }

       /// <summary>
       ///列名stock_pfizer
       /// </summary>
       [Display(Name ="列名stock_pfizer")]
       [Column(TypeName="int")]
       public int? stock_pfizer { get; set; }

       /// <summary>
       ///Sample Safty Stock
       /// </summary>
       [Display(Name ="Sample Safty Stock")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? safty_stock { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string state { get; set; }

       /// <summary>
       ///Samples Prohibited
       /// </summary>
       [Display(Name ="Samples Prohibited")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status_sample { get; set; }

       /// <summary>
       ///Bids Prohibited
       /// </summary>
       [Display(Name ="Bids Prohibited")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status_bid { get; set; }

       /// <summary>
       ///No Stock(Pfizer)
       /// </summary>
       [Display(Name ="No Stock(Pfizer)")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status_stock_pfizer { get; set; }

       /// <summary>
       ///No Stock(Dist)
       /// </summary>
       [Display(Name ="No Stock(Dist)")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status_stock_dist { get; set; }

       /// <summary>
       ///Default Distributor
       /// </summary>
       [Display(Name ="Default Distributor")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string default_dist_id { get; set; }

       /// <summary>
       ///Product Short Name
       /// </summary>
       [Display(Name ="Product Short Name")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       [Editable(true)]
       public string prod_short_name { get; set; }

       /// <summary>
       ///列名prod_category
       /// </summary>
       [Display(Name ="列名prod_category")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_category { get; set; }

       /// <summary>
       ///Form
       /// </summary>
       [Display(Name ="Form")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       [Editable(true)]
       public string prod_form { get; set; }

       /// <summary>
       ///Strength
       /// </summary>
       [Display(Name ="Strength")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       [Editable(true)]
       public string prod_strength { get; set; }

       /// <summary>
       ///Packed
       /// </summary>
       [Display(Name ="Packed")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       [Editable(true)]
       public string prod_packed { get; set; }

       /// <summary>
       ///列名lmpg_dbid
       /// </summary>
       [Display(Name ="列名lmpg_dbid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int lmpg_dbid { get; set; }

       /// <summary>
       ///列名lmpg_entity
       /// </summary>
       [Display(Name ="列名lmpg_entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string lmpg_entity { get; set; }

       /// <summary>
       ///localmpgid
       /// </summary>
       [Display(Name ="localmpgid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? localmpg_dbid { get; set; }

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
       ///列名modified_date
       /// </summary>
       [Display(Name ="列名modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///列名prod_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_dbid { get; set; }

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

       
    }
}