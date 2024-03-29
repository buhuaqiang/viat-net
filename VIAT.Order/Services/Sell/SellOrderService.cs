/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下SellOrderService与ISellOrderService中编写
 */
using VIAT.Order.IRepositories;
using VIAT.Order.IServices;
using VIAT.Core.BaseProvider;
using VIAT.Core.Extensions.AutofacManager;
using VIAT.Entity.DomainModels;

namespace VIAT.Order.Services
{
    public partial class SellOrderService : ServiceBase<SellOrder, ISellOrderRepository>, ISellOrderService, IDependency
    {
        public SellOrderService(ISellOrderRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISellOrderService Instance
        {
           get { return AutofacContainerModule.GetService<ISellOrderService>(); }
        }
    }
}
