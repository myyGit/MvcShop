using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcShop.Entity;

namespace MvcShop.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryReposity;
        public CategoryService(IRepository<Category> categoryReposity)
        {
            _categoryReposity = categoryReposity;
        }
        public List<Category> GetCategories(int? levels=null)  
        {
            var list = _categoryReposity.Table.Where(p => p.IsActive);
            if (levels != null)
            {
                list = list.Where(p => p.Levels == levels);
            }
            return list.OrderByDescending(p=>p.Weight).ThenByDescending(p=>p.CreateTime).ToList();
        }

        public void InsertCategory(Category category)
        {
            category.CreateTime = DateTime.Now;
            category.LastChangeTime = DateTime.Now;
            category.IsActive = true;
            _categoryReposity.Insert(category);
        }
        public List<Category> GetCategoriesIndex()
        {
            var list = _categoryReposity.Table.Where(p => p.IsActive && (p.Levels ==1 || p.Levels == 2));
            return list.OrderByDescending(p => p.Weight).ThenByDescending(p => p.CreateTime).ToList();
        }
    }
}
