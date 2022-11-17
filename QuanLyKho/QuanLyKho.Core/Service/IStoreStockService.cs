using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model.Domain;
using QuanLyKho.Model.Service;

namespace QuanLyKho.Core.Service
{
    public interface IStoreStockService : IService<StoreStockDTO>
    {
        Task<ServiceResult<IEnumerable<StoreStockDTO>>> StoreStockReport(StoreStockDTO criteria);
    }
}
