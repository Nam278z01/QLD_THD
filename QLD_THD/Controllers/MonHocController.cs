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
    public class MonHocController : ControllerBase
    {
        IMonHocBusiness _bus;
        public MonHocController(IMonHocBusiness bus) 
        {
            _bus = bus;
        }
        //[Route("get-all")]
        //[HttpPost]
        //public List<MonHoc> GetMonHocs()
        //{
        //    return _bus.GetMonHocs();
        //}
        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<MonHoc>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<MonHoc>>();
            try
            {
                long total = 0;
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var mamh = formData.Keys.Contains("mamh") ? Convert.ToString(formData["mamh"]) : "";
                var tenmh = formData.Keys.Contains("tenmh") ? Convert.ToString(formData["tenmh"]) : "";

                var data = await Task.FromResult(_bus.Search(page, pageSize, mamh, tenmh, out total));
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
        public async Task<ResponseMessage<MonHoc>> GetById(string id)
        {
            var response = new ResponseMessage<MonHoc>();
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
        public async Task<ResponseMessage<MonHoc>> Create([FromBody] MonHoc model)
        {
            var response = new ResponseMessage<MonHoc>();
            try
            {
                var resultBUS = await Task.FromResult(_bus.Create(model));
                if (resultBUS)
                {
                    response.Data = model;
                    response.MessageCode = "CreateSuccessfully";
                }
                else
                {
                    response.MessageCode = "CreateFail";
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
        public async Task<ResponseMessage<MonHoc>> UpdateWebsiteTag([FromBody] MonHoc model)
        {
            var response = new ResponseMessage<MonHoc>();
            try
            {

                var resultBUS = await Task.FromResult(_bus.Update(model));
                if (resultBUS)
                {
                    response.Data = model;
                    response.MessageCode = "UpdateSuccessfully";
                }
                else
                {
                    response.MessageCode = "UpdateFail";
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
                    response.MessageCode = "DeleteSuccessfully";
                }
                else
                {
                    response.MessageCode = "DeleteFail";
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
