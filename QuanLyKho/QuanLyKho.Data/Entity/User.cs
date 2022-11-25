using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Data.Entity
{
    public class User : BaseEntity
    { 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string cmnd { get; set; }

        public string sdt { get; set; }
        public DateTime? ngaysinh { get; set; }
    }
}
