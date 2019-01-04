using MvcShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Service
{
    public interface IGoodService
    {
        List<GoodAndCategory> GetGoodAndCategory(int size, List<int> categoryIds = null);
        List<Good> GetGoodsByCategoryId(int categoryId, out int count, int pageSize=10,int pageIndex=1);
        Good GetGoodById(int goodId);
        List<GoodImage> GetGoodImagesByGoodIds(List<int> goodIds);
        int InsertGood(Good good);
        void InsertGoodImage(GoodImage goodImage);
    }
}
