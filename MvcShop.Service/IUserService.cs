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
        #region 用户基本信息操作
        UserAccount GetUserByUserId(int userId);

        UserAccount GetUserByUserName(string userName);

        void InsertUser(UserAccount user);

        void UpdateUser(UserAccount user);

        void DeleteUser(UserAccount user);
        #endregion

        #region 用户地址信息
        void InserAddress(Address address);
        void DeleteAddressById(Address address);
        void UpdateAddress(Address address);
        List<Address> GetAddressListByUserId(int? userId);
        Address GetDefaultAddressByUserId(int userId);
        #endregion
    }
}
