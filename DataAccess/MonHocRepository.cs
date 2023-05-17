using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.EntityFrameworkCore;

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
        public List<MonHoc> Search(int page, int pageSize, string mamh, string tenmh, out long total)
        {
            total = 0;
            if (pageSize == 0)
            {
                return _context.MonHocs
                    .AsNoTracking()
                    .Where(m => m.MaMonHoc.Contains(mamh) && m.TenMonHoc.Contains(tenmh))
                    .ToList();
            }
            else
            {
                total = _context.MonHocs
                    .AsNoTracking()
                    .Where(m => m.MaMonHoc.Contains(mamh) && m.TenMonHoc.Contains(tenmh))
                    .Count();
                return _context.MonHocs
                    .AsNoTracking()
                    .Where(m => m.MaMonHoc.Contains(mamh) && m.TenMonHoc.Contains(tenmh))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public MonHoc GetById(string id)
        {
            return _context.MonHocs
                .AsNoTracking()
                .FirstOrDefault(m => m.MaMonHoc == id);
        }
        public bool Create(MonHoc model)
        {
            model.Ctdiems = null;
            _context.MonHocs.Add(model);
            _context.SaveChanges();
            return true;
        }
        public bool Update(MonHoc model)
        {
            MonHoc newModel = _context.MonHocs
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaMonHoc == model.MaMonHoc);
            newModel.TenMonHoc = model.TenMonHoc;
            newModel.SoTiet = model.SoTiet;
            model.Ctdiems = null;
            _context.MonHocs.Update(newModel);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(List<string> ids)
        {
            List<MonHoc> deleteList = _context.MonHocs.Where(m => ids.Contains(m.MaMonHoc)).ToList();
            _context.MonHocs.RemoveRange(deleteList);
            _context.SaveChanges();
            return true;
        }
    }
}
