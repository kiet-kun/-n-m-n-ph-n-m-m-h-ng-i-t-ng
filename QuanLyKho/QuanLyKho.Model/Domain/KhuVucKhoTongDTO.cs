using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Model.Domain
{
    public class KhuVucKhoTongDTO : BaseDTO
    {
        public string ten { get; set; }

        public int? KhoTongId { get; set; }
        public string tenkhotong { get; set; }
    }
}
