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
    [Entity(TableCnName = "Local MPG Maintain",TableName = "View_com_local_mpg")]
    public partial class View_com_local_mpg:BaseEntity
    {
        /// <summary>
       ///localmpg_dbid
       /// </summary>
       [Key]
       [Display(Name ="localmpg_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid localmpg_dbid { get; set; }

       /// <summary>
       ///Global Mpg
       /// </summary>
       [Display(Name ="Global Mpg")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       public Guid? globalmpg_dbid { get; set; }

       /// <summary>
       ///Entity
       /// </summary>
       [Display(Name ="Entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///Local Mpg ID
       /// </summary>
       [Display(Name ="Local Mpg ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string mpg_id { get; set; }

       /// <summary>
       ///Local Mpg Name
       /// </summary>
       [Display(Name ="Local Mpg Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string mpg_name { get; set; }

       /// <summary>
       ///Bu ID
       /// </summary>
       [Display(Name ="Bu ID")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string bu_id { get; set; }

       /// <summary>
       ///Category
       /// </summary>
       [Display(Name ="Category")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string category { get; set; }

       /// <summary>
       ///Ta
       /// </summary>
       [Display(Name ="Ta")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       [Editable(true)]
       public string ta { get; set; }

       /// <summary>
       ///Ma
       /// </summary>
       [Display(Name ="Ma")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string maUserName { get; set; }

       /// <summary>
       ///PM
       /// </summary>
       [Display(Name ="PM")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Editable(true)]
       public string supervisorUserName { get; set; }

       /// <summary>
       ///Medical Reviewe Name
       /// </summary>
       [Display(Name ="Medical Reviewe Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string medical_reviewe_name { get; set; }

       /// <summary>
       ///sort
       /// </summary>
       [Display(Name ="sort")]
       [Column(TypeName="int")]
       public int? sort { get; set; }

       /// <summary>
       ///Global Mpg Name
       /// </summary>
       [Display(Name ="Global Mpg Name")]
       [MaxLength(66)]
       [Column(TypeName="nvarchar(66)")]
       [Required(AllowEmptyStrings=false)]
       public string globalMpgName { get; set; }

       /// <summary>
       ///status
       /// </summary>
       [Display(Name ="status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string status { get; set; }

       /// <summary>
       ///main_prod
       /// </summary>
       [Display(Name ="main_prod")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string main_prod { get; set; }

       /// <summary>
       ///created_user
       /// </summary>
       [Display(Name ="created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///created_username
       /// </summary>
       [Display(Name ="created_username")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///created_client
       /// </summary>
       [Display(Name ="created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

       /// <summary>
       ///created_clientusername
       /// </summary>
       [Display(Name ="created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

       /// <summary>
       ///created_date
       /// </summary>
       [Display(Name ="created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///modified_user
       /// </summary>
       [Display(Name ="modified_user")]
       [Column(TypeName="int")]
       public int? modified_user { get; set; }

       /// <summary>
       ///Last Modified
       /// </summary>
       [Display(Name ="Last Modified")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_username { get; set; }

       /// <summary>
       ///modified_client
       /// </summary>
       [Display(Name ="modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///modified_clientusername
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
       ///Ma ID
       /// </summary>
       [Display(Name ="Ma ID")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string ma_id { get; set; }

       /// <summary>
       ///Pm ID
       /// </summary>
       [Display(Name ="Pm ID")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string pm_id { get; set; }

       /// <summary>
       ///Ma Name
       /// </summary>
       [Display(Name ="Ma Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string ma_name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="pm_name")]
       [MaxLength(255)]
       [Column(TypeName="varchar(255)")]
       public string pm_name { get; set; }

       /// <summary>
       ///Medical Reviewe ID
       /// </summary>
       [Display(Name ="Medical Reviewe ID")]
       [MaxLength(5)]
       [Column(TypeName="varchar(5)")]
       [Editable(true)]
       public string medical_reviewe_id { get; set; }

       
    }
}