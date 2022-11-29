using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyKho.Model.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace QuanLyKho.Model.ViewModel.KhuVucKhoTong
{
    public class CreateKhuVucKhoTongViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Tên khu vực kho tổng")]
        public string ten { get; set; }

        [Required]
        [Display(Name = "Kho tổng")]
        public int KhoTongId { get; set; }
        public IEnumerable<SelectListItem> KhoTongList { get; set; }
    }
}
