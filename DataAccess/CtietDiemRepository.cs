using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class CtietDiemRepository : ICtietDiemRepository
    {
        private QLD_THDContext _context;
        public CtietDiemRepository(QLD_THDContext context)
        {
            _context = context;
        }

        public List<Ctdiem> GetCtietDiems()
        {
            return _context.Ctdiems.ToList();
        }
    }
}
