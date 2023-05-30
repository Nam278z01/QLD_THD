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

    }
}
