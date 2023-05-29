using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class HocSinhRepository : IHocSinhRepository
    {
        private QLD_THDContext _context;
        public HocSinhRepository(QLD_THDContext context)
        {
            _context = context;
        }

        //public List<HocSinh> GetHocSinhs()
        //{
        //    return _context.HocSinhs.ToList();
        //}
        public List<HocSinh> Search(int page, int pageSize, string mamh, string tenmh, out long total)
        {
            total = 0;
            if (pageSize == 0)
            {
                return _context.HocSinhs
                    .AsNoTracking()
                    .Where(m => m.MaHocSinh.Contains(mamh) && m.HoTen.Contains(tenmh))
                    .ToList();
            }
            else
            {
                total = _context.HocSinhs
                    .AsNoTracking()
                    .Where(m => m.MaHocSinh.Contains(mamh) && m.HoTen.Contains(tenmh))
                    .Count();
                return _context.HocSinhs
                    .AsNoTracking()
                    .Where(m => m.MaHocSinh.Contains(mamh) && m.HoTen.Contains(tenmh))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public HocSinh GetById(string id)
        {
            return _context.HocSinhs
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaHocSinh == id);
        }
        public bool Create(HocSinh model)
        {
            //model.Ctdiems = null;
            _context.HocSinhs.Add(model);
            _context.SaveChanges();
            return true;
        }
        public bool Update(HocSinh model)
        {
            HocSinh newModel = _context.HocSinhs
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaHocSinh == model.MaHocSinh);
            newModel.HoTen = model.HoTen;
            newModel.NgaySinh = model.NgaySinh;
            newModel.GioiTinh = model.GioiTinh;
            newModel.QueQuan = model.QueQuan;
            newModel.SoDienThoai = model.SoDienThoai;
            newModel.SoCmnd = model.SoCmnd;
            //newModel.SoTiet = model.SoTiet;
            //model.Ctdiems = null;
            _context.HocSinhs.Update(newModel);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(List<string> ids)
        {
            List<HocSinh> deleteList = _context.HocSinhs.Where(m => ids.Contains(m.MaHocSinh)).ToList();
            _context.HocSinhs.RemoveRange(deleteList);
            _context.SaveChanges();
            return true;
        }
    }
}
