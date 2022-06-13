/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_sys_deputyController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VIAT.Basic.IServices;
using VOL.Core.Filters;
using VOL.Entity.DomainModels;
namespace VIAT.Basic.Controllers
{
    [Route("api/View_sys_deputy")]
    [PermissionTable(Name = "View_sys_deputy")]
    public partial class View_sys_deputyController : ApiBaseController<IView_sys_deputyService>
    {
        public View_sys_deputyController(IView_sys_deputyService service)
        : base(service)
        {
        }

        [HttpPost, Route("GetPageDataByDeputy")]
        [ApiActionPermission()]
        public  ActionResult GetPageDataByDeputy()
        {
            //根据后端user的值进行数据查询
            //优先取代理ID，防止多次切换代理，如果代理ID没有，说明没有切换过代理，直接取当前用户ID
            int? nDeputyID = VOL.Core.ManageUser.UserContext.Current.ClientID;
            if(nDeputyID == null || nDeputyID ==0)
            {
                nDeputyID =VOL.Core.ManageUser.UserContext.Current.UserId;
            }
           
            PageDataOptions option = new PageDataOptions();
            option.Wheres = "[{\"name\":\"deputy_user_id\"" + "," + "\"value\":" + nDeputyID + "}]"; 

            return base.GetPageData(option);
        }
    }
}

