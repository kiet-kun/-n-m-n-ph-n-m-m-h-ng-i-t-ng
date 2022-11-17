using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Core.Repository
{
    public interface IStoreStockRepository : IRepository<QuanLyKho.Data.Entity.StoreStock>
    {
        Task RemoveByStoreAndProductId(int productId, int storeId);
        Task<QuanLyKho.Data.Entity.StoreStock> GetByStoreAndProductId(int productId, int storeId);
    }
}
