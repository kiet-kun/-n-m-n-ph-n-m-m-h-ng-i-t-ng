using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Model.ViewModel.Base;

namespace QuanLyKho.Model.ViewModel.UnitOfMeasure
{
    public class ListUnitOfMeasureViewModel : BaseViewModel
    {
        public string UnitOfMeasureName { get; set; }
        public string Isocode { get; set; }
    }
}
