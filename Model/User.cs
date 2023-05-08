using System;
using System.Collections.Generic;

#nullable disable

namespace DataModel
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string GioiTinh { get; set; }
        public string AnhDaiDien { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
