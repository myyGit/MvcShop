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
    [CustomAuthorizeAttribute]
    public class CartController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICartService _cartService;
        private readonly IGoodService _goodService;
        public CartController(IUserService userService, ICartService cartService, IGoodService goodService)
        {
            this._userService = userService;
            this._cartService = cartService;
            this._goodService = goodService;
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(int productId=0,int count = 0)
        {
            if (productId == 0 || count == 0)
            {
                return Json(new SuccessResult { status = 2, data = "Data Error", msg = "请选择要添加的商品" });
            }
            CurrentUser currentUser = (CurrentUser)base.HttpContext.Session["CurrentUser"];
            Good good = _goodService.GetGoodById(productId);
            Cart cart = _cartService.GetCartByGoodId(productId);
            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = currentUser.UserId,
                    GoodId = productId,
                    GoodPrice = good.GoodPrice,
                    Num = count
                };
                _cartService.InsertCart(cart);
            }
            else
            {
                cart.Num += count;
                _cartService.UpdateCart(cart);
            }
            return Json(new SuccessResult { status = 1, data = "OK", msg = "OK" });
        }
        public ActionResult List()
        {
            CurrentUser currentUser = (CurrentUser)base.HttpContext.Session["CurrentUser"];
            int count = 0;
            List<Cart> cartList = _cartService.GetCartByUserId(out count, currentUser.UserId, 10, 1);
            List<int> goodIds = cartList.Select(p => p.GoodId).ToList();
            var imgList = _goodService.GetGoodImagesByGoodIds(goodIds);
            ViewData["ImgList"] = imgList;
            return View(cartList);
        }
        [HttpPost]
        public ActionResult DeleteProduct(string productIds)
        {
            if (string.IsNullOrEmpty(productIds))
            {
                return Json(new SuccessResult { status = 2, data = "Data Error", msg = "请选择要删除的商品" });
            }
            List<string> goodIdStr = productIds.Split(',').ToList();
            List<int> goodIds = goodIdStr.Select(p => Convert.ToInt32(p)).ToList();
            _cartService.DeleteCartByGoodIds(goodIds);
            return Json(new SuccessResult { status = 1, data = "OK", msg = "OK" });
        }
        [HttpPost]
        public ActionResult Update(int productId,int count)
        {
            if (productId <= 0 || count <=0 )
            {
                return Json(new SuccessResult { status = 2, data = "Data Error", msg = "请选择要删除的商品" });
            }
            Cart cart = _cartService.GetCartByGoodId(productId);
            if (cart == null)
            {
                return Json(new SuccessResult { status = 2, data = "Data Error", msg = "购物车中不存在该商品" });
            }
            cart.Num = count;
            _cartService.UpdateCart(cart);
            return Json(new SuccessResult { status = 1, data = "OK", msg = "OK" });
        }
    }
}