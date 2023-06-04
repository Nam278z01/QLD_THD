using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class HocSinhBusiness : IHocSinhBusiness
    {
        IHocSinhRepository _res;
        public HocSinhBusiness(IHocSinhRepository res) 
        {
            _res = res;
        }

        //public List<HocSinh> GetHocSinhs()
        //{
        //    return _res.GetHocSinhs();
        //}
        public List<HocSinh> Search(int page, int pageSize, string mamh, string tenmh, out long total)
        {
            return _res.Search(page, pageSize, mamh, tenmh, out total);
        }
        public HocSinh GetById(string id)
        {
            return _res.GetById(id);
        }
        public bool Create(HocSinh model)
        {
            return _res.Create(model);
        }
        public bool Update(HocSinh model)
        {
            return _res.Update(model);
        }
        public bool Delete(List<string> ids)
        {
            return _res.Delete(ids);
        }
    }
}
