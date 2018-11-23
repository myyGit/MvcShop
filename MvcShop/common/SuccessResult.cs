using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop
{
    public class SuccessResult
    {
        /// <summary>
        /// 返回状态 0：强制登录  1：请求成功 2：请求数据错误
        /// </summary>
        public int status { get; set; }
        public string data { get; set; }
        public string msg { get; set; }
    }
}