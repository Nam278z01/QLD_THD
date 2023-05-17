using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class GiaoVienRepository : IGiaoVienRepository
    {
        private QLD_THDContext _context;
        public GiaoVienRepository(QLD_THDContext context)
        {
            _context = context;
        }

        public List<GiaoVien> GetGiaoViens()
        {
            return _context.GiaoViens.ToList();
        }
    }
}
