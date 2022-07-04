using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;
using System.Linq;
using VIAT.Core.Extensions;
using System.Collections.Generic;
using VIAT.Core.Enums;

namespace VIAT.System.Services
{
    public partial class Sys_DictionaryListService
    {

        public override PageGridData<Sys_DictionaryList> GetPageData(PageDataOptions pageData)
        {
            base.OrderByExpression = x => new Dictionary<object, QueryOrderBy>() { {
                    x.OrderNo,QueryOrderBy.Desc
                },
                {
                    x.DicList_ID,QueryOrderBy.Asc
                }
            };
            return base.GetPageData(pageData);
        }
    }
}

