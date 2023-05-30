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

        public List<GiaoVien> GetGiaoViens()
        {
            return _res.GetGiaoViens();
        }

    }
}
