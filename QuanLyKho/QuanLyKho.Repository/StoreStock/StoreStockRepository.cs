using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;

namespace QuanLyKho.Repository.StoreStock
{
    public class StoreStockRepository : Repository<QuanLyKho.Data.Entity.StoreStock>, IStoreStockRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }
        public StoreStockRepository(DbContext context) : base(context)
        {
        }

        public async Task RemoveByStoreAndProductId(int productId, int storeId)
        {
            var entity = await dbContext.StoreStock.FirstOrDefaultAsync(x => x.StoreId == storeId && x.ProductId == productId);
            if (entity != null)
                dbContext.StoreStock.Remove(entity);
        }

        public async Task<QuanLyKho.Data.Entity.StoreStock> GetByStoreAndProductId(int productId, int storeId)
        {
            var entity = await dbContext.StoreStock.FirstOrDefaultAsync(x => x.StoreId == storeId && x.ProductId == productId);
            return entity;
        }

        
    }
}
