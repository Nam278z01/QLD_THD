using BusinesslogicLayer;
using DataModel;
using DataModel.ResponseMessage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        //[Route("get-all")]
        //[HttpPost]
        //public List<Lop> GetLopHocs()
        //{
        //    return _bus.GetLopHocs();
        //}
        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<Lop>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<Lop>>();
            try
            {
                long total = 0;
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var malop = formData.Keys.Contains("malop") ? Convert.ToString(formData["malop"]) : "";
                var tenlop = formData.Keys.Contains("tenlop") ? Convert.ToString(formData["tenlop"]) : "";

                var data = await Task.FromResult(_bus.Search(page, pageSize, malop, tenlop, out total));
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;

            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public async Task<ResponseMessage<Lop>> GetById(string id)
        {
            var response = new ResponseMessage<Lop>();
            try
            {
                response.Data = await Task.FromResult(_bus.GetById(id));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }
        [Route("create")]
        [HttpPost]
        public async Task<ResponseMessage<Lop>> Create([FromBody] Lop model)
        {
            var response = new ResponseMessage<Lop>();
            try
            {
                var resultBUS = await Task.FromResult(_bus.Create(model));
                if (resultBUS)
                {
                    response.Data = model;
                    response.MessageCode = MessageCodes.CreateSuccessfully;
                }
                else
                {
                    response.MessageCode = MessageCodes.CreateFail;
                }

            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }
        [Route("update")]
        [HttpPost]
        public async Task<ResponseMessage<Lop>> UpdateWebsiteTag([FromBody] Lop model)
        {
            var response = new ResponseMessage<Lop>();
            try
            {

                var resultBUS = await Task.FromResult(_bus.Update(model));
                if (resultBUS)
                {
                    response.Data = model;
                    response.MessageCode = MessageCodes.UpdateSuccessfully;
                }
                else
                {
                    response.MessageCode = MessageCodes.UpdateFail;
                }
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }
        [Route("delete")]
        [HttpPost]
        public async Task<ResponseListMessage<bool>> DeleteWebsiteTag([FromBody] List<string> items)
        {
            var response = new ResponseListMessage<bool>();
            try
            {
                var resultBUS = await Task.FromResult(_bus.Delete(items));
                if (resultBUS)
                {
                    response.MessageCode = MessageCodes.DeleteSuccessfully;
                }
                else
                {
                    response.MessageCode = MessageCodes.DeleteFail;
                }
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }
    }
}
