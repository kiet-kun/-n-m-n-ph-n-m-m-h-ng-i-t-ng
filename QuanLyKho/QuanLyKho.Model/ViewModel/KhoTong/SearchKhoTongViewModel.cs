using QuanLyKho.Model.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace QuanLyKho.Model.ViewModel.KhoTong
{
    public class SearchKhoTongViewModel : BaseViewModel
    {
        [Display(Name = "Tên kho tổng")]
        public string ten { get; set; }


        [Display(Name = "Mã kho tổng")]
        public string khotongcode { get; set; }
    }
}
