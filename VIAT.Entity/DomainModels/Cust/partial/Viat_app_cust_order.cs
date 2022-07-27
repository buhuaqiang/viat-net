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
    
    public partial class Viat_app_cust_order
    {
        //此处配置字段(字段配置见此model的另一个partial),如果表中没有此字段请加上 [NotMapped]属性，否则会异常

        /// <summary>
        ///客戶編號
        /// </summary>
         [NotMapped]
        [Display(Name = "客戶編號")]
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        [Required(AllowEmptyStrings = false)]
        public string cust_id { get; set; }

        /// <summary>
        ///客戶名稱
        /// </summary>
        [NotMapped]
        [Display(Name = "客戶名稱")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string cust_name { get; set; }

        /// <summary>
        ///產品id
        /// </summary>
        [NotMapped]
        [Display(Name = "產品id")]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        [Required(AllowEmptyStrings = false)]
        public string prod_id { get; set; }

        /// <summary>
        ///英文名稱
        /// </summary>
        [NotMapped]
        [Display(Name = "英文名稱")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string prod_ename { get; set; }

    }
}