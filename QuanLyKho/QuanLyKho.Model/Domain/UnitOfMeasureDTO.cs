﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Model.Domain
{
    public class UnitOfMeasureDTO : BaseDTO
    {
        public string UnitOfMeasureName { get; set; }
        public string Isocode { get; set; }
    }
}
