using MvcShop.Entity;
using MvcShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Areas.AdminArea.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: AdminArea/Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _categoryService.InsertCategory(category);
            return View();
        }
    }
}