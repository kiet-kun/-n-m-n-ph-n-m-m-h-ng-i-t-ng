using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;

namespace QuanLyKho.Repository.Product
{
    public class ProductRepository : Repository<QuanLyKho.Data.Entity.Product>, IProductRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }

        public ProductRepository(DbContext context) : base(context)
        {
        }

        public async Task DeleteProductImage(int id)
        {
            QuanLyKho.Data.Entity.Product product = await dbContext.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                product.Image = null;
                dbContext.Entry(product).Property(f => f.Image).IsModified = true;
            }
        }

        public async Task<IEnumerable<Data.Entity.Product>> GetProductsByBarcodeAndName(string term)
        {
            return await dbContext.Product.Where(x => x.ProductName.Contains(term) || x.Barcode.Contains(term)).AsNoTracking().ToListAsync();
        }
    }
}
