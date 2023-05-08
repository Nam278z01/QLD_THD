using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class Khoi
    {
        public Khoi()
        {
            Lops = new HashSet<Lop>();
        }

        public string MaKhoi { get; set; }
        public string TenKhoi { get; set; }

        public virtual ICollection<Lop> Lops { get; set; }
    }
}
