using BusinesslogicLayer;
using DataModel;
using DataModel.ResponseMessage;
using Microsoft.AspNetCore.Hosting;
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
    public class LoaiDiemController : ControllerBase
    {
       
        //[Route("get-all")]
        //[HttpPost]
        //public List<LoaiDiem> GetLoaiDiems()
        //{
        //    return _bus.GetLoaiDiems();
        //}
        IWebHostEnvironment _env;
        ILoaiDiemBusiness _bus;
        public LoaiDiemController(ILoaiDiemBusiness bus, IWebHostEnvironment env)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _bus = bus;
        }
        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<LoaiDiem>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<LoaiDiem>>();
            try
            {
                long total = 0;
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var maloaidiem = formData.Keys.Contains("maloaidiem") ? Convert.ToString(formData["maloaidiem"]) : "";
                var tenloaidiem = formData.Keys.Contains("tenmloaidiem") ? Convert.ToString(formData["tenloaidiem"]) : "";

                var data = await Task.FromResult(_bus.Search(page, pageSize, maloaidiem, tenloaidiem, out total));
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
        public async Task<ResponseMessage<LoaiDiem>> GetById(string id)
        {
            var response = new ResponseMessage<LoaiDiem>();
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
        public async Task<ResponseMessage<LoaiDiem>> Create([FromBody] LoaiDiem model)
        {
            var response = new ResponseMessage<LoaiDiem>();
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
        public async Task<ResponseMessage<LoaiDiem>> UpdateWebsiteTag([FromBody] LoaiDiem model)
        {
            var response = new ResponseMessage<LoaiDiem>();
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
