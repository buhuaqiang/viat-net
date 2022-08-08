/*
 *所有关于Viat_com_employee类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Viat_com_employeeService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VIAT.Basic.IRepositories;
using System.Collections.Generic;

namespace VIAT.Basic.Services
{
    public partial class Viat_com_employeeService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IViat_com_employeeRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Viat_com_employeeService(
            IViat_com_employeeRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override PageGridData<Viat_com_employee> GetPageData(PageDataOptions options)
        {
            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();

            string whereConditon = "";
            for (int i = searchParametersList.Count - 1; i >= 0; i--)
            {
                SearchParameters item = searchParametersList[i];
                
                if (item.Name == "profession_type")
                {
                    searchParametersList.Remove(item);
                    whereConditon += " and emp_dbid in (SELECT emp_dbid from Sys_User WHERE profession_type='"+item.Value+"')";
                    break;
                }

            }
            QuerySql =@"select * from viat_com_employee where 1=1";
            QuerySql += whereConditon;
            return base.GetPageData(options);
        }
    }
}
