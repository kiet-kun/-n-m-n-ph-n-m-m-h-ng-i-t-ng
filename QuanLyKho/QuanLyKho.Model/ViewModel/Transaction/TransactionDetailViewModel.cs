﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Model.ViewModel.Transaction
{
    public class TransactionDetailViewModel
    {
        public int? ProductId { get; set; }
        public int? TransactionId { get; set; }
        public decimal? Amount { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string UnitOfMeasureShortName { get; set; }
    }
}
