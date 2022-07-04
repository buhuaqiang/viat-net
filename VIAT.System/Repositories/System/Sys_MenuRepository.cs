using VIAT.System.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Core.EFDbContext;
using VIAT.Entity.DomainModels;

namespace VIAT.System.Repositories
{
    public partial class Sys_MenuRepository : RepositoryBase<Sys_Menu>, ISys_MenuRepository
    {
        public Sys_MenuRepository(VOLContext dbContext)
        : base(dbContext)
        {

        }
        public static ISys_MenuRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_MenuRepository>(); }
        }
    }
}

