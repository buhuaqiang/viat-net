/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Viat_sftp_importService与IViat_sftp_importService中编写
 */
using VIAT.DataEntry.IRepositories;
using VIAT.DataEntry.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.DataEntry.Services
{
    public partial class Viat_sftp_importService : ServiceBase<Viat_sftp_import, IViat_sftp_importRepository>
    , IViat_sftp_importService, IDependency
    {
    public Viat_sftp_importService(IViat_sftp_importRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IViat_sftp_importService Instance
    {
      get { return AutofacContainerModule.GetService<IViat_sftp_importService>(); } }
    }
 }
