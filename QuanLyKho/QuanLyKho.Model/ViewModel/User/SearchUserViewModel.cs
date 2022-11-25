using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QuanLyKho.Model.ViewModel.Base;

namespace QuanLyKho.Model.ViewModel.User
{
    public class SearchUserViewModel : BaseViewModel
    {

        [Display]
        public string Email { get; set; }

        [Display]
        public string Name { get; set; }

        [Display]
        public string Surname { get; set; }

        public string cmnd { get; set; }
    }
}
