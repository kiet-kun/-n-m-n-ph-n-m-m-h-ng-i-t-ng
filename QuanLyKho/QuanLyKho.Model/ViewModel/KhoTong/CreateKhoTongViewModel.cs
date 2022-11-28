using QuanLyKho.Model.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace QuanLyKho.Model.ViewModel.KhoTong
{
    public class CreateKhoTongViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Tên kho tổng")]
        public string ten { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Mã kho tổng")]
        public string khotongcode { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string diachi { get; set; }
    }
}
