using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;

namespace QuanLyKho.Repository.Store
{
    public class StoreRepository : Repository<QuanLyKho.Data.Entity.Store>, IStoreRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }

        public StoreRepository(DbContext context) : base(context)
        {
        }
    }
}
