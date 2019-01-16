using Common;
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
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ICartService _cartService;
        private readonly IGoodService _goodService;
        public OrderController(IOrderService orderService, IUserService userService, ICartService cartService,
            IGoodService goodService)
        {
            _orderService = orderService;
            this._userService = userService;
            this._cartService = cartService;
            this._goodService = goodService;
        }
        public UserAccount GetUserAccount()
        {
            CurrentUser currentUser = (CurrentUser)base.HttpContext.Session["CurrentUser"];
            UserAccount userAccount = _userService.GetUserByUserId(currentUser.UserId);
            return userAccount;
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult OrderDetail(string cartIds)
        {
            UserAccount userAccount = GetUserAccount();
            if (userAccount == null)
            {
                return Json(new SuccessResult { status = 2, data = "用户不存在", msg = "用户不存在" });
            }
            List<Address> addressList = _userService.GetAddressListByUserId(userAccount.UserId);
            ViewData["AddressList"] = addressList;
            string[] arr = cartIds.Split(',');
            List<int> cartIdInts = arr.Select(p => Convert.ToInt32(p)).ToList();
            List<Cart> cartlist = _cartService.GetCartByCartIds(cartIdInts);
            List<int> goodIds = cartlist.Select(p => p.GoodId).ToList();
            var imgList = _goodService.GetGoodImagesByGoodIds(goodIds);
            ViewData["ImgList"] = imgList;
            return View(cartlist);
        }
        [HttpPost]
        public ActionResult AddOrder(string cartIds)
        {
            Order order = new Order();
            order.AddressId = 1;
            order.GoodCount = 3;
            order.GoodTotalPrice = 100m;
            order.HGUID = GuidUtils.ToClearLow(GuidUtils.ClearLow);
            order.OrderNumber = "2190239231212";
            order.OrderState = 0;
            order.PayMoney = 100m;
            order.UserId = 1;
            //order. = 1;
            return View();
        }
    }
}