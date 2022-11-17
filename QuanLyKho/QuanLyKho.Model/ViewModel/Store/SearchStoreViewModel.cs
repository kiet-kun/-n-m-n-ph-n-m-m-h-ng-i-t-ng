using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QuanLyKho.Model.ViewModel.Base;

namespace QuanLyKho.Model.ViewModel.Store
{
    public class SearchStoreViewModel : BaseViewModel
    {

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }


        [Display(Name = "Store Code")]
        public string StoreCode { get; set; }
    }
}
