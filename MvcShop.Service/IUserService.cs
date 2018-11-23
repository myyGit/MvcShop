using MvcShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcShop.Service
{
    public interface IUserService
    {

        UserAccount GetUserByUserId(int userId);

        UserAccount GetUserByUserName(string userName);

        void InsertUser(UserAccount user);

        void UpdateUser(UserAccount user);

        void DeleteUser(UserAccount user);
    }
}
