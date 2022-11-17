using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QuanLyKho.Model.ViewModel.Base;

namespace QuanLyKho.Model.ViewModel.Category
{
    public class SearchCategoryViewModel: BaseViewModel
    {

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

    }
}
