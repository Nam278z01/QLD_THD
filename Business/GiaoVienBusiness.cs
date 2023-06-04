using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class GiaoVienBusiness : IGiaoVienBusiness
    {
        IGiaoVienRepository _res;
        public GiaoVienBusiness(IGiaoVienRepository res) 
        {
            _res = res;
        }

        //public List<GiaoVien> GetGiaoViens()
        //{
        //    return _res.GetGiaoViens();
        //}
        public List<GiaoVien> Search(int page, int pageSize, string magv, string tengv, out long total)
        {
            return _res.Search(page, pageSize, magv, tengv, out total);
        }
        public GiaoVien GetById(string id)
        {
            return _res.GetById(id);
        }
        public bool Create(GiaoVien model)
        {
            return _res.Create(model);
        }
        public bool Update(GiaoVien model)
        {
            return _res.Update(model);
        }
        public bool Delete(List<string> ids)
        {
            return _res.Delete(ids);
        }
    }
}
