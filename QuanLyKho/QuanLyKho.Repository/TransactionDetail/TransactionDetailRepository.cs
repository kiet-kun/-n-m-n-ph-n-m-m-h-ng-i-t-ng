using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;

namespace QuanLyKho.Repository.TransactionDetail
{
    public class TransactionDetailRepository : Repository<QuanLyKho.Data.Entity.TransactionDetail>, ITransactionDetailRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }
        public TransactionDetailRepository(DbContext context) : base(context)
        {
        }

        public void DeleteAllRecordByTransaction(ICollection<QuanLyKho.Data.Entity.TransactionDetail> transactionDetails)
        {
            dbContext.RemoveRange(transactionDetails);
        }

        public async Task<IEnumerable<QuanLyKho.Data.Entity.TransactionDetail>> GetByTransactionId(int transactionId)
        {
            return await dbContext.TransactionDetail.Include(x => x.Product).ThenInclude(x=> x.UnitOfMeasure).Where(x => x.TransactionId == transactionId).ToListAsync();
        }
    }
}
