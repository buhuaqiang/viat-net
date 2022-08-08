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
    [Entity(TableCnName = "Price Group",TableName = "Viat_app_cust_price_group")]
    public partial class Viat_app_cust_price_group_select:BaseEntity
    {
        /// <summary>
       ///主鍵
       /// </summary>
       [Key]
       [Display(Name ="主鍵")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid pricegroup_dbid { get; set; }

       /// <summary>
       ///公司別,舊版SUN_DB
       /// </summary>
       [Display(Name ="公司別,舊版SUN_DB")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///所屬事業單位,01:PH;03:AH;05:CH;06:NU
       /// </summary>
       [Display(Name ="所屬事業單位,01:PH;03:AH;05:CH;06:NU")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///Group ID
       /// </summary>
       [Display(Name ="Group ID")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string group_id { get; set; }

       /// <summary>
       ///Group Name
       /// </summary>
       [Display(Name ="Group Name")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string group_name { get; set; }

       /// <summary>
       ///Group Price Channel
       /// </summary>
       [Display(Name ="Group Price Channel")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       public string group_type { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///Gov/Private
       /// </summary>
       [Display(Name ="Gov/Private")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string cust_type { get; set; }

       /// <summary>
       ///Created User
       /// </summary>
       [Display(Name ="Created User")]
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
       ///建立者的委託人
       /// </summary>
       [Display(Name ="建立者的委託人")]
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
       ///Created Date
       /// </summary>
       [Display(Name ="Created Date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///最後修改用戶
       /// </summary>
       [Display(Name ="最後修改用戶")]
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
       ///最後修改者的委託人
       /// </summary>
       [Display(Name ="最後修改者的委託人")]
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
       ///Pricing Field
       /// </summary>
       [Display(Name ="Pricing Field")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? pricing_field { get; set; }


        [Display(Name = "Pricing Manager")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string pricing_manager_name { get; set; }


        /// <summary>
        ///Remarks
        /// </summary>
        [Display(Name ="Remarks")]
       [MaxLength(450)]
       [Column(TypeName="nvarchar(450)")]
       [Editable(true)]
       public string remarks { get; set; }

       
    }
}