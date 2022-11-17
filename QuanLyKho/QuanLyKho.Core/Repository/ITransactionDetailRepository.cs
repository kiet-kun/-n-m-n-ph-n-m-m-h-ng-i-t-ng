using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Data.Entity;

namespace QuanLyKho.Core.Repository
{
    public interface ITransactionDetailRepository : IRepository<QuanLyKho.Data.Entity.TransactionDetail>
    {
        void DeleteAllRecordByTransaction(ICollection<QuanLyKho.Data.Entity.TransactionDetail> transactionDetails);
        Task<IEnumerable<QuanLyKho.Data.Entity.TransactionDetail>> GetByTransactionId(int transactionId);
    }
}
