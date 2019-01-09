using System;
using System.Collections.Generic;
using System.Linq;
using MvcShop.Entity;
using EntityFramework.Extensions;

namespace MvcShop.Service
{
    public class GoodService : IGoodService
    {
        private readonly IRepository<Good> _goodReposity;
        private readonly IRepository<GoodImage> _goodImageReposity;


        public GoodService(IRepository<Good> goodReposity, IRepository<GoodImage> goodImageReposity)
        {
            _goodReposity = goodReposity;
            _goodImageReposity = goodImageReposity;
        }
        public Good GetGoodById(int goodId)
        {
            return _goodReposity.Table.Where(p => p.GoodId == goodId).FirstOrDefault();
        }

        public List<GoodAndCategory> GetGoodAndCategory(int size, List<int> categoryIds=null)
        {
            var glist = _goodReposity.Table;
            if (categoryIds != null)
            {
                glist = glist.Where(p => categoryIds.Contains(p.CategoryId));
            }
            var list = glist.GroupBy(x => x.CategoryId,
                 (key, group) => group.OrderByDescending(p => p.GoodWeight).ThenByDescending(p => p.CreateTime).Take(size).ToList()).ToList();
            List<GoodAndCategory> resultList = new List<GoodAndCategory>();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    GoodAndCategory goodAndCategory = new GoodAndCategory();
                    goodAndCategory.CategoryId = item.FirstOrDefault().CategoryId;
                    goodAndCategory.CategoryName = item.FirstOrDefault().Category.CategoryName;
                    goodAndCategory.GoodList = item;
                    resultList.Add(goodAndCategory);
                }
            }
            return resultList;
        }

        public List<Good> GetGoodsByCategoryId(int? categoryId, out int count, int pageSize = 10, int pageIndex = 1)
        {
            count = 0;
            var listQuery = _goodReposity.Table.Where(p=>p.IsActive);
            if (categoryId != null && categoryId > 0)
            {
                listQuery = listQuery.Where(p => p.CategoryId == categoryId);
            }
            count = listQuery.FutureCount();  
            
            listQuery = listQuery.OrderByDescending(p => p.GoodWeight).ThenByDescending(p => p.CreateTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            var list = listQuery.Future().ToList();
            return list;
        }

        public List<GoodImage> GetGoodImagesByGoodIds(List<int> goodIds)
        {
            var ilist = _goodImageReposity.Table.Where(p => goodIds.Contains(p.GoodId))
                        .GroupBy(p => p.GoodId,
                                    (key, list) => list.OrderByDescending(p => p.Weight).ThenBy(p => p.CreateTime).Take(1))
                              .ToList();
            List<GoodImage> goodImages = new List<GoodImage>();
            foreach (var item in ilist)
            {
                goodImages.Add(item.FirstOrDefault());
            }
            return goodImages;
        }
        public List<GoodImage> GetGoodAllImagesByGoodIds(List<int> goodIds)
        {
            var ilist = _goodImageReposity.Table.Where(p => goodIds.Contains(p.GoodId) && p.IsActive).OrderByDescending(p=>p.Weight).ThenBy(p=>p.CreateTime);
            return ilist.ToList();
        }

        public int InsertGood(Good good)
        {
            good.CreateTime = DateTime.Now;
            good.LastChangeTime = DateTime.Now;
            good.IsActive = true;
            return _goodReposity.InsertReturnId(good);
        }
        public void InsertGoodImage(GoodImage goodImage)
        {
            goodImage.CreateTime = DateTime.Now;
            goodImage.LastChangeTime = DateTime.Now;
            goodImage.IsActive = true;
            _goodImageReposity.Insert(goodImage);
        }

        public void UpdateGood(Good good)
        {
            good.LastChangeTime = DateTime.Now;
            _goodReposity.Update(good);
        }
    }
}
