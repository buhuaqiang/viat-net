using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIAT.Utillity
{
    /// <summary>
    /// vemp excel資料模型。
    /// </summary>
    public class VempDataModel
    {
        /// <summary>
        /// 序列號。
        /// </summary>
        public string SerialNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Entity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<VempDetailModel> Details { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class VempDetailModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Period { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MarkupUsd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BudgetUsd { get; set; }
    }
}
