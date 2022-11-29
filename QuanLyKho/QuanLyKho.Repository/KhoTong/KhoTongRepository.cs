using Microsoft.EntityFrameworkCore;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Repository.KhoTong
{
    public class KhoTongRepository : Repository<QuanLyKho.Data.Entity.KhoTong>, IKhoTongRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }

        public KhoTongRepository(DbContext context) : base(context)
        {
        }
    }
}
