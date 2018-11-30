using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcShop
{
    public class CurrentUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        public DateTime LoginTime { get; set; }
    }
}