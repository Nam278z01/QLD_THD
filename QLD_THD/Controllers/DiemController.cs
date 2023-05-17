using BusinesslogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QLD_THD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemController : ControllerBase
    {
        IDiemBusiness _bus;
        public DiemController(IDiemBusiness bus) 
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public List<Diem> GetDiems()
        {
            return _bus.GetDiems();
        }
    }
}
