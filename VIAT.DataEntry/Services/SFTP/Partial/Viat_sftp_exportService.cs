/*
 *所有关于Viat_sftp_export类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_sftp_exportService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;
using System.Linq;
using VIAT.Core.Utilities;
using System.Linq.Expressions;
using VIAT.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.DataEntry.IRepositories;
using System.Collections.Generic;
using VIAT.DataEntry.Utillity;
using System;
using System.ComponentModel;
using System.Reflection;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.IO;
using System.Text;
using VIAT.Entity.DomainModels.SFTP;
using VIAT.Core.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using VIAT.Core.DBManager;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace VIAT.DataEntry.Services
{
    public partial class Viat_sftp_exportService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_sftp_exportRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_sftp_exportService(
            IViat_sftp_exportRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webResponse = new WebResponseContent();

        /// <summary>
        /// 汇总
        /// </summary>
        private List<SftpSummaryModel> SummaryList = new List<SftpSummaryModel>();
        /// <summary>
        /// 获取SFTP信息
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override PageGridData<Viat_sftp_export> GetPageData(PageDataOptions options)
        { 
            PageGridData<Viat_sftp_export> pageData = new PageGridData<Viat_sftp_export>();
            Dictionary<string, List<Viat_sftp_export>> dicStfp = new Dictionary<string, List<Viat_sftp_export>>();
            List<SearchParameters> searchParametersList = new List<SearchParameters>();

            string s_type = null;
            string s_Distributor = null;
            string transfer_date = "";
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        switch (sp.Name.ToLower())
                        {
                            case "type":
                                s_type = GetTypeName(sp.Value);
                                break;
                            case "dist_id":
                                s_Distributor = GetDistEName(sp.Value);
                                break;
                            case "transfer_date":
                                transfer_date = sp.Value;
                                break;
                        }
                    }
                }
            }
            s_type = string.IsNullOrEmpty(s_type) ? GetTypeName("") : s_type;
            s_Distributor = string.IsNullOrEmpty(s_Distributor) ? GetDistEName("") : s_Distributor;
            string[] type = s_type.Split(new char[] { ',' });
            string[] distributor = s_Distributor.Split(new char[] { ',' });
            //SFTPHelper s = new SFTPHelper();
            using (SFTPHelper s = new SFTPHelper())
            {
                foreach (var item in distributor)
                {
                    List<Viat_sftp_export> ss = s.GetFileList($"/home/{item}/Download", ".csv");
                    dicStfp.Add(item, ss);
                }
            }

            IEnumerable<Viat_sftp_export> value = dicStfp.SelectMany(x => x.Value);
            List<Viat_sftp_export> SftpList = new List<Viat_sftp_export>();
            SftpList.AddRange(value);
            if (type != null)
            {
                SftpList = SftpList.Where(x=> type.Contains(x.file_name.Split('_')[0])).ToList();
            }
            if (!string.IsNullOrEmpty(transfer_date))
            {
                SftpList = SftpList.Where(x=> Convert.ToDateTime(x.modified_date) >= Convert.ToDateTime(transfer_date)).ToList();
            }

            pageData.total = SftpList.Count();
            pageData.rows = SftpList.Skip((options.Page - 1) * options.Rows).Take(options.Rows).ToList();
            return pageData;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public WebResponseContent Execute(SaveModel saveModel)
        {
            string distId = saveModel.MainData["distId"].ToString();
            string s_type = GetTypeName(saveModel.MainData["type"].ToString());
           
            string date = saveModel.MainData["transferDate"].ToString();

            return SftpUpload(s_type, distId, date);
        }

        public WebResponseContent ExecuteBatch()
        {
            WebResponseContent webContent = new WebResponseContent();
            SummaryList = new List<SftpSummaryModel>();

            List<Viat_com_system_value> systemValueList = repository.DbContext.Set<Viat_com_system_value>().Where(x=>x.category_id == "DistID" && x.status == "Y").OrderBy(x=>x.sys_key).ToList();
            if (systemValueList.Count()>0)
            {
                foreach (var item in systemValueList)
                {
                    if (item.sys_key.Equals("3"))
                    {
                        SftpUpload("customer", item.sys_key, DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    SftpUpload("price", item.sys_key, DateTime.Now.ToString("yyyy-MM-dd"));
                    SftpUpload("order", item.sys_key, DateTime.Now.ToString("yyyy-MM-dd"));
                    SftpUpload("Allowance", item.sys_key, DateTime.Now.ToString("yyyy-MM-dd"));
                }
            }
            if (SummaryList.Count()>0)
            {
                using (SFTPHelper s = new SFTPHelper())
                {
                    FileSave<SftpSummaryModel> summaryFile = new FileSave<SftpSummaryModel>();
                    foreach (var item in systemValueList)
                    {
                        string s_Distributor = GetDistEName(item.sys_key);
                        var summary = SummaryList.Where(x => x.DicName == s_Distributor).ToList();
                        if (summary.Count()>0)
                        {
                            string path = $"/home/{s_Distributor}/Download/";
                            //本地文件和保存文件的名称
                            string[] localPath = LocalPath("summary", s_Distributor, DateTime.Now.ToString("yyyyMMdd"));
                            summaryFile.CsvSave(localPath[0], summary);
                            //判断是否存在当天有相同的类型的文件夹
                            List<Viat_sftp_export> exportList = s.GetFileList(path, ".csv");
                            string csvName = $"summary_{s_Distributor}_{DateTime.Now.ToString("yyyyMMdd")}";
                            var exportExtis = exportList.Where(x => x.file_name.Contains(csvName)).ToList();
                            if (exportExtis.Count() > 0)
                            {
                                foreach (var items in exportExtis)
                                {
                                    s.Delete(path + items.file_name);
                                }
                            }
                            s.CreateDirectory(path);
                            if (!s.Put(localPath[0], path + localPath[1]))
                            {
                                File.Delete(localPath[0]);
                                return webResponse.Error("fail to upload");
                            }
                            File.Delete(localPath[0]);
                        }
                        
                    }
                }
                
            }
            return webContent.OK("export success!");
        }

        public Stream ExecuteRow(string file_name)
        {
            string[] s_fileName = file_name.Split('_');
            string localPath = $"Upload/{s_fileName[0]}/{s_fileName[1]}/".MapPath();
            byte[] bytes = null;
            using (SFTPHelper sftp = new SFTPHelper())
            {
                bytes = sftp.GetByte($"/home/{s_fileName[1]}/Download/{file_name}");
            }
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        public WebResponseContent SftpUpload(string s_type,string distId,string date)
        {
            SftpSummaryModel summaryModel = new SftpSummaryModel();
            string s_Distributor = GetDistEName(distId);
            string dates = Convert.ToDateTime(date).ToString("yyyyMMdd");
            string path = "";
            string[] strings = new string[2];
            switch (s_type)
            {
                case "price":
                    List<SftpPrice> priceList = GetSftpPrices(distId, dates);
                    if (priceList.Count == 0)
                    {
                        return webResponse.Error("price no data");
                    }
                    foreach (var item in priceList)
                    {
                        item.modified_time = item.modified_time.Replace(":","");
                    }
                    strings = LocalPath(s_type, s_Distributor, dates);
                    FileSave<SftpPrice> priceFile = new FileSave<SftpPrice>();
                    priceFile.CsvSaveValuesSingle(strings[0], priceList);
                    path = $"/home/{s_Distributor}/Download/";
                    summaryModel.共计 = priceList.Count();
                    break;
                case "order":
                    List<SftpOrder> OrderList = GetSftpOrder(distId, dates);
                    if (OrderList.Count == 0)
                    {
                        return webResponse.Error("order no data");
                    }
                    foreach (var item in OrderList)
                    {
                        item.order_date = Convert.ToDateTime(item.order_date).ToString("yyyyMMdd");
                    }
                    strings = LocalPath(s_type, s_Distributor, dates);
                    FileSave<SftpOrder> orderFile = new FileSave<SftpOrder>();
                    orderFile.CsvSaveValuesSingle(strings[0], OrderList);
                    path = $"/home/{s_Distributor}/Download/";
                    summaryModel.共计 = OrderList.Count();
                    break;
                case "Allowance":
                    List<SftpAllowance> allowanceList = GetSftpAllowance(distId, dates);
                    if (allowanceList.Count == 0)
                    {
                        return webResponse.Error("Allowance no data");
                    }
                    strings = LocalPath(s_type, s_Distributor, dates);
                    FileSave<SftpAllowance> alowanceFile = new FileSave<SftpAllowance>();
                    alowanceFile.CsvSaveValues(strings[0], allowanceList);
                    path = $"/home/{s_Distributor}/Download/";
                    summaryModel.共计 = allowanceList.Count();
                    break;
                case "customer":
                    List<SftpCustomer> customerList = GetSftpCustomer(date);
                    if (customerList.Count == 0)
                    {
                        return webResponse.Error("customer no data");
                    }
                    strings = LocalPath(s_type, s_Distributor, dates);
                    FileSave<SftpCustomer> customerFile = new FileSave<SftpCustomer>();
                    customerFile.CsvSaveValues(strings[0], customerList);
                    path = $"/home/arich/Download/";
                    summaryModel.共计 = customerList.Count();
                    break;
            }

            summaryModel.PathName = path;
            summaryModel.文件名称 = strings[1];
            summaryModel.保存时间 = DateTime.Now.ToString();
            summaryModel.DicName = s_Distributor;
            SummaryList.Add(summaryModel);
            using (SFTPHelper s = new SFTPHelper())
            {
                //判断是否存在当天有相同的类型的文件夹
                List<Viat_sftp_export> exportList = s.GetFileList(path, ".csv");
                string csvName = s_type.Equal("customer") ? $"{s_type}_arich_{dates}" : $"{s_type}_{s_Distributor}_{dates}";
                var exportExtis = exportList.Where(x => x.file_name.Contains(csvName)).ToList();
                if (exportExtis.Count()>0)
                {
                    foreach (var item in exportExtis)
                    {
                        s.Delete(path + item.file_name);
                    }
                }
                s.CreateDirectory(path);
                if (!s.Put(strings[0], path + strings[1]))
                {
                    File.Delete(strings[0]);
                    return webResponse.Error("fail to upload");
                }
            }
            File.Delete(strings[0]);
            return webResponse.OK();
        }

        public string[] LocalPath(string s_type,string s_Distributor,string date)
        {
            string localPath = "", csvName ="";
            string[] strings = new string[2];
            if (s_type.Equal("customer"))
            {
                localPath = $"Upload/customer/arich/".MapPath();
                csvName = $"{s_type}_arich_{date}{DateTime.Now.ToString("HHmmss")}.csv";
            }
            else
            {
                localPath = $"Upload/{s_type}/{s_Distributor}/".MapPath();
                csvName = $"{s_type}_{s_Distributor}_{date}{DateTime.Now.ToString("HHmmss")}.csv";
            }
            if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);
            localPath += csvName;
            strings[0] = localPath;
            strings[1] = csvName;
            return strings;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="distId"></param>
        /// <param name="dates"></param>
        /// <returns></returns>
        public List<SftpPrice> GetSftpPrices(string distId,string dates)
        {
            return repository.DapperContext.QueryList<SftpPrice>("sp_viat_price_to_distributor_data", new { @DistId = distId, @trans_date = dates }, System.Data.CommandType.StoredProcedure);
        }
        public List<SftpOrder> GetSftpOrder(string distId, string dates)
        {
            return repository.DapperContext.QueryList<SftpOrder>("sp_viat_customer_order_to_distributor_data", new { @DistId = distId, @trans_date = dates }, System.Data.CommandType.StoredProcedure);
        }
        public List<SftpAllowance> GetSftpAllowance(string distId, string dates)
        {
            return repository.DapperContext.QueryList<SftpAllowance>("sp_viat_nhi_allw_to_distributor", new { @DistId = distId, @trans_date = dates }, System.Data.CommandType.StoredProcedure);
        }
        public List<SftpCustomer> GetSftpCustomer(string date)
        {
            return CustomerData(date);
        }

        public List<SftpCustomer> CustomerData(string date)
        {
            string sql = $@"SELECT a.cust_id,a.cust_name,a.invoice_name,a.cust_address,a.tax_id,a.tel_no 
            , a.owner,a.contact,CONVERT(varchar(100), a.modified_date, 112) as datey,right(cast(power(10,2) as varchar)+DATEPART(hour, a.modified_date),2)+right(cast(power(10,2) as varchar)+DATEPART(minute, a.modified_date),2)+right(cast(power(10,2) as varchar)+DATEPART(ss, a.modified_date),2) as dateh
            ,b.zip_id as invoice_zip_id,a.ctrl_drug_no,a.ctrl_drug_contact,a.doh_type,a.margin_type
            ,case when a.status = 'C' then 'N' else a.status end as status,a.remarks
            from viat_com_cust as a
            left join viat_com_zip_city as b on a.invoice_zip_id = b.zip_id 
            where 1 = 1 and a.doh_type <> 'WS' and(a.created_date >= '{date}' or a.modified_date >= '{date}') ";
            return repository.DapperContext.QueryList<SftpCustomer>(sql, null);
        }

        public string GetTypeName(string type)
        {
            string typeName = "";
            switch (type)
            {
                case "01":
                    typeName = "price";
                    break;
                case "02":
                    typeName = "customer";
                    break;
                case "03":
                    typeName = "order";
                    break;
                case "04":
                    typeName = "Allowance";
                    break;
                default:
                    typeName = "price,customer,order,Allowance";
                    break;
            }
            return typeName;
        }

        /// <summary>
        /// Distributor名称
        /// </summary>
        /// <param name="dist_id"></param>
        /// <returns></returns>
        public string GetDistEName(string dist_id)
        {
            string na = "";
            switch (dist_id)
            {
                case "1":
                    na = "ParkeDavis";
                    break;
                case "2":
                    na = "Zuellig";
                    break;
                case "3":
                    na = "Arich";
                    break;
                case "4":
                    na = "ShineSeng";
                    break;
                case "5":
                    na = "Holding";
                    break;
                case "6":
                    na = "grholddi";
                    break;
                case "7":
                    na = "Hintz";
                    break;
                case "8":
                    na = "Summit";
                    break;
                case "9":
                    na = "OrientEropharma";
                    break;
                case "A":
                    na = "AnChiang";
                    break;
                case "B":
                    na = "HuiMaw";
                    break;
                case "C":
                    na = "SingLong";
                    break;
                case "D":
                    na = "HorngWang";
                    break;
                case "E":
                    na = "EnHong";
                    break;
                case "F":
                    na = "YiHui";
                    break;
                case "G":
                    na = "CCPC";
                    break;
                case "H":
                    na = "CONMED";
                    break;
                case "I":
                    na = "keto";
                    break;
                case "J":
                    na = "zowhong";
                    break;
                case "K":
                    na = "medlion";
                    break;
                case "L":
                    na = "dkshph";
                    break;
                case "M":
                    na = "supermed";
                    break;
                case "N":
                    na = "astrong";
                    break;
                case "O":
                    na = "pingtin";
                    break;
                default:
                    na = "ParkeDavis,Zuellig,Arich,ShineSeng,Holding,grholddi,Summit,OrientEropharma,AnChiang,HuiMaw,SingLong,HorngWang,EnHong,CCPC,CONMED,keto,zowhong,medlion,supermed,astrong,pingtin";
                    break;
                    

            }
            return na.ToLower();
        }
    }
    /// <summary>
    /// 指定是否保存到文件中
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FileSaveAttribute : Attribute
    {
        public bool Save { get; set; }
        public FileSaveAttribute(bool isSave)
        {
            Save = isSave;
        }
    }
    public class FileSave<T>
    {
        public void CsvSave(string path, List<T> list, string title = null)
        {
            StringBuilder sb = new StringBuilder();
            if (title != null)
            {
                sb.AppendLine(title);
            }
            Type tInfo = typeof(T);
            List<object> listHeader = new List<object>();
            Dictionary<string, object> dictData = new Dictionary<string, object>();
            foreach (PropertyInfo p in tInfo.GetProperties())
            {
                string key = p.Name;
                if (GetAttributes<FileSaveAttribute>(key, out object isSave))
                {
                    if (!(bool)isSave)
                    {
                        continue;
                    }
                }
                //不存在默认为保存
                GetAttributes<DisplayNameAttribute>(key, out object displayName);
                listHeader.Add(displayName ?? key);
                dictData[key] = null;
            }
            sb.AppendLine(string.Join(",", listHeader));
            foreach (var model in list)
            {
                foreach (PropertyInfo p in tInfo.GetProperties())
                {
                    string key = p.Name;
                    if (dictData.ContainsKey(key))
                    {
                        dictData[key] = p.GetValue(model, null);
                    }
                }
                sb.AppendLine(string.Join(",", dictData.Values));
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        public void CsvSaveValues(string path, List<T> list, string title = null)
        {
            StringBuilder sb = new StringBuilder();
            if (title != null)
            {
                sb.AppendLine(title);
            }
            Type tInfo = typeof(T);
            //List<object> listHeader = new List<object>();
            Dictionary<string, object> dictData = new Dictionary<string, object>();
            foreach (PropertyInfo p in tInfo.GetProperties())
            {
                string key = p.Name;
                if (GetAttributes<FileSaveAttribute>(key, out object isSave))
                {
                    if (!(bool)isSave)
                    {
                        continue;
                    }
                }
                //不存在默认为保存
                GetAttributes<DisplayNameAttribute>(key, out object displayName);
                //listHeader.Add(displayName ?? key);
                dictData[key] = null;
            }
            //sb.AppendLine(string.Join(",", listHeader));
            foreach (var model in list)
            {
                foreach (PropertyInfo p in tInfo.GetProperties())
                {
                    string key = p.Name;
                    if (dictData.ContainsKey(key))
                    {
                        dictData[key] = p.GetValue(model, null);
                    }
                }
                sb.AppendLine(string.Join(",", dictData.Values));
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
        public void CsvSaveValuesSingle(string path, List<T> list, string title = null)
        {
            StringBuilder sb = new StringBuilder();
            if (title != null)
            {
                sb.AppendLine(title);
            }
            Type tInfo = typeof(T);
            //List<object> listHeader = new List<object>();
            Dictionary<string, object> dictData = new Dictionary<string, object>();
            foreach (PropertyInfo p in tInfo.GetProperties())
            {
                string key = p.Name;
                if (GetAttributes<FileSaveAttribute>(key, out object isSave))
                {
                    if (!(bool)isSave)
                    {
                        continue;
                    }
                }
                //不存在默认为保存
                GetAttributes<DisplayNameAttribute>(key, out object displayName);
                //listHeader.Add(displayName ?? key);
                dictData[key] = null;
            }
            //sb.AppendLine(string.Join(",", listHeader));
            foreach (var model in list)
            {
                foreach (PropertyInfo p in tInfo.GetProperties())
                {
                    string key = p.Name;
                    if (dictData.ContainsKey(key))
                    {
                        dictData[key] = p.GetValue(model, null);
                    }
                }
                object value = string.Join(",", dictData.Values);
                sb.AppendLine(string.Format("'{0}'", value.ToString().Replace(",", "','")));
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
        /// <summary>
        /// 获取该属性设对应的特性值（若该属性没有这个特性会抛出异常）
        /// </summary>
        bool GetAttributes<A>(string propertyName, out object value)
        {
            value = default;
            Type attributeType = typeof(A);
            PropertyInfo propertyInfo = typeof(T).GetProperties().FirstOrDefault(p => p.Name == propertyName);
            if (propertyInfo != null)
            {
                Attribute attr = Attribute.GetCustomAttribute(propertyInfo, attributeType);
                if (attr != null)
                {
                    //string attributeFieldName = string.Empty;
                    //switch (attributeType.Name)
                    //{
                    //    case "CategoryAttribute": attributeFieldName = "categoryValue"; break;
                    //    case "DescriptionAttribute": attributeFieldName = "description"; break;
                    //    case "DisplayNameAttribute": attributeFieldName = "_displayName"; break;
                    //    case "ReadOnlyAttribute": attributeFieldName = "isReadOnly"; break;
                    //    case "BrowsableAttribute": attributeFieldName = "browsable"; break;
                    //    case "DefaultValueAttribute": attributeFieldName = "value"; break;
                    //    case "FileSaveAttribute": attributeFieldName = "Save"; break;
                    //    default:
                    //        return false;
                    //}
                    //PropertyDescriptorCollection attributes = TypeDescriptor.GetProperties(typeof(T));
                    //FieldInfo fieldInfo = attributeType.GetField(attributeFieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
                    //value = fieldInfo.GetValue(attributes[propertyInfo.Name].Attributes[attributeType]);
                    value = false;
                    return true;
                }
            }
            return false;
        }

    }

    internal class SftpSummaryModel
    {
        /// <summary>
        /// SFTP保存地址
        /// </summary>
        [FileSaveAttribute(true)]
        public string PathName { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string 文件名称 { get; set; }
        /// <summary>
        /// 保存时间
        /// </summary>
        public string 保存时间 { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int 共计 { get; set; }
        /// <summary>
        /// 经销商
        /// </summary>
        [FileSaveAttribute(true)]
        public string DicName { get; set; }

    }
}
