/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Viat_sftp_import",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VIAT.Entity.DomainModels;
using VIAT.DataEntry.IServices;
using VIAT.Core.Utilities;

namespace VIAT.DataEntry.Controllers
{
    public partial class Viat_sftp_importController
    {
        private readonly IViat_sftp_importService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Viat_sftp_importController(
            IViat_sftp_importService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            string distId = "";
            string source = "";
            if (!string.IsNullOrEmpty( loadData.Wheres))
            {
                List<Dictionary<string, string>> whereList=  Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(loadData.Wheres);
                if(whereList != null && whereList.Count > 0)
                {
                    foreach(Dictionary<string, string> w in whereList)
                    {
                        if(w["name"] == "dist_id")
                        {
                            distId = w["value"];
                        }
                        if (w["name"] == "source")
                        {
                            source = w["value"];
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(distId))
            {
                return Json(new WebResponseContent { Status = false, Message = "請至少選取一個經銷商" });
            }

            List<Viat_sftp_export> result = _service.queryCSVFromSftp(distId, source);
            return Json(result);
            //return base.GetPageData(loadData);
        }

        [HttpPost, Route("doImportCSVFromSftp")]
        public IActionResult DoImportCSVFromSftp([FromBody] SftpImportViewModel options)
        {
            if(string.IsNullOrEmpty(options.DistId))
            {
                return Json(new WebResponseContent { Status = false, Message = "請至少選取一個經銷商" });
            }

            if(options.FileNames == null || options.FileNames.Length ==0)
            {
                return Json(new WebResponseContent { Status = false, Message = "請至少選取一個檔案" });
            }

            _service.doImportCSVFromSftp(options.DistId, options.FileNames);

            return Json(new WebResponseContent { Status = true });
        }


        public override ActionResult Import(List<IFormFile> fileInput)
        {
            if (fileInput == null || fileInput.Count == 0)
            {
                return Json(new WebResponseContent { Status = false, Message = "請至少選取一個檔案" });
            }
            int c = fileInput.Count;
            _service.doImportCSVFromFile(fileInput);
            return Json(new WebResponseContent { Status = true });
        }

      

        [HttpPost, Route("doExecute")]
        public IActionResult DoExecute([FromBody] Dictionary<string,string> options)
        {
            int c = options.Count;
            List<Viat_sftp_export>  result=_service.queryCSVFromSftp("2", "");
            //string[] fileNames = { "sales_3_20220708191938.csv" };
            //string[] fileNames = { "sales_3_20220707191938.csv" };
            //string[] fileNames = { "invdist_3_2022070819.csv" , "invpfizer_3_2022070819.csv" };
            
            //_service.doImportCSVFromFile("D:\\Documents\\MyProject\\耀得\\SFTP Import", fileNames);
            return Json(options);
        }
    }

    public class SftpImportViewModel
    {
        public string DistId { get; set; }
        public string Source { get; set; }
        public string[] FileNames { get; set; }
    }
}
