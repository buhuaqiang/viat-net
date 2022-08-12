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
    [Entity(TableCnName = "Full Allowance Reverse", TableName = "View_full_allowance_main")]
    public partial class View_full_allowance_main : BaseEntity
    {

        /// <summary>
        ///列名hpcont_dbid
        /// </summary>
        [Key]
        [Display(Name = "列名hpcont_dbid")]
        [Column(TypeName = "uniqueidentifier")]
        [Required(AllowEmptyStrings = false)]
        public Guid hpcont_dbid { get; set; }

        /// <summary>
        ///列名entity
        /// </summary>
        [Display(Name = "列名entity")]
        [MaxLength(3)]
        [Column(TypeName = "varchar(3)")]
        public string entity { get; set; }

        /// <summary>
        ///列名division
        /// </summary>
        [Display(Name = "列名division")]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string division { get; set; }

        /// <summary>
        ///Contract No
        /// </summary>
        [Display(Name = "Contract No")]
        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string contract_no { get; set; }

        /// <summary>
        ///pricegroup_dbid
        /// </summary>
        [Display(Name = "pricegroup_dbid")]
        [Column(TypeName = "uniqueidentifier")]
        [Editable(true)]
        public Guid? pricegroup_dbid { get; set; }

        /// <summary>
        ///生效日
        /// </summary>
        [Display(Name = "生效日")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? start_date { get; set; }

        /// <summary>
        ///結束日
        /// </summary>
        [Display(Name = "結束日")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? end_date { get; set; }

        /// <summary>
        ///Allowance Type
        /// </summary>
        [Display(Name = "Allowance Type")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int allw_type { get; set; }

        /// <summary>
        ///預估參考月數
        /// </summary>
        [Display(Name = "預估參考月數")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? est_months { get; set; }

        /// <summary>
        ///預估金額
        /// </summary>
        [Display(Name = "預估金額")]
        [DisplayFormat(DataFormatString = "18,5")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? accrue_amt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "accrue_price")]
        [DisplayFormat(DataFormatString = "18,5")]
        [Column(TypeName = "decimal")]
        public decimal? accrue_price { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "accrue_start_date")]
        [Column(TypeName = "datetime")]
        public DateTime? accrue_start_date { get; set; }

        /// <summary>
        ///合約條款
        /// </summary>
        [Display(Name = "合約條款")]
        [MaxLength(16)]
        [Column(TypeName = "text(16)")]
        [Editable(true)]
        public string contract_term { get; set; }

        /// <summary>
        ///合約狀態,Y:Valid;N:Invalid;C:Over period still active;A:Not Achieve
        /// </summary>
        [Display(Name = "合約狀態,Y:Valid;N:Invalid;C:Over period still active;A:Not Achieve")]
        [MaxLength(1)]
        [Column(TypeName = "varchar(1)")]
        [Editable(true)]
        public string state { get; set; }

        /// <summary>
        ///LocalAddon Contractno
        /// </summary>
        [Display(Name = "LocalAddon Contractno")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? o_contract_no { get; set; }

        /// <summary>
        ///建立用戶
        /// </summary>
        [Display(Name = "建立用戶")]
        [Column(TypeName = "int")]
        public int? created_user { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "created_username")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string created_username { get; set; }

        /// <summary>
        ///建立者的委託人
        /// </summary>
        [Display(Name = "建立者的委託人")]
        [Column(TypeName = "int")]
        public int? created_client { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "created_clientusername")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string created_clientusername { get; set; }

        /// <summary>
        ///建立時間
        /// </summary>
        [Display(Name = "建立時間")]
        [Column(TypeName = "datetime")]
        public DateTime? created_date { get; set; }

        /// <summary>
        ///最後修改用戶
        /// </summary>
        [Display(Name = "最後修改用戶")]
        [Column(TypeName = "int")]
        public int? modified_user { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "modified_username")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string modified_username { get; set; }

        /// <summary>
        ///最後修改者的委託人
        /// </summary>
        [Display(Name = "最後修改者的委託人")]
        [Column(TypeName = "int")]
        public int? modified_client { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "modified_clientusername")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string modified_clientusername { get; set; }

        /// <summary>
        ///最後修改時間
        /// </summary>
        [Display(Name = "最後修改時間")]
        [Column(TypeName = "datetime")]
        public DateTime? modified_date { get; set; }

        /// <summary>
        ///Bu Id
        /// </summary>
        [Display(Name = "Bu Id")]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string bu_id { get; set; }

        /// <summary>
        ///列名C1
        /// </summary>
        [Display(Name = "列名C1")]
        [DisplayFormat(DataFormatString = "38,5")]
        [Column(TypeName = "decimal")]
        public decimal? C1 { get; set; }

        /// <summary>
        ///列名C2
        /// </summary>
        [Display(Name = "Reverse Amount")]
        [DisplayFormat(DataFormatString = "38,5")]
        [Column(TypeName = "decimal")]
        public decimal? C2 { get; set; }

        /// <summary>
        ///列名C3
        /// </summary>
        [Display(Name = "Adjustment Amount")]
        [DisplayFormat(DataFormatString = "38,5")]
        [Column(TypeName = "decimal")]
        public decimal? C3 { get; set; }

        /// <summary>
        ///GroupId
        /// </summary>
        [Display(Name = "GroupId")]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string group_id { get; set; }

        /// <summary>
        ///GroupName
        /// </summary>
        [Display(Name = "GroupName")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(50)")]
        public string group_name { get; set; }

        /// <summary>
        ///cust_dbid
        /// </summary>
        [Display(Name = "cust_dbid")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid cust_dbid { get; set; }

        /// <summary>
        ///CustID
        /// </summary>
        [Display(Name = "CustID")]
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string cust_id { get; set; }

        /// <summary>
        ///CustName
        /// </summary>
        [Display(Name = "CustName")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string cust_name { get; set; }

        /// <summary>
        ///列名prod_dbid
        /// </summary>
        [Display(Name = "列名prod_dbid")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid? prod_dbid { get; set; }

        /// <summary>
        ///Product Code
        /// </summary>
        [Display(Name = "Product Code")]
        [MaxLength(1000)]
        [Column(TypeName = "varchar(1000)")]
        public string prod_id { get; set; }

        /// <summary>
        ///Product Name
        /// </summary>
        [Display(Name = "Product Name")]
        [MaxLength(1000)]
        [Column(TypeName = "varchar(1000)")]
        public string prod_ename { get; set; }


        /// <summary>
        ///p_prod_dbid
        /// </summary>
        [Display(Name = "p_prod_dbid")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid p_prod_dbid { get; set; }

        /// <summary>
        ///f_prod_dbid
        /// </summary>
        [Display(Name = "f_prod_dbid")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid f_prod_dbid { get; set; }

    }
}