using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;

namespace QuanLyKho.Repository.UnitOfMeasure
{
    public class UnitOfMeasureRepository : Repository<QuanLyKho.Data.Entity.UnitOfMeasure>, IUnitOfMeasureRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }
        public UnitOfMeasureRepository(DbContext context) : base(context)
        {
        }
    }
}
