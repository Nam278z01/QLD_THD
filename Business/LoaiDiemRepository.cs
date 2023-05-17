using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class LoaiDiemBusiness : ILoaiDiemBusiness
    {
        ILoaiDiemRepository _res;
        public LoaiDiemBusiness(ILoaiDiemRepository res) 
        {
            _res = res;
        }

        public List<LoaiDiem> GetLoaiDiems()
        {
            return _res.GetLoaiDiems();
        }

    }
}
