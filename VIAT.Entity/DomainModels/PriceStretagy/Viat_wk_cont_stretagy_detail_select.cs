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
    [Entity(TableCnName = "價格策略合約產品信息",TableName = "Viat_wk_cont_stretagy_detail_select")]
    public partial class Viat_wk_cont_stretagy_detail_select:BaseEntity
    {
        /// <summary>
       ///PKID
       /// </summary>
       [Key]
       [Display(Name ="PKID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid contstretail_dbid { get; set; }

       /// <summary>
       ///FK
       /// </summary>
       [Display(Name ="FK")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public Guid contstret_dbid { get; set; }

       /// <summary>
       ///產品表主鍵
       /// </summary>
       [Display(Name ="產品表主鍵")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public Guid prod_dbid { get; set; }

      

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///列created_username
       /// </summary>
       [Display(Name ="列created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///列created_clientusername
       /// </summary>
       [Display(Name ="列created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///建立時間
       /// </summary>
       [Display(Name ="建立時間")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///列modified_username
       /// </summary>
       [Display(Name ="列modified_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///列modified_clientusername
       /// </summary>
       [Display(Name ="列modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       /// <summary>
       ///最後修改時間
       /// </summary>
       [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

        /// <summary>
        ///Stretagy ID
        /// </summary>
        [Display(Name = "Stretagy ID")]
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        [Editable(true)]
        public string stretagy_id { get; set; }

        /// <summary>
        ///Stretagy Name
        /// </summary>
        [Display(Name = "Stretagy Name")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Editable(true)]
        public string stretagy_name { get; set; }

        /// <summary>
        ///Rang
        /// </summary>
        [Display(Name = "Rang")]
        [Column(TypeName = "numeric")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public decimal amount { get; set; }

        /// <summary>
        ///Product Id
        /// </summary>
        [Display(Name = "Product Id")]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        [Editable(true)]
        public string prod_id { get; set; }

        /// <summary>
        ///Product Name
        /// </summary>
        [Display(Name = "Product Name")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string prod_ename { get; set; }

        /// <summary>
        ///NHI Price
        /// </summary>
        [Display(Name = "NHI Price")]
        [DisplayFormat(DataFormatString = "18,5")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? nhi_price { get; set; }

        /// <summary>
        ///發票價
        /// </summary>
        [Display(Name = "發票價")]
        [DisplayFormat(DataFormatString = "18,5")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? invoice_price { get; set; }

        /// <summary>
        ///實售價
        /// </summary>
        [Display(Name = "實售價")]
        [DisplayFormat(DataFormatString = "18,5")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? net_price { get; set; }

        /// <summary>
        ///最低數量
        /// </summary>
        [Display(Name = "最低數量")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? min_qty { get; set; }

        /// <summary>
        ///是否屬合約品項
        /// </summary>
        [Display(Name = "Is Belong")]
        [MaxLength(1)]
        [Column(TypeName = "varchar(1)")]
        [Editable(true)]
        public string isbelong { get; set; }


    }
}