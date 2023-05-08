using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class Ctdiem
    {
        public string MaCtdiem { get; set; }
        public string MaBangDiem { get; set; }
        public string MaHocSinh { get; set; }
        public string MaMonHoc { get; set; }
        public string MaLoaiDiem { get; set; }
        public int Diem { get; set; }
        public int DiemTbmon { get; set; }
        public string MaGvcn { get; set; }

        public virtual Diem MaBangDiemNavigation { get; set; }
        public virtual LoaiDiem MaLoaiDiemNavigation { get; set; }
        public virtual MonHoc MaMonHocNavigation { get; set; }
    }
}
