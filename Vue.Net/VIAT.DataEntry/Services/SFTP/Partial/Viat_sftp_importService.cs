/*
 *所有关于Viat_sftp_import类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_sftp_importService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System.IO;
using System.Text;

using VIAT.Utillity;
using System;
using VIAT.Basic.IRepositories;
using System.Collections.Generic;
using VIAT.DataEntry.Utillity;
using System.Text.RegularExpressions;
using VIAT.Core.Configuration;

namespace VIAT.DataEntry.Services
{
    public partial class Viat_sftp_importService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_sftp_importRepository _repository;//访问数据库
        private readonly IViat_com_custRepository _viat_com_custRepository;
        private readonly IViat_com_prodRepository _viat_com_prodRepository;
        private readonly IViat_com_close_periodRepository _viat_com_close_periodRepository;
        private readonly IViat_imp_error_logRepository _viat_imp_error_logRepository;
        private readonly Iviat_app_sales_transferRepository _viat_app_sales_transferRepository;
        private readonly IViat_com_system_valueRepository _viat_com_system_valueRepository;
        private readonly IViat_app_stock_viatrisRepository _viat_app_stock_viatrisRepository;
        private readonly IViat_app_stock_distRepository _viat_app_stock_distRepository;

        private WebResponseContent Response { get; set; }

        [ActivatorUtilitiesConstructor]
        public Viat_sftp_importService(
            IViat_sftp_importRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IViat_com_custRepository viat_com_custRepository,
            IViat_com_prodRepository viat_com_prodRepository,
            IViat_com_close_periodRepository viat_com_close_periodRepository,
            IViat_imp_error_logRepository viat_imp_error_logRepository,
            Iviat_app_sales_transferRepository viat_app_sales_transferRepository,
            IViat_com_system_valueRepository viat_com_system_valueRepository,
            IViat_app_stock_viatrisRepository viat_app_stock_viatrisRepository,
            IViat_app_stock_distRepository viat_app_stock_distRepository

            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _viat_com_custRepository = viat_com_custRepository;
            _viat_com_prodRepository = viat_com_prodRepository;
            _viat_com_close_periodRepository = viat_com_close_periodRepository;
            _viat_imp_error_logRepository = viat_imp_error_logRepository;
             _viat_app_sales_transferRepository = viat_app_sales_transferRepository;
            _viat_com_system_valueRepository = viat_com_system_valueRepository;
            _viat_app_stock_viatrisRepository = viat_app_stock_viatrisRepository;
            _viat_app_stock_distRepository = viat_app_stock_distRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webResponse = new WebResponseContent();
        /// <summary>
        /// 获取SFTP信息
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override PageGridData<Viat_sftp_import> GetPageData(PageDataOptions options)
        {
            string distId = "";
            string source = "";
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                if (searchParametersList != null && searchParametersList.Count > 0)
                {
                    foreach (SearchParameters sp in searchParametersList)
                    {
                        switch (sp.Name.ToLower())
                        {
                            case "dist_id":
                                distId = sp.Value;
                                break;
                            case "source":
                                source = sp.Value;
                                break;
                        }
                    }
                }
            }
            List<Viat_sftp_import> rows = queryCSVFromSftp(distId, source);
            PageGridData<Viat_sftp_import> gridData = new PageGridData<Viat_sftp_import>();
            gridData.total = rows.Count();
            gridData.rows = rows.Skip((options.Page - 1) * options.Rows).Take(options.Rows).ToList();
            return gridData;
        }

        /// <summary>
        /// 從SFTP查詢檔案清單
        /// </summary>
        /// <param name="distId"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<Viat_sftp_import> queryCSVFromSftp(string distId,string source)
        {
            this.Response = new WebResponseContent();
            List<Viat_sftp_import> fileNameList = new List<Viat_sftp_import>();
            Dictionary<string, List<Viat_sftp_import>> dicStfp = new Dictionary<string, List<Viat_sftp_import>>();
            Regex reg1 = new Regex(@"sales_[a-zA-Z0-9]{1,}_\d{14}\.csv");
            Regex reg2 = new Regex(@"invp[a-z]{0,5}_[a-zA-Z0-9]{1,}_\d{10,14}\.csv");
            Regex reg3 = new Regex(@"invd[a-z]{0,3}_[a-zA-Z0-9]{1,}_\d{10,14}\.csv");
            string dist = "";
            switch (distId)
            {
                case "1":
                    dist = "ParkeDavis";
                    break;
                case "2":
                    dist = "Zuellig";
                    break;
                case "3":
                    dist = "Arich";
                    break;
                case "4":
                    dist = "ShineSeng";
                    break;
                case "5":
                    dist = "Holding";
                    break;
                case "6":
                    dist = "grholddi";
                    break;
                case "7":
                    dist = "Hintz";
                    break;
                case "8":
                    dist = "Summit";
                    break;
                case "9":
                    dist = "OrientEropharma";
                    break;
                case "A":
                    dist = "AnChiang";
                    break;
                case "B":
                    dist = "HuiMaw";
                    break;
                case "C":
                    dist = "SingLong";
                    break;
                case "D":
                    dist = "HorngWang";
                    break;
                case "E":
                    dist = "EnHong";
                    break;
                case "F":
                    dist = "YiHui";
                    break;
                case "G":
                    dist = "CCPC";
                    break;
                case "H":
                    dist = "CONMED";
                    break;
                case "I":
                    dist = "keto";
                    break;
                case "J":
                    dist = "zowhong";
                    break;
                case "K":
                    dist = "medlion";
                    break;
                case "L":
                    dist = "dkshph";
                    break;
                case "M":
                    dist = "supermed";
                    break;
                case "N":
                    dist = "astrong";
                    break;
                case "O":
                    dist = "pingtin";
                    break;
                default:
                    dist = "ParkeDavis,Zuellig,Arich,ShineSeng,Holding,grholddi,Summit,OrientEropharma,AnChiang,HuiMaw,SingLong,HorngWang,EnHong,CCPC,CONMED,keto,zowhong,medlion,supermed,astrong,pingtin";
                    break;
            }
            dist = dist.ToLower();
            string[] distributor = dist.Split(new char[] { ',' });
            string sftpPath = "";
            Console.WriteLine("sftpPath:" + sftpPath);
            List<Viat_sftp_import> sftpFileList = null;
            using (SFTPHelper sftpClient = new SFTPHelper())
            {
                foreach (var item in distributor)
                {
                    sftpPath = "/home/" + item + "/Download";
                    sftpFileList = sftpClient.GetFileImportList(sftpPath, ".csv");
                    foreach (Viat_sftp_import p in sftpFileList)
                    {
                        if (string.IsNullOrEmpty(source))
                        {
                            if (!reg1.IsMatch(p.file_name) && !reg2.IsMatch(p.file_name) && !reg3.IsMatch(p.file_name))
                                continue;
                        }
                        else if (source == "sales")
                        {
                            if (!reg1.IsMatch(p.file_name))
                                continue;
                        }
                        else if (source == "invp")
                        {
                            if (!reg2.IsMatch(p.file_name))
                                continue;
                        }
                        else if (source == "invdist")
                        {
                            if (!reg3.IsMatch(p.file_name))
                                continue;
                        }
                        else if (source == "resales")
                        {
                            //邏輯待之後加入
                            continue;
                        }
                        string filenameAlike = getFilenameDatePart(p.file_name);
                        int findNum = _viat_imp_error_logRepository.Find(x => x.filenameimp == p.file_name || (p.file_name.Contains(filenameAlike) && p.file_name.CompareTo(p.file_name) > 0)).Count();
                        if (findNum > 0)
                            continue;

                        fileNameList.Add(p);
                    }
                    dicStfp.Add(item, fileNameList);
                }
            }
            IEnumerable<Viat_sftp_import> value = dicStfp.SelectMany(x => x.Value);
            List<Viat_sftp_import> SftpList = new List<Viat_sftp_import>();
            SftpList.AddRange(value);
            return SftpList;
        }

        public WebResponseContent ImportBatch(IHeaderDictionary header)
        {
            WebResponseContent webContent = new WebResponseContent();
            var keys = header.Keys;
            var values = header.Values;
            bool key = keys.Any((id) =>
            {
                return AppSetting.quartzHeader.Name.Equals(id, StringComparison.OrdinalIgnoreCase);
            });
            bool value = values.Any((id) =>
            {
                return AppSetting.quartzHeader.Password.Equals(id, StringComparison.OrdinalIgnoreCase);
            });
            if (!key)
            {
                return webContent.Error("人员不存在，没有权限");
            }
            if (!value)
            {
                return webContent.Error("密码不对，没有权限");
            }
            Dictionary<string, List<Viat_sftp_export>> dicStfp = new Dictionary<string, List<Viat_sftp_export>>();
            List<Viat_com_system_value> systemValueList = repository.DbContext.Set<Viat_com_system_value>().Where(x => x.category_id == "DistID" && x.status == "Y").OrderBy(x=>x.sys_key).ToList();
            if (systemValueList.Count() > 0)
            {
                string date = DateTime.Now.ToString("yyyyMMdd");
                string localPath = $"Upload/SftpUpload/".MapPath();
                if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);
                using (SFTPHelper s = new SFTPHelper())
                {
                    foreach (var item in systemValueList)
                    {
                        string distid = Viat_sftp_exportService.Instance.GetDistEName(item.sys_key);
                        string path = $"/home/{distid}/Upload/";
                        List<Viat_sftp_export> ss = s.GetFileList(path, ".csv");
                        ss = ss.Where(x => x.file_name.Contains(date)).ToList();
                        foreach (var import in ss)
                        {
                            s.Get(path + import.file_name, localPath + import.file_name);
                        }
                        dicStfp.Add(path, ss);
                    }
                }
                IEnumerable<Viat_sftp_export> exportAble = dicStfp.SelectMany(x => x.Value);
                List<Viat_sftp_export> SftpList = new List<Viat_sftp_export>();
                SftpList.AddRange(exportAble);

                foreach (var item in SftpList)
                {
                    if (item.file_name.IndexOf("sales") != -1)
                    {
                        importSalesCSV(localPath + item.file_name);
                    }
                    else if (item.file_name.IndexOf("invp") != -1)
                    {
                        ImportInvpfizerCSV(localPath + item.file_name);
                    }
                    else if (item.file_name.IndexOf("invd") != -1)
                    {
                        ImportInvdistCSV(localPath + item.file_name);
                    }
                    File.Delete(localPath+item.file_name);
                }
            }
            return webContent.OK();
        }

        /// <summary>
        /// 匯入SFTP上檔案內容
        /// </summary>
        /// <param name="distId"></param>
        /// <param name="fileNames"></param>
        public void doImportCSVFromSftp(string distId, string[] fileNames)
        {
            Console.WriteLine("doImportCSVFromSftp");
            this.Response = new WebResponseContent();
            string dist = "";
            switch (distId)
            {
                case "1":
                    dist = "ParkeDavis";
                    break;
                case "2":
                    dist = "Zuellig";
                    break;
                case "3":
                    dist = "Arich";
                    break;
                case "4":
                    dist = "ShineSeng";
                    break;
                case "5":
                    dist = "Holding";
                    break;
                case "6":
                    dist = "grholddi";
                    break;
                case "7":
                    dist = "Hintz";
                    break;
                case "8":
                    dist = "Summit";
                    break;
                case "9":
                    dist = "OrientEropharma";
                    break;
                case "A":
                    dist = "AnChiang";
                    break;
                case "B":
                    dist = "HuiMaw";
                    break;
                case "C":
                    dist = "SingLong";
                    break;
                case "D":
                    dist = "HorngWang";
                    break;
                case "E":
                    dist = "EnHong";
                    break;
                case "F":
                    dist = "YiHui";
                    break;
                case "G":
                    dist = "CCPC";
                    break;
                case "H":
                    dist = "CONMED";
                    break;
                case "I":
                    dist = "keto";
                    break;
                case "J":
                    dist = "zowhong";
                    break;
                case "K":
                    dist = "medlion";
                    break;
                case "L":
                    dist = "dkshph";
                    break;
                case "M":
                    dist = "supermed";
                    break;
                case "N":
                    dist = "astrong";
                    break;
                case "O":
                    dist = "pingtin";
                    break;
                default:
                    dist = "ParkeDavis,Zuellig,Arich,ShineSeng,Holding,grholddi,Summit,OrientEropharma,AnChiang,HuiMaw,SingLong,HorngWang,EnHong,CCPC,CONMED,keto,zowhong,medlion,supermed,astrong,pingtin";
                    break;
            }
            dist = dist.ToLower();
            string sftpPath = "/home/" + "anching" + "/Download";
            fileNames[0] = "sales_3_20220707191938.csv";
            foreach (string fileName in fileNames)
            {
                using(SFTPHelper sftpClient = new SFTPHelper())
                {
                    string remotePath = sftpPath + "/" + fileName;
                    string localPath = Path.Combine(Path.GetTempPath(), fileName);
                    sftpClient.Get(remotePath, localPath);
                    if(File.Exists(localPath))
                    {
                        if (fileName.IndexOf("sales") != -1)
                        {
                            importSalesCSV(localPath);
                        }
                        else if (fileName.IndexOf("invp") != -1)
                        {
                            ImportInvpfizerCSV(localPath);
                        }
                        else if (fileName.IndexOf("invd") != -1)
                        {
                            ImportInvdistCSV(localPath);
                        }
                        else if (fileName.IndexOf("re-sales") != -1)
                        {
                            //TODO: 暫時還未知
                        }
                        else
                        {

                        }
                    }
                }
            }
        }


        /// <summary>
        /// 匯入檔案內容
        /// </summary>
        /// <param name="tempPath"></param>
        /// <param name="fileNames"></param>
        public void doImportCSVFromFile(string tempPath, string[] fileNames)
        {
            Console.WriteLine("doImport");
            this.Response = new WebResponseContent();
            foreach (string fileName in fileNames)
            {
                string filePath = Path.Combine(tempPath, fileName);
                if (fileName.IndexOf("sales") != -1)
                {
                    importSalesCSV(filePath);
                }
                else if (fileName.IndexOf("invp") != -1)
                {
                    ImportInvpfizerCSV(filePath);
                }
                else if (fileName.IndexOf("invd") != -1)
                {
                    ImportInvdistCSV(filePath);
                }
                else if (fileName.IndexOf("re-sales") != -1)
                {
                    //TODO: 暫時還未知
                }
                else
                {

                }
            }

        }

        /// <summary>
        /// 匯入檔案內容
        /// </summary>
        /// <param name="fileFullPaths"></param>
        public void doImportCSVFromFile(List<IFormFile> fileFullPaths)
        {
            this.Response = new WebResponseContent();
            IFormFile formFile = fileFullPaths[0];
            string targetPath = $"Upload/{DateTime.Now.ToString("yyyMMdd")}/{typeof(Viat_sftp_import).Name}/".MapPath();
            if (!Directory.Exists(targetPath)) Directory.CreateDirectory(targetPath);

            List<string> fileNamePathList = new List<string>();
            foreach (IFormFile f in fileFullPaths)
            {
                string dicPath = $"{targetPath}{Guid.NewGuid().ToString()}_{f.FileName}";
                FileInfo file = new FileInfo(dicPath);
                using (var stream = new FileStream(dicPath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                fileNamePathList.Add(dicPath);
            }


            foreach (string filePath in fileNamePathList)
            {
                string fileName = Path.GetFileName(filePath);
                if (fileName.IndexOf("sales") != -1)
                {
                    importSalesCSV(filePath);
                }
                else if (fileName.IndexOf("invp") != -1)
                {
                    ImportInvpfizerCSV(filePath);
                }
                else if (fileName.IndexOf("invd") != -1)
                {
                    ImportInvdistCSV(filePath);
                }
                else if (fileName.IndexOf("re-sales") != -1)
                {
                    //TODO: 暫時還未知
                }
                else
                {

                }
            }

        }

        /// <summary>
        /// In-Market Sales(In-Market交易資料)交易資料匯入，內含中文BIG5編碼，目前檔案編碼皆為BIG5
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="neet_check_trans_date">為空的話表示排程執行，需檢查trans_date是否小於viat_com_close_period的sales_start_date-4，有值的話，不需檢查</param>
        private List<viat_app_sales_transfer> importSalesCSV(string filePath, string neet_check_trans_date = "")
        {
            Console.WriteLine("importSalesCSV");
            string newFile = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "_1" + Path.GetExtension(filePath));
            File.WriteAllText(newFile, File.ReadAllText(filePath, Encoding.GetEncoding(950)), Encoding.UTF8);
            int contentRowIndex = 0;
            List<Viat_com_cust> cust_content = new List<Viat_com_cust>();
            List<Viat_com_prod> prod_content = new List<Viat_com_prod>();
            List<string> tmp_duplicate = new List<string>();

            List<viat_app_sales_transfer> result = new List<viat_app_sales_transfer>();
            List<Viat_imp_error_log> errorDatas = new List<Viat_imp_error_log>();

            string[] tmp_dist_id = Path.GetFileNameWithoutExtension(filePath).Split('_');
            string dist_id = tmp_dist_id[1];
            //TODO: 檢查sales_start_date
            DateTime now = DateTime.Now.Date;
            DateTime? sales_start_date = null; //Maintainer.GetSalesStartDate();
            Viat_com_close_period ccp = _viat_com_close_periodRepository.Find(cc => cc.sales_start_date <= now && cc.sales_end_date >= now).FirstOrDefault();
            if (ccp != null)
            {
                sales_start_date = ccp.sales_start_date;
            }

            using (CSVReader csvReader = new CSVReader(newFile, contentRowIndex))
            {
                object[] data = null;
                while ((data = csvReader.ReadWithQuotationMarks()) != null)
                {
                    string trans_type = data[0].ToString().Replace("'", "").Trim();
                    string trans_class = data[1].ToString().Replace("'", "").Trim();
                    string dist_cust_id = data[5].ToString().Replace("'", "").Trim();
                    string cust_id = data[7].ToString().Replace("'", "").Trim();
                    string prod_id = data[9].ToString().Replace("'", "").Trim();
                    DateTime? trans_date = DateTime.ParseExact(data[4].ToString().Replace("'", ""), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                    string invoice_no = data[3].ToString().Replace("'", "");
                    string lot_no = data[15].ToString().Replace("'", "");
                    string order_no = data[17].ToString().Replace("'", "");
                    Guid? cust_id_dbid = null;
                    Guid? prod_id_dbid = null;
                    string custName = "";
                    bool flag = true; bool NotProd = false; bool NotCust = false;
                    decimal _decimal = 0;
                    decimal? nhi_price = null, invoice_price = null, net_price = null;

                    #region check data rules
                    //檢查資料，須檢查的欄位有trans_type,trans_class,dist_cust_id,cust_id,prod_id,trans_date,

                    if (string.IsNullOrEmpty(trans_type))
                        flag = false;
                    if (trans_type != "O" && string.IsNullOrEmpty(trans_class))
                        flag = false;//trans_type==O則trans_class允許NULL，否則視為錯誤資料
                    if (string.IsNullOrEmpty(dist_cust_id))
                        flag = false;
                    if (string.IsNullOrEmpty(cust_id))
                        flag = false;
                    if (string.IsNullOrEmpty(prod_id))
                        flag = false;
                    if (data[4].ToString() == "''")
                        flag = false;//交易日期不能為空
                    if (data.Count() < 18)
                        flag = false;//資料欄位不齊全，視為錯誤資料
                    if (invoice_no.Length > 10)
                        flag = false;
                    if (string.IsNullOrEmpty(invoice_no))
                        flag = false;
                    if (data.Count() == 22)
                    {
                        if (!string.IsNullOrEmpty(data[19].ToString().Replace("'", "")))
                        {
                            if (decimal.TryParse(data[19].ToString().Replace("'", ""), out _decimal))
                                nhi_price = _decimal;
                            else
                                flag = false;
                        }
                        if (!string.IsNullOrEmpty(data[20].ToString().Replace("'", "")))
                        {
                            if (decimal.TryParse(data[20].ToString().Replace("'", ""), out _decimal))
                                invoice_price = _decimal;
                            else
                                flag = false;
                        }
                        if (!string.IsNullOrEmpty(data[21].ToString().Replace("'", "")))
                        {
                            if (decimal.TryParse(data[21].ToString().Replace("'", ""), out _decimal))
                                net_price = _decimal;
                            else
                                flag = false;
                        }
                    }
                    Viat_com_cust com_cust = this._viat_com_custRepository.Find(x => x.cust_id == cust_id).FirstOrDefault();
                    if (com_cust == null)
                    {
                        flag = false; NotCust = true;
                    }
                    else
                    {
                        cust_id_dbid = com_cust.cust_dbid;
                        custName = com_cust.cust_name;
                        cust_content.Add(com_cust);
                    }

                    Viat_com_prod pr = _viat_com_prodRepository.Find(y => y.prod_id == prod_id).FirstOrDefault();
                    if (pr == null)
                    {
                        flag = false; NotProd = true;
                    }
                    else
                    {
                        prod_id_dbid = pr.prod_dbid;
                        prod_content.Add(pr);
                    }
                    if (string.IsNullOrEmpty(neet_check_trans_date) && sales_start_date != null && trans_date < sales_start_date.Value.AddDays(-30))
                        flag = false;

                    if (tmp_duplicate.Contains(trans_date.Value.ToString("yyyyMMdd") + trans_type + invoice_no + prod_id + lot_no + trans_class + order_no))
                    {
                        flag = false;//	duplicate key
                    }
                    #endregion
                    if (flag == true)
                    {
                        #region effect data

                        string cust_order_no = data[16].ToString().Replace("'", "");

                        string cust_name = data[8].ToString().Replace("'", "");
                        string dist_prod_id = data[6].ToString().Replace("'", "");

                        decimal unit_price = Convert.ToDecimal(data[10]);
                        decimal qty = Convert.ToDecimal(data[11]);
                        decimal free_qty = Convert.ToDecimal(data[12]);
                        decimal amt = Convert.ToDecimal(data[13]);
                        decimal tax = Convert.ToDecimal(data[14]);
                        string trans_class1 = data[2].ToString().Replace("'", "");


                        //string trans_date = data[4].ToString();
                        DateTime? ai_basedate;
                        if (data[18].ToString() == "''")
                            ai_basedate = null;
                        else
                            ai_basedate = DateTime.ParseExact(data[18].ToString().Replace("'", ""), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);

                        tmp_duplicate.Add(trans_date.Value.ToString("yyyyMMdd") + trans_type + invoice_no + prod_id + lot_no + trans_class + order_no);
                        result.Add(new viat_app_sales_transfer
                        {
                            salestransfer_dbid = System.Guid.NewGuid(),
                            created_date = DateTime.Now,
                            trans_type = trans_type,
                            trans_class = string.IsNullOrEmpty(trans_class) ? null : trans_class,
                            trans_date = DateTime.ParseExact(data[4].ToString().Replace("'", ""), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces),
                            invoice_no = invoice_no,
                            cust_order_no = cust_order_no,
                            order_no = order_no,
                            dist_cust_id = dist_cust_id,
                            cust_name = cust_name,
                            dist_prod_id = dist_prod_id,
                            lot_no = lot_no,
                            unit_price = unit_price,
                            qty = qty,
                            free_qty = free_qty,
                            amt = amt,
                            tax = tax,
                            ai_basedate = ai_basedate,
                            dist_id = dist_id,
                            cust_dbid = cust_id_dbid,
                            prod_dbid = prod_id_dbid,
                            nhi_price = nhi_price,
                            net_price = net_price,
                            invoice_price = invoice_price
                        });
                        #endregion
                    }
                    else
                    {
                        #region error data
                        string msg = "";
                        if (data.Count() < 18)
                            msg += "資料欄位有誤,";
                        if (string.IsNullOrEmpty(trans_type))
                            msg += "交易類別為空,";
                        if (trans_type != "O" && string.IsNullOrEmpty(trans_class))
                            msg += "價差類別為空,";
                        if (string.IsNullOrEmpty(dist_cust_id))
                            msg += "經銷商客戶代碼為空,";
                        if (string.IsNullOrEmpty(cust_id))
                            msg += "客戶代碼為空,";
                        if (string.IsNullOrEmpty(prod_id))
                            msg += "產品代碼為空,";
                        if (data[4].ToString() == "''")
                            msg += "交易日期為空,";
                        if (NotProd)
                            msg += "產品代碼不存在,";
                        if (NotCust)
                            msg += "客戶代碼不存在,";
                        if (tmp_duplicate.Contains(trans_date.Value.ToString("yyyyMMdd") + trans_type + invoice_no + prod_id + lot_no + trans_class + order_no))
                            msg += "資料重複,";
                        if (string.IsNullOrEmpty(invoice_no))
                            msg += "發票號碼為空,";
                        if (invoice_no.Length > 10)
                            msg += "發票號碼超過10碼,";
                        if (data.Count() == 22)
                        {
                            if (!string.IsNullOrEmpty(data[19].ToString().Replace("'", "")))
                            {
                                if (!decimal.TryParse(data[19].ToString().Replace("'", ""), out _decimal))
                                    msg += "健保價格錯誤,";
                            }
                            if (!string.IsNullOrEmpty(data[20].ToString().Replace("'", "")))
                            {
                                if (!decimal.TryParse(data[20].ToString().Replace("'", ""), out _decimal))
                                    msg += "發票價錯誤,";
                            }
                            if (!string.IsNullOrEmpty(data[21].ToString().Replace("'", "")))
                            {
                                if (!decimal.TryParse(data[21].ToString().Replace("'", ""), out _decimal))
                                    msg += "銷售價錯誤,";
                            }
                        }
                        if (string.IsNullOrEmpty(neet_check_trans_date) && sales_start_date != null && trans_date < sales_start_date.Value.AddDays(-30))
                            msg += "資料交易日期不可小於" + sales_start_date.Value.AddDays(-30).ToString("yyyy/MM/dd") + ",";
                        string fileText = "";
                        fileText = string.Join(",", data);
                        errorDatas.Add(new Viat_imp_error_log
                        {
                            errorlog_dbid= System.Guid.NewGuid(),   
                          
                            created_date = DateTime.Now,
                            filenameimp = Path.GetFileName(filePath),
                            filetext = fileText + " " + Path.GetFileName(filePath),
                            errormessage = msg.TrimEnd(',')
                        }); ;
                        #endregion
                    }
                }

            }
            try
            {
                File.Delete(newFile);
            }
            catch { }
            if (errorDatas.Count > 0)
            {
                List<Viat_imp_error_log> data = new List<Viat_imp_error_log>();
                data.Add(new Viat_imp_error_log { filenameimp = Path.GetFileName(filePath) });
                Response = _viat_imp_error_logRepository.DbContextBeginTransaction(() =>
                {
                    _viat_imp_error_logRepository.AddRange(errorDatas, true);
                    _viat_imp_error_logRepository.SaveChanges();
                    Response.OK(Core.Enums.ResponseType.SaveSuccess);
                    return Response;
                });
                SendMailToDistributor(errorDatas, false);
                
                return null;
            }
            else
            {
                try
                {
                    Response = _viat_app_sales_transferRepository.DbContextBeginTransaction(() =>
                    {
                        _viat_app_sales_transferRepository.AddRange(result, true);
                       int c= _viat_app_sales_transferRepository.SaveChanges();
                        Response.OK(Core.Enums.ResponseType.SaveSuccess);
                        return Response;
                    });
                    
                    List<Viat_imp_error_log> successInfo = new List<Viat_imp_error_log>();
                    successInfo.Add(new Viat_imp_error_log
                    {
                        filenameimp = Path.GetFileName(filePath),
                        errormessage = " 檔案 import 成功 "
                    });
                    SendMailToDistributor(successInfo, true);
                }
                catch (Exception)
                {
                    errorDatas.Add(new Viat_imp_error_log
                    {
                        errorlog_dbid = System.Guid.NewGuid(),
                        created_date = DateTime.Now,
                        filenameimp = Path.GetFileName(filePath),
                        filetext = Path.GetFileName(filePath),
                        errormessage = "Insert error!"
                    });
                    Response = _viat_imp_error_logRepository.DbContextBeginTransaction(() =>
                    {
                        _viat_imp_error_logRepository.AddRange(errorDatas, true);
                        _viat_imp_error_logRepository.SaveChanges();
                        Response.OK(Core.Enums.ResponseType.SaveSuccess);
                        return Response;
                    });


                    //Maintainer.AddToImportErrorLog(null, errorDatas, fileName);
                    return null;
                }                               
            }
            return result;
        }


        /// <summary>
        /// invpfizer_X_XXXXXXXXXXXXXX.csv 資料匯入，內含中文BIG5編碼，檔案編碼不固定，有時為UTF8，有時為BIG5
        /// </summary>        
        /// <param name="filePath">檔案路徑</param>
        /// <returns></returns>
        private List<Viat_app_stock_viatris > ImportInvpfizerCSV(string filePath)
        {
            Console.WriteLine("ImportInvpfizerCSV");
            int contentRowIndex = 0;
            List<Viat_app_stock_viatris> importDatas = new List<Viat_app_stock_viatris>();
            List<Viat_imp_error_log> errorDatas = new List<Viat_imp_error_log>();
            List<Viat_app_stock_viatris> temp = new List<Viat_app_stock_viatris>();

            //先把該檔案轉成UTF8，否則會有亂碼
            string newFile = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "_1" + Path.GetExtension(filePath));
            File.WriteAllText(newFile, File.ReadAllText(filePath, Encoding.GetEncoding(950)), Encoding.UTF8);

            try
            {
                using (CSVReader csvReader = new CSVReader(newFile, contentRowIndex))
                {
                    object[] data = null;
                    string[] tmp_dist_id = Path.GetFileNameWithoutExtension(filePath).Split('_');//filename.Split('_');
                    string[] tmp_dist_upload = tmp_dist_id[2].Split('.');
                    string dist_id = tmp_dist_id[1];

                    DateTime dist_upload_date;
                    DateTime.TryParseExact(tmp_dist_upload[0].Substring(0, 8), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dist_upload_date);

                    while ((data = csvReader.ReadWithQuotationMarks()) != null)
                    {

                        string dist_product_id = data[6].ToString().Replace("'", "");
                        string prod_id = data[0].ToString().Replace("'", "");
                        string prod_name = data[1].ToString().Replace("'", "");
                        string lot_no = data[3].ToString().Replace("'", "");
                        DateTime? expired_date = DateTime.ParseExact(data[4].ToString().Replace("'", ""), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces); //Convert.ToDateTime(data[4].ToString().Replace("'", ""));
                        string wh_id = data[7].ToString().Replace("'", "");
                        decimal qty = Convert.ToDecimal(data[5]);
                        Guid? prod_id_dbid = null;

                        bool flag = true; bool NotProd = false;
                        #region check data rules
                        //需檢查欄位dist_upload_date+lot_no+prod_id_dbid

                        if (string.IsNullOrEmpty(prod_id))
                            flag = false;
                        if (string.IsNullOrEmpty(data[4].ToString()))
                            flag = false;
                        if (string.IsNullOrEmpty(dist_product_id))
                            flag = false;

                        Viat_com_prod pr = _viat_com_prodRepository.Find(y => y.prod_id == prod_id).FirstOrDefault();
                        if (pr == null)
                        {
                            flag = false; NotProd = true;
                        }
                        else
                        {
                            prod_id_dbid = pr.prod_dbid;
                        }

                        if (temp.FirstOrDefault(d => (string.Equals(d.lot_no, lot_no) && string.Equals(d.prod_dbid, prod_id_dbid) && string.Equals(d.wh_id, wh_id))) != null)
                            flag = false;//檢查檔案裡這三個欄位的資料有無重複，若有視為錯誤資料
                        #endregion

                        if (flag == true)
                        {
                            #region effect data
                            importDatas.Add(new Viat_app_stock_viatris
                            {
                                stock_viatris_dbid=  System.Guid.NewGuid(),
                                dist_prod_id = dist_product_id,
                                lot_no = lot_no,
                                expired_date = expired_date,
                                wh_id = wh_id,
                                //WhName=wh_name,
                                qty = qty,
                                dist_id = dist_id,
                                dist_upload_date = dist_upload_date,
                                prod_dbid = prod_id_dbid,                    
                            });
                            temp.Add(new Viat_app_stock_viatris { lot_no = lot_no, prod_dbid = prod_id_dbid, wh_id = wh_id });
                            #endregion
                        }
                        else
                        {
                            #region error data
                            string msg = "";
                            if (temp.FirstOrDefault(d => (d.lot_no == lot_no && d.prod_dbid == prod_id_dbid && d.wh_id == wh_id)) != null)
                                msg += "批次號碼和產品代碼重複,";
                            if (string.IsNullOrEmpty(prod_id))
                                msg += "產品代碼為空,";
                            if (NotProd)
                                msg += "產品代碼不存在,";
                            if (string.IsNullOrEmpty(data[4].ToString()))
                                msg += "效期為空,";
                            if (string.IsNullOrEmpty(dist_product_id))
                                msg += "經銷商產品代碼為空,";

                            string fileText = "";
                            //int filelengt = fileName.Length;
                            for (int i = 0; i < data.Length; i++)
                            {
                                fileText += data[i] + ",";
                            }
                            fileText = fileText.TrimEnd(',');
                            errorDatas.Add(new Viat_imp_error_log
                            {
                                errorlog_dbid = System.Guid.NewGuid(),
                                created_date = DateTime.Now,
                                filenameimp = Path.GetFileName(filePath),
                                filetext = fileText + " " + Path.GetFileName(filePath),
                                errormessage = msg.TrimEnd(',')
                            });
                            #endregion
                        }
                    }
                }
                try
                {
                    //File.Delete(fileName);
                    File.Delete(newFile);
                }
                catch { }
                if (errorDatas.Count > 0)
                {
                    Response = _viat_imp_error_logRepository.DbContextBeginTransaction(() =>
                    {
                        _viat_imp_error_logRepository.AddRange(errorDatas);
                        int c=_viat_imp_error_logRepository.SaveChanges();
                        Response.OK(Core.Enums.ResponseType.SaveSuccess);
                        return Response;
                    });
                    SendMailToDistributor(errorDatas);                   
                    return null;
                }
                else
                {
                    try
                    {
                        Response = _viat_app_stock_viatrisRepository.DbContextBeginTransaction(() =>
                        {
                            _viat_app_stock_viatrisRepository.AddRange(importDatas);
                            int c= _viat_app_stock_viatrisRepository.SaveChanges();
                            Response.OK(Core.Enums.ResponseType.SaveSuccess);
                            return Response;
                        });

                        List<Viat_imp_error_log> successInfo = new List<Viat_imp_error_log>();
                        successInfo.Add(new Viat_imp_error_log
                        {
                            filenameimp = Path.GetFileName(filePath),
                            errormessage = " 檔案 import 成功 "
                        });
                        SendMailToDistributor(successInfo, true);
                    }
                    catch (Exception)
                    {
                        errorDatas.Add(new Viat_imp_error_log
                        {
                            errorlog_dbid = System.Guid.NewGuid(),
                            created_date = DateTime.Now,
                            filenameimp = Path.GetFileName(filePath),
                            filetext = Path.GetFileName(filePath),
                            errormessage = "Insert error!"
                        });
                        Response = _viat_imp_error_logRepository.DbContextBeginTransaction(() =>
                        {
                            _viat_imp_error_logRepository.AddRange(errorDatas);
                            _viat_imp_error_logRepository.SaveChanges();
                            Response.OK(Core.Enums.ResponseType.SaveSuccess);
                            return Response;
                        });


                        return null;
                    }                    
                }
                return importDatas;
            }
            catch (Exception e)
            {
                errorDatas.Add(new Viat_imp_error_log
                {
                    created_date = DateTime.Now,
                    filenameimp = Path.GetFileName(filePath),
                    filetext = Path.GetFileName(filePath),
                    errormessage = e.Message
                });
                _viat_imp_error_logRepository.AddRange(errorDatas, true);
                SendMailToDistributor(errorDatas);
                
                return null;
            }
        }

        /// <summary>
        /// invdist_X_XXXXXXXXXXXXXX.csv 資料匯入        
        /// </summary>
        /// <param name="filePath">檔案路徑</param>
        /// <returns></returns>
        private List<Viat_app_stock_dist> ImportInvdistCSV(string filePath)
        {
            Console.WriteLine("ImportInvdistCSV");
            int contentRowIndex = 0;
            List<Viat_app_stock_dist> importDatas = new List<Viat_app_stock_dist>();
            List< Viat_imp_error_log> errorDatas = new List<Viat_imp_error_log>();
            List<Viat_app_stock_dist> tmp = new List<Viat_app_stock_dist>();

            //先把該檔案轉成UTF8，否則會有亂碼
            string newFile = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "_1" + Path.GetExtension(filePath));
            File.WriteAllText(newFile, File.ReadAllText(filePath, Encoding.GetEncoding(950)), Encoding.UTF8);

            decimal num;
            try
            {
                using (CSVReader csvReader = new CSVReader(newFile, contentRowIndex))
                {
                    object[] data = null;
                    string[] tmp_dist_id = Path.GetFileNameWithoutExtension(filePath).Split('_');
                    string[] tmp_dist_upload = tmp_dist_id[2].Split('.');
                    DateTime dist_upload_date;
                    DateTime.TryParseExact(tmp_dist_upload[0].Substring(0, 8), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dist_upload_date);
                    string dist_id = tmp_dist_id[1];
                    while ((data = csvReader.ReadWithQuotationMarks()) != null)
                    {
                        string dist_prod_id = data[0].ToString().Replace("'", "");
                        string prod_id = data[1].ToString().Replace("'", "");
                        string prod_name = data[2].ToString().Replace("'", "").Trim();
                        string lot_no = data[14].ToString().Replace("'", "");
                        string start_qty = data[4].ToString();//Convert.ToDecimal(data[4].ToString());
                        string receive_qty = data[5].ToString();//Convert.ToDecimal(data[5].ToString());
                        string return_qty = data[6].ToString();//Convert.ToDecimal(data[6].ToString());
                        string bad_qty = data[7].ToString();
                        string issues_qty = data[8].ToString();
                        string sample_qty = data[9].ToString();
                        string adjust_qty = data[10].ToString();
                        string end_qty = data[11].ToString();
                        string borrow_qty = data[15].ToString();
                        string borrow_sales = data[16].ToString();
                        DateTime start_date = DateTime.ParseExact(data[12].ToString().Replace("'", ""), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                        DateTime end_date = DateTime.ParseExact(data[13].ToString().Replace("'", ""), "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                        Guid? prod_id_dbid = null;

                        //int prod_id_dbid = 1;
                        bool flag = true; bool NotProd = false;
                        string msg = "";

                        //須轉為decimal的欄位
                        List<int> primes = new List<int>(new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 15, 16 });

                        foreach (int number in primes)
                        {
                            if (!Decimal.TryParse(data[number].ToString(), out num))
                            {
                                flag = false;
                                msg = "無法轉為decimal";
                            }
                        }
                        if (tmp.FirstOrDefault(d => (string.Equals(d.lot_no, lot_no) && string.Equals(d.dist_prod_id, dist_prod_id))) != null)
                        {
                            flag = false; // Lot No, Dist Prod Id 重複則視為錯誤資料
                            msg += ", Key Field 重複 [dist_prod_id = " + dist_prod_id + " lot_no = " + lot_no + "]";
                        }

                        Viat_com_prod pr = _viat_com_prodRepository.Find(y => y.prod_id == prod_id).FirstOrDefault();
                        if (pr == null)
                        {
                            flag = false; NotProd = true;
                        }
                        else
                        {
                            prod_id_dbid = pr.prod_dbid;
                        }

                        if (flag == true)
                        {
                            importDatas.Add(new Viat_app_stock_dist
                            {
                                stock_dist_dbid =  System.Guid.NewGuid(),
                                dist_upload_date = dist_upload_date,
                                dist_id = dist_id,
                                dist_prod_id = dist_prod_id,
                                //ProdId = prod_id,
                                prod_name = prod_name,
                                lot_no = lot_no,
                                start_qty = Convert.ToDecimal(start_qty),
                                receive_qty = Convert.ToDecimal(receive_qty),
                                return_qty = Convert.ToDecimal(return_qty),//receive_qty,
                                bad_qty = Convert.ToDecimal(bad_qty),
                                issues_qty = Convert.ToDecimal(issues_qty),
                                sample_qty = Convert.ToDecimal(sample_qty),
                                adjust_qty = Convert.ToDecimal(adjust_qty),
                                end_qty = Convert.ToDecimal(end_qty),
                                borrow_qty = Convert.ToDecimal(borrow_qty),
                                borrow_sales = Convert.ToDecimal(borrow_sales),
                                start_date = start_date,
                                end_date = end_date,
                                prod_dbid = prod_id_dbid
                            });
                            tmp.Add(new Viat_app_stock_dist { lot_no = lot_no, dist_prod_id = dist_prod_id });
                        }
                        else
                        {
                            string fileText = "";
                            for (int i = 0; i < data.Length; i++)
                            {
                                fileText += data[i] + ",";
                            }
                            fileText = fileText.TrimEnd(',');
                            errorDatas.Add(new Viat_imp_error_log
                            {
                                errorlog_dbid = System.Guid.NewGuid(),
                                created_date = DateTime.Now,
                                filenameimp = Path.GetFileName(filePath),
                                filetext = fileText + " " + Path.GetFileName(filePath),
                                errormessage = msg.TrimEnd(',')
                            });
                        }
                    }
                }
                try
                {
                    //File.Delete(fileName);
                    File.Delete(newFile);
                }
                catch { }

                if (errorDatas.Count() > 0)
                {
                    Response = _viat_imp_error_logRepository.DbContextBeginTransaction(() =>
                    {
                        _viat_imp_error_logRepository.AddRange(errorDatas);
                        int c = _viat_imp_error_logRepository.SaveChanges();
                        Response.OK(Core.Enums.ResponseType.SaveSuccess);
                        return Response;
                    });

                    //_viat_imp_error_logRepository.AddRange(errorDatas, true);
                    SendMailToDistributor(errorDatas);
                    return null;
                }
                else
                {
                    try
                    {
                        
                        Response = _viat_app_stock_distRepository.DbContextBeginTransaction(() =>
                        {
                            _viat_app_stock_distRepository.AddRange(importDatas, false);
                            int c=_viat_app_stock_distRepository.SaveChanges();
                            Response.OK(Core.Enums.ResponseType.SaveSuccess);
                            return Response;
                        });
                        List<Viat_imp_error_log> successInfo = new List<Viat_imp_error_log>();
                        successInfo.Add(new Viat_imp_error_log
                        {
                            filenameimp = Path.GetFileName(filePath),
                            errormessage = " 檔案 import 成功 "
                        });
                        SendMailToDistributor(successInfo, true);
                    }
                    catch (Exception)
                    {

                        errorDatas.Add(new Viat_imp_error_log
                        {
                            errorlog_dbid = System.Guid.NewGuid(),
                            created_date = DateTime.Now,
                            filenameimp = Path.GetFileName(filePath),
                            filetext = Path.GetFileName(filePath),
                            errormessage = "Insert error!"
                        });
                        Response = _viat_imp_error_logRepository.DbContextBeginTransaction(() =>
                        {
                            _viat_imp_error_logRepository.AddRange(errorDatas, true);
                            _viat_imp_error_logRepository.SaveChanges();
                            Response.OK(Core.Enums.ResponseType.SaveSuccess);
                            return Response;
                        });
                        return null;
                    }
                }

                return importDatas;
            }
            catch (Exception e)
            {
                errorDatas.Add(new Viat_imp_error_log
                {
                    errorlog_dbid = System.Guid.NewGuid(),
                    created_date = DateTime.Now,
                    filenameimp = Path.GetFileName(filePath),
                    filetext = Path.GetFileName(filePath),
                    errormessage = e.Message
                });                
                Response = _viat_imp_error_logRepository.DbContextBeginTransaction(() =>
                {
                    _viat_imp_error_logRepository.AddRange(errorDatas, true);
                    _viat_imp_error_logRepository.SaveChanges();
                    Response.OK(Core.Enums.ResponseType.SaveSuccess);
                    return Response;
                });
                SendMailToDistributor(errorDatas);
                return null;
            }
        }

        private bool SendMailToDistributor(List<Viat_imp_error_log> errorMessage, bool success = false)
        {
            Viat_imp_error_log data = errorMessage.First();
            string[] fileInfo = data.filenameimp.Split('_');

            try
            {
                Viat_com_system_value distMail=_viat_com_system_valueRepository.Find(x => x.category_id == "DistID" && x.sys_key == fileInfo[1]).FirstOrDefault();
                if(distMail != null)
                {
                    string pattern = "\"(.*)\"";
                    Regex rg = new Regex(pattern);
                    string[] mails = rg.Match(distMail.remarks).ToString().Replace("\"", "").Split(';');
                    //信件內容
                    string pcontect = data.filenameimp + " " + data.errormessage;//"string or html";
                    string subject = "";
                    //主旨
                    if (success == false)
                    {
                        string content = data.filenameimp + " File Error";
                        if (errorMessage.Count() > 0 && data.filetext != "")
                        {
                            pcontect = "<br>Data:<br>";
                            foreach (var p in errorMessage)
                            {
                                if (p.filetext != "")
                                    pcontect += p.filetext + " " + p.errormessage + "<br>";
                            }
                        }
                        subject = data.filenameimp + " " + " File Import Error ";
                    }
                    else
                        subject = data.filenameimp + " File Import Successful";
                    SmtpHelper smtpHelper = new SmtpHelper();
                    foreach (var dist_mail in mails)
                    {
                        smtpHelper.sendMail(dist_mail, subject, pcontect);
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private string getFilenameDatePart(string filename)
        {
            string extension = null;
            string datePart = null;
            string results = filename;
            string[] filenameAry = null;

            if (string.IsNullOrEmpty(filename))
            {
                return filename;
            }
            try
            {
                extension = Path.GetExtension(filename);
                filenameAry = filename.Split('_');

                if (filenameAry.Length > 2)
                {
                    datePart = filenameAry[2].Substring(0, 8); // yyyyMMdd
                    filenameAry[2] = datePart;//string.Concat(new string[] { datePart, extension });
                    results = string.Join("_", filenameAry);
                }
            }
            catch (Exception e)
            {
                
            }

            return results;
        }
    }
}
