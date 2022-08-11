using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VIAT.Utillity
{
    /// <summary>
    /// CSV格式幫助器。内部密封類型。
    /// </summary>
    internal sealed class CSVFormatParser
    {
        static Regex innerRegex = new Regex("\"[^\"]*\"|'[^']*'|[^,]+");
        /// <summary>
        /// 將資料轉換成CSV格式要求的格式。
        /// </summary>
        /// <param name="data">要格式化的資料。</param>
        /// <returns>格式化后得到的CSV的資料行的格式。以逗號分隔每個項。</returns>
        public static string DataToCSV(object[] data)
        {
            string result = string.Empty;
            if (data != null && data.Length > 0)
            {
                string temp;
                foreach (object item in data)
                {
                    if (item != null)
                    {
                        //important.
                        temp = item.ToString();
                        if (temp.IndexOf(',') > -1)//如果包含CSV保留字元，則需要使用雙引號括起資料。
                            temp = "\"" + temp + "\"";
                        result += temp;
                    }
                    result += ",";
                }
                result = result.Substring(0, result.Length - 1);//remove the last ','.
            }
            return result;
        }
        /// <summary>
        /// 將CSV資料行轉換成資料項數組。
        /// </summary>
        /// <param name="csvRow">要轉換的CSV資料行。</param>
        /// <returns>轉換得到的資料項數組。</returns>
        public static object[] CSVToData(string csvRow)
        {
            if (!string.IsNullOrEmpty(csvRow))
            {
                string[] sub = csvRow.Split(',');
                if (sub != null && sub.Length > 0)
                {
                    object[] result = new object[sub.Length];
                    for (int i = 0; i < sub.Length; i++)
                    {
                        result[i] = sub[i];
                    }
                    return result;
                }
            }
            return null;
        }
        /// <summary>
        /// 分析逗号和引号分割的CSV资料。若col为空，则应塞一个space，否则会被忽略。
        /// </summary>
        /// <param name="csvRow">原始资料行。</param>
        /// <param name="isSingleQM">标志是否使用单引号分割资料。默认为false，表示使用双引号分割。</param>
        /// <returns>格式化后得到的CSV的資料行的格式。以逗號分隔每個項。</returns>
        public static object[] CSVToDataWithQuotationMarks(string csvRow, bool isSingleQM = false)
        {
            if (!string.IsNullOrEmpty(csvRow))
            {
                MatchCollection mc = innerRegex.Matches(csvRow);
                object[] result = new object[mc.Count];
                int index = 0;
                foreach (Match item in mc)
                {
                    if (isSingleQM)
                        result[index] = item.Value.Trim('\'');
                    else
                        result[index] = item.Value.Trim('"');
                    index++;
                }
                return result;
            }
            return null;
        }
    }
}
