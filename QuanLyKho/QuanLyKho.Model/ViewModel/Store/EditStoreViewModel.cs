using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QuanLyKho.Model.ViewModel.Base;

namespace QuanLyKho.Model.ViewModel.Store
{
  public  class EditStoreViewModel:BaseViewModel
    {
        [Required]
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Store Code")]
        public string StoreCode { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string diachi { get; set; }
    }
}
