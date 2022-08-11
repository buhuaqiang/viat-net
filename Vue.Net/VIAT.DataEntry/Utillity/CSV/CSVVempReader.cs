using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace VIAT.Utillity
{
    public class CSVVempReader:CSVReader
    {
        public CSVVempReader(string filename)
            : base(filename, 1)
        { }

        public object[][] ReadArray()
        {
            object[][] result;
            int vempCount = 0;
            List<VempDataModel> vemps = new List<VempDataModel>();
            object[] rowData = null;
            while ((rowData=Read())!=null)
            {
                if (NewMaster(rowData))//msater 行。
                {
                    vemps.Add(ParseVempMaster(rowData));//添加一筆master和同一行的detail。
                }
                else
                {
                    ParseVempDetail(vemps[vemps.Count - 1], rowData);
                }
            }
            vempCount = vemps.Count;
            result = new object[vempCount][];
            for (int i = 0; i < vempCount; i++)
            {
                result[i] = new object[] { vemps[i] };
            }
            return result;
        }

        #region Helper Routines

        private bool NewMaster(object[] rowData)
        {
            return (rowData[0] != null && !string.IsNullOrEmpty(rowData[0].ToString())) ||
                (rowData[1] != null && !string.IsNullOrEmpty(rowData[1].ToString())) ||
                (rowData[2] != null && !string.IsNullOrEmpty(rowData[2].ToString())) ||
                (rowData[3] != null && !string.IsNullOrEmpty(rowData[3].ToString()));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowData"></param>
        /// <returns></returns>
        private VempDataModel ParseVempMaster(object[] rowData)
        {
            VempDataModel result = new VempDataModel();
            result.SerialNo = rowData[0].ToString();
            result.Entity = rowData[1].ToString();
            result.Year = rowData[2].ToString();
            result.ProductId = rowData[3].ToString();
            result.Details = new List<VempDetailModel>();
            //添加一筆和master在同一行的detail。
            VempDetailModel detail = new VempDetailModel();
            detail.Period = rowData[4].ToString();
            detail.MarkupUsd = rowData[5].ToString();
            detail.BudgetUsd = rowData[6].ToString();
            result.Details.Add(detail);

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="master"></param>
        /// <param name="rowData"></param>
        private void ParseVempDetail(VempDataModel master,object[] rowData)
        {
            //添加一筆和master不在同一行的detail。
            VempDetailModel detail = new VempDetailModel();
            detail.Period = rowData[4].ToString();
            detail.MarkupUsd = rowData[5].ToString();
            detail.BudgetUsd = rowData[6].ToString();
            master.Details.Add(detail);
        }

        #endregion
    }
}
