using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VIAT.Utillity;

namespace VIAT.Utillity
{
    /// <summary>
    /// 
    /// </summary>
    public class CSVReader : StreamFileOperator
    {
        private int innerContentRowIndex;
        private int innerCurrentRowIndex;
        private StreamReader innerReader;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contentRowIndex">内容開始行的索引，從0開始。</param>
        public CSVReader(string fileName,int contentRowIndex=1)
            : base(fileName)
        {
            this.BaseFileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Delete);
            this.innerContentRowIndex = contentRowIndex;
            ResetCursor();
        }
        /// <summary>
        /// 開始從流中讀取一筆資料。
        /// <remarks>資料不能為空行，否則認爲是結束。</remarks>
        /// </summary>
        /// <returns>有資料返回資料，否則返回null。</returns>
        public object[] Read()
        {
            string data = this.innerReader.ReadLine();
            this.innerCurrentRowIndex++;
            if (string.IsNullOrEmpty(data))
                return null;
            return CSVFormatParser.CSVToData(data);
        }
        /// <summary>
        /// 读取以逗号和引号分割的资料。
        /// </summary>
        /// <param name="isSingleQM">标志是否使用单引号分割资料。默认为false，表示使用双引号分割。</param>
        /// <returns>有資料返回資料，否則返回null。</returns>
        public object[] ReadWithQuotationMarks(bool isSingleQM = false)
        {
            string data = this.innerReader.ReadLine();
            this.innerCurrentRowIndex++;
            if (string.IsNullOrEmpty(data))
                return null;
            return CSVFormatParser.CSVToDataWithQuotationMarks(data, isSingleQM);
        }
        /// <summary>
        /// 重新設置遊標到内容起始行的索引。
        /// </summary>
        public void ResetCursor()
        {
            this.innerCurrentRowIndex = this.innerContentRowIndex;
            this.BaseFileStream.Position = 0;
            this.innerReader = new StreamReader(this.BaseFileStream);
            for (int i = 0; i < this.innerContentRowIndex; i++, this.innerReader.ReadLine()) ;
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void OnDispose()
        {
            this.innerReader.Dispose();
        }
    }
}