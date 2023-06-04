using BusinesslogicLayer;
using DataModel;
using DataModel.ResponseMessage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using QLD_THD.Helper;
using QLD_THD.CustomImport;
using System.Data;

namespace QLD_THD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        IWebHostEnvironment _env;
        IMonHocBusiness _bus;
        public MonHocController(IMonHocBusiness bus, IWebHostEnvironment env) 
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _bus = bus;
        }
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
        public async Task<ResponseMessage<MonHoc>> UpdateWebsiteTag([FromBody] MonHoc model)
        {
            var response = new ResponseMessage<MonHoc>();
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

        [Route("upload")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0 && file.FileName.Contains(".xlsx"))
                {
                    var filename = Guid.NewGuid().ToString().Replace("-", "") + ".xlsx";
                    var webRoot = _env.ContentRootPath;
                    var filePath = Path.Combine(webRoot + "/Upload/", filename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    var messageError = "";
                    var data = ImportExcel.ReadFromExcelFileForMonHoc(filePath, 1, out messageError);
                    var list = ExcelHelper.ConvertDataTable<MonHoc>(data);
                    foreach (var model in list)
                        if (!string.IsNullOrEmpty(model.MaMonHoc))
                        {
                            await Task.FromResult(_bus.Create(model));
                        }
                    return Ok(new { MessageCodes.UpdateSuccessfully });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return Ok(new { MessageCodes.UpdateFail });
            }
        }

        [Route("export-to-excel")]
        [HttpPost]
        public async Task<IActionResult> ExportToExcel([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                long total = 0;
                var page = 1;
                var pageSize = 0;
                var mamh = formData.Keys.Contains("mamh") ? Convert.ToString(formData["mamh"]) : "";
                var tenmh = formData.Keys.Contains("tenmh") ? Convert.ToString(formData["tenmh"]) : "";

                var data = await Task.FromResult(_bus.Search(page, pageSize, mamh, tenmh, out total));

                DataTable dataExport = new DataTable();
                dataExport.Columns.Add("MaMonHoc");
                dataExport.Columns.Add("TenMonHoc");
                dataExport.Columns.Add("SoTiet");

                List<ExcelDataExtention> staticDataValue = new List<ExcelDataExtention>();
                staticDataValue.Add(new ExcelDataExtention
                {
                    IsEnd = true,
                    StartColumnName = "C",
                    EndColumnName = "D",
                    StartRowIndex = 1,
                    EndRowIndex = 1,
                    IsMerge = true,
                    AlignmentCenter = true,
                    FontItalic = true,
                    Value = "Hưng Yên, ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.ToString("MM") + " năm " + DateTime.Now.ToString("yyyy")
                });
                List<string> list_charge_types = new List<string>();
                int start_row = 2;
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        DataRow row = dataExport.NewRow();
                        row["MaMonHoc"] = item.MaMonHoc;
                        row["TenMonHoc"] = item.TenMonHoc;
                        row["SoTiet"] = item.SoTiet;
                        dataExport.Rows.Add(row);
                    }
                }
                else
                {
                    dataExport.Rows.Add();
                }

                var webRoot = _env.ContentRootPath;
                var tempPath = Path.Combine(webRoot + @"\ExcelTemplates\", "mon_hoc_temp.xlsx");
                var exportPath = Path.Combine(webRoot + @"\Export\Excel\", "mon_hoc_temp" + Guid.NewGuid().ToString() + ".xlsx");
                string result = ExcelHelper.ExportDataTableToExcel(exportPath, tempPath, dataExport, 1, start_row + 1, staticDataValue, true, "", "", false, "");
                if (string.IsNullOrEmpty(result))
                {
                    var stream = new FileStream(exportPath, FileMode.Open, FileAccess.Read);
                    return File(stream, "application/octet-stream");
                }
                else
                {
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
