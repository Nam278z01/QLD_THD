using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class LoaiDiemRepository : ILoaiDiemRepository
    {
        private QLD_THDContext _context;
        public LoaiDiemRepository(QLD_THDContext context)
        {
            _context = context;
        }

        //public List<LoaiDiem> GetLoaiDiems()
        //{
        //    return _context.LoaiDiems.ToList();
        //}
        public List<LoaiDiem> Search(int page, int pageSize, string maloaidiem, string tenloaidiem, out long total)
        {
            total = 0;
            if (pageSize == 0)
            {
                return _context.LoaiDiems
                    .AsNoTracking()
                    .Where(m => m.MaLoaiDiem.Contains(maloaidiem) && m.TenLoaiDiem.Contains(tenloaidiem))
                    .ToList();
            }
            else
            {
                total = _context.LoaiDiems
                    .AsNoTracking()
                    .Where(m => m.MaLoaiDiem.Contains(maloaidiem) && m.TenLoaiDiem.Contains(tenloaidiem))
                    .Count();
                return _context.LoaiDiems
                    .AsNoTracking()
                    .Where(m => m.MaLoaiDiem.Contains(maloaidiem) && m.TenLoaiDiem.Contains(tenloaidiem))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public LoaiDiem GetById(string id)
        {
            return _context.LoaiDiems
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaLoaiDiem == id);
        }
        public bool Create(LoaiDiem model)
        {
            // model.Ctdiems = null;
            _context.LoaiDiems.Add(model);
            _context.SaveChanges();
            return true;
        }
        public bool Update(LoaiDiem model)
        {
            LoaiDiem newModel = _context.LoaiDiems
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaLoaiDiem == model.MaLoaiDiem);
            newModel.TenLoaiDiem = model.TenLoaiDiem;
            //newModel.SoTiet = model.SoTiet;
            //model.Ctdiems = null;
            _context.LoaiDiems.Update(newModel);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(List<string> ids)
        {
            List<LoaiDiem> deleteList = _context.LoaiDiems.Where(m => ids.Contains(m.MaLoaiDiem)).ToList();
            _context.LoaiDiems.RemoveRange(deleteList);
            _context.SaveChanges();
            return true;
        }
    }
}
