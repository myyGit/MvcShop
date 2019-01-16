using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Data
{
    public enum EnumOrderStatus
    {
        [Description("待支付")]
        WaitPay = 0,
        [Description("待发货")]
        WaitDelivery = 1,
        [Description("待收货")]
        WaitReceived = 2,
        [Description("已收货")]
        Already = 3

    }
}
