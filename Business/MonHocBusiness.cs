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

        public List<MonHoc> GetMonHocs()
        {
            return _res.GetMonHocs();
        }

    }
}
