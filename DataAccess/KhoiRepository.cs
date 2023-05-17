using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class KhoiRepository : IKhoiRepository
    {
        private QLD_THDContext _context;
        public KhoiRepository(QLD_THDContext context)
        {
            _context = context;
        }

        public List<Khoi> GetKhoiHocs()
        {
            return _context.Khois.ToList();
        }
    }
}
