using BusinesslogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QLD_THD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoiController : ControllerBase
    {
        IKhoiBusiness _bus;
        public KhoiController(IKhoiBusiness bus) 
        {
            _bus = bus;
        }
        //[Route("get-all")]
        //[HttpPost]
        //public List<Khoi> GetKhoiHocs()
        //{
        //    return _bus.GetKhoiHocs();
        //}
    }
}
