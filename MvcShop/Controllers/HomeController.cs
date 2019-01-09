using MvcShop.common;
using MvcShop.Entity;
using MvcShop.Service;
using MvcShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGoodService _goodService;
        private readonly ICategoryService _categoryService;
        private readonly ICartService _cartService;
        public HomeController(IGoodService goodService, ICategoryService categoryService, ICartService cartService)
        {
            _goodService = goodService;
            _categoryService = categoryService;
            _cartService = cartService;
        }
        // GET: Home
        public ActionResult Index()
        {
            List<Category> categories = _categoryService.GetCategoriesIndex();
            List<int> categoryIds = categories.Where(p=>p.Levels == 2).Select(p => p.CategoryId).ToList();
            if (categories != null && categories.Count > 0)
            {
                categories = categories.Totree();
            }
            var list = _goodService.GetGoodAndCategory(1,categoryIds);

            List<int> goodIds = new List<int>();
            foreach (var item in list)
            {
                goodIds.AddRange(item.GoodList.Select(p => p.GoodId));
            }
            var imgList = _goodService.GetGoodImagesByGoodIds(goodIds);
            ViewData["GoodList"] = list;
            ViewData["ImgList"] = imgList;
            ViewData["CategoryList"] = categories;
            var context = base.HttpContext;
            if (context.Session["CurrentUser"] != null && context.Session["CurrentUser"] is CurrentUser)
            {
                CurrentUser currentUser = (CurrentUser)context.Session["CurrentUser"];
                ViewBag.IsLogin = true;
                ViewBag.UserName = currentUser.UserName;
                ViewBag.CartNum = _cartService.GetCartCount(currentUser.UserId);
            }
            else
            {
                ViewBag.IsLogin = false;
                ViewBag.UserName = "";
                ViewBag.CartNum = 0;
            }
            
            return View();
        }
        public ActionResult Result()
        {
            return View();
        }

    }
}