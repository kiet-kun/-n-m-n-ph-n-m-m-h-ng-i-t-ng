using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Data.Entity
{
    public class NhaCungCap  : BaseEntity
    {
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string Email { get; set; }

        public string NguoiDaiDien { get; set; }
    }
}
