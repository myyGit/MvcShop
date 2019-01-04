using MvcShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Areas.AdminArea
{
    public class AddGoodModel : Good
    {
        public string GoodImageName { get; set; }
        public string GoodImageUrl { get; set; }
    }

}