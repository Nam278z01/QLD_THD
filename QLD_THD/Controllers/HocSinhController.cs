using BusinesslogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QLD_THD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocSinhController : ControllerBase
    {
        IHocSinhBusiness _bus;
        public HocSinhController(IHocSinhBusiness bus) 
        {
            _bus = bus;
        }
        //[Route("get-all")]
        //[HttpPost]
        //public List<HocSinh> GetHocSinhs()
        //{
        //    return _bus.GetHocSinhs();
        //}
    }
}
