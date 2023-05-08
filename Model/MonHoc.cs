using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            Ctdiems = new HashSet<Ctdiem>();
        }

        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTiet { get; set; }

        public virtual ICollection<Ctdiem> Ctdiems { get; set; }
    }
}
