using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class GiaoVien
    {
        public GiaoVien()
        {
            Diems = new HashSet<Diem>();
            Lops = new HashSet<Lop>();
        }

        public string MaGiaoVien { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCmnd { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
        public virtual ICollection<Lop> Lops { get; set; }
    }
}
