using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class DiemBusiness : IDiemBusiness
    {
        IDiemRepository _res;
        public DiemBusiness(IDiemRepository res) 
        {
            _res = res;
        }

        //public List<Diem> GetDiems()
        //{
        //    return _res.GetDiems();
        //}

    }
}
