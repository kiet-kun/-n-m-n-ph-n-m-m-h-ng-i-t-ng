using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

using QuanLyKho.Data.Entity;

namespace QuanLyKho.Data.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, ProductName = "Áo sơ mi", Barcode = "MAVACH01", CreateDate = DateTime.Now, UnitOfMeasureId = 1, Price = 1 },
                 new Product { Id = 2, ProductName = "Áo thun", Barcode = "MAVACH02", CreateDate = DateTime.Now, UnitOfMeasureId = 1, Price = 1 },
                  new Product { Id = 3, ProductName = "Áo khoác", Barcode = "MAVACH03", CreateDate = DateTime.Now, UnitOfMeasureId = 1, Price = 1 }
            );
        }
    }
}
