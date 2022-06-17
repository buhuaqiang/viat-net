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
    [Entity(TableCnName = "代理人pop框",TableName = "View_sys_deputy_pop")]
    public partial class View_sys_deputy_pop:BaseEntity
    {
        /// <summary>
       ///列名CreateDate
       /// </summary>
       [Display(Name ="列名CreateDate")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///E-name
       /// </summary>
       [Display(Name ="E-name")]
       [MaxLength(40)]
       [Column(TypeName="varchar(40)")]
       public string emp_ename2 { get; set; }

       /// <summary>
       ///Department Name
       /// </summary>
       [Display(Name ="Department Name")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string dept_name2 { get; set; }

       /// <summary>
       ///UserName
       /// </summary>
       [Display(Name ="UserName")]
       [MaxLength(20)]
       [Column(TypeName="varchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string user_name2 { get; set; }

       /// <summary>
       ///列名emp_dbid
       /// </summary>
       [Display(Name ="列名emp_dbid")]
       [Column(TypeName="uniqueidentifier")]
       public Guid? emp_dbid { get; set; }

       /// <summary>
       ///列名OrderNo
       /// </summary>
       [Display(Name ="列名OrderNo")]
       [Column(TypeName="int")]
       public int? OrderNo { get; set; }

       /// <summary>
       ///列名UserTrueName
       /// </summary>
       [Display(Name ="列名UserTrueName")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string UserTrueName { get; set; }

       /// <summary>
       ///列名UserPwd
       /// </summary>
       [Display(Name ="列名UserPwd")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string UserPwd { get; set; }

       /// <summary>
       ///列名UserName
       /// </summary>
       [Display(Name ="列名UserName")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Required(AllowEmptyStrings=false)]
       public string UserName { get; set; }

       /// <summary>
       ///列名Tel
       /// </summary>
       [Display(Name ="列名Tel")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string Tel { get; set; }

       /// <summary>
       ///列名Remark
       /// </summary>
       [Display(Name ="列名Remark")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Remark { get; set; }

       /// <summary>
       ///列名PhoneNo
       /// </summary>
       [Display(Name ="列名PhoneNo")]
       [MaxLength(11)]
       [Column(TypeName="nvarchar(11)")]
       public string PhoneNo { get; set; }

       /// <summary>
       ///列名RoleName
       /// </summary>
       [Display(Name ="列名RoleName")]
       [MaxLength(150)]
       [Column(TypeName="nvarchar(150)")]
       [Required(AllowEmptyStrings=false)]
       public string RoleName { get; set; }

       /// <summary>
       ///列名Role_Id
       /// </summary>
       [Display(Name ="列名Role_Id")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int Role_Id { get; set; }

       /// <summary>
       ///C-Name
       /// </summary>
       [Display(Name ="C-Name")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string emp_cname2 { get; set; }

       /// <summary>
       ///列名Token
       /// </summary>
       [Display(Name ="列名Token")]
       [MaxLength(500)]
       [Column(TypeName="nvarchar(500)")]
       public string Token { get; set; }

       /// <summary>
       ///列名ModifyID
       /// </summary>
       [Display(Name ="列名ModifyID")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       /// <summary>
       ///列名Modifier
       /// </summary>
       [Display(Name ="列名Modifier")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Modifier { get; set; }

       /// <summary>
       ///列名Address
       /// </summary>
       [Display(Name ="列名Address")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Address { get; set; }

       /// <summary>
       ///列名AppType
       /// </summary>
       [Display(Name ="列名AppType")]
       [Column(TypeName="int")]
       public int? AppType { get; set; }

       /// <summary>
       ///列名AuditDate
       /// </summary>
       [Display(Name ="列名AuditDate")]
       [Column(TypeName="datetime")]
       public DateTime? AuditDate { get; set; }

       /// <summary>
       ///列名AuditStatus
       /// </summary>
       [Display(Name ="列名AuditStatus")]
       [Column(TypeName="int")]
       public int? AuditStatus { get; set; }

       /// <summary>
       ///列名Auditor
       /// </summary>
       [Display(Name ="列名Auditor")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Auditor { get; set; }

       /// <summary>
       ///列名CreateID
       /// </summary>
       [Display(Name ="列名CreateID")]
       [Column(TypeName="int")]
       public int? CreateID { get; set; }

       /// <summary>
       ///列名Creator
       /// </summary>
       [Display(Name ="列名Creator")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Creator { get; set; }

       /// <summary>
       ///列名DeptName
       /// </summary>
       [Display(Name ="列名DeptName")]
       [MaxLength(150)]
       [Column(TypeName="nvarchar(150)")]
       public string DeptName { get; set; }

       /// <summary>
       ///列名Dept_Id
       /// </summary>
       [Display(Name ="列名Dept_Id")]
       [Column(TypeName="int")]
       public int? Dept_Id { get; set; }

       /// <summary>
       ///列名Email
       /// </summary>
       [Display(Name ="列名Email")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string Email { get; set; }

       /// <summary>
       ///列名Enable
       /// </summary>
       [Display(Name ="列名Enable")]
       [Column(TypeName="tinyint")]
       [Required(AllowEmptyStrings=false)]
       public byte Enable { get; set; }

       /// <summary>
       ///列名Gender
       /// </summary>
       [Display(Name ="列名Gender")]
       [Column(TypeName="int")]
       public int? Gender { get; set; }

       /// <summary>
       ///列名HeadImageUrl
       /// </summary>
       [Display(Name ="列名HeadImageUrl")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string HeadImageUrl { get; set; }

       /// <summary>
       ///列名IsRegregisterPhone
       /// </summary>
       [Display(Name ="列名IsRegregisterPhone")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int IsRegregisterPhone { get; set; }

       /// <summary>
       ///列名LastLoginDate
       /// </summary>
       [Display(Name ="列名LastLoginDate")]
       [Column(TypeName="datetime")]
       public DateTime? LastLoginDate { get; set; }

       /// <summary>
       ///列名LastModifyPwdDate
       /// </summary>
       [Display(Name ="列名LastModifyPwdDate")]
       [Column(TypeName="datetime")]
       public DateTime? LastModifyPwdDate { get; set; }

       /// <summary>
       ///列名Mobile
       /// </summary>
       [Display(Name ="列名Mobile")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string Mobile { get; set; }

       /// <summary>
       ///列名ModifyDate
       /// </summary>
       [Display(Name ="列名ModifyDate")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///列名User_Id
       /// </summary>
       [Key]
       [Display(Name ="列名User_Id")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int User_Id { get; set; }

       
    }
}