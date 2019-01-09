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
        List<Good> GetGoodsByCategoryId(int? categoryId, out int count, int pageSize=15,int pageIndex=1);
        Good GetGoodById(int goodId);
        /// <summary>
        /// 获取每个商品对应的第一张图片
        /// </summary>
        /// <param name="goodIds"></param>
        /// <returns></returns>
        List<GoodImage> GetGoodImagesByGoodIds(List<int> goodIds);
        /// <summary>
        /// 获取每个商品的所有图片
        /// </summary>
        /// <param name="goodIds"></param>
        /// <returns></returns>
        List<GoodImage> GetGoodAllImagesByGoodIds(List<int> goodIds);
        int InsertGood(Good good);
        void InsertGoodImage(GoodImage goodImage);
        void UpdateGood(Good good);
    }
}
