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
        private readonly IRepository<Address> _addressReposity;

        public UserService(IRepository<UserAccount> userAccount, IRepository<Address> addressReposity)
        {
            this._userAccount = userAccount;
            this._addressReposity = addressReposity;
        }

        public void DeleteAddressById(Address address)
        {
            address.IsActive = false;
            address.LastChangeTime = DateTime.Now;
            _addressReposity.Update(address);
        }

        public void DeleteUser(UserAccount user)
        {
            if (user != null)
            {
                _userAccount.Delete(user);
            }
        }

        public List<Address> GetAddressListByUserId(int? userId)
        {
            var list = _addressReposity.Table.Where(p => p.IsActive);
            if (userId != null && userId > 0)
            {
                list = list.Where(p => p.UserId == userId);
            }
            return list.OrderByDescending(p => p.CreateTime).ToList();
        }

        public Address GetDefaultAddressByUserId(int userId)
        {
            return _addressReposity.Table.Where(p => p.IsActive && p.UserId == userId && p.IsDefault).FirstOrDefault();
        }

        public UserAccount GetUserByUserId(int userId)
        {
            return _userAccount.Table.Where(p => p.UserId == userId && p.IsActive).FirstOrDefault();
        }

        public UserAccount GetUserByUserName(string userName)
        {
            return _userAccount.Table.Where(p => p.UserName == userName && p.IsActive).FirstOrDefault();
        }

        public void InserAddress(Address address)
        {
            address.CreateTime = DateTime.Now;
            address.LastChangeTime = DateTime.Now;
            address.IsActive = true;
            _addressReposity.Insert(address);
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

        public void UpdateAddress(Address address)
        {
            address.LastChangeTime = DateTime.Now;
            _addressReposity.Update(address);
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
