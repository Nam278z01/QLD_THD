using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class LoaiDiemBusiness : ILoaiDiemBusiness
    {
        ILoaiDiemRepository _res;
        public LoaiDiemBusiness(ILoaiDiemRepository res) 
        {
            _res = res;
        }

        //public List<LoaiDiem> GetLoaiDiems()
        //{
        //    return _res.GetLoaiDiems();
        //}
        public List<LoaiDiem> Search(int page, int pageSize, string maloaidiem, string tenloaidiem, out long total)
        {
            return _res.Search(page, pageSize, maloaidiem, tenloaidiem, out total);
        }
        public LoaiDiem GetById(string id)
        {
            return _res.GetById(id);
        }
        public bool Create(LoaiDiem model)
        {
            return _res.Create(model);
        }
        public bool Update(LoaiDiem model)
        {
            return _res.Update(model);
        }
        public bool Delete(List<string> ids)
        {
            return _res.Delete(ids);
        }
    }
}
