using BusinesslogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QLD_THD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoVienController : ControllerBase
    {
        IGiaoVienBusiness _bus;
        public GiaoVienController(IGiaoVienBusiness bus) 
        {
            _bus = bus;
        }
        //[Route("get-all")]
        //[HttpPost]
        //public List<GiaoVien> GetGiaoViens()
        //{
        //    return _bus.GetGiaoViens();
        //}
    }
}
