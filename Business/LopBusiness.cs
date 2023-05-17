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

        public List<Lop> GetLopHocs()
        {
            return _res.GetLopHocs();
        }

    }
}
