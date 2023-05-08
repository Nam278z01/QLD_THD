using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class MonHocRepository : IMonHocRepository
    {
        private QLD_THDContext _context;
        public MonHocRepository(QLD_THDContext context)
        {
            _context = context;
        }

        public List<MonHoc> GetMonHocs()
        {
            return _context.MonHocs.ToList();
        }
    }
}
