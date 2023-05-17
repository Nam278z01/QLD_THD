using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class DiemRepository : IDiemRepository
    {
        private QLD_THDContext _context;
        public DiemRepository(QLD_THDContext context)
        {
            _context = context;
        }

        public List<Diem> GetDiems()
        {
            return _context.Diems.ToList();
        }
    }
}
