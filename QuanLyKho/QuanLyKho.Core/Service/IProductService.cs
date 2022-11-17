using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model.Domain;
using QuanLyKho.Model.Service;

namespace QuanLyKho.Core.Service
{
    public interface IProductService : IService<ProductDTO>
    {
        Task<ServiceResult> DeleteProductImage(int id);
        Task<ServiceResult<IEnumerable<ProductDTO>>> GetProductsByBarcodeAndName(string term);
    }
}
