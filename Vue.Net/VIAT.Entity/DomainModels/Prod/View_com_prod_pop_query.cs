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
    [Entity(TableCnName = "產品pop框",TableName = "View_com_prod_pop_query")]
    public partial class View_com_prod_pop_query:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="localmpg_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? localmpg_dbid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Required(AllowEmptyStrings=false)]
       public string prod_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_ename")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

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
       [Display(Name ="prod_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_cname { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_sname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_sname { get; set; }

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
       [Display(Name ="pack_size")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? pack_size { get; set; }

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
       [Display(Name ="std_cost")]
       [DisplayFormat(DataFormatString="12,5")]
       [Column(TypeName="decimal")]
       public decimal? std_cost { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="unit_stock")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string unit_stock { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="unit_sale")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string unit_sale { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="global_mpg")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string global_mpg { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="nhi_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string nhi_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_type")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_type { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="inv_type")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string inv_type { get; set; }

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
       [Display(Name ="new_prod_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string new_prod_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="is_ctrl_drug")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string is_ctrl_drug { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="license_no")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string license_no { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="license_name")]
       [MaxLength(60)]
       [Column(TypeName="nvarchar(60)")]
       public string license_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="stock_market")]
       [Column(TypeName="int")]
       public int? stock_market { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="stock_pfizer")]
       [Column(TypeName="int")]
       public int? stock_pfizer { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="safty_stock")]
       [Column(TypeName="int")]
       public int? safty_stock { get; set; }

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
       [Display(Name ="status_sample")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status_sample { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="status_bid")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status_bid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="status_stock_pfizer")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status_stock_pfizer { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="status_stock_dist")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status_stock_dist { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="default_dist_id")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       public string default_dist_id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_short_name")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_short_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_category")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_category { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_form")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_form { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_strength")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_strength { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="prod_packed")]
       [MaxLength(30)]
       [Column(TypeName="varchar(30)")]
       public string prod_packed { get; set; }

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
       ///
       /// </summary>
       [Display(Name ="modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="globalmpg_dbid2")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? globalmpg_dbid2 { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="lmpg_mpg_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string lmpg_mpg_id { get; set; }


        /// <summary>
        ///
        /// </summary>
        [Display(Name = "category")]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string category { get; set; }


    }
}