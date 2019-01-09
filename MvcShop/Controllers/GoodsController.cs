using Common;
using MvcShop.Entity;
using MvcShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IGoodService _goodService;
        private readonly ICategoryService _categoryService;
        public GoodsController(IGoodService goodService, ICategoryService categoryService)
        {
            _goodService = goodService;
            _categoryService = categoryService;
        }
        // GET: Goods
        public ActionResult List(int? categoryId=null)
        {
            int count = 0;
            List<Good> goodList = _goodService.GetGoodsByCategoryId(categoryId,out count);
            //List<GoodListModel> models = new List<GoodListModel>();
            //models.O2D(goodList);
            List<int> goodIds = goodList.Select(p => p.GoodId).ToList();
            var imgList = _goodService.GetGoodImagesByGoodIds(goodIds);
            ViewData["ImgList"] = imgList;
            return View(goodList);
        }
        public ActionResult Detail(int? productId=null)
        {
            if (productId == null || productId <= 0)
            {
                return View();
            }
            Good good = _goodService.GetGoodById(Convert.ToInt32(productId));
            var imgList = _goodService.GetGoodAllImagesByGoodIds(new List<int>() { good .GoodId });
            ViewData["ImgList"] = imgList;
            return View(good);
        }
    }
}