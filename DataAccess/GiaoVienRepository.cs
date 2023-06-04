using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class GiaoVienRepository : IGiaoVienRepository
    {
        private QLD_THDContext _context;
        public GiaoVienRepository(QLD_THDContext context)
        {
            _context = context;
        }

        //public List<GiaoVien> GetGiaoViens()
        //{
        //    return _context.GiaoViens.ToList();
        //}
        public List<GiaoVien> Search(int page, int pageSize, string magv, string tengv, out long total)
        {
            total = 0;
            if (pageSize == 0)
            {
                return _context.GiaoViens
                    .AsNoTracking()
                    .Where(m => m.MaGiaoVien.Contains(magv) && m.HoTen.Contains(tengv))
                    .ToList();
            }
            else
            {
                total = _context.GiaoViens
                    .AsNoTracking()
                    .Where(m => m.MaGiaoVien.Contains(magv) && m.HoTen.Contains(tengv))
                    .Count();
                return _context.GiaoViens
                    .AsNoTracking()
                    .Where(m => m.MaGiaoVien.Contains(magv) && m.HoTen.Contains(tengv))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public GiaoVien GetById(string id)
        {
            return _context.GiaoViens
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaGiaoVien == id);
        }
        public bool Create(GiaoVien model)
        {
           
            _context.GiaoViens.Add(model);
            _context.SaveChanges();
            return true;
        }
        public bool Update(GiaoVien model)
        {
            GiaoVien newModel = _context.GiaoViens
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaGiaoVien == model.MaGiaoVien);
            newModel.HoTen = model.HoTen;
            newModel.NgaySinh = model.NgaySinh;
            newModel.QueQuan = model.QueQuan;
            newModel.SoDienThoai = model.SoDienThoai;
            newModel.GioiTinh = model.GioiTinh;
            newModel.SoCmnd = model.SoCmnd;
            _context.GiaoViens.Update(newModel);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(List<string> ids)
        {
            List<GiaoVien> deleteList = _context.GiaoViens.Where(m => ids.Contains(m.MaGiaoVien)).ToList();
            _context.GiaoViens.RemoveRange(deleteList);
            _context.SaveChanges();
            return true;
        }
    }
}
