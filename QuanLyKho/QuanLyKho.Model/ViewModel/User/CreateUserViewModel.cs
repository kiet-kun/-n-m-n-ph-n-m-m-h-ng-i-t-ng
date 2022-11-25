﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QuanLyKho.Model.ViewModel.Base;

namespace QuanLyKho.Model.ViewModel.User
{
    public class CreateUserViewModel: BaseViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
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

        [Required(ErrorMessage = "Vui lòng nhập chứng minh nhân dân")]
        [MaxLength(9)]
        [Display(Name = "Chứng minh nhân dân")]
        public string cmnd { get; set; }

        [Display(Name = "Số điện thoại")]
        public string sdt { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime ngaysinh { get; set; }
    }
}
