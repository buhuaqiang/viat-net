/*
 *Author：jxx
 *Contact：283591387@qq.com
 *Date：2018-07-01
 * 此代码由框架生成，请勿随意更改
 */
using VIAT.System.IRepositories;
using VIAT.Core.BaseProvider;
using VIAT.Core.EFDbContext;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.System.Repositories
{
    public partial class Sys_RoleRepository : RepositoryBase<Sys_Role>, ISys_RoleRepository
    {
        public Sys_RoleRepository(VOLContext dbContext)
        : base(dbContext)
        {

        }
        public static ISys_RoleRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_RoleRepository>(); }
        }
    }
}

