using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model.Domain;
using QuanLyKho.Model.Service;

namespace QuanLyKho.Core.Service
{
    public interface ITransactionService : IService<TransactionDTO>
    {
        Task<ServiceResult<TransactionDTO>> GetWithDetailAndProductById(int id);
        Task<ServiceResult<IEnumerable<TransactionDetailDTO>>> GetTransactionDetailByTransactionId(int transactionId);
        Task<ServiceResult<IEnumerable<TransactionDetailReportDTO>>> TransactionDetailReport(TransactionDetailReportDTO criteria);
        Task<ServiceResult<int>> TransactionDetailReportCount(TransactionDetailReportDTO criteria);
    }
}
