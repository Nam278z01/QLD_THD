using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class LopRepository : ILopRepository
    {
        private QLD_THDContext _context;
        public LopRepository(QLD_THDContext context)
        {
            _context = context;
        }

        //public List<Lop> GetLopHocs()
        //{
        //    return _context.Lops.ToList();
        //}
        public List<Lop> Search(int page, int pageSize, string malop, string tenlop, out long total)
        {
            total = 0;
            if (pageSize == 0)
            {
                return _context.Lops
                    .AsNoTracking()
                    .Where(m => m.MaLop.Contains(malop) && m.TenLop.Contains(tenlop))
                    .ToList();
            }
            else
            {
                total = _context.Lops
                    .AsNoTracking()
                    .Where(m => m.MaLop.Contains(malop) && m.TenLop.Contains(tenlop))
                    .Count();
                return _context.Lops
                    .AsNoTracking()
                    .Where(m => m.MaLop.Contains(malop) && m.TenLop.Contains(tenlop))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public Lop GetById(string id)
        {
            return _context.Lops
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaLop == id);
        }
        public bool Create(Lop model)
        {
           // model.Ctdiems = null;
            _context.Lops.Add(model);
            _context.SaveChanges();
            return true;
        }
        public bool Update(Lop model)
        {
            Lop newModel = _context.Lops
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaLop == model.MaLop);
            newModel.TenLop = model.TenLop;
            //newModel.SoTiet = model.SoTiet;
            //model.Ctdiems = null;
            _context.Lops.Update(newModel);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(List<string> ids)
        {
            List<Lop> deleteList = _context.Lops.Where(m => ids.Contains(m.MaLop)).ToList();
            _context.Lops.RemoveRange(deleteList);
            _context.SaveChanges();
            return true;
        }
    }
}
