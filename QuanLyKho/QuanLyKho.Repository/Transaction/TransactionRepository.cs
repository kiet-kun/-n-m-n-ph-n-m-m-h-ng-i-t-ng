using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;

namespace QuanLyKho.Repository.Transaction
{
    public class TransactionRepository : Repository<QuanLyKho.Data.Entity.Transaction>, ITransactionRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }
        public TransactionRepository(DbContext context) : base(context)
        {
        }
        public async Task<QuanLyKho.Data.Entity.Transaction> GetWithDetailById(int id)
        {
            return await dbContext.Transaction.Include(x => x.TransactionDetail).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<QuanLyKho.Data.Entity.Transaction> GetWithDetailAndProductById(int id)
        {
            return await dbContext.Transaction.Include(x => x.TransactionDetail).ThenInclude(x=> x.Product).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
