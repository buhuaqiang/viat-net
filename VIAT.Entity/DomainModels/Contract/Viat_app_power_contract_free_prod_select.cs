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
    [Entity(TableCnName = "合約產品List", TableName = "Viat_app_power_contract_free_prod")]
    public partial class Viat_app_power_contract_free_prod_select : BaseEntity
    {
      /*  /// <summary>
        ///識別碼, PK, Identity
        /// </summary>
        [Display(Name = "識別碼, PK, Identity")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int dbid { get; set; }
*/
        /// <summary>
        ///所屬事業單位,01:PH;03:AH;05:CH;06:NU
        /// </summary>
        [Display(Name = "所屬事業單位,01:PH;03:AH;05:CH;06:NU")]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        [Editable(true)]
        public string division { get; set; }

        /*/// <summary>
        ///序號
        /// </summary>
        [Display(Name = "序號")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public decimal serial_no { get; set; }*/

        /// <summary>
        ///GP合約表主鍵
        /// </summary>
        [Display(Name = "GP合約表主鍵")]
        [Column(TypeName = "uniqueidentifier")]
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public Guid powercont_dbid { get; set; }

        /// <summary>
        ///客戶表主鍵
        /// </summary>
        [Display(Name = "客戶表主鍵")]
        [Column(TypeName = "uniqueidentifier")]
        [Editable(true)]
        public Guid? cust_dbid { get; set; }

        

        /// <summary>
        ///主鍵
        /// </summary>
        [Key]
        [Display(Name = "主鍵")]
        [Column(TypeName = "uniqueidentifier")]
        [Required(AllowEmptyStrings = false)]
        public Guid powercontfreeprod_dbid { get; set; }

        /// <summary>
        ///產品表PKID,舊版ITEM_CODE
        /// </summary> 
        [Column(TypeName = "uniqueidentifier")]
        [Required(AllowEmptyStrings = false)]
        public Guid prod_dbid { get; set; }

        /// <summary>
        ///產品ID
        /// </summary> 
        [Column(TypeName = "prod_id")]
        [Required(AllowEmptyStrings = false)]
        public string prod_id { get; set; }


        /// <summary>
        ///產品名
        /// </summary> 
        [Column(TypeName = "prod_ename")]
        [Required(AllowEmptyStrings = false)]
        public string prod_ename { get; set; }

        /// <summary>
        ///數量
        /// </summary>
        [Display(Name = "數量")]
        [Column(TypeName = "decimal")]
        public decimal? qty { get; set; }

        /// <summary>
        ///金額
        /// </summary>
        [Display(Name = "金額")]
        [Column(TypeName = "decimal")]
        public decimal? amt { get; set; }


        /// <summary>
        ///列名modified_date
        /// </summary>
        [Display(Name = "列名modified_date")]
        [Column(TypeName = "datetime")]
        public DateTime? modified_date { get; set; }

        /// <summary>
        ///列名modified_client
        /// </summary>
        [Display(Name = "列名modified_client")]
        [Column(TypeName = "int")]
        public int? modified_client { get; set; }

        /// <summary>
        ///列名modified_user
        /// </summary>
        [Display(Name = "列名modified_user")]
        [Column(TypeName = "int")]
        public int? modified_user { get; set; }

        /// <summary>
        ///列名created_date
        /// </summary>
        [Display(Name = "列名created_date")]
        [Column(TypeName = "datetime")]
        public DateTime? created_date { get; set; }

        /// <summary>
        ///列名created_client
        /// </summary>
        [Display(Name = "列名created_client")]
        [Column(TypeName = "int")]
        public int? created_client { get; set; }

        /// <summary>
        ///列名created_user
        /// </summary>
        [Display(Name = "列名created_user")]
        [Column(TypeName = "int")]
        public int? created_user { get; set; }


        /// <summary>
        ///
        /// </summary>
        [Display(Name = "modified_username")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string modified_username { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "created_username")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string created_username { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "created_clientusername")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string created_clientusername { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "modified_clientusername")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string modified_clientusername { get; set; }

    }
}
