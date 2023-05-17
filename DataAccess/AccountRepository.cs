using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class AccountRepository : IAccountRepository
    {
        private QLD_THDContext _context;
        public AccountRepository(QLD_THDContext context)
        {
            _context = context;
        }

        public List<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }
    }
}
