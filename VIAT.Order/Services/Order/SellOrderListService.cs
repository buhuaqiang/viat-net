/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下SellOrderListService与ISellOrderListService中编写
 */
using VIAT.Order.IRepositories;
using VIAT.Order.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Order.Services
{
    public partial class SellOrderListService : ServiceBase<SellOrderList, ISellOrderListRepository>, ISellOrderListService, IDependency
    {
        public SellOrderListService(ISellOrderListRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISellOrderListService Instance
        {
           get { return AutofacContainerModule.GetService<ISellOrderListService>(); }
        }
    }
}
