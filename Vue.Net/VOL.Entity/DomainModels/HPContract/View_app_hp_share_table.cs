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
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels
{
    [Entity(TableCnName = "shareTable",TableName = "View_app_hp_share_table")]
    public partial class View_app_hp_share_table:BaseEntity
    {
        /// <summary>
       ///列名hpcontshare_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名hpcontshare_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid hpcontshare_dbid { get; set; }

       /// <summary>
       ///列名division
       /// </summary>
       [Display(Name ="列名division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///列名hpcont_dbid
       /// </summary>
       [Display(Name ="列名hpcont_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? hpcont_dbid { get; set; }

       /// <summary>
       ///列名prod_dbid
       /// </summary>
       [Display(Name ="列名prod_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? prod_dbid { get; set; }

       /// <summary>
       ///列名cust_dbid
       /// </summary>
       [Display(Name ="列名cust_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? cust_dbid { get; set; }

       /// <summary>
       ///列名serial_no
       /// </summary>
       [Display(Name ="列名serial_no")]
       [Column(TypeName="decimal")]
       public decimal? serial_no { get; set; }

       /// <summary>
       ///Cust ID
       /// </summary>
       [Display(Name ="Cust ID")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
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
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string prod_id { get; set; }

       /// <summary>
       ///Prod Name
       /// </summary>
       [Display(Name ="Prod Name")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string prod_ename { get; set; }

       /// <summary>
       ///Sharing %
       /// </summary>
       [Display(Name ="Sharing %")]
       [DisplayFormat(DataFormatString="18,5")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? percent { get; set; }

       /// <summary>
       ///Status
       /// </summary>
       [Display(Name ="Status")]
       [Column(TypeName="bit")]
       [Editable(true)]
       public bool? status { get; set; }

       /// <summary>
       ///Update Date
       /// </summary>
       [Display(Name ="Update Date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///Update User
       /// </summary>
       [Display(Name ="Update User")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///列名o_contract_no
       /// </summary>
       [Display(Name ="列名o_contract_no")]
       [Column(TypeName="int")]
       public int? o_contract_no { get; set; }

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

       
    }
}