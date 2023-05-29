using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DiemRepository : IDiemRepository
    {
        private QLD_THDContext _context;
        public DiemRepository(QLD_THDContext context)
        {
            _context = context;
        }

        //public List<Diem> GetDiems()
        //{
        //    return _context.Diems.ToList();
        //}
        public List<Diem> Search(int page, int pageSize, string mabangdiem, string malop,string mahocsinh ,out long total)
        {
            total = 0;
            if (pageSize == 0)
            {
                return _context.Diems
                    .AsNoTracking()
                    .Where(m => m.MaBangDiem.Contains(mabangdiem) )
                    .ToList();
            }
            else
            {
                total = _context.Diems
                    .AsNoTracking()
                    .Where(m => m.MaHocSinh.Contains(mahocsinh))
                    .Count();
                return _context.Diems
                    .AsNoTracking()
                    .Where(m => m.MaLop.Contains(malop))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public Diem GetById(string id)
        {
            return _context.Diems
                   .AsNoTracking()
                   .FirstOrDefault(m => m.MaBangDiem == id);
        }
        public bool Create(Diem model)
        {
            model.Ctdiems = null;
            _context.Diems.Add(model);
            _context.SaveChanges();
            return true;
        }
        //public bool Update(Diem model)
        //{
        //    Diem newModel = _context.Diems
        //           .AsNoTracking()
        //           .FirstOrDefault(m => m.MaBangDiem == model.MaDiem);
        //    newModel.TenDiem = model.TenDiem;
        //    newModel.SoTiet = model.SoTiet;
        //    model.Ctdiems = null;
        //    _context.Diems.Update(newModel);
        //    _context.SaveChanges();
        //    return true;
        //}
        //public bool Delete(List<string> ids)
        //{
        //    List<Diem> deleteList = _context.Diems.Where(m => ids.Contains(m.MaDiem)).ToList();
        //    _context.Diems.RemoveRange(deleteList);
        //    _context.SaveChanges();
        //    return true;
        //}
    }
}
