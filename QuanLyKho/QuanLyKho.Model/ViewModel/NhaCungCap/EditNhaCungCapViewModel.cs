using QuanLyKho.Model.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyKho.Model.ViewModel.NhaCungCap
{
    public class EditNhaCungCapViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập")]
        [MaxLength(50)]
        public string TenNhaCungCap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập")]
        [MaxLength(50)]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập")]
        [MaxLength(10)]
        public string SoDienThoai { get; set; }

        [MaxLength(50)]
        [Display]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(30)]
        public string NguoiDaiDien { get; set; }
    }
}
