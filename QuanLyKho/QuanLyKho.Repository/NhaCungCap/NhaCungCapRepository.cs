using Microsoft.EntityFrameworkCore;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Repository.NhaCungCap
{
    public class NhaCungCapRepository : Repository<QuanLyKho.Data.Entity.NhaCungCap>, INhaCungCapRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }

        public NhaCungCapRepository(DbContext context) : base(context)
        {
        }
    }
}
