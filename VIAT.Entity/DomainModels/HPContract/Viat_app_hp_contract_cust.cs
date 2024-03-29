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
using System.Reflection;

namespace VIAT.Entity.DomainModels
{
    [Entity(TableCnName = "HP合約客戶", TableName = "viat_app_hp_contract_cust")]
    public partial class Viat_app_hp_contract_cust : BaseEntity
    {
      /*  /// <summary>
       ///識別碼, PK, Identity
       /// </summary>
       [Display(Name ="識別碼, PK, Identity")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int dbid { get; set; }
*/
       /// <summary>
       ///所屬事業單位,01:PH;03:AH;05:CH;06:NU
       /// </summary>
       [Display(Name ="所屬事業單位,01:PH;03:AH;05:CH;06:NU")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string division { get; set; }

      /* /// <summary>
       ///序號
       /// </summary>
       [Display(Name ="序號")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public decimal serial_no { get; set; }
*/
       /// <summary>
       ///GP合約表主鍵
       /// </summary>
       [Display(Name ="HP合約表主鍵")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       [Editable(true)]
        public Guid hpcont_dbid { get; set; }


        /// <summary>
        //Y;Valid;N;Invalid;C;OverA:Not Achieve
        /// </summary>
        [Display(Name = "Y;Valid;N;Invalid;C;OverA:Not Achieve")]
        [Column(TypeName = "varcher（1）")]
        [Editable(true)]

        public string status { get; set; }

        /// <summary>
        ///合約號碼(案號)
        /// </summary>
       /* [Display(Name = "Y;Valid;N;Invalid;C;OverA:Not Achieve")] 
 
        public string contract_no { get; set; }*/

        /// <summary>
        ///客戶表主鍵
        /// </summary>
        [Display(Name ="客戶表主鍵")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///建立用戶
       /// </summary>
       [Display(Name ="建立用戶")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

        /// <summary>
        ///建立用戶名称
        /// </summary>
        [Display(Name = "建立用戶名称")]
        [Column(TypeName = "varcher（50）")]
        public string created_username { get; set; }

        /// <summary>
        ///建立者的委託人
        /// </summary>
        [Display(Name ="建立者的委託人")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

        /// <summary>
        ///建立委託人用戶名称
        /// </summary>
        [Display(Name = "建立用戶名称")]
        [Column(TypeName = "varcher（50）")]
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
        ///最後修改用戶名称
        /// </summary>
        [Display(Name = "最後修改用戶名称")]
        [Column(TypeName = "varcher（50）")]
        public string modified_username { get; set; }

        /// <summary>
        ///最後修改者的委託人
        /// </summary>
        [Display(Name ="最後修改者的委託人")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

        /// <summary>
        ///最後修改委託人用戶名称
        /// </summary>
        [Display(Name = "最後修改用戶名称")]
        [Column(TypeName = "varcher（50）")]
        public string modified_clientusername { get; set; }

        /// <summary>
        ///最後修改時間
        /// </summary>
        [Display(Name ="最後修改時間")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///主鍵
       /// </summary>
       [Key]
       [Display(Name ="主鍵")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid hpcontcust_dbid { get; set; }
 

    }
}