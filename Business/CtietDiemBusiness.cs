using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class CtietDiemBusiness : ICtietDiemBusiness
    {
        ICtietDiemRepository _res;
        public CtietDiemBusiness(ICtietDiemRepository res) 
        {
            _res = res;
        }

        public List<Ctdiem> GetCtietDiems()
        {
            return _res.GetCtietDiems();
        }

    }
}
