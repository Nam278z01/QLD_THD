using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class UserBusiness : IUserBusiness
    {
        IUserRepository _res;
        public UserBusiness(IUserRepository res) 
        {
            _res = res;
        }

        public List<User> GetUsers()
        {
            return _res.GetUsers();
        }

    }
}
