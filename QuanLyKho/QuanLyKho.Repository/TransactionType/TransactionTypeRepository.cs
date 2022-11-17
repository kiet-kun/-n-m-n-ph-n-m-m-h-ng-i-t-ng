using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;

namespace QuanLyKho.Repository.TransactionType
{
    public class TransactionTypeRepository : Repository<QuanLyKho.Data.Entity.TransactionType>, ITransactionTypeRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }
        public TransactionTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
