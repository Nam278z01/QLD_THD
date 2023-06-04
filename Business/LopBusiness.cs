using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class LopBusiness : ILopBusiness
    {
        ILopRepository _res;
        public LopBusiness(ILopRepository res) 
        {
            _res = res;
        }

        //public List<Lop> GetLopHocs()
        //{
        //    return _res.GetLopHocs();
        //}
        public List<Lop> Search(int page, int pageSize, string malop, string tenlop, out long total)
        {
            return _res.Search(page, pageSize, malop, tenlop, out total);
        }
        public Lop GetById(string id)
        {
            return _res.GetById(id);
        }
        public bool Create(Lop model)
        {
            return _res.Create(model);
        }
        public bool Update(Lop model)
        {
            return _res.Update(model);
        }
        public bool Delete(List<string> ids)
        {
            return _res.Delete(ids);
        }

    }
}
