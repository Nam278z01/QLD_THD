using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class HocSinhRepository : IHocSinhRepository
    {
        private QLD_THDContext _context;
        public HocSinhRepository(QLD_THDContext context)
        {
            _context = context;
        }

        public List<HocSinh> GetHocSinhs()
        {
            return _context.HocSinhs.ToList();
        }
    }
}
