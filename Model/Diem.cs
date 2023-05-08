using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class Diem
    {
        public Diem()
        {
            Ctdiems = new HashSet<Ctdiem>();
        }

        public string MaBangDiem { get; set; }
        public string MaLop { get; set; }
        public string MaHocSinh { get; set; }
        public int KiHoc { get; set; }
        public string NamHoc { get; set; }
        public double DiemTb { get; set; }
        public string HanhKiem { get; set; }
        public string HocLuc { get; set; }
        public string DanhHieu { get; set; }
        public string MaGvcn { get; set; }

        public virtual GiaoVien MaGvcnNavigation { get; set; }
        public virtual HocSinh MaHocSinhNavigation { get; set; }
        public virtual Lop MaLopNavigation { get; set; }
        public virtual ICollection<Ctdiem> Ctdiems { get; set; }
    }
}
