using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Data.Entity;

namespace QuanLyKho.Data.Seed
{
    internal class StoreSeed : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(
                    new Store { Id = 1, StoreCode = "CUAHANG01", StoreName = "Cửa hàng chi nhánh Gò Vấp", CreateDate = DateTime.Now },
                    new Store { Id = 2, StoreCode = "CUAHANG02", StoreName = "Cửa hàng chi nhánh Quận 1", CreateDate = DateTime.Now }
                );
           
        }
    }
}
