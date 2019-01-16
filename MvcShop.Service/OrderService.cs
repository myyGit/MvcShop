using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using MvcShop.Data;
using MvcShop.Entity;

namespace MvcShop.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderReposity;
        public OrderService(IRepository<Order> orderReposity)
        {
            this._orderReposity = orderReposity;
        }
        public void DeleteOrder(Order order)
        {
            order.LastChangeTime = DateTime.Now;
            order.IsActive = false;
            _orderReposity.Update(order);
        }

        public List<Order> GetOrderListByUserIdAndStatus(int? userId, EnumOrderStatus? status,out int? count,int pageIndex=1,int pageSize=10)
        {
            var order = _orderReposity.Table.Where(p => p.IsActive);
            if (userId != null && userId > 0)
            {
                order = order.Where(p => p.UserId == userId);
            }
            if (status != null)
            {
                order = order.Where(p => p.OrderState == (int)status);
            }
            count = order.FutureCount();
            order = order.OrderByDescending(p => p.CreateTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            return order.ToList();
        }

        public void InsertOrder(Order order)
        {
            order.CreateTime = DateTime.Now;
            order.LastChangeTime = DateTime.Now;
            order.IsActive = true;
            _orderReposity.Insert(order);
        }

        public void UpdateOrder(Order order)
        {
            order.LastChangeTime = DateTime.Now;
            _orderReposity.Insert(order);
        }
    }
}
