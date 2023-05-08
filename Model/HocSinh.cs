using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class HocSinh
    {
        public HocSinh()
        {
            Diems = new HashSet<Diem>();
        }

        public string MaHocSinh { get; set; }
        public string MaLop { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCmnd { get; set; }

        public virtual Lop MaLopNavigation { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
    }
}
