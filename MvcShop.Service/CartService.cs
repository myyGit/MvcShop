using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using MvcShop.Entity;

namespace MvcShop.Service
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartReposity;
        public CartService(IRepository<Cart> cartReposity)
        {
            _cartReposity = cartReposity;
        }
        public void DeleteCart(List<int> cartIds)
        {
            _cartReposity.Table.Where(p=>cartIds.Contains(p.CartId)).Delete();
        }

        public List<Cart> GetCartByUserId(out int count, int? userId, int pageSize = 10, int pageIndex = 1)
        {
            var list = _cartReposity.Table.Where(p => p.IsActive);
            if (userId != null && userId > 0)
            {
                list = list.Where(p => p.UserId == userId);
            }
            count = list.FutureCount();
            list = list.OrderByDescending(p => p.CreateTime).Skip((pageIndex-1)*pageSize).Take(pageSize);
            return list.ToList();
        }

        public void InsertCart(Cart cart)
        {
            cart.CreateTime = DateTime.Now;
            cart.LastChangeTime = DateTime.Now;
            cart.IsActive = true;
            _cartReposity.Insert(cart);
        }

        public void UpdateCart(Cart cart)
        {
            cart.LastChangeTime = DateTime.Now;
            _cartReposity.Update(cart);
        }
    }
}
