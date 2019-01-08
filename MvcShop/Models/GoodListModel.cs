using MvcShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop
{
    public class GoodListModel
    {
        public int GoodId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string GoodName { get; set; }
        public decimal GoodPrice { get; set; }
        public DateTime CreateTime { get; set; }
        public string GoodImageUrl { get; set; }
        public string GoodImageName { get; set; }
    }
}