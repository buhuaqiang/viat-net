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
    [Entity(TableCnName = "價格策略合約產品PickUp",TableName = "View_wk_cont_stretagy_detail_main")]
    public partial class View_wk_cont_stretagy_detail_main:BaseEntity
    {
        /// <summary>
       ///Stretagy ID
       /// </summary>
       [Display(Name ="Stretagy ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cont_stretagy_id { get; set; }

       /// <summary>
       ///Stretagy Name
       /// </summary>
       [Display(Name ="Stretagy Name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       public string cont_stretagy_name { get; set; }

       /// <summary>
       ///列名prod_id
       /// </summary>
       [Display(Name ="列名prod_id")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Required(AllowEmptyStrings=false)]
       public string prod_id { get; set; }

       /// <summary>
       ///Product Ename
       /// </summary>
       [Display(Name ="Product Ename")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///Product Cname 
       /// </summary>
       [Display(Name ="Product Cname ")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string prod_cname { get; set; }

       /// <summary>
       ///NHI Price
       /// </summary>
       [Display(Name ="NHI Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? nhi_price { get; set; }

       /// <summary>
       ///Invoice Price
       /// </summary>
       [Display(Name ="Invoice Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? invoice_price { get; set; }

       /// <summary>
       ///Net Price
       /// </summary>
       [Display(Name ="Net Price")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       public decimal? net_price { get; set; }

       /// <summary>
       ///Min Qty
       /// </summary>
       [Display(Name ="Min Qty")]
       [Column(TypeName="int")]
       public int? min_qty { get; set; }

       /// <summary>
       ///Product Type
       /// </summary>
       [Display(Name ="Product Type")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string prod_type { get; set; }

        /// <summary>
        ///Product Type
        /// </summary>
        [Display(Name = "Category")]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string category { get; set; }

        /// <summary>
        ///列名contstretail_dbid
        /// </summary>
        [Key]
       [Display(Name ="列名contstretail_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid contstretail_dbid { get; set; }

        /// <summary>
        ///是否屬合約品項
        /// </summary>
        [Display(Name = "Is Belong")]
        [MaxLength(1)]
        [Column(TypeName = "varchar(1)")]
        [Editable(true)]
        public string isbelong { get; set; }

        /// <summary>
        ///列名modified_date
        /// </summary>
        [Display(Name ="列名modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///列名modified_clientusername
       /// </summary>
       [Display(Name ="列名modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///列名modified_client
       /// </summary>
       [Display(Name ="列名modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///列名modified_username
       /// </summary>
       [Display(Name ="列名modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

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
       ///列名created_username
       /// </summary>
       [Display(Name ="列名created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///列名created_user
       /// </summary>
       [Display(Name ="列名created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///列名prod_dbid
       /// </summary>
       [Display(Name ="列名prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_dbid { get; set; }

       /// <summary>
       ///列名contstret_dbid
       /// </summary>
       [Display(Name ="列名contstret_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid contstret_dbid { get; set; }

       /// <summary>
       ///列名created_clientusername
       /// </summary>
       [Display(Name ="列名created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       
    }
}