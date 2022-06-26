
using System;
using System.Collections;
using System.Collections.Generic;

namespace VOL.Entity.DomainModels
{
    public class SaveModel
    {
        public Dictionary<string, object> MainData { get; set; }

        public List<Dictionary<string, object>> DetailData { get; set; }


        /// <summary>
        /// 当用视图作为查询时，指定实际操作表的类型, 用委托AddOnExecute 进行指定
        /// </summary>
        public Type MainFacType { get; set; }

        /// <summary>
        /// 主表操作：新增，修改
        /// </summary>
        public MainOptionType mainOptionType = MainOptionType.None;


        #region 多表体对像
        /// <summary>
        /// 多表体对像
        /// </summary>
        public List<DetailListDataResult> DetailListData = new List<DetailListDataResult>();

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

        /// <summary>
        /// 记录表头新增修改操作
        /// </summary>

        public enum MainOptionType
        {
            //默认
            None =0,
            //新增
            add =1,
            //更新
            update=2
        }
    }
}
