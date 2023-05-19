using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class MonHocBusiness : IMonHocBusiness
    {
        IMonHocRepository _res;
        public MonHocBusiness(IMonHocRepository res) 
        {
            _res = res;
        }

        public List<MonHoc> Search(int page, int pageSize, string mamh, string tenmh, out long total)
        {
            return _res.Search(page, pageSize, mamh, tenmh, out total);
        }
        public MonHoc GetById(string id)
        {
            return _res.GetById(id);
        }
        public bool Create(MonHoc model)
        {
            return _res.Create(model);
        }
        public bool Update(MonHoc model)
        {
            return _res.Update(model);
        }
        public bool Delete(List<string> ids)
        {
            return _res.Delete(ids);
        }
    }
}
