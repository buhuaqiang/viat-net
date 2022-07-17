
using System;
using System.Collections;
using System.Collections.Generic;

namespace VIAT.Entity.DomainModels
{
    public class SaveModel
    {
        public Dictionary<string, object> MainData { get; set; }

        /// <summary>
        /// 主表一次性保存多条
        /// </summary>
        public List<Dictionary<string, object>> MainDatas { get; set; }

        //多表体数据，每条数据的实体是一致的
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
        /// 多表体对像,可包含不同类型的实体
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
            public List<Dictionary<string, object>> DetailData = new List<Dictionary<string, object>>();

            //删除key记录
            public List<object> detailDelKeys = new List<object>();

            //多实类操作 新增，修改
            public MainOptionType optionType;

            /// <summary>
            /// 默认更新时，更新modify等信息
            /// </summary>
            public bool bUpdateModifyInformation = true;
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
            update=2,
            //删除
            delete =3,
        }
    }
}
