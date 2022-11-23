using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Core.Repository;

namespace QuanLyKho.Core.UnitOfWorks
{
    public interface IUnitOfWorks : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IStoreRepository StoreRepository { get; }
        IStoreStockRepository StoreStockRepository { get; }
        ITransactionDetailRepository TransactionDetailRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        ITransactionTypeRepository TransactionTypeRepository { get; }
        IUnitOfMeasureRepository UnitOfMeasureRepository { get; }
        IUserRepository UserRepository { get; }

        INhaCungCapRepository NhaCungCapRepository { get; }
        Task SaveAsync();
        void Save();
        void Commit();
        void RollBack();
        void CreateTransaction();

    }
}
