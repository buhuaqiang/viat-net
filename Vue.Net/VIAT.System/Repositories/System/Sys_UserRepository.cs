﻿/*
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
    public partial class Sys_UserRepository : RepositoryBase<Sys_User>, ISys_UserRepository
    {
        public Sys_UserRepository(VOLContext dbContext)
        : base(dbContext)
        {

        }
        public static ISys_UserRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_UserRepository>(); }
        }
    }
}

