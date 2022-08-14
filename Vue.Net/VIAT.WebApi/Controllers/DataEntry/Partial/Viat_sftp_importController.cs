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
using Microsoft.AspNetCore.Authorization;

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
            Dictionary<string, object> result = new Dictionary<string, object>();
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

            WebResponseContent webContent = new WebResponseContent();
            if (string.IsNullOrEmpty(distId))
            {
                //result.Add("status", null);
                //result.Add("Status", false);
                //result.Add("msg", "請至少選取一個經銷商");
                //result.Add("Message", "請至少選取一個經銷商");
                //return Json(result);
                //return Json(webContent.Error("請至少選取一個經銷商"));
                return Json(new WebResponseContent { Status = false, Message = "請至少選取一個經銷商" });
            }

            List<Viat_sftp_import> rows = _service.queryCSVFromSftp(distId, source);
            result.Add("status",true);
            result.Add("msg", null);
            result.Add("total", rows.Count);
            result.Add("rows", rows);
            result.Add("summary", null);
            result.Add("extra", null);
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

        [HttpPost, Route("ExecuteBatch"), AllowAnonymous]
        public ActionResult ImportBatch()
        {
            return Json(_service.ImportBatch(HttpContext.Request.Headers));
        }




    }

    public class SftpImportViewModel
    {
        public string DistId { get; set; }
        public string Source { get; set; }
        public string[] FileNames { get; set; }
    }
}
