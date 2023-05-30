using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class AccountBusiness : IAccountBusiness
    {
        IAccountRepository _res;
        public AccountBusiness(IAccountRepository res) 
        {
            _res = res;
        }

        //public List<Account> GetAccounts()
        //{
        //    return _res.GetAccounts();
        //}

    }
}
