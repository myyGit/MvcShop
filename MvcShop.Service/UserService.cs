using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcShop.Entity;

namespace MvcShop.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserAccount> _userAccount;

        public UserService(IRepository<UserAccount> userAccount)
        {
            this._userAccount = userAccount;
        }
        public void DeleteUser(UserAccount user)
        {
            if (user != null)
            {
                _userAccount.Delete(user);
            }
        }

        public UserAccount GetUserByUserId(int userId)
        {
            return _userAccount.Table.Where(p => p.UserId == userId && p.IsActive).FirstOrDefault();
        }

        public UserAccount GetUserByUserName(string userName)
        {
            return _userAccount.Table.Where(p => p.UserName == userName && p.IsActive).FirstOrDefault();
        }

        public void InsertUser(UserAccount user)
        {
            if (user != null)
            {
                user.CreateTime = DateTime.Now;
                user.LastChangeTime = DateTime.Now;
                user.IsActive = true;
                
                _userAccount.Insert(user);
            }
        }

        public void UpdateUser(UserAccount user)
        {
            if (user != null)
            {
                user.LastChangeTime = DateTime.Now;
                _userAccount.Update(user);
            }
        }
    }
}
