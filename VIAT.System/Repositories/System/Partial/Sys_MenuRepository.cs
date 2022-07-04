using VIAT.System.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Core.EFDbContext;
using VIAT.Entity.DomainModels;

namespace VIAT.System.Repositories
{
    public partial class Sys_MenuRepository
    {
        public override VOLContext DbContext => base.DbContext;
    }
}

