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
    [Entity(TableCnName = "價格群組對應客戶",TableName = "View_cust_custgroup_pricegroup")]
    public partial class View_cust_custgroup_pricegroup:BaseEntity
    {

        /// <summary>
        ///
        /// </summary>
        [Key]
        [Display(Name = "cust_dbid")]
        [Column(TypeName = "uniqueidentifier")]
        [Required(AllowEmptyStrings = false)]
        public Guid cust_dbid { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Group Id")]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string group_id
        {
            get; set;
        }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Group Name")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string group_name { get; set; }

        //-------------------
        [Display(Name = "Pricing Manager")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string pricing_manager_name { get; set; }

        [Display(Name = "Group Channel")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string groupTypeName { get; set; }


        [Display(Name = "Cust Type")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string custTypeName { get; set; }

        [Display(Name = "Remarks")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string remarks { get; set; }
        //==================


        /// <summary>
        ///
        /// </summary>
        [Display(Name ="Cust Id")]
       [MaxLength(10)]
       [Column(TypeName="varchar(10)")]
       public string cust_id { get; set; }


       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Cust Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string cust_name { get; set; }


        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Status")]
        [MaxLength(1)]
        [Column(TypeName = "varchar(1)")]
        [Editable(true)]
        public string status { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name ="Cust Status")]
       [MaxLength(1)]
       [Column(TypeName="varchar(1)")]
       [Editable(true)]
       public string custStatus { get; set; }
   

    }
}