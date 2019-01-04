﻿using MvcShop.Entity;
using MvcShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace MvcShop.Areas.AdminArea.Controllers
{
    public class GoodsController : Controller
    {
        private ICategoryService _categoryService;
        private IGoodService _goodService;
        public GoodsController(ICategoryService categoryService, IGoodService goodService)
        {
            _categoryService = categoryService;
            _goodService = goodService;
        }
        // GET: AdminArea/Goods
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddGood()
        {
            var list = _categoryService.GetCategories(2);
            ViewData["CategoryList"] = list;
            return View();
        }
        [HttpPost]
        public ActionResult AddGood(AddGoodModel goodModel)
        {
            Good good = new Good();
            good.O2D(goodModel);
            int goodId = _goodService.InsertGood(good);
            GoodImage goodImage = new GoodImage();
            goodImage.GoodId = goodId;
            goodImage.GoodImageName = goodModel.GoodImageName;
            goodImage.GoodImageUrl = goodModel.GoodImageUrl;
            goodImage.Weight = 0;
            _goodService.InsertGoodImage(goodImage);
            var list = _categoryService.GetCategories(2);
            ViewData["CategoryList"] = list;
            return View();
        }
    }
}