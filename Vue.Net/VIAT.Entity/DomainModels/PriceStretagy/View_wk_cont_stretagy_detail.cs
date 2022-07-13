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
    [Entity(TableCnName = "價格策略合約產品",TableName = "View_wk_cont_stretagy_detail")]
    public partial class View_wk_cont_stretagy_detail:BaseEntity
    {
        /// <summary>
       ///產品
       /// </summary>
       [Display(Name ="產品")]
       [MaxLength(67)]
       [Column(TypeName="varchar(67)")]
       public string prod_enameid { get; set; }

       /// <summary>
       ///NHI
       /// </summary>
       [Display(Name ="NHI")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///發票價
       /// </summary>
       [Display(Name ="發票價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? invoice_price { get; set; }

       /// <summary>
       ///實售價
       /// </summary>
       [Display(Name ="實售價")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? net_price { get; set; }

       /// <summary>
       ///最低數量
       /// </summary>
       [Display(Name ="最低數量")]
       [Column(TypeName="int")]
       public int? min_qty { get; set; }

       /// <summary>
       ///類別
       /// </summary>
       [Display(Name ="類別")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string inv_type { get; set; }

       /// <summary>
       ///列名contstretail_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名contstretail_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid contstretail_dbid { get; set; }

       /// <summary>
       ///列名contstret_dbid
       /// </summary>
       [Display(Name ="列名contstret_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid contstret_dbid { get; set; }

       /// <summary>
       ///列名prod_dbid
       /// </summary>
       [Display(Name ="列名prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_dbid { get; set; }

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
       ///列名modified_date
       /// </summary>
       [Display(Name ="列名modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///列名prod_id
       /// </summary>
       [Display(Name ="列名prod_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_id { get; set; }

       /// <summary>
       ///列名prod_ename
       /// </summary>
       [Display(Name ="列名prod_ename")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       
    }
}