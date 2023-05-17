using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class LoaiDiemRepository : ILoaiDiemRepository
    {
        private QLD_THDContext _context;
        public LoaiDiemRepository(QLD_THDContext context)
        {
            _context = context;
        }

        public List<LoaiDiem> GetLoaiDiems()
        {
            return _context.LoaiDiems.ToList();
        }
    }
}
