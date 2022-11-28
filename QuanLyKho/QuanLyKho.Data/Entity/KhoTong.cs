using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Data.Entity
{
    public class KhoTong : BaseEntity
    {
        public string ten { get; set; }

        public string khotongcode { get; set; }
        public string diachi { get; set; }
    }
}
