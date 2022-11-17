using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Core.Repository
{
    public interface ITransactionRepository : IRepository<QuanLyKho.Data.Entity.Transaction>
    {
        Task<QuanLyKho.Data.Entity.Transaction> GetWithDetailById(int id);
        Task<QuanLyKho.Data.Entity.Transaction> GetWithDetailAndProductById(int id);
    }
}
