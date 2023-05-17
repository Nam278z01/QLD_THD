using BusinesslogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QLD_THD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiDiemController : ControllerBase
    {
        ILoaiDiemBusiness _bus;
        public LoaiDiemController(ILoaiDiemBusiness bus) 
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public List<LoaiDiem> GetLoaiDiems()
        {
            return _bus.GetLoaiDiems();
        }
    }
}
