using Microsoft.EntityFrameworkCore;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Repository.KhuVucKhoTong
{
    public class KhuVucKhoTongRepository : Repository<QuanLyKho.Data.Entity.KhuVucKhoTong>, IKhuVucKhoTongRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }

        public KhuVucKhoTongRepository(DbContext context) : base(context)
        {
        }
    }
}
