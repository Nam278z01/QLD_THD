using BusinesslogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QLD_THD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountBusiness _bus;
        public AccountController(IAccountBusiness bus) 
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public List<Account> GetAccounts()
        {
            return _bus.GetAccounts();
        }
    }
}
