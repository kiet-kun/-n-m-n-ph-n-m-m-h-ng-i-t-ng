using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Data.Entity
{
    public class KhuVucKhoTong : BaseEntity
    {
        public string ten { get; set; }
        public int? KhoTongId { get; set; }

        public virtual KhoTong KhoTong { get; set; }

    }
}
