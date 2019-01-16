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
        public void DeleteCartByGoodIds(List<int> goodIds)
        {
            _cartReposity.Table.Where(p=> goodIds.Contains(p.GoodId)).Update(p=> new Cart() {
                IsActive = false
            });
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
        public List<Cart> GetCartByCartIds(List<int> cartIds)
        {
            return _cartReposity.Table.Where(p => p.IsActive && cartIds.Contains(p.CartId)).OrderByDescending(p => p.CreateTime).ToList();
        }
        public Cart GetCartByGoodId(int goodId)
        {
            return _cartReposity.Table.Where(p => p.GoodId == goodId && p.IsActive).OrderByDescending(p=>p.CreateTime).FirstOrDefault();
        }
        public int GetCartCount(int? userId)
        {
            var list = _cartReposity.Table.Where(p => p.IsActive);
            if (userId != null && userId > 0)
            {
                list.Where(p => p.UserId == userId);
            }
            return list.Count();
        }
    }
}
