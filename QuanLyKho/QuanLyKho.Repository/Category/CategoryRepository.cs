using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;

namespace QuanLyKho.Repository.Category
{
    public class CategoryRepository : Repository<QuanLyKho.Data.Entity.Category>, ICategoryRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }

        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
