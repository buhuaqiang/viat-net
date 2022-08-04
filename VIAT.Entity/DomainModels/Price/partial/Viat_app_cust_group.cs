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
    
    public partial class Viat_app_cust_group
    {
        //此处配置字段(字段配置见此model的另一个partial),如果表中没有此字段请加上 [NotMapped]属性，否则会异常

        /// <summary>
        ///Group Id
        /// </summary>
        [Display(Name = "Group Id")]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        [Editable(true)]
        [NotMapped]
        public string group_id { get; set; }

        /// <summary>
        ///Group Name
        /// </summary>
        [Display(Name = "Group Name")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        [NotMapped]
        public string group_name { get; set; }


        /// <summary>
        ///Product Id
        /// </summary>
        [Display(Name = "Product Id")]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        [Editable(true)]
        [NotMapped]
        public string prod_id { get; set; }

        /// <summary>
        ///Product Name
        /// </summary>
        [Display(Name = "Product Name")]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [NotMapped]
        public string prod_ename { get; set; }


        /// <summary>
        ///NHI Price
        /// </summary>
        [Display(Name = "NHI Price")]
        [DisplayFormat(DataFormatString = "18,5")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? nhi_price { get; set; }

        /// <summary>
        ///Invoice Price
        /// </summary>
        [Display(Name = "Invoice Price")]
        [DisplayFormat(DataFormatString = "18,5")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        [NotMapped]
        public decimal? invoice_price { get; set; }

        /// <summary>
        ///Net Price
        /// </summary>
        [Display(Name = "Net Price")]
        [DisplayFormat(DataFormatString = "18,5")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        [NotMapped]
        public decimal? net_price { get; set; }


        /// <summary>
        ///Min Qty
        /// </summary>
        [Display(Name = "Min Qty")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [NotMapped]
        public int? min_qty { get; set; }
    }
}