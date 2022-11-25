using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Model.ViewModel.Base;

namespace QuanLyKho.Model.ViewModel.Store
{
    public class ListStoreViewModel : BaseViewModel
    {
        public string StoreName { get; set; }
        public string StoreCode { get; set; }

        public string diachi { get; set; }
    }
}
