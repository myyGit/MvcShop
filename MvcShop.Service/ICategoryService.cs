using MvcShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Service
{
    public interface ICategoryService
    {
        List<Category> GetCategories(int? levels = null);
        void InsertCategory(Category category);
        List<Category> GetCategoriesIndex();
    }
}
