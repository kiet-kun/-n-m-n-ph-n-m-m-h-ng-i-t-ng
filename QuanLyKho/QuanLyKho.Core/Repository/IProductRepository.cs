using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Core.Repository
{
    public interface IProductRepository : IRepository<QuanLyKho.Data.Entity.Product>
    {
        Task DeleteProductImage(int id);
        Task<IEnumerable<QuanLyKho.Data.Entity.Product>> GetProductsByBarcodeAndName(string term);
    }
}
