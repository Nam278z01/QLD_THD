using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class LopRepository : ILopRepository
    {
        private QLD_THDContext _context;
        public LopRepository(QLD_THDContext context)
        {
            _context = context;
        }

        public List<Lop> GetLopHocs()
        {
            return _context.Lops.ToList();
        }
    }
}
