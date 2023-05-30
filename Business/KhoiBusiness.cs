using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class KhoiBusiness : IKhoiBusiness
    {
        IKhoiRepository _res;
        public KhoiBusiness(IKhoiRepository res) 
        {
            _res = res;
        }

        //public List<Khoi> GetKhoiHocs()
        //{
        //    return _res.GetKhoiHocs();
        //}

    }
}
