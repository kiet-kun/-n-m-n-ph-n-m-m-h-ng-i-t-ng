using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Model.Domain
{
    public class NhaCungCapDTO : BaseDTO
    {
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string Email { get; set; }

        public string NguoiDaiDien { get; set; }
    }
}
