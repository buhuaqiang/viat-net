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
    [Entity(TableCnName = "代理信息",TableName = "View_sys_deputy")]
    public partial class View_sys_deputy:BaseEntity
    {
        /// <summary>
       ///列名deputy_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名deputy_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid deputy_dbid { get; set; }

       /// <summary>
       ///Start Date
       /// </summary>
       [Display(Name ="Start Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime end_date { get; set; }

       /// <summary>
       ///Deputy Id
       /// </summary>
       [Display(Name ="Deputy Id")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int deputy_user_id { get; set; }

       /// <summary>
       ///列userid
       /// </summary>
       [Display(Name ="列userid")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int user_id { get; set; }

       /// <summary>
       ///created_date
       /// </summary>
       [Display(Name ="created_date")]
       [Column(TypeName="datetime")]
       public DateTime? created_date { get; set; }

       /// <summary>
       ///status
       /// </summary>
       [Display(Name ="status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string status { get; set; }

       /// <summary>
       ///列名emp_cname2
       /// </summary>
       [Display(Name ="列名emp_cname2")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string emp_cname2 { get; set; }

       /// <summary>
       ///列名emp_ename2
       /// </summary>
       [Display(Name ="列名emp_ename2")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string emp_ename2 { get; set; }

       /// <summary>
       ///列名UserTrueName1
       /// </summary>
       [Display(Name ="列名UserTrueName1")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string UserTrueName1 { get; set; }

       /// <summary>
       ///列名UserName1
       /// </summary>
       [Display(Name ="列名UserName1")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Required(AllowEmptyStrings=false)]
       public string UserName1 { get; set; }

       /// <summary>
       ///列名userid1
       /// </summary>
       [Display(Name ="列名userid1")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int userid1 { get; set; }

         /// <summary>
       ///列名UserTrueName1
       /// </summary>
       [Display(Name ="列名UserTrueName2")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string UserTrueName2 { get; set; }


        /// <summary>
       ///列名UserName2
       /// </summary>
       [Display(Name ="列名UserName2")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string UserName2 { get; set; }

       /// <summary>
       ///列名userid1
       /// </summary>
       [Display(Name ="列名userid2")]
       [Column(TypeName="int")]
       public int userid2 { get; set; }

       /// <summary>
       ///列名modified_date
       /// </summary>
       [Display(Name ="列名modified_date")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date { get; set; }

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
       ///列名created_clientusername
       /// </summary>
       [Display(Name ="列名created_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_clientusername { get; set; }

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
       ///列名division
       /// </summary>
       [Display(Name ="列名division")]
       [MaxLength(15)]
       [Column(TypeName="varchar(15)")]
       public string division { get; set; }

       /// <summary>
       ///列名entity
       /// </summary>
       [Display(Name ="列名entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///列名modified_clientusername
       /// </summary>
       [Display(Name ="列名modified_clientusername")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string modified_clientusername { get; set; }

       
    }
}