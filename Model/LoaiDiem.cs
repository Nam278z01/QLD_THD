using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class LoaiDiem
    {
        public LoaiDiem()
        {
            Ctdiems = new HashSet<Ctdiem>();
        }

        public string MaLoaiDiem { get; set; }
        public string TenLoaiDiem { get; set; }
        public int HeSo { get; set; }

        public virtual ICollection<Ctdiem> Ctdiems { get; set; }
    }
}
