using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop
{
    public class RegisterModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
    }
}