using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcShop.utils
{
    public class UserManager
    {
      //  private static Logger logger = Logger.CreateLogger(typeof(UserManager));
         
    }
    public enum LoginResult
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        [Description("登录成功")]
        Success = 0,
        /// <summary>
        /// 用户不存在
        /// </summary>
        [Description("用户不存在")]
        NoUser = 1,
        /// <summary>
        /// 密码错误
        /// </summary>
        [Description("密码错误")]
        WrongPwd = 2,
        /// <summary>
        /// 验证码错误
        /// </summary>
        [Description("验证码错误")]
        WrongVerify = 3,
        /// <summary>
        /// 账号被冻结
        /// </summary>
        [Description("账号被冻结")]
        Frozen = 4
    }

}