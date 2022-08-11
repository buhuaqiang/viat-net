using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VIAT.Utillity
{
    /// <summary>
    /// 以流的方式操作文件的基類。
    /// </summary>
    public abstract class StreamFileOperator:IDisposable
    {
        private bool innerIsDisposed;
        private string innerFileName;
        private FileStream innerFileStream;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        protected StreamFileOperator(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("filename cannot be null or empty.");
            this.innerFileName = fileName;
            this.innerIsDisposed = false;
        }
        /// <summary>
        /// 
        /// </summary>
        protected FileStream BaseFileStream { get { return this.innerFileStream; } set { this.innerFileStream = value; } }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (!innerIsDisposed)
            {
                if (innerFileStream != null)
                {
                    innerFileStream.Close();
                    innerFileStream.Dispose();
                }
                OnDispose();
                innerIsDisposed = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnDispose()
        { }
        /// <summary>
        /// 
        /// </summary>
        ~StreamFileOperator()
        {
            Dispose();
        }
    }
}
