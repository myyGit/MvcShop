using MvcShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Service
{
    public interface ICartService
    {
        void InsertCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(List<int> cartIds);
        List<Cart> GetCartByUserId(out int count, int? userId, int pageSize=10,int pageIndex=1);
    }
}
