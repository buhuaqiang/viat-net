using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VIAT.Utillity
{
    /// <summary>
    /// 
    /// </summary>
    public class CSVWriter:StreamFileOperator
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private string[] innerTitles;
        /// <summary>
        /// 
        /// </summary>
        private StreamWriter innerWriter;

        #endregion

        /// <summary>
        /// 構造新的實例，該實例將使用FileStream以byte[]形式將内容寫入文件。
        /// <para>注意：不同的平臺文件使用的編碼是不同的，比如en-US使用ANSI編碼讀取，若不將内容的編碼（如utf-8）信息寫入文件屬性，則導致讀出中文為亂碼。</para>
        /// <para>建議使用該構造函數的帶encoding參數的重載版本，該重載使用不同的策略寫文件，確保文件編碼屬性和内容編碼屬性一致。</para>
        /// </summary>
        /// <param name="fileName">要寫入的文件完整路徑。</param>
        /// <param name="titles">文件内容標題。</param>
        public CSVWriter(string fileName,string[] titles) : base(fileName)
        {
            this.BaseFileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete);
            this.innerWriter = null;
            this.innerTitles = titles;
            Write(titles);
        }
        /// <summary>
        /// 建議使用該構造函數構造新的實例。
        /// <para>儅寫入文件的内容出現漢字時在英文版的系統上寫入文件，就容易出現亂碼，此時應使用StreamWriter指定寫入文件的編碼，通常為UTF8，從而確保文件編碼屬性和内容編碼屬性一致。</para>
        /// <para>文件編碼屬性：不同語言區域特性的OS對文件編碼屬性有不同的值，比如en-US默認為ANSI，zh-CN默認為Unicode等等，文件的讀取時將使用該屬性值。</para>
        /// <para>内容編碼屬性：表示文件内容使用何種編碼寫入的。</para>
        /// <para>注意：儅文件編碼屬性和内容編碼屬性不一致時，比如一個為ANSI一個為UTF8，則内容中漢字部分統統顯示為亂碼。</para>
        /// </summary>
        /// <param name="fileName">要寫入的文件完整路徑。</param>
        /// <param name="titles">文件内容標題。</param>
        /// <param name="encoding">文件編碼和内容編碼</param>
        public CSVWriter(string fileName, string[] titles, Encoding encoding) : base(fileName)
        {
            this.BaseFileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete);
            this.innerWriter = new StreamWriter(this.BaseFileStream, encoding);
            this.innerWriter.AutoFlush = true;
            this.innerTitles = titles;
            Write(titles);
        }
        /// <summary>
        /// 將一筆資料寫入流。
        /// <para>默認為UTF-8編碼。</para>
        /// <remarks>資料的數量應和title的數量相同，否則會做刪減或添加以適應title的數量。</remarks>
        /// </summary>
        /// <param name="record">要寫入的資料。</param>
        public void Write(object[] record)
        {
            //string data = CSVFormatParser.DataToCSV(record);
            //if (!string.IsNullOrEmpty(data))
            //{
            //    byte[] writeData = Encoding.UTF8.GetBytes(data + Environment.NewLine);
            //    this.BaseFileStream.Write(writeData, 0, writeData.Length);
            //}
            Write(record, Encoding.UTF8);
        }
        /// <summary>
        /// 將一筆資料寫入流。
        /// <remarks>資料的數量應和title的數量相同，否則會做刪減或添加以適應title的數量。</remarks>
        /// </summary>
        /// <param name="record">要寫入的資料。</param>
        /// <param name="encoding">寫入時使用的編碼。儅採用策略2時，則忽略該參數值。</param>
        public void Write(object[] record,Encoding encoding)
        {
            string data = CSVFormatParser.DataToCSV(record);
            if (!string.IsNullOrEmpty(data))
            {
                if (this.innerWriter == null)//策略1。
                {
                    if (encoding == null) encoding = Encoding.Default;
                    byte[] writeData = encoding.GetBytes(data + Environment.NewLine);
                    this.BaseFileStream.Write(writeData, 0, writeData.Length);
                }
                else//策略2。
                {
                    this.innerWriter.WriteLine(data);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();
            if (this.innerWriter != null)
            {
                this.innerWriter = null;
            }
        }
    }
}
