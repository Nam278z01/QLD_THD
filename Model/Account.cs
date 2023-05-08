using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public int? UserId { get; set; }
        public string AccountName { get; set; }
        public string TrangThai { get; set; }
        public string LoaiQuyen { get; set; }
        public string MatKhau { get; set; }

        public virtual User User { get; set; }
    }
}
