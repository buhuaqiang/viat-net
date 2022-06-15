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
    [Entity(TableCnName = "系統訊息設置",TableName = "View_com_bulletin")]
    public partial class View_com_bulletin:BaseEntity
    {
        /// <summary>
       ///列名user_id
       /// </summary>
       [Display(Name ="列名user_id")]
       [Column(TypeName="int")]
       public int? user_id { get; set; }

       /// <summary>
       ///列名bulletin_dbid
       /// </summary>
       [Key]
       [Display(Name ="列名bulletin_dbid")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid bulletin_dbid { get; set; }

       /// <summary>
       ///列名C1
       /// </summary>
       [Display(Name ="列名C1")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int C1 { get; set; }

       /// <summary>
       ///列名created_user
       /// </summary>
       [Display(Name ="列名created_user")]
       [Column(TypeName="int")]
       public int? created_user { get; set; }

       /// <summary>
       ///列名created_client
       /// </summary>
       [Display(Name ="列名created_client")]
       [Column(TypeName="int")]
       public int? created_client { get; set; }

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
       ///列名modified_client
       /// </summary>
       [Display(Name ="列名modified_client")]
       [Column(TypeName="int")]
       public int? modified_client { get; set; }

       /// <summary>
       ///Modified Date
       /// </summary>
       [Display(Name ="Modified Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? modified_date { get; set; }

       /// <summary>
       ///列名entity
       /// </summary>
       [Display(Name ="列名entity")]
       [MaxLength(3)]
       [Column(TypeName="varchar(3)")]
       public string entity { get; set; }

       /// <summary>
       ///Start Date
       /// </summary>
       [Display(Name ="Start Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? start_date { get; set; }

       /// <summary>
       ///End Date
       /// </summary>
       [Display(Name ="End Date")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? end_date { get; set; }

       /// <summary>
       ///Subject
       /// </summary>
       [Display(Name ="Subject")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string subject { get; set; }

       /// <summary>
       ///Content
       /// </summary>
       [Display(Name ="Content")]
       [MaxLength(4000)]
       [Column(TypeName="nvarchar(4000)")]
       [Editable(true)]
       public string content { get; set; }

       /// <summary>
       ///列名type
       /// </summary>
       [Display(Name ="列名type")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string type { get; set; }

       /// <summary>
       ///列名emp_cname
       /// </summary>
       [Display(Name ="列名emp_cname")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string emp_cname { get; set; }

       /// <summary>
       ///Last Modified
       /// </summary>
       [Display(Name ="Last Modified")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       [Editable(true)]
       public string emp_ename { get; set; }

       /// <summary>
       ///列名C2
       /// </summary>
       [Display(Name ="列名C2")]
       [Column(TypeName="int")]
       public int? C2 { get; set; }

       /// <summary>
       ///列名created_user1
       /// </summary>
       [Display(Name ="列名created_user1")]
       [Column(TypeName="int")]
       public int? created_user1 { get; set; }

       /// <summary>
       ///列名created_client1
       /// </summary>
       [Display(Name ="列名created_client1")]
       [Column(TypeName="int")]
       public int? created_client1 { get; set; }

       /// <summary>
       ///列名created_date1
       /// </summary>
       [Display(Name ="列名created_date1")]
       [Column(TypeName="datetime")]
       public DateTime? created_date1 { get; set; }

       /// <summary>
       ///列名modified_user1
       /// </summary>
       [Display(Name ="列名modified_user1")]
       [Column(TypeName="int")]
       public int? modified_user1 { get; set; }

       /// <summary>
       ///列名modified_client1
       /// </summary>
       [Display(Name ="列名modified_client1")]
       [Column(TypeName="int")]
       public int? modified_client1 { get; set; }

       /// <summary>
       ///列名modified_date1
       /// </summary>
       [Display(Name ="列名modified_date1")]
       [Column(TypeName="datetime")]
       public DateTime? modified_date1 { get; set; }

       /// <summary>
       ///列名user_id1
       /// </summary>
       [Display(Name ="列名user_id1")]
       [Column(TypeName="int")]
       public int? user_id1 { get; set; }

       /// <summary>
       ///列名status
       /// </summary>
       [Display(Name ="列名status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       public string status { get; set; }

       /// <summary>
       ///Creator
       /// </summary>
       [Display(Name ="Creator")]
       [MaxLength(50)]
       [Column(TypeName="varchar(50)")]
       public string created_username { get; set; }

       /// <summary>
       ///Send To
       /// </summary>
       [Display(Name ="Send To")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int send { get; set; }

       
    }
}