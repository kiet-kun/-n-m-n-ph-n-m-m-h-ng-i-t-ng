using QuanLyKho.Model.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyKho.Model.ViewModel.NhaCungCap
{
    public class ListNhaCungCapViewModel : BaseViewModel
    {
  
        public string TenNhaCungCap { get; set; }

     
        public string DiaChi { get; set; }


        public string SoDienThoai { get; set; }


        public string Email { get; set; }

  
        public string NguoiDaiDien { get; set; }
    }
}
