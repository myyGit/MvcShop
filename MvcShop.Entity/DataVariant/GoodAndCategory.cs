using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Entity
{
    public class GoodAndCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Good> GoodList { get; set; }
    }
}
