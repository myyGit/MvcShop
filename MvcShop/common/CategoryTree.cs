using MvcShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.common
{
    public static class CategoryTree
    {
        public static List<Category> Totree(this List<Category> list)
        {
            var treeList = list;
            var dic = new Dictionary<int, Category>(treeList.Count);
            foreach (var tree in treeList)
            {
                dic.Add(tree.CategoryId, tree);
            }
            foreach (var tree in dic.Values)
            {
                if (dic.ContainsKey(tree.PId))
                {
                    if (dic[tree.PId].Children == null)
                    {
                        dic[tree.PId].Children = new List<Category>();
                    }
                    dic[tree.PId].Children.Add(tree);
                }
            }
            return dic.Values.Where(t => t.PId == 0).ToList();
        }
    }
}