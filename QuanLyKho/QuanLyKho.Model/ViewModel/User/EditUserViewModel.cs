﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QuanLyKho.Model.ViewModel.Base;

namespace QuanLyKho.Model.ViewModel.User
{
    public class EditUserViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display]
        [EmailAddress]
        public string Email { get; set; }

   
        [MaxLength(18)]
        [Display]
        public string Password { get; set; }

        [Required]
        [MaxLength(30)]
        [Display]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [Display]
        public string Surname { get; set; }
    }
}
