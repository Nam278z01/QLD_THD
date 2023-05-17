using BusinesslogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QLD_THD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CtietDiemController : ControllerBase
    {
        ICtietDiemBusiness _bus;
        public CtietDiemController(ICtietDiemBusiness bus) 
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public List<Ctdiem> GetCtietDiems()
        {
            return _bus.GetCtietDiems();
        }
    }
}
