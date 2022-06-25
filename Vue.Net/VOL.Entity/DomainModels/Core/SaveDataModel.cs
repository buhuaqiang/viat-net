
using System;
using System.Collections;
using System.Collections.Generic;

namespace VOL.Entity.DomainModels
{
    public class SaveModel
    {
        public Dictionary<string, object> MainData { get; set; }

        /// <summary>
        /// 当用视图作为查询时，指定实际操作表的类型
        /// </summary>
        public Type MainFacType { get; set; }

        public List<Dictionary<string, object>> DetailData { get; set; }

        #region 多表体对像
        /// <summary>
        /// 多表体对像
        /// </summary>
        public List<DetailListDataResult> DetailListData { get; set; }

        /// <summary>
        /// 接收多表体中的一个datatable
        /// </summary>
        public List<Dictionary<string, object>> DetailsData { get; set; }

        #endregion
        public List<object> DelKeys { get; set; }

        /// <summary>
        /// 从前台传入的其他参数(自定义扩展可以使用)
        /// </summary>
        public object Extra { get; set; }


        public class DetailListDataResult
        {
            public Type detailType { get; set; }
            public List<Dictionary<string, object>> DetailData { get; set; }
        }
    }
}
