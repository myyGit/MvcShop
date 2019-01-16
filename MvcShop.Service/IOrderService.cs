using MvcShop.Data;
using MvcShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Service
{
    public interface IOrderService
    {
        void InsertOrder(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
        List<Order> GetOrderListByUserIdAndStatus(int? userId, EnumOrderStatus? status, out int? count, int pageIndex = 1, int pageSize = 10);
    }
}
