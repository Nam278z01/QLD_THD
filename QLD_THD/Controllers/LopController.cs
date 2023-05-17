using BusinesslogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QLD_THD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopController : ControllerBase
    {
        ILopBusiness _bus;
        public LopController(ILopBusiness bus) 
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public List<Lop> GetLopHocs()
        {
            return _bus.GetLopHocs();
        }
    }
}
