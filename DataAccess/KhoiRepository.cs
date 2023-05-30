using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class KhoiRepository : IKhoiRepository
    {
        private QLD_THDContext _context;
        public KhoiRepository(QLD_THDContext context)
        {
            _context = context;
        }

        //public List<Khoi> GetKhoiHocs()
        //{
        //    return _context.Khois.ToList();
        //}
        public List<Khoi> Search(int page, int pageSize, string makh, string tenkh, out long total)
        {
            total = 0;
            if (pageSize == 0)
            {
                return _context.Khois
                    .AsNoTracking()
                    .Where(m => m.MaKhoi.Contains(makh) && m.TenKhoi.Contains(tenkh))
                    .ToList();
            }
            else
            {
                total = _context.Khois
                    .AsNoTracking()
                    .Where(m => m.MaKhoi.Contains(makh) && m.TenKhoi.Contains(tenkh))
                    .Count();
                return _context.Khois
                    .AsNoTracking()
                    .Where(m => m.MaKhoi.Contains(makh) && m.TenKhoi.Contains(tenkh))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public Khoi GetById(string id)
        {
            return _context.Khois
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaKhoi == id);
        }
        public bool Create(Khoi model)
        {
           // model.Ctdiems = null;
            _context.Khois.Add(model);
            _context.SaveChanges();
            return true;
        }
        public bool Update(Khoi model)
        {
            Khoi newModel = _context.Khois
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaKhoi == model.MaKhoi);
            newModel.TenKhoi = model.TenKhoi;
            //newModel.SoTiet = model.SoTiet;
            //model.Ctdiems = null;
            _context.Khois.Update(newModel);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(List<string> ids)
        {
            List<Khoi> deleteList = _context.Khois.Where(m => ids.Contains(m.MaKhoi)).ToList();
            _context.Khois.RemoveRange(deleteList);
            _context.SaveChanges();
            return true;
        }
    }
}
