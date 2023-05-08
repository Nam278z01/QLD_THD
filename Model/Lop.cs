using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class Lop
    {
        public Lop()
        {
            Diems = new HashSet<Diem>();
            HocSinhs = new HashSet<HocSinh>();
        }

        public string MaLop { get; set; }
        public string MaGvcn { get; set; }
        public string MaKhoi { get; set; }
        public string TenLop { get; set; }
        public int SiSo { get; set; }

        public virtual GiaoVien MaGvcnNavigation { get; set; }
        public virtual Khoi MaKhoiNavigation { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
        public virtual ICollection<HocSinh> HocSinhs { get; set; }
    }
}
