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
        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<GiaoVien>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<GiaoVien>>();
            try
            {
                long total = 0;
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var magv = formData.Keys.Contains("magv") ? Convert.ToString(formData["magv"]) : "";
                var tengv = formData.Keys.Contains("tengv") ? Convert.ToString(formData["tengv"]) : "";

                var data = await Task.FromResult(_bus.Search(page, pageSize, magv, tengv, out total));
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
        public async Task<ResponseMessage<GiaoVien>> GetById(string id)
        {
            var response = new ResponseMessage<GiaoVien>();
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
        public async Task<ResponseMessage<GiaoVien>> Create([FromBody] GiaoVien model)
        {
            var response = new ResponseMessage<GiaoVien>();
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
        public async Task<ResponseMessage<GiaoVien>> UpdateWebsiteTag([FromBody] GiaoVien model)
        {
            var response = new ResponseMessage<GiaoVien>();
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
